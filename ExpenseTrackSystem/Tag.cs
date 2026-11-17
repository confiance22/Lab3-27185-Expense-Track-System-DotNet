namespace ExpenseTrackSystem;

public class Tag
{
    public int TagId { get; set; }
    public int UserId { get; set; }
    public string TagName { get; set; } = "";

    public override string ToString() => TagName;
}
