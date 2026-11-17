using MySqlConnector;

namespace ExpenseTrackSystem;

public class TagController
{
    public List<Tag> GetAll(int userId)
    {
        List<Tag> tags = new List<Tag>();
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "SELECT tag_id, user_id, tag_name FROM tags " +
            "WHERE user_id = @userId ORDER BY tag_name", connection);
        command.Parameters.AddWithValue("@userId", userId);
        using MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            tags.Add(MapTag(reader));
        }

        return tags;
    }

    public void Save(Tag tag)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using (MySqlCommand checkCommand = new MySqlCommand(
            "SELECT COUNT(*) FROM tags WHERE user_id = @userId AND tag_name = @name", connection))
        {
            checkCommand.Parameters.AddWithValue("@userId", tag.UserId);
            checkCommand.Parameters.AddWithValue("@name", tag.TagName);
            long count = Convert.ToInt64(checkCommand.ExecuteScalar());
            if (count > 0)
                throw new InvalidOperationException("You already have a tag with that name.");
        }

        using MySqlCommand command = new MySqlCommand(
            "INSERT INTO tags (user_id, tag_name) VALUES (@userId, @name)", connection);
        command.Parameters.AddWithValue("@userId", tag.UserId);
        command.Parameters.AddWithValue("@name", tag.TagName);
        command.ExecuteNonQuery();
    }

    public void Delete(int tagId, int userId)
    {
        using MySqlConnection connection = new MySqlConnection(Database.ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "DELETE FROM tags WHERE tag_id = @id AND user_id = @userId", connection);
        command.Parameters.AddWithValue("@id", tagId);
        command.Parameters.AddWithValue("@userId", userId);
        int affected = command.ExecuteNonQuery();
        if (affected == 0)
            throw new InvalidOperationException("No tag with that ID.");
    }

    private static Tag MapTag(MySqlDataReader reader)
    {
        return new Tag
        {
            TagId = reader.GetInt32("tag_id"),
            UserId = reader.GetInt32("user_id"),
            TagName = reader.GetString("tag_name")
        };
    }
}
