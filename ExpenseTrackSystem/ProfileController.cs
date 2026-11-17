using MySqlConnector;

namespace ExpenseTrackSystem;

public class ProfileController
{
    public UserProfile? GetByUserId(int userId)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT profile_id, user_id, phone, currency, photo_path " +
            "FROM user_profiles WHERE user_id = @userId", connection);
        command.Parameters.AddWithValue("@userId", userId);
        using MySqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
            return null;

        return new UserProfile
        {
            ProfileId = reader.GetInt32("profile_id"),
            UserId = reader.GetInt32("user_id"),
            Phone = reader.GetString("phone"),
            Currency = reader.GetString("currency"),
            PhotoPath = reader.GetString("photo_path")
        };
    }

    public void Save(UserProfile profile)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "UPDATE user_profiles SET phone = @phone, currency = @currency, photo_path = @photo " +
            "WHERE user_id = @userId", connection);
        command.Parameters.AddWithValue("@phone", profile.Phone);
        command.Parameters.AddWithValue("@currency", profile.Currency);
        command.Parameters.AddWithValue("@photo", profile.PhotoPath);
        command.Parameters.AddWithValue("@userId", profile.UserId);
        int affected = command.ExecuteNonQuery();

        if (affected == 0)
            throw new InvalidOperationException("Profile not found. Please log in again.");
    }
}
