using System.Security.Cryptography;

namespace ExpenseTrackSystem;

public static class PasswordHelper
{
    public static string CreateSalt()
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        return Convert.ToBase64String(salt);
    }

    public static string HashPassword(string password, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password, saltBytes, 100000, HashAlgorithmName.SHA256, 32);
        return Convert.ToBase64String(hash);
    }

    public static bool Verify(string password, string salt, string savedHash)
    {
        string computedHash = HashPassword(password, salt);
        return computedHash == savedHash;
    }
}
