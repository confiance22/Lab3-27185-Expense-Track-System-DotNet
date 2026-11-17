namespace ExpenseTrackSystem;

public class Category
{
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public string CategoryName { get; set; } = "";

    // This makes the category show its name inside combo boxes.
    public override string ToString() => CategoryName;
}
