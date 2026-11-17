using MySqlConnector;

namespace ExpenseTrackSystem;

public class UserController
{
    public User Register(string fullName, string username, string password)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using (MySqlCommand checkCommand = new MySqlCommand(
            "SELECT COUNT(*) FROM users WHERE username = @username", connection))
        {
            checkCommand.Parameters.AddWithValue("@username", username);
            long count = Convert.ToInt64(checkCommand.ExecuteScalar());
            if (count > 0)
                throw new InvalidOperationException("That username is already taken.");
        }

        string salt = PasswordHelper.CreateSalt();
        string hash = PasswordHelper.HashPassword(password, salt);

        using MySqlCommand command = new MySqlCommand(
            "INSERT INTO users (username, password_hash, password_salt, full_name) " +
            "VALUES (@username, @hash, @salt, @fullName)", connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@hash", hash);
        command.Parameters.AddWithValue("@salt", salt);
        command.Parameters.AddWithValue("@fullName", fullName);
        command.ExecuteNonQuery();

        int userId = (int)command.LastInsertedId;

        using MySqlCommand profileCommand = new MySqlCommand(
            "INSERT INTO user_profiles (user_id, phone, currency, photo_path) " +
            "VALUES (@userId, '', 'USD', '')", connection);
        profileCommand.Parameters.AddWithValue("@userId", userId);
        profileCommand.ExecuteNonQuery();

        // Give every new account a few starter categories so the app is usable right away.
        string[] defaultCategories = { "Food", "Transport", "Bills", "Shopping", "Other" };
        foreach (string categoryName in defaultCategories)
        {
            using MySqlCommand categoryCommand = new MySqlCommand(
                "INSERT INTO categories (user_id, category_name) VALUES (@userId, @name)", connection);
            categoryCommand.Parameters.AddWithValue("@userId", userId);
            categoryCommand.Parameters.AddWithValue("@name", categoryName);
            categoryCommand.ExecuteNonQuery();
        }

        return new User
        {
            UserId = userId,
            Username = username,
            FullName = fullName,
            PasswordHash = hash,
            PasswordSalt = salt,
            CreatedAt = DateTime.Now
        };
    }

    public User? Login(string username, string password)
    {
        User? user = FindByUsername(username);
        if (user == null)
            return null;

        if (!PasswordHelper.Verify(password, user.PasswordSalt, user.PasswordHash))
            return null;

        return user;
    }

    public User? FindByUsername(string username)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT user_id, username, password_hash, password_salt, full_name, created_at " +
            "FROM users WHERE username = @username", connection);
        command.Parameters.AddWithValue("@username", username);
        using MySqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
            return null;

        return MapUser(reader);
    }

    public User? FindById(int userId)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT user_id, username, password_hash, password_salt, full_name, created_at " +
            "FROM users WHERE user_id = @id", connection);
        command.Parameters.AddWithValue("@id", userId);
        using MySqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
            return null;

        return MapUser(reader);
    }

    public void UpdateFullName(int userId, string fullName)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "UPDATE users SET full_name = @fullName WHERE user_id = @id", connection);
        command.Parameters.AddWithValue("@fullName", fullName);
        command.Parameters.AddWithValue("@id", userId);
        command.ExecuteNonQuery();
    }

    private static User MapUser(MySqlDataReader reader)
    {
        return new User
        {
            UserId = reader.GetInt32("user_id"),
            Username = reader.GetString("username"),
            PasswordHash = reader.GetString("password_hash"),
            PasswordSalt = reader.GetString("password_salt"),
            FullName = reader.GetString("full_name"),
            CreatedAt = reader.GetDateTime("created_at")
        };
    }
}
