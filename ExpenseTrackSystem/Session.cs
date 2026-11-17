namespace ExpenseTrackSystem;

// Keeps the logged-in user in memory while the app is running.
public static class Session
{
    public static User? CurrentUser { get; set; }
    public static UserProfile? CurrentProfile { get; set; }

    public static int UserId => CurrentUser?.UserId ?? 0;
    public static string Currency => CurrentProfile?.Currency ?? "USD";
}
