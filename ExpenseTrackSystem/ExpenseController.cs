using MySqlConnector;

namespace ExpenseTrackSystem;

public class ExpenseController
{
    public List<Expense> GetAll(int userId, List<int>? tagIds = null)
    {
        List<Expense> expenses = new List<Expense>();

        string sql =
            "SELECT e.expense_id, e.user_id, e.category_id, e.title, e.amount, e.expense_date, " +
            "c.category_name " +
            "FROM expenses e " +
            "INNER JOIN categories c ON c.category_id = e.category_id " +
            "WHERE e.user_id = @userId";

        // If the user picked tags, only return expenses that have ALL of them.
        if (tagIds != null && tagIds.Count > 0)
        {
            sql += " AND e.expense_id IN (" +
                   "SELECT et.expense_id FROM expense_tags et WHERE et.tag_id IN (";
            for (int i = 0; i < tagIds.Count; i++)
            {
                if (i > 0)
                    sql += ", ";
                sql += "@tag" + i;
            }
            sql += ") GROUP BY et.expense_id HAVING COUNT(DISTINCT et.tag_id) = @tagCount)";
        }

        sql += " ORDER BY e.expense_date DESC, e.expense_id DESC";

        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@userId", userId);
        if (tagIds != null)
        {
            for (int i = 0; i < tagIds.Count; i++)
            {
                command.Parameters.AddWithValue("@tag" + i, tagIds[i]);
            }
            command.Parameters.AddWithValue("@tagCount", tagIds.Count);
        }

        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            expenses.Add(MapExpense(reader));
        }

        LoadTagNames(expenses, userId);
        return expenses;
    }

    public List<Expense> GetRecent(int userId, int count)
    {
        List<Expense> expenses = new List<Expense>();

        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT e.expense_id, e.user_id, e.category_id, e.title, e.amount, e.expense_date, " +
            "c.category_name " +
            "FROM expenses e " +
            "INNER JOIN categories c ON c.category_id = e.category_id " +
            "WHERE e.user_id = @userId " +
            "ORDER BY e.expense_date DESC, e.expense_id DESC LIMIT @count", connection);
        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@count", count);

        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            expenses.Add(MapExpense(reader));
        }

        LoadTagNames(expenses, userId);
        return expenses;
    }

    public void Save(Expense expense, List<int> tagIds)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "INSERT INTO expenses (user_id, category_id, title, amount, expense_date) " +
            "VALUES (@userId, @categoryId, @title, @amount, @date)", connection);
        AddParameters(command, expense);
        command.ExecuteNonQuery();

        expense.ExpenseId = (int)command.LastInsertedId;
        SetTags(expense.ExpenseId, expense.UserId, tagIds);
    }

    public void Update(Expense expense, List<int> tagIds)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "UPDATE expenses SET category_id = @categoryId, title = @title, amount = @amount, " +
            "expense_date = @date " +
            "WHERE expense_id = @id AND user_id = @userId", connection);
        AddParameters(command, expense);
        command.Parameters.AddWithValue("@id", expense.ExpenseId);
        int affected = command.ExecuteNonQuery();
        if (affected == 0)
            throw new InvalidOperationException("No expense with that ID.");

        SetTags(expense.ExpenseId, expense.UserId, tagIds);
    }

    public void Delete(int expenseId, int userId)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "DELETE FROM expenses WHERE expense_id = @id AND user_id = @userId", connection);
        command.Parameters.AddWithValue("@id", expenseId);
        command.Parameters.AddWithValue("@userId", userId);
        int affected = command.ExecuteNonQuery();
        if (affected == 0)
            throw new InvalidOperationException("No expense with that ID.");
    }

    public List<int> GetTagsForExpense(int expenseId)
    {
        List<int> tagIds = new List<int>();

        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT tag_id FROM expense_tags WHERE expense_id = @id", connection);
        command.Parameters.AddWithValue("@id", expenseId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            tagIds.Add(reader.GetInt32("tag_id"));
        }

        return tagIds;
    }

    public decimal GetTotalSpent(int userId, int year, int month)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT COALESCE(SUM(amount), 0) FROM expenses " +
            "WHERE user_id = @userId AND YEAR(expense_date) = @year AND MONTH(expense_date) = @month",
            connection);
        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@year", year);
        command.Parameters.AddWithValue("@month", month);

        return Convert.ToDecimal(command.ExecuteScalar());
    }

    private static void SetTags(int expenseId, int userId, List<int> tagIds)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using (MySqlCommand deleteCommand = new MySqlCommand(
            "DELETE FROM expense_tags WHERE expense_id = @expenseId", connection))
        {
            deleteCommand.Parameters.AddWithValue("@expenseId", expenseId);
            deleteCommand.ExecuteNonQuery();
        }

        foreach (int tagId in tagIds)
        {
            using MySqlCommand insertCommand = new MySqlCommand(
                "INSERT INTO expense_tags (expense_id, tag_id) " +
                "SELECT @expenseId, @tagId FROM tags WHERE tag_id = @tagId AND user_id = @userId",
                connection);
            insertCommand.Parameters.AddWithValue("@expenseId", expenseId);
            insertCommand.Parameters.AddWithValue("@tagId", tagId);
            insertCommand.Parameters.AddWithValue("@userId", userId);
            insertCommand.ExecuteNonQuery();
        }
    }

    private static void LoadTagNames(List<Expense> expenses, int userId)
    {
        if (expenses.Count == 0)
            return;

        Dictionary<int, List<string>> tagsByExpense = new Dictionary<int, List<string>>();

        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT et.expense_id, t.tag_name " +
            "FROM expense_tags et " +
            "INNER JOIN tags t ON t.tag_id = et.tag_id " +
            "WHERE t.user_id = @userId ORDER BY t.tag_name", connection);
        command.Parameters.AddWithValue("@userId", userId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int expenseId = reader.GetInt32("expense_id");
            if (!tagsByExpense.ContainsKey(expenseId))
                tagsByExpense[expenseId] = new List<string>();
            tagsByExpense[expenseId].Add(reader.GetString("tag_name"));
        }

        foreach (Expense expense in expenses)
        {
            if (tagsByExpense.ContainsKey(expense.ExpenseId))
                expense.TagNames = string.Join(", ", tagsByExpense[expense.ExpenseId]);
        }
    }

    private static void AddParameters(MySqlCommand command, Expense expense)
    {
        command.Parameters.AddWithValue("@userId", expense.UserId);
        command.Parameters.AddWithValue("@categoryId", expense.CategoryId);
        command.Parameters.AddWithValue("@title", expense.Title);
        command.Parameters.AddWithValue("@amount", expense.Amount);
        command.Parameters.AddWithValue("@date", expense.ExpenseDate.Date);
    }

    private static Expense MapExpense(MySqlDataReader reader)
    {
        return new Expense
        {
            ExpenseId = reader.GetInt32("expense_id"),
            UserId = reader.GetInt32("user_id"),
            CategoryId = reader.GetInt32("category_id"),
            Title = reader.GetString("title"),
            Amount = reader.GetDecimal("amount"),
            ExpenseDate = reader.GetDateTime("expense_date"),
            CategoryName = reader.GetString("category_name")
        };
    }
}
