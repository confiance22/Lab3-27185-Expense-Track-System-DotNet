using MySqlConnector;

namespace ExpenseTrackSystem;

public class CategoryController
{
    public List<Category> GetAll(int userId)
    {
        List<Category> categories = new List<Category>();
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT category_id, user_id, category_name FROM categories " +
            "WHERE user_id = @userId ORDER BY category_name", connection);
        command.Parameters.AddWithValue("@userId", userId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            categories.Add(MapCategory(reader));
        }

        return categories;
    }

    public Category? Find(int categoryId, int userId)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT category_id, user_id, category_name FROM categories " +
            "WHERE category_id = @id AND user_id = @userId", connection);
        command.Parameters.AddWithValue("@id", categoryId);
        command.Parameters.AddWithValue("@userId", userId);
        using MySqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
            return null;

        return MapCategory(reader);
    }

    public void Save(Category category)
    {
        CheckDuplicateName(category.UserId, category.CategoryName, 0);

        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "INSERT INTO categories (user_id, category_name) VALUES (@userId, @name)", connection);
        command.Parameters.AddWithValue("@userId", category.UserId);
        command.Parameters.AddWithValue("@name", category.CategoryName);
        command.ExecuteNonQuery();
    }

    public void Update(Category category)
    {
        CheckDuplicateName(category.UserId, category.CategoryName, category.CategoryId);

        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "UPDATE categories SET category_name = @name " +
            "WHERE category_id = @id AND user_id = @userId", connection);
        command.Parameters.AddWithValue("@name", category.CategoryName);
        command.Parameters.AddWithValue("@id", category.CategoryId);
        command.Parameters.AddWithValue("@userId", category.UserId);
        int affected = command.ExecuteNonQuery();
        if (affected == 0)
            throw new InvalidOperationException("No category with that ID.");
    }

    public void Delete(int categoryId, int userId)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using (MySqlCommand checkCommand = new MySqlCommand(
            "SELECT COUNT(*) FROM expenses WHERE category_id = @id AND user_id = @userId", connection))
        {
            checkCommand.Parameters.AddWithValue("@id", categoryId);
            checkCommand.Parameters.AddWithValue("@userId", userId);
            long count = Convert.ToInt64(checkCommand.ExecuteScalar());
            if (count > 0)
                throw new InvalidOperationException(
                    "This category is used by expenses. Delete or move those expenses first.");
        }

        using MySqlCommand command = new MySqlCommand(
            "DELETE FROM categories WHERE category_id = @id AND user_id = @userId", connection);
        command.Parameters.AddWithValue("@id", categoryId);
        command.Parameters.AddWithValue("@userId", userId);
        int affected = command.ExecuteNonQuery();
        if (affected == 0)
            throw new InvalidOperationException("No category with that ID.");
    }

    private static void CheckDuplicateName(int userId, string name, int exceptId)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT COUNT(*) FROM categories " +
            "WHERE user_id = @userId AND category_name = @name AND category_id <> @exceptId", connection);
        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@exceptId", exceptId);
        long count = Convert.ToInt64(command.ExecuteScalar());
        if (count > 0)
            throw new InvalidOperationException("You already have a category with that name.");
    }

    private static Category MapCategory(MySqlDataReader reader)
    {
        return new Category
        {
            CategoryId = reader.GetInt32("category_id"),
            UserId = reader.GetInt32("user_id"),
            CategoryName = reader.GetString("category_name")
        };
    }
}
