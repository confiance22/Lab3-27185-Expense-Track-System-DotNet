using System.Drawing.Drawing2D;

namespace ExpenseTrackSystem;

public partial class MainForm : Form
{
    private readonly CategoryController categoryController = new CategoryController();
    private readonly ExpenseController expenseController = new ExpenseController();
    private readonly TagController tagController = new TagController();
    private readonly BudgetController budgetController = new BudgetController();
    private readonly ProfileController profileController = new ProfileController();
    private readonly UserController userController = new UserController();

    private List<Category> categories = new List<Category>();
    private List<Tag> tags = new List<Tag>();
    private List<Budget> dashboardBudgets = new List<Budget>();

    private int selectedExpenseId;
    private int selectedCategoryId;
    private int selectedBudgetId;
    private string selectedPhotoPath = "";
    private bool loadingData;

    public bool LoggedOut { get; private set; }

    public MainForm()
    {
        InitializeComponent();
        WireEvents();
        PrepareComboBoxes();

        loadingData = true;
        try
        {
            LoadProfile();
            LoadCategories();
            LoadTags();
            LoadExpenses();
            LoadBudgets();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Could not load your data.\n\n" + ex.Message +
                "\n\nMake sure XAMPP MySQL is running and you imported database.sql.",
                "ExpenseTrack", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            loadingData = false;
        }
    }

    private void WireEvents()
    {
        // Dashboard reloads itself when the month or year changes.
        cboDashMonth.SelectedIndexChanged += (_, _) =>
        {
            if (!loadingData)
                RunSafely(LoadDashboard, "Dashboard");
        };
        numDashYear.ValueChanged += (_, _) =>
        {
            if (!loadingData)
                RunSafely(LoadDashboard, "Dashboard");
        };
        panelChart.Paint += PanelChart_Paint;

        // Expenses
        btnSaveExpense.Click += BtnSaveExpense_Click;
        btnUpdateExpense.Click += BtnUpdateExpense_Click;
        btnDeleteExpense.Click += BtnDeleteExpense_Click;
        btnAddTag.Click += BtnAddTag_Click;
        btnClearFilter.Click += BtnClearFilter_Click;
        clbFilterTags.ItemCheck += (_, _) =>
        {
            if (!loadingData && !IsDisposed)
                BeginInvoke(new Action(() => RunSafely(LoadExpenses, "Expenses")));
        };
        dgvExpenses.CellClick += DgvExpenses_CellClick;

        // Categories
        btnAddCategory.Click += BtnAddCategory_Click;
        btnUpdateCategory.Click += BtnUpdateCategory_Click;
        btnDeleteCategory.Click += BtnDeleteCategory_Click;
        dgvCategories.CellClick += DgvCategories_CellClick;

        // Budgets reload themselves when the month or year changes.
        btnSaveBudget.Click += BtnSaveBudget_Click;
        btnDeleteBudget.Click += BtnDeleteBudget_Click;
        cboBudgetMonth.SelectedIndexChanged += (_, _) =>
        {
            if (!loadingData)
                RunSafely(LoadBudgets, "Budgets");
        };
        numBudgetYear.ValueChanged += (_, _) =>
        {
            if (!loadingData)
                RunSafely(LoadBudgets, "Budgets");
        };
        dgvBudgets.CellClick += DgvBudgets_CellClick;

        // Profile
        btnSaveProfile.Click += BtnSaveProfile_Click;
        btnBrowsePhoto.Click += BtnBrowsePhoto_Click;
        btnLogout.Click += BtnLogout_Click;
    }

    private void PrepareComboBoxes()
    {
        for (int month = 1; month <= 12; month++)
        {
            string monthName = new DateTime(2000, month, 1).ToString("MMMM");
            cboDashMonth.Items.Add(monthName);
            cboBudgetMonth.Items.Add(monthName);
        }

        cboDashMonth.SelectedIndex = DateTime.Today.Month - 1;
        cboBudgetMonth.SelectedIndex = DateTime.Today.Month - 1;

        numDashYear.Value = DateTime.Today.Year;
        numBudgetYear.Value = DateTime.Today.Year;

        cboProfileCurrency.Items.AddRange(new object[]
        {
            "USD", "EUR", "GBP", "RWF", "KES", "NGN", "ZAR", "INR", "CAD", "AUD"
        });
        cboProfileCurrency.SelectedIndex = 0;
    }

    // ---------------- Profile ----------------

    private void LoadProfile()
    {
        if (Session.CurrentUser == null)
            return;

        lblLoggedIn.Text = "Logged in as: " + Session.CurrentUser.Username;
        txtProfileFullName.Text = Session.CurrentUser.FullName;
        txtProfileUsername.Text = Session.CurrentUser.Username;
        lblMemberSince.Text = "Member since " + Session.CurrentUser.CreatedAt.ToString("dd MMM yyyy");

        if (Session.CurrentProfile == null)
            return;

        txtProfilePhone.Text = Session.CurrentProfile.Phone;
        SelectCurrency(Session.CurrentProfile.Currency);
        selectedPhotoPath = Session.CurrentProfile.PhotoPath;
        ShowPhoto(selectedPhotoPath);
    }

    private void SelectCurrency(string currency)
    {
        int index = cboProfileCurrency.Items.IndexOf(currency);
        if (index < 0 && currency != "")
        {
            cboProfileCurrency.Items.Add(currency);
            index = cboProfileCurrency.Items.Count - 1;
        }
        cboProfileCurrency.SelectedIndex = index;
    }

    private void ShowPhoto(string path)
    {
        if (picProfile.Image != null)
        {
            Image oldImage = picProfile.Image;
            picProfile.Image = null;
            oldImage.Dispose();
        }

        if (path == "" || !File.Exists(path))
            return;

        try
        {
            picProfile.Image = Image.FromFile(path);
        }
        catch
        {
            // If the image cannot be read, just leave the picture box empty.
        }
    }

    private void BtnSaveProfile_Click(object? sender, EventArgs e)
    {
        if (Session.CurrentUser == null || Session.CurrentProfile == null)
            return;

        string fullName = txtProfileFullName.Text.Trim();
        if (fullName == "")
        {
            MessageBox.Show("Full name cannot be empty.", "Profile",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cboProfileCurrency.SelectedItem == null)
        {
            MessageBox.Show("Choose a currency.", "Profile",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            string currency = cboProfileCurrency.SelectedItem.ToString() ?? "USD";

            userController.UpdateFullName(Session.CurrentUser.UserId, fullName);
            Session.CurrentUser.FullName = fullName;
            Session.CurrentProfile.Phone = txtProfilePhone.Text.Trim();
            Session.CurrentProfile.Currency = currency;
            Session.CurrentProfile.PhotoPath = selectedPhotoPath;
            profileController.Save(Session.CurrentProfile);

            MessageBox.Show("Profile saved.", "Profile",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Profile",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnBrowsePhoto_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog dialog = new OpenFileDialog();
        dialog.Title = "Choose a profile photo";
        dialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files|*.*";

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        selectedPhotoPath = dialog.FileName;
        ShowPhoto(selectedPhotoPath);
    }

    private void BtnLogout_Click(object? sender, EventArgs e)
    {
        DialogResult answer = MessageBox.Show("Log out now?", "Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes)
            return;

        LoggedOut = true;
        Close();
    }

    // ---------------- Categories ----------------

    private void LoadCategories()
    {
        categories = categoryController.GetAll(Session.UserId);

        cboExpenseCategory.Items.Clear();
        cboBudgetCategory.Items.Clear();
        foreach (Category category in categories)
        {
            cboExpenseCategory.Items.Add(category);
            cboBudgetCategory.Items.Add(category);
        }

        if (categories.Count > 0)
        {
            cboExpenseCategory.SelectedIndex = 0;
            cboBudgetCategory.SelectedIndex = 0;
        }

        dgvCategories.DataSource = null;
        dgvCategories.DataSource = categories;
    }

    private void BtnAddCategory_Click(object? sender, EventArgs e)
    {
        string name = txtCategoryName.Text.Trim();
        if (name == "")
        {
            MessageBox.Show("Enter a category name.", "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            categoryController.Save(new Category
            {
                UserId = Session.UserId,
                CategoryName = name
            });

            MessageBox.Show("Category added.", "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearCategoryForm();
            LoadCategories();
            LoadBudgets();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnUpdateCategory_Click(object? sender, EventArgs e)
    {
        if (selectedCategoryId == 0)
        {
            MessageBox.Show("Click a category in the grid first.", "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string name = txtCategoryName.Text.Trim();
        if (name == "")
        {
            MessageBox.Show("Enter a category name.", "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            categoryController.Update(new Category
            {
                CategoryId = selectedCategoryId,
                UserId = Session.UserId,
                CategoryName = name
            });

            MessageBox.Show("Category updated.", "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearCategoryForm();
            LoadCategories();
            LoadExpenses();
            LoadBudgets();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnDeleteCategory_Click(object? sender, EventArgs e)
    {
        if (selectedCategoryId == 0)
        {
            MessageBox.Show("Click a category in the grid first.", "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult answer = MessageBox.Show(
            "Delete this category? Its budgets will also be removed.",
            "Delete category", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes)
            return;

        try
        {
            categoryController.Delete(selectedCategoryId, Session.UserId);
            MessageBox.Show("Category deleted.", "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearCategoryForm();
            LoadCategories();
            LoadExpenses();
            LoadBudgets();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Category",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void DgvCategories_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (dgvCategories.CurrentRow?.DataBoundItem is not Category category)
            return;

        selectedCategoryId = category.CategoryId;
        txtCategoryName.Text = category.CategoryName;
    }

    private void ClearCategoryForm()
    {
        selectedCategoryId = 0;
        txtCategoryName.Clear();
        dgvCategories.ClearSelection();
        txtCategoryName.Focus();
    }

    // ---------------- Tags ----------------

    private void LoadTags()
    {
        tags = tagController.GetAll(Session.UserId);

        clbTags.Items.Clear();
        foreach (Tag tag in tags)
        {
            clbTags.Items.Add(tag);
        }

        clbFilterTags.Items.Clear();
        foreach (Tag tag in tags)
        {
            clbFilterTags.Items.Add(tag);
        }
    }

    private void BtnAddTag_Click(object? sender, EventArgs e)
    {
        string name = txtNewTag.Text.Trim();
        if (name == "")
        {
            MessageBox.Show("Enter a tag name.", "Tag",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            tagController.Save(new Tag
            {
                UserId = Session.UserId,
                TagName = name
            });

            txtNewTag.Clear();
            LoadTags();
            MessageBox.Show("Tag added. Tick it in the list to use it.", "Tag",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tag",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // ---------------- Expenses ----------------

    private void LoadExpenses()
    {
        List<int> filterTagIds = new List<int>();
        foreach (object item in clbFilterTags.CheckedItems)
        {
            if (item is Tag tag)
                filterTagIds.Add(tag.TagId);
        }

        dgvExpenses.DataSource = null;
        dgvExpenses.DataSource = expenseController.GetAll(Session.UserId, filterTagIds);
    }

    private void BtnSaveExpense_Click(object? sender, EventArgs e)
    {
        Expense? expense = ReadExpenseForm();
        if (expense == null)
            return;

        try
        {
            expenseController.Save(expense, GetCheckedTagIds());
            MessageBox.Show("Expense added.", "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearExpenseForm();
            LoadExpenses();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnUpdateExpense_Click(object? sender, EventArgs e)
    {
        if (selectedExpenseId == 0)
        {
            MessageBox.Show("Click an expense in the grid first.", "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Expense? expense = ReadExpenseForm();
        if (expense == null)
            return;

        expense.ExpenseId = selectedExpenseId;

        try
        {
            expenseController.Update(expense, GetCheckedTagIds());
            MessageBox.Show("Expense updated.", "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearExpenseForm();
            LoadExpenses();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnDeleteExpense_Click(object? sender, EventArgs e)
    {
        if (selectedExpenseId == 0)
        {
            MessageBox.Show("Click an expense in the grid first.", "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult answer = MessageBox.Show("Delete this expense?", "Delete expense",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes)
            return;

        try
        {
            expenseController.Delete(selectedExpenseId, Session.UserId);
            MessageBox.Show("Expense deleted.", "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearExpenseForm();
            LoadExpenses();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private Expense? ReadExpenseForm()
    {
        if (cboExpenseCategory.SelectedItem is not Category category)
        {
            MessageBox.Show("Add a category first, then add your expense.", "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        string title = txtExpenseTitle.Text.Trim();
        if (title == "")
        {
            MessageBox.Show("Enter a title for the expense.", "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        if (!decimal.TryParse(txtExpenseAmount.Text.Trim(), out decimal amount) || amount <= 0)
        {
            MessageBox.Show("Amount must be a number greater than zero.", "Expense",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        return new Expense
        {
            UserId = Session.UserId,
            CategoryId = category.CategoryId,
            Title = title,
            Amount = amount,
            ExpenseDate = dtpExpenseDate.Value.Date
        };
    }

    private List<int> GetCheckedTagIds()
    {
        List<int> tagIds = new List<int>();
        foreach (object item in clbTags.CheckedItems)
        {
            if (item is Tag tag)
                tagIds.Add(tag.TagId);
        }
        return tagIds;
    }

    private void DgvExpenses_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (dgvExpenses.CurrentRow?.DataBoundItem is not Expense expense)
            return;

        selectedExpenseId = expense.ExpenseId;
        txtExpenseTitle.Text = expense.Title;
        txtExpenseAmount.Text = expense.Amount.ToString("0.00");
        dtpExpenseDate.Value = expense.ExpenseDate;
        SelectCategory(cboExpenseCategory, expense.CategoryId);

        try
        {
            List<int> tagIds = expenseController.GetTagsForExpense(expense.ExpenseId);
            for (int i = 0; i < clbTags.Items.Count; i++)
            {
                if (clbTags.Items[i] is Tag tag)
                    clbTags.SetItemChecked(i, tagIds.Contains(tag.TagId));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Tags",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ClearExpenseForm()
    {
        selectedExpenseId = 0;
        txtExpenseTitle.Clear();
        txtExpenseAmount.Clear();
        dtpExpenseDate.Value = DateTime.Today;

        for (int i = 0; i < clbTags.Items.Count; i++)
        {
            clbTags.SetItemChecked(i, false);
        }

        if (cboExpenseCategory.Items.Count > 0)
            cboExpenseCategory.SelectedIndex = 0;

        dgvExpenses.ClearSelection();
        txtExpenseTitle.Focus();
    }

    private void BtnClearFilter_Click(object? sender, EventArgs e)
    {
        loadingData = true;
        for (int i = 0; i < clbFilterTags.Items.Count; i++)
        {
            clbFilterTags.SetItemChecked(i, false);
        }
        loadingData = false;

        RunSafely(LoadExpenses, "Expenses");
    }

    private static void SelectCategory(ComboBox comboBox, int categoryId)
    {
        for (int i = 0; i < comboBox.Items.Count; i++)
        {
            if (comboBox.Items[i] is Category category && category.CategoryId == categoryId)
            {
                comboBox.SelectedIndex = i;
                return;
            }
        }
    }

    // ---------------- Budgets ----------------

    private void LoadBudgets()
    {
        if (cboBudgetMonth.SelectedIndex < 0)
            return;

        int month = cboBudgetMonth.SelectedIndex + 1;
        int year = (int)numBudgetYear.Value;

        List<Budget> budgets = budgetController.GetAll(Session.UserId, year, month);
        dgvBudgets.DataSource = null;
        dgvBudgets.DataSource = budgets;
    }

    private void BtnSaveBudget_Click(object? sender, EventArgs e)
    {
        if (cboBudgetCategory.SelectedItem is not Category category)
        {
            MessageBox.Show("Add a category first, then set a budget.", "Budget",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cboBudgetMonth.SelectedIndex < 0)
        {
            MessageBox.Show("Choose a month.", "Budget",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!decimal.TryParse(txtBudgetLimit.Text.Trim(), out decimal limit) || limit <= 0)
        {
            MessageBox.Show("Limit must be a number greater than zero.", "Budget",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            budgetController.Save(new Budget
            {
                UserId = Session.UserId,
                CategoryId = category.CategoryId,
                BudgetMonth = cboBudgetMonth.SelectedIndex + 1,
                BudgetYear = (int)numBudgetYear.Value,
                LimitAmount = limit
            });

            MessageBox.Show("Budget saved.", "Budget",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearBudgetForm();
            LoadBudgets();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Budget",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnDeleteBudget_Click(object? sender, EventArgs e)
    {
        if (selectedBudgetId == 0)
        {
            MessageBox.Show("Click a budget in the grid first.", "Budget",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult answer = MessageBox.Show("Delete this budget?", "Delete budget",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes)
            return;

        try
        {
            budgetController.Delete(selectedBudgetId, Session.UserId);
            MessageBox.Show("Budget deleted.", "Budget",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearBudgetForm();
            LoadBudgets();
            LoadDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Budget",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void DgvBudgets_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (dgvBudgets.CurrentRow?.DataBoundItem is not Budget budget)
            return;

        selectedBudgetId = budget.BudgetId;
        SelectCategory(cboBudgetCategory, budget.CategoryId);
        cboBudgetMonth.SelectedIndex = budget.BudgetMonth - 1;
        numBudgetYear.Value = budget.BudgetYear;
        txtBudgetLimit.Text = budget.LimitAmount.ToString("0.00");
    }

    private void ClearBudgetForm()
    {
        selectedBudgetId = 0;
        txtBudgetLimit.Clear();
        dgvBudgets.ClearSelection();
    }

    // ---------------- Dashboard ----------------

    private void LoadDashboard()
    {
        if (cboDashMonth.SelectedIndex < 0)
            return;

        int month = cboDashMonth.SelectedIndex + 1;
        int year = (int)numDashYear.Value;

        decimal spent = expenseController.GetTotalSpent(Session.UserId, year, month);
        dashboardBudgets = budgetController.GetAll(Session.UserId, year, month);

        decimal limit = 0;
        foreach (Budget budget in dashboardBudgets)
        {
            limit += budget.LimitAmount;
        }
        decimal remaining = limit - spent;

        lblSpentValue.Text = FormatMoney(spent);
        lblBudgetValue.Text = FormatMoney(limit);
        lblRemainingValue.Text = FormatMoney(remaining);

        dgvRecent.DataSource = null;
        dgvRecent.DataSource = expenseController.GetRecent(Session.UserId, 6);

        panelChart.Invalidate();
    }

    private static string FormatMoney(decimal amount)
    {
        return Session.Currency + " " + amount.ToString("N2");
    }

    private void PanelChart_Paint(object? sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;

        using Font smallFont = new Font("Segoe UI", 8F);
        using SolidBrush textBrush = new SolidBrush(Color.DimGray);
        using Pen gridPen = new Pen(Color.Gainsboro);

        if (dashboardBudgets.Count == 0)
        {
            graphics.DrawString(
                "No budgets for this month yet. Add one in the Budgets tab.",
                smallFont, textBrush, 20, 20);
            return;
        }

        int left = 65;
        int right = panelChart.Width - 30;
        int top = 30;
        int bottom = panelChart.Height - 35;
        int height = bottom - top;
        if (height < 20 || right - left < 50)
            return;

        decimal maximum = 0;
        foreach (Budget budget in dashboardBudgets)
        {
            maximum = Math.Max(maximum, Math.Max(budget.LimitAmount, budget.Spent));
        }
        if (maximum <= 0)
            maximum = 1;

        // Horizontal guide lines with value labels.
        for (int i = 0; i <= 4; i++)
        {
            int y = bottom - height * i / 4;
            graphics.DrawLine(gridPen, left, y, right, y);
            decimal value = maximum * i / 4;
            graphics.DrawString(value.ToString("N0"), smallFont, textBrush, 5, y - 8);
        }

        int groupWidth = (right - left) / dashboardBudgets.Count;
        int barWidth = Math.Min(26, groupWidth / 3);
        if (barWidth < 5)
            barWidth = 5;

        for (int i = 0; i < dashboardBudgets.Count; i++)
        {
            Budget budget = dashboardBudgets[i];
            int center = left + groupWidth * i + groupWidth / 2;

            int limitHeight = (int)(height * (budget.LimitAmount / maximum));
            int spentHeight = (int)(height * (budget.Spent / maximum));

            Rectangle limitRectangle = new Rectangle(
                center - barWidth - 3, bottom - limitHeight, barWidth, limitHeight);
            Rectangle spentRectangle = new Rectangle(
                center + 3, bottom - spentHeight, barWidth, spentHeight);

            using (SolidBrush limitBrush = new SolidBrush(Color.Gainsboro))
                graphics.FillRectangle(limitBrush, limitRectangle);

            Color spentColor = budget.Spent > budget.LimitAmount ? Color.Firebrick : Color.SeaGreen;
            using (SolidBrush spentBrush = new SolidBrush(spentColor))
                graphics.FillRectangle(spentBrush, spentRectangle);

            string name = budget.CategoryName;
            if (name.Length > 10)
                name = name.Substring(0, 9) + ".";
            graphics.DrawString(name, smallFont, textBrush, center - 25, bottom + 4);
        }

        // Legend
        using (SolidBrush legendBrush = new SolidBrush(Color.Gainsboro))
            graphics.FillRectangle(legendBrush, right - 150, 4, 12, 12);
        graphics.DrawString("Budget", smallFont, textBrush, right - 134, 2);

        using (SolidBrush spentLegendBrush = new SolidBrush(Color.SeaGreen))
            graphics.FillRectangle(spentLegendBrush, right - 70, 4, 12, 12);
        graphics.DrawString("Spent", smallFont, textBrush, right - 54, 2);
    }

    // ---------------- Small helper ----------------

    private void RunSafely(Action action, string title)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
