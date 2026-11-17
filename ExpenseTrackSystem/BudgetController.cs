using MySqlConnector;

namespace ExpenseTrackSystem;

public class BudgetController
{
    public List<Budget> GetAll(int userId, int year, int month)
    {
        List<Budget> budgets = new List<Budget>();

        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT b.budget_id, b.user_id, b.category_id, b.budget_month, b.budget_year, " +
            "b.limit_amount, c.category_name, " +
            "COALESCE((SELECT SUM(e.amount) FROM expenses e " +
            "          WHERE e.category_id = b.category_id AND e.user_id = b.user_id " +
            "          AND YEAR(e.expense_date) = b.budget_year " +
            "          AND MONTH(e.expense_date) = b.budget_month), 0) AS spent " +
            "FROM budgets b " +
            "INNER JOIN categories c ON c.category_id = b.category_id " +
            "WHERE b.user_id = @userId AND b.budget_year = @year AND b.budget_month = @month " +
            "ORDER BY c.category_name", connection);
        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@year", year);
        command.Parameters.AddWithValue("@month", month);

        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            budgets.Add(new Budget
            {
                BudgetId = reader.GetInt32("budget_id"),
                UserId = reader.GetInt32("user_id"),
                CategoryId = reader.GetInt32("category_id"),
                BudgetMonth = reader.GetInt32("budget_month"),
                BudgetYear = reader.GetInt32("budget_year"),
                LimitAmount = reader.GetDecimal("limit_amount"),
                CategoryName = reader.GetString("category_name"),
                Spent = reader.GetDecimal("spent")
            });
        }

        return budgets;
    }

    // Save inserts a new budget, or updates the limit if this
    // category already has a budget for the same month and year.
    public void Save(Budget budget)
    {
        int? existingId = FindId(budget.UserId, budget.CategoryId, budget.BudgetMonth, budget.BudgetYear);

        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        if (existingId == null)
        {
            using MySqlCommand command = new MySqlCommand(
                "INSERT INTO budgets (user_id, category_id, budget_month, budget_year, limit_amount) " +
                "VALUES (@userId, @categoryId, @month, @year, @limit)", connection);
            AddParameters(command, budget);
            command.ExecuteNonQuery();
        }
        else
        {
            using MySqlCommand command = new MySqlCommand(
                "UPDATE budgets SET limit_amount = @limit " +
                "WHERE budget_id = @id AND user_id = @userId", connection);
            command.Parameters.AddWithValue("@limit", budget.LimitAmount);
            command.Parameters.AddWithValue("@id", existingId.Value);
            command.Parameters.AddWithValue("@userId", budget.UserId);
            command.ExecuteNonQuery();
        }
    }

    public void Delete(int budgetId, int userId)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "DELETE FROM budgets WHERE budget_id = @id AND user_id = @userId", connection);
        command.Parameters.AddWithValue("@id", budgetId);
        command.Parameters.AddWithValue("@userId", userId);
        int affected = command.ExecuteNonQuery();
        if (affected == 0)
            throw new InvalidOperationException("No budget with that ID.");
    }

    private static int? FindId(int userId, int categoryId, int month, int year)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT budget_id FROM budgets " +
            "WHERE user_id = @userId AND category_id = @categoryId " +
            "AND budget_month = @month AND budget_year = @year", connection);
        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@categoryId", categoryId);
        command.Parameters.AddWithValue("@month", month);
        command.Parameters.AddWithValue("@year", year);

        object? result = command.ExecuteScalar();
        if (result == null)
            return null;

        return Convert.ToInt32(result);
    }

    private static void AddParameters(MySqlCommand command, Budget budget)
    {
        command.Parameters.AddWithValue("@userId", budget.UserId);
        command.Parameters.AddWithValue("@categoryId", budget.CategoryId);
        command.Parameters.AddWithValue("@month", budget.BudgetMonth);
        command.Parameters.AddWithValue("@year", budget.BudgetYear);
        command.Parameters.AddWithValue("@limit", budget.LimitAmount);
    }
}
