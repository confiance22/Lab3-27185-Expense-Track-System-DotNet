namespace ExpenseTrackSystem;

public class Budget
{
    public int BudgetId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int BudgetMonth { get; set; }
    public int BudgetYear { get; set; }
    public decimal LimitAmount { get; set; }

    // These are filled in by the controller for display.
    public string CategoryName { get; set; } = "";
    public decimal Spent { get; set; }

    public string MonthName => new DateTime(2000, BudgetMonth, 1).ToString("MMMM");
    public decimal Remaining => LimitAmount - Spent;
}
