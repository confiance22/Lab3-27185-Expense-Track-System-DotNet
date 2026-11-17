namespace ExpenseTrackSystem;

public class UserProfile
{
    public int ProfileId { get; set; }
    public int UserId { get; set; }
    public string Phone { get; set; } = "";
    public string Currency { get; set; } = "USD";
    public string PhotoPath { get; set; } = "";
}
