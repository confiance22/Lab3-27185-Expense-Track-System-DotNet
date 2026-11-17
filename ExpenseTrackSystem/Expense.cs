namespace ExpenseTrackSystem;

public class Expense
{
    public int ExpenseId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; } = DateTime.Today;

    // These are filled in by the controller for display in the grid.
    public string CategoryName { get; set; } = "";
    public string TagNames { get; set; } = "";
}
