namespace ExpenseTrackSystem;

partial class MainForm
{
    private void InitializeComponent()
    {
        lblHeader = new Label();
        lblLoggedIn = new Label();
        tabMain = new TabControl();
        tabDashboard = new TabPage();
        lblDashMonth = new Label();
        cboDashMonth = new ComboBox();
        lblDashYear = new Label();
        numDashYear = new NumericUpDown();
        lblSpentCaption = new Label();
        lblSpentValue = new Label();
        lblBudgetCaption = new Label();
        lblBudgetValue = new Label();
        lblRemainingCaption = new Label();
        lblRemainingValue = new Label();
        lblChartTitle = new Label();
        panelChart = new Panel();
        lblRecentTitle = new Label();
        dgvRecent = new DataGridView();
        colRecentTitle = new DataGridViewTextBoxColumn();
        colRecentCategory = new DataGridViewTextBoxColumn();
        colRecentAmount = new DataGridViewTextBoxColumn();
        colRecentDate = new DataGridViewTextBoxColumn();
        colRecentTags = new DataGridViewTextBoxColumn();
        tabExpenses = new TabPage();
        lblExpenseTitle = new Label();
        txtExpenseTitle = new TextBox();
        lblExpenseAmount = new Label();
        txtExpenseAmount = new TextBox();
        lblExpenseDate = new Label();
        dtpExpenseDate = new DateTimePicker();
        lblExpenseCategory = new Label();
        cboExpenseCategory = new ComboBox();
        lblExpenseTags = new Label();
        clbTags = new CheckedListBox();
        btnSaveExpense = new Button();
        btnUpdateExpense = new Button();
        btnDeleteExpense = new Button();
        lblNewTag = new Label();
        txtNewTag = new TextBox();
        btnAddTag = new Button();
        lblFilterTag = new Label();
        clbFilterTags = new CheckedListBox();
        btnClearFilter = new Button();
        dgvExpenses = new DataGridView();
        colExpenseTitle = new DataGridViewTextBoxColumn();
        colExpenseCategory = new DataGridViewTextBoxColumn();
        colExpenseAmount = new DataGridViewTextBoxColumn();
        colExpenseDate = new DataGridViewTextBoxColumn();
        colExpenseTags = new DataGridViewTextBoxColumn();
        lblExpenseHint = new Label();
        tabCategories = new TabPage();
        lblCategoryName = new Label();
        txtCategoryName = new TextBox();
        btnAddCategory = new Button();
        btnUpdateCategory = new Button();
        btnDeleteCategory = new Button();
        dgvCategories = new DataGridView();
        colCategoryName = new DataGridViewTextBoxColumn();
        tabBudgets = new TabPage();
        lblBudgetCategory = new Label();
        cboBudgetCategory = new ComboBox();
        lblBudgetMonth = new Label();
        cboBudgetMonth = new ComboBox();
        lblBudgetYear = new Label();
        numBudgetYear = new NumericUpDown();
        lblBudgetLimit = new Label();
        txtBudgetLimit = new TextBox();
        btnSaveBudget = new Button();
        btnDeleteBudget = new Button();
        dgvBudgets = new DataGridView();
        colBudgetCategory = new DataGridViewTextBoxColumn();
        colBudgetMonth = new DataGridViewTextBoxColumn();
        colBudgetYear = new DataGridViewTextBoxColumn();
        colBudgetLimit = new DataGridViewTextBoxColumn();
        colBudgetSpent = new DataGridViewTextBoxColumn();
        colBudgetRemaining = new DataGridViewTextBoxColumn();
        lblBudgetHint = new Label();
        tabProfile = new TabPage();
        lblProfileHeading = new Label();
        lblProfileFullName = new Label();
        txtProfileFullName = new TextBox();
        lblProfileUsername = new Label();
        txtProfileUsername = new TextBox();
        lblProfilePhone = new Label();
        txtProfilePhone = new TextBox();
        lblProfileCurrency = new Label();
        cboProfileCurrency = new ComboBox();
        btnSaveProfile = new Button();
        btnLogout = new Button();
        picProfile = new PictureBox();
        btnBrowsePhoto = new Button();
        lblProfileHint = new Label();
        lblMemberSince = new Label();
        DataGridViewCellStyle dataGridViewCellStyleAmount = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyleDate = new DataGridViewCellStyle();
        dataGridViewCellStyleAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyleAmount.Format = "N2";
        dataGridViewCellStyleDate.Format = "yyyy-MM-dd";
        tabMain.SuspendLayout();
        tabDashboard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numDashYear).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
        tabExpenses.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
        tabCategories.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
        tabBudgets.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numBudgetYear).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvBudgets).BeginInit();
        tabProfile.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picProfile).BeginInit();
        SuspendLayout();
        // 
        // lblHeader
        // 
        lblHeader.AutoSize = true;
        lblHeader.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblHeader.Location = new Point(12, 10);
        lblHeader.Name = "lblHeader";
        lblHeader.Size = new Size(196, 28);
        lblHeader.TabIndex = 0;
        lblHeader.Text = "ExpenseTrack System";
        // 
        // lblLoggedIn
        // 
        lblLoggedIn.Font = new Font("Segoe UI", 9F);
        lblLoggedIn.Location = new Point(700, 18);
        lblLoggedIn.Name = "lblLoggedIn";
        lblLoggedIn.Size = new Size(395, 20);
        lblLoggedIn.TabIndex = 1;
        lblLoggedIn.Text = "Logged in";
        lblLoggedIn.TextAlign = ContentAlignment.MiddleRight;
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabDashboard);
        tabMain.Controls.Add(tabExpenses);
        tabMain.Controls.Add(tabCategories);
        tabMain.Controls.Add(tabBudgets);
        tabMain.Controls.Add(tabProfile);
        tabMain.Location = new Point(12, 48);
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(1096, 720);
        tabMain.TabIndex = 2;
        // 
        // tabDashboard
        // 
        tabDashboard.Controls.Add(lblDashMonth);
        tabDashboard.Controls.Add(cboDashMonth);
        tabDashboard.Controls.Add(lblDashYear);
        tabDashboard.Controls.Add(numDashYear);
        tabDashboard.Controls.Add(lblSpentCaption);
        tabDashboard.Controls.Add(lblSpentValue);
        tabDashboard.Controls.Add(lblBudgetCaption);
        tabDashboard.Controls.Add(lblBudgetValue);
        tabDashboard.Controls.Add(lblRemainingCaption);
        tabDashboard.Controls.Add(lblRemainingValue);
        tabDashboard.Controls.Add(lblChartTitle);
        tabDashboard.Controls.Add(panelChart);
        tabDashboard.Controls.Add(lblRecentTitle);
        tabDashboard.Controls.Add(dgvRecent);
        tabDashboard.Location = new Point(4, 26);
        tabDashboard.Name = "tabDashboard";
        tabDashboard.Padding = new Padding(3);
        tabDashboard.Size = new Size(1088, 690);
        tabDashboard.TabIndex = 0;
        tabDashboard.Text = "Dashboard";
        tabDashboard.UseVisualStyleBackColor = true;
        // 
        // lblDashMonth
        // 
        lblDashMonth.AutoSize = true;
        lblDashMonth.Location = new Point(20, 20);
        lblDashMonth.Name = "lblDashMonth";
        lblDashMonth.Size = new Size(52, 19);
        lblDashMonth.TabIndex = 0;
        lblDashMonth.Text = "Month";
        // 
        // cboDashMonth
        // 
        cboDashMonth.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDashMonth.FormattingEnabled = true;
        cboDashMonth.Location = new Point(85, 16);
        cboDashMonth.Name = "cboDashMonth";
        cboDashMonth.Size = new Size(130, 25);
        cboDashMonth.TabIndex = 1;
        // 
        // lblDashYear
        // 
        lblDashYear.AutoSize = true;
        lblDashYear.Location = new Point(235, 20);
        lblDashYear.Name = "lblDashYear";
        lblDashYear.Size = new Size(37, 19);
        lblDashYear.TabIndex = 2;
        lblDashYear.Text = "Year";
        // 
        // numDashYear
        // 
        numDashYear.Location = new Point(280, 16);
        numDashYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
        numDashYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
        numDashYear.Name = "numDashYear";
        numDashYear.Size = new Size(80, 25);
        numDashYear.TabIndex = 3;
        numDashYear.Value = new decimal(new int[] { 2026, 0, 0, 0 });
        // 
        // lblSpentCaption
        // 
        lblSpentCaption.AutoSize = true;
        lblSpentCaption.Location = new Point(20, 66);
        lblSpentCaption.Name = "lblSpentCaption";
        lblSpentCaption.Size = new Size(74, 19);
        lblSpentCaption.TabIndex = 5;
        lblSpentCaption.Text = "Total spent:";
        // 
        // lblSpentValue
        // 
        lblSpentValue.AutoSize = true;
        lblSpentValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblSpentValue.Location = new Point(130, 61);
        lblSpentValue.Name = "lblSpentValue";
        lblSpentValue.Size = new Size(42, 25);
        lblSpentValue.TabIndex = 6;
        lblSpentValue.Text = "0.00";
        // 
        // lblBudgetCaption
        // 
        lblBudgetCaption.AutoSize = true;
        lblBudgetCaption.Location = new Point(20, 100);
        lblBudgetCaption.Name = "lblBudgetCaption";
        lblBudgetCaption.Size = new Size(87, 19);
        lblBudgetCaption.TabIndex = 7;
        lblBudgetCaption.Text = "Total budget:";
        // 
        // lblBudgetValue
        // 
        lblBudgetValue.AutoSize = true;
        lblBudgetValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblBudgetValue.Location = new Point(130, 95);
        lblBudgetValue.Name = "lblBudgetValue";
        lblBudgetValue.Size = new Size(42, 25);
        lblBudgetValue.TabIndex = 8;
        lblBudgetValue.Text = "0.00";
        // 
        // lblRemainingCaption
        // 
        lblRemainingCaption.AutoSize = true;
        lblRemainingCaption.Location = new Point(20, 134);
        lblRemainingCaption.Name = "lblRemainingCaption";
        lblRemainingCaption.Size = new Size(74, 19);
        lblRemainingCaption.TabIndex = 9;
        lblRemainingCaption.Text = "Remaining:";
        // 
        // lblRemainingValue
        // 
        lblRemainingValue.AutoSize = true;
        lblRemainingValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblRemainingValue.Location = new Point(130, 129);
        lblRemainingValue.Name = "lblRemainingValue";
        lblRemainingValue.Size = new Size(42, 25);
        lblRemainingValue.TabIndex = 10;
        lblRemainingValue.Text = "0.00";
        // 
        // lblChartTitle
        // 
        lblChartTitle.AutoSize = true;
        lblChartTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblChartTitle.Location = new Point(20, 180);
        lblChartTitle.Name = "lblChartTitle";
        lblChartTitle.Size = new Size(181, 19);
        lblChartTitle.TabIndex = 11;
        lblChartTitle.Text = "Budget vs actual this month";
        // 
        // panelChart
        // 
        panelChart.BackColor = Color.White;
        panelChart.BorderStyle = BorderStyle.FixedSingle;
        panelChart.Location = new Point(20, 205);
        panelChart.Name = "panelChart";
        panelChart.Size = new Size(1045, 250);
        panelChart.TabIndex = 12;
        // 
        // lblRecentTitle
        // 
        lblRecentTitle.AutoSize = true;
        lblRecentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblRecentTitle.Location = new Point(20, 470);
        lblRecentTitle.Name = "lblRecentTitle";
        lblRecentTitle.Size = new Size(129, 19);
        lblRecentTitle.TabIndex = 13;
        lblRecentTitle.Text = "Recent expenses";
        // 
        // dgvRecent
        // 
        dgvRecent.AllowUserToAddRows = false;
        dgvRecent.AllowUserToDeleteRows = false;
        dgvRecent.AutoGenerateColumns = false;
        dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvRecent.BackgroundColor = Color.White;
        dgvRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvRecent.Columns.AddRange(new DataGridViewColumn[] { colRecentTitle, colRecentCategory, colRecentAmount, colRecentDate, colRecentTags });
        dgvRecent.Location = new Point(20, 495);
        dgvRecent.MultiSelect = false;
        dgvRecent.Name = "dgvRecent";
        dgvRecent.ReadOnly = true;
        dgvRecent.RowHeadersVisible = false;
        dgvRecent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRecent.Size = new Size(1045, 175);
        dgvRecent.TabIndex = 14;
        // 
        // colRecentTitle
        // 
        colRecentTitle.DataPropertyName = "Title";
        colRecentTitle.FillWeight = 30F;
        colRecentTitle.HeaderText = "Title";
        colRecentTitle.Name = "colRecentTitle";
        // 
        // colRecentCategory
        // 
        colRecentCategory.DataPropertyName = "CategoryName";
        colRecentCategory.FillWeight = 20F;
        colRecentCategory.HeaderText = "Category";
        colRecentCategory.Name = "colRecentCategory";
        // 
        // colRecentAmount
        // 
        colRecentAmount.DataPropertyName = "Amount";
        colRecentAmount.DefaultCellStyle = dataGridViewCellStyleAmount;
        colRecentAmount.FillWeight = 15F;
        colRecentAmount.HeaderText = "Amount";
        colRecentAmount.Name = "colRecentAmount";
        // 
        // colRecentDate
        // 
        colRecentDate.DataPropertyName = "ExpenseDate";
        colRecentDate.DefaultCellStyle = dataGridViewCellStyleDate;
        colRecentDate.FillWeight = 15F;
        colRecentDate.HeaderText = "Date";
        colRecentDate.Name = "colRecentDate";
        // 
        // colRecentTags
        // 
        colRecentTags.DataPropertyName = "TagNames";
        colRecentTags.FillWeight = 20F;
        colRecentTags.HeaderText = "Tags";
        colRecentTags.Name = "colRecentTags";
        // 
        // tabExpenses
        // 
        tabExpenses.Controls.Add(lblExpenseTitle);
        tabExpenses.Controls.Add(txtExpenseTitle);
        tabExpenses.Controls.Add(lblExpenseAmount);
        tabExpenses.Controls.Add(txtExpenseAmount);
        tabExpenses.Controls.Add(lblExpenseDate);
        tabExpenses.Controls.Add(dtpExpenseDate);
        tabExpenses.Controls.Add(lblExpenseCategory);
        tabExpenses.Controls.Add(cboExpenseCategory);
        tabExpenses.Controls.Add(lblExpenseTags);
        tabExpenses.Controls.Add(clbTags);
        tabExpenses.Controls.Add(btnSaveExpense);
        tabExpenses.Controls.Add(btnUpdateExpense);
        tabExpenses.Controls.Add(btnDeleteExpense);
        tabExpenses.Controls.Add(lblNewTag);
        tabExpenses.Controls.Add(txtNewTag);
        tabExpenses.Controls.Add(btnAddTag);
        tabExpenses.Controls.Add(lblFilterTag);
        tabExpenses.Controls.Add(clbFilterTags);
        tabExpenses.Controls.Add(btnClearFilter);
        tabExpenses.Controls.Add(dgvExpenses);
        tabExpenses.Controls.Add(lblExpenseHint);
        tabExpenses.Location = new Point(4, 26);
        tabExpenses.Name = "tabExpenses";
        tabExpenses.Padding = new Padding(3);
        tabExpenses.Size = new Size(1088, 690);
        tabExpenses.TabIndex = 1;
        tabExpenses.Text = "Expenses";
        tabExpenses.UseVisualStyleBackColor = true;
        // 
        // lblExpenseTitle
        // 
        lblExpenseTitle.AutoSize = true;
        lblExpenseTitle.Location = new Point(20, 20);
        lblExpenseTitle.Name = "lblExpenseTitle";
        lblExpenseTitle.Size = new Size(33, 19);
        lblExpenseTitle.TabIndex = 0;
        lblExpenseTitle.Text = "Title";
        // 
        // txtExpenseTitle
        // 
        txtExpenseTitle.Location = new Point(20, 43);
        txtExpenseTitle.Name = "txtExpenseTitle";
        txtExpenseTitle.Size = new Size(340, 25);
        txtExpenseTitle.TabIndex = 1;
        // 
        // lblExpenseAmount
        // 
        lblExpenseAmount.AutoSize = true;
        lblExpenseAmount.Location = new Point(20, 83);
        lblExpenseAmount.Name = "lblExpenseAmount";
        lblExpenseAmount.Size = new Size(59, 19);
        lblExpenseAmount.TabIndex = 2;
        lblExpenseAmount.Text = "Amount";
        // 
        // txtExpenseAmount
        // 
        txtExpenseAmount.Location = new Point(20, 106);
        txtExpenseAmount.Name = "txtExpenseAmount";
        txtExpenseAmount.Size = new Size(160, 25);
        txtExpenseAmount.TabIndex = 3;
        // 
        // lblExpenseDate
        // 
        lblExpenseDate.AutoSize = true;
        lblExpenseDate.Location = new Point(200, 83);
        lblExpenseDate.Name = "lblExpenseDate";
        lblExpenseDate.Size = new Size(38, 19);
        lblExpenseDate.TabIndex = 4;
        lblExpenseDate.Text = "Date";
        // 
        // dtpExpenseDate
        // 
        dtpExpenseDate.Format = DateTimePickerFormat.Short;
        dtpExpenseDate.Location = new Point(200, 106);
        dtpExpenseDate.Name = "dtpExpenseDate";
        dtpExpenseDate.Size = new Size(160, 25);
        dtpExpenseDate.TabIndex = 5;
        // 
        // lblExpenseCategory
        // 
        lblExpenseCategory.AutoSize = true;
        lblExpenseCategory.Location = new Point(20, 146);
        lblExpenseCategory.Name = "lblExpenseCategory";
        lblExpenseCategory.Size = new Size(69, 19);
        lblExpenseCategory.TabIndex = 6;
        lblExpenseCategory.Text = "Category";
        // 
        // cboExpenseCategory
        // 
        cboExpenseCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cboExpenseCategory.FormattingEnabled = true;
        cboExpenseCategory.Location = new Point(20, 169);
        cboExpenseCategory.Name = "cboExpenseCategory";
        cboExpenseCategory.Size = new Size(340, 25);
        cboExpenseCategory.TabIndex = 7;
        // 
        // lblExpenseTags
        // 
        lblExpenseTags.AutoSize = true;
        lblExpenseTags.Location = new Point(20, 209);
        lblExpenseTags.Name = "lblExpenseTags";
        lblExpenseTags.Size = new Size(36, 19);
        lblExpenseTags.TabIndex = 8;
        lblExpenseTags.Text = "Tags";
        // 
        // clbTags
        // 
        clbTags.CheckOnClick = true;
        clbTags.FormattingEnabled = true;
        clbTags.Location = new Point(20, 232);
        clbTags.Name = "clbTags";
        clbTags.Size = new Size(340, 160);
        clbTags.TabIndex = 9;
        // 
        // btnSaveExpense
        // 
        btnSaveExpense.Location = new Point(20, 405);
        btnSaveExpense.Name = "btnSaveExpense";
        btnSaveExpense.Size = new Size(105, 35);
        btnSaveExpense.TabIndex = 10;
        btnSaveExpense.Text = "Add";
        btnSaveExpense.UseVisualStyleBackColor = true;
        // 
        // btnUpdateExpense
        // 
        btnUpdateExpense.Location = new Point(135, 405);
        btnUpdateExpense.Name = "btnUpdateExpense";
        btnUpdateExpense.Size = new Size(105, 35);
        btnUpdateExpense.TabIndex = 11;
        btnUpdateExpense.Text = "Update";
        btnUpdateExpense.UseVisualStyleBackColor = true;
        // 
        // btnDeleteExpense
        // 
        btnDeleteExpense.Location = new Point(250, 405);
        btnDeleteExpense.Name = "btnDeleteExpense";
        btnDeleteExpense.Size = new Size(105, 35);
        btnDeleteExpense.TabIndex = 12;
        btnDeleteExpense.Text = "Delete";
        btnDeleteExpense.UseVisualStyleBackColor = true;
        // 
        // lblNewTag
        // 
        lblNewTag.AutoSize = true;
        lblNewTag.Location = new Point(20, 455);
        lblNewTag.Name = "lblNewTag";
        lblNewTag.Size = new Size(58, 19);
        lblNewTag.TabIndex = 13;
        lblNewTag.Text = "New tag";
        // 
        // txtNewTag
        // 
        txtNewTag.Location = new Point(90, 452);
        txtNewTag.Name = "txtNewTag";
        txtNewTag.Size = new Size(150, 25);
        txtNewTag.TabIndex = 14;
        // 
        // btnAddTag
        // 
        btnAddTag.Location = new Point(250, 450);
        btnAddTag.Name = "btnAddTag";
        btnAddTag.Size = new Size(105, 30);
        btnAddTag.TabIndex = 15;
        btnAddTag.Text = "Add tag";
        btnAddTag.UseVisualStyleBackColor = true;
        // 
        // lblFilterTag
        // 
        lblFilterTag.AutoSize = true;
        lblFilterTag.Location = new Point(400, 22);
        lblFilterTag.Name = "lblFilterTag";
        lblFilterTag.Size = new Size(92, 19);
        lblFilterTag.TabIndex = 16;
        lblFilterTag.Text = "Filter by tags:";
        // 
        // clbFilterTags
        // 
        clbFilterTags.CheckOnClick = true;
        clbFilterTags.FormattingEnabled = true;
        clbFilterTags.Location = new Point(505, 12);
        clbFilterTags.Name = "clbFilterTags";
        clbFilterTags.Size = new Size(175, 76);
        clbFilterTags.TabIndex = 17;
        // 
        // btnClearFilter
        // 
        btnClearFilter.Location = new Point(690, 15);
        btnClearFilter.Name = "btnClearFilter";
        btnClearFilter.Size = new Size(100, 30);
        btnClearFilter.TabIndex = 18;
        btnClearFilter.Text = "Clear filter";
        btnClearFilter.UseVisualStyleBackColor = true;
        // 
        // dgvExpenses
        // 
        dgvExpenses.AllowUserToAddRows = false;
        dgvExpenses.AllowUserToDeleteRows = false;
        dgvExpenses.AutoGenerateColumns = false;
        dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvExpenses.BackgroundColor = Color.White;
        dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvExpenses.Columns.AddRange(new DataGridViewColumn[] { colExpenseTitle, colExpenseCategory, colExpenseAmount, colExpenseDate, colExpenseTags });
        dgvExpenses.Location = new Point(400, 100);
        dgvExpenses.MultiSelect = false;
        dgvExpenses.Name = "dgvExpenses";
        dgvExpenses.ReadOnly = true;
        dgvExpenses.RowHeadersVisible = false;
        dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvExpenses.Size = new Size(660, 505);
        dgvExpenses.TabIndex = 23;
        // 
        // colExpenseTitle
        // 
        colExpenseTitle.DataPropertyName = "Title";
        colExpenseTitle.FillWeight = 25F;
        colExpenseTitle.HeaderText = "Title";
        colExpenseTitle.Name = "colExpenseTitle";
        // 
        // colExpenseCategory
        // 
        colExpenseCategory.DataPropertyName = "CategoryName";
        colExpenseCategory.FillWeight = 18F;
        colExpenseCategory.HeaderText = "Category";
        colExpenseCategory.Name = "colExpenseCategory";
        // 
        // colExpenseAmount
        // 
        colExpenseAmount.DataPropertyName = "Amount";
        colExpenseAmount.DefaultCellStyle = dataGridViewCellStyleAmount;
        colExpenseAmount.FillWeight = 12F;
        colExpenseAmount.HeaderText = "Amount";
        colExpenseAmount.Name = "colExpenseAmount";
        // 
        // colExpenseDate
        // 
        colExpenseDate.DataPropertyName = "ExpenseDate";
        colExpenseDate.DefaultCellStyle = dataGridViewCellStyleDate;
        colExpenseDate.FillWeight = 15F;
        colExpenseDate.HeaderText = "Date";
        colExpenseDate.Name = "colExpenseDate";
        // 
        // colExpenseTags
        // 
        colExpenseTags.DataPropertyName = "TagNames";
        colExpenseTags.FillWeight = 30F;
        colExpenseTags.HeaderText = "Tags";
        colExpenseTags.Name = "colExpenseTags";
        // 
        // lblExpenseHint
        // 
        lblExpenseHint.AutoSize = true;
        lblExpenseHint.Font = new Font("Segoe UI", 8.5F);
        lblExpenseHint.Location = new Point(400, 617);
        lblExpenseHint.Name = "lblExpenseHint";
        lblExpenseHint.Size = new Size(253, 15);
        lblExpenseHint.TabIndex = 24;
        lblExpenseHint.Text = "Click a row in the grid to load it into the form.";
        // 
        // tabCategories
        // 
        tabCategories.Controls.Add(lblCategoryName);
        tabCategories.Controls.Add(txtCategoryName);
        tabCategories.Controls.Add(btnAddCategory);
        tabCategories.Controls.Add(btnUpdateCategory);
        tabCategories.Controls.Add(btnDeleteCategory);
        tabCategories.Controls.Add(dgvCategories);
        tabCategories.Location = new Point(4, 26);
        tabCategories.Name = "tabCategories";
        tabCategories.Padding = new Padding(3);
        tabCategories.Size = new Size(1088, 690);
        tabCategories.TabIndex = 2;
        tabCategories.Text = "Categories";
        tabCategories.UseVisualStyleBackColor = true;
        // 
        // lblCategoryName
        // 
        lblCategoryName.AutoSize = true;
        lblCategoryName.Location = new Point(20, 25);
        lblCategoryName.Name = "lblCategoryName";
        lblCategoryName.Size = new Size(107, 19);
        lblCategoryName.TabIndex = 0;
        lblCategoryName.Text = "Category name";
        // 
        // txtCategoryName
        // 
        txtCategoryName.Location = new Point(165, 21);
        txtCategoryName.Name = "txtCategoryName";
        txtCategoryName.Size = new Size(250, 25);
        txtCategoryName.TabIndex = 1;
        // 
        // btnAddCategory
        // 
        btnAddCategory.Location = new Point(435, 18);
        btnAddCategory.Name = "btnAddCategory";
        btnAddCategory.Size = new Size(110, 32);
        btnAddCategory.TabIndex = 2;
        btnAddCategory.Text = "Add";
        btnAddCategory.UseVisualStyleBackColor = true;
        // 
        // btnUpdateCategory
        // 
        btnUpdateCategory.Location = new Point(555, 18);
        btnUpdateCategory.Name = "btnUpdateCategory";
        btnUpdateCategory.Size = new Size(110, 32);
        btnUpdateCategory.TabIndex = 3;
        btnUpdateCategory.Text = "Update";
        btnUpdateCategory.UseVisualStyleBackColor = true;
        // 
        // btnDeleteCategory
        // 
        btnDeleteCategory.Location = new Point(675, 18);
        btnDeleteCategory.Name = "btnDeleteCategory";
        btnDeleteCategory.Size = new Size(110, 32);
        btnDeleteCategory.TabIndex = 4;
        btnDeleteCategory.Text = "Delete";
        btnDeleteCategory.UseVisualStyleBackColor = true;
        // 
        // dgvCategories
        // 
        dgvCategories.AllowUserToAddRows = false;
        dgvCategories.AllowUserToDeleteRows = false;
        dgvCategories.AutoGenerateColumns = false;
        dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCategories.BackgroundColor = Color.White;
        dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCategories.Columns.AddRange(new DataGridViewColumn[] { colCategoryName });
        dgvCategories.Location = new Point(20, 70);
        dgvCategories.MultiSelect = false;
        dgvCategories.Name = "dgvCategories";
        dgvCategories.ReadOnly = true;
        dgvCategories.RowHeadersVisible = false;
        dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCategories.Size = new Size(1045, 580);
        dgvCategories.TabIndex = 6;
        // 
        // colCategoryName
        // 
        colCategoryName.DataPropertyName = "CategoryName";
        colCategoryName.FillWeight = 100F;
        colCategoryName.HeaderText = "Category";
        colCategoryName.Name = "colCategoryName";
        // 
        // tabBudgets
        // 
        tabBudgets.Controls.Add(lblBudgetCategory);
        tabBudgets.Controls.Add(cboBudgetCategory);
        tabBudgets.Controls.Add(lblBudgetMonth);
        tabBudgets.Controls.Add(cboBudgetMonth);
        tabBudgets.Controls.Add(lblBudgetYear);
        tabBudgets.Controls.Add(numBudgetYear);
        tabBudgets.Controls.Add(lblBudgetLimit);
        tabBudgets.Controls.Add(txtBudgetLimit);
        tabBudgets.Controls.Add(btnSaveBudget);
        tabBudgets.Controls.Add(btnDeleteBudget);
        tabBudgets.Controls.Add(dgvBudgets);
        tabBudgets.Controls.Add(lblBudgetHint);
        tabBudgets.Location = new Point(4, 26);
        tabBudgets.Name = "tabBudgets";
        tabBudgets.Padding = new Padding(3);
        tabBudgets.Size = new Size(1088, 690);
        tabBudgets.TabIndex = 3;
        tabBudgets.Text = "Budgets";
        tabBudgets.UseVisualStyleBackColor = true;
        // 
        // lblBudgetCategory
        // 
        lblBudgetCategory.AutoSize = true;
        lblBudgetCategory.Location = new Point(20, 22);
        lblBudgetCategory.Name = "lblBudgetCategory";
        lblBudgetCategory.Size = new Size(69, 19);
        lblBudgetCategory.TabIndex = 0;
        lblBudgetCategory.Text = "Category";
        // 
        // cboBudgetCategory
        // 
        cboBudgetCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBudgetCategory.FormattingEnabled = true;
        cboBudgetCategory.Location = new Point(165, 18);
        cboBudgetCategory.Name = "cboBudgetCategory";
        cboBudgetCategory.Size = new Size(190, 25);
        cboBudgetCategory.TabIndex = 1;
        // 
        // lblBudgetMonth
        // 
        lblBudgetMonth.AutoSize = true;
        lblBudgetMonth.Location = new Point(375, 22);
        lblBudgetMonth.Name = "lblBudgetMonth";
        lblBudgetMonth.Size = new Size(52, 19);
        lblBudgetMonth.TabIndex = 2;
        lblBudgetMonth.Text = "Month";
        // 
        // cboBudgetMonth
        // 
        cboBudgetMonth.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBudgetMonth.FormattingEnabled = true;
        cboBudgetMonth.Location = new Point(465, 18);
        cboBudgetMonth.Name = "cboBudgetMonth";
        cboBudgetMonth.Size = new Size(125, 25);
        cboBudgetMonth.TabIndex = 3;
        // 
        // lblBudgetYear
        // 
        lblBudgetYear.AutoSize = true;
        lblBudgetYear.Location = new Point(610, 22);
        lblBudgetYear.Name = "lblBudgetYear";
        lblBudgetYear.Size = new Size(37, 19);
        lblBudgetYear.TabIndex = 4;
        lblBudgetYear.Text = "Year";
        // 
        // numBudgetYear
        // 
        numBudgetYear.Location = new Point(665, 18);
        numBudgetYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
        numBudgetYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
        numBudgetYear.Name = "numBudgetYear";
        numBudgetYear.Size = new Size(80, 25);
        numBudgetYear.TabIndex = 5;
        numBudgetYear.Value = new decimal(new int[] { 2026, 0, 0, 0 });
        // 
        // lblBudgetLimit
        // 
        lblBudgetLimit.AutoSize = true;
        lblBudgetLimit.Location = new Point(765, 22);
        lblBudgetLimit.Name = "lblBudgetLimit";
        lblBudgetLimit.Size = new Size(55, 19);
        lblBudgetLimit.TabIndex = 6;
        lblBudgetLimit.Text = "Limit";
        // 
        // txtBudgetLimit
        // 
        txtBudgetLimit.Location = new Point(835, 18);
        txtBudgetLimit.Name = "txtBudgetLimit";
        txtBudgetLimit.Size = new Size(130, 25);
        txtBudgetLimit.TabIndex = 7;
        // 
        // btnSaveBudget
        // 
        btnSaveBudget.Location = new Point(20, 60);
        btnSaveBudget.Name = "btnSaveBudget";
        btnSaveBudget.Size = new Size(120, 32);
        btnSaveBudget.TabIndex = 8;
        btnSaveBudget.Text = "Save budget";
        btnSaveBudget.UseVisualStyleBackColor = true;
        // 
        // btnDeleteBudget
        // 
        btnDeleteBudget.Location = new Point(150, 60);
        btnDeleteBudget.Name = "btnDeleteBudget";
        btnDeleteBudget.Size = new Size(120, 32);
        btnDeleteBudget.TabIndex = 9;
        btnDeleteBudget.Text = "Delete";
        btnDeleteBudget.UseVisualStyleBackColor = true;
        // 
        // dgvBudgets
        // 
        dgvBudgets.AllowUserToAddRows = false;
        dgvBudgets.AllowUserToDeleteRows = false;
        dgvBudgets.AutoGenerateColumns = false;
        dgvBudgets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvBudgets.BackgroundColor = Color.White;
        dgvBudgets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBudgets.Columns.AddRange(new DataGridViewColumn[] { colBudgetCategory, colBudgetMonth, colBudgetYear, colBudgetLimit, colBudgetSpent, colBudgetRemaining });
        dgvBudgets.Location = new Point(20, 110);
        dgvBudgets.MultiSelect = false;
        dgvBudgets.Name = "dgvBudgets";
        dgvBudgets.ReadOnly = true;
        dgvBudgets.RowHeadersVisible = false;
        dgvBudgets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBudgets.Size = new Size(1045, 500);
        dgvBudgets.TabIndex = 12;
        // 
        // colBudgetCategory
        // 
        colBudgetCategory.DataPropertyName = "CategoryName";
        colBudgetCategory.FillWeight = 30F;
        colBudgetCategory.HeaderText = "Category";
        colBudgetCategory.Name = "colBudgetCategory";
        // 
        // colBudgetMonth
        // 
        colBudgetMonth.DataPropertyName = "MonthName";
        colBudgetMonth.FillWeight = 15F;
        colBudgetMonth.HeaderText = "Month";
        colBudgetMonth.Name = "colBudgetMonth";
        // 
        // colBudgetYear
        // 
        colBudgetYear.DataPropertyName = "BudgetYear";
        colBudgetYear.FillWeight = 10F;
        colBudgetYear.HeaderText = "Year";
        colBudgetYear.Name = "colBudgetYear";
        // 
        // colBudgetLimit
        // 
        colBudgetLimit.DataPropertyName = "LimitAmount";
        colBudgetLimit.DefaultCellStyle = dataGridViewCellStyleAmount;
        colBudgetLimit.FillWeight = 15F;
        colBudgetLimit.HeaderText = "Limit";
        colBudgetLimit.Name = "colBudgetLimit";
        // 
        // colBudgetSpent
        // 
        colBudgetSpent.DataPropertyName = "Spent";
        colBudgetSpent.DefaultCellStyle = dataGridViewCellStyleAmount;
        colBudgetSpent.FillWeight = 15F;
        colBudgetSpent.HeaderText = "Spent";
        colBudgetSpent.Name = "colBudgetSpent";
        // 
        // colBudgetRemaining
        // 
        colBudgetRemaining.DataPropertyName = "Remaining";
        colBudgetRemaining.DefaultCellStyle = dataGridViewCellStyleAmount;
        colBudgetRemaining.FillWeight = 15F;
        colBudgetRemaining.HeaderText = "Remaining";
        colBudgetRemaining.Name = "colBudgetRemaining";
        // 
        // lblBudgetHint
        // 
        lblBudgetHint.AutoSize = true;
        lblBudgetHint.Font = new Font("Segoe UI", 8.5F);
        lblBudgetHint.Location = new Point(20, 622);
        lblBudgetHint.Name = "lblBudgetHint";
        lblBudgetHint.Size = new Size(532, 15);
        lblBudgetHint.TabIndex = 13;
        lblBudgetHint.Text = "Saving a budget for the same category, month and year updates the existing limit.";
        // 
        // tabProfile
        // 
        tabProfile.Controls.Add(lblProfileHeading);
        tabProfile.Controls.Add(lblProfileFullName);
        tabProfile.Controls.Add(txtProfileFullName);
        tabProfile.Controls.Add(lblProfileUsername);
        tabProfile.Controls.Add(txtProfileUsername);
        tabProfile.Controls.Add(lblProfilePhone);
        tabProfile.Controls.Add(txtProfilePhone);
        tabProfile.Controls.Add(lblProfileCurrency);
        tabProfile.Controls.Add(cboProfileCurrency);
        tabProfile.Controls.Add(btnSaveProfile);
        tabProfile.Controls.Add(btnLogout);
        tabProfile.Controls.Add(picProfile);
        tabProfile.Controls.Add(btnBrowsePhoto);
        tabProfile.Controls.Add(lblProfileHint);
        tabProfile.Controls.Add(lblMemberSince);
        tabProfile.Location = new Point(4, 26);
        tabProfile.Name = "tabProfile";
        tabProfile.Padding = new Padding(3);
        tabProfile.Size = new Size(1088, 690);
        tabProfile.TabIndex = 4;
        tabProfile.Text = "Profile";
        tabProfile.UseVisualStyleBackColor = true;
        // 
        // lblProfileHeading
        // 
        lblProfileHeading.AutoSize = true;
        lblProfileHeading.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblProfileHeading.Location = new Point(20, 20);
        lblProfileHeading.Name = "lblProfileHeading";
        lblProfileHeading.Size = new Size(96, 21);
        lblProfileHeading.TabIndex = 0;
        lblProfileHeading.Text = "My profile";
        // 
        // lblProfileFullName
        // 
        lblProfileFullName.AutoSize = true;
        lblProfileFullName.Location = new Point(20, 65);
        lblProfileFullName.Name = "lblProfileFullName";
        lblProfileFullName.Size = new Size(63, 19);
        lblProfileFullName.TabIndex = 1;
        lblProfileFullName.Text = "Full name";
        // 
        // txtProfileFullName
        // 
        txtProfileFullName.Location = new Point(170, 62);
        txtProfileFullName.Name = "txtProfileFullName";
        txtProfileFullName.Size = new Size(250, 25);
        txtProfileFullName.TabIndex = 2;
        // 
        // lblProfileUsername
        // 
        lblProfileUsername.AutoSize = true;
        lblProfileUsername.Location = new Point(20, 110);
        lblProfileUsername.Name = "lblProfileUsername";
        lblProfileUsername.Size = new Size(66, 19);
        lblProfileUsername.TabIndex = 3;
        lblProfileUsername.Text = "Username";
        // 
        // txtProfileUsername
        // 
        txtProfileUsername.Location = new Point(170, 107);
        txtProfileUsername.Name = "txtProfileUsername";
        txtProfileUsername.ReadOnly = true;
        txtProfileUsername.Size = new Size(250, 25);
        txtProfileUsername.TabIndex = 4;
        txtProfileUsername.TabStop = false;
        // 
        // lblProfilePhone
        // 
        lblProfilePhone.AutoSize = true;
        lblProfilePhone.Location = new Point(20, 155);
        lblProfilePhone.Name = "lblProfilePhone";
        lblProfilePhone.Size = new Size(45, 19);
        lblProfilePhone.TabIndex = 5;
        lblProfilePhone.Text = "Phone";
        // 
        // txtProfilePhone
        // 
        txtProfilePhone.Location = new Point(170, 152);
        txtProfilePhone.Name = "txtProfilePhone";
        txtProfilePhone.Size = new Size(250, 25);
        txtProfilePhone.TabIndex = 6;
        // 
        // lblProfileCurrency
        // 
        lblProfileCurrency.AutoSize = true;
        lblProfileCurrency.Location = new Point(20, 200);
        lblProfileCurrency.Name = "lblProfileCurrency";
        lblProfileCurrency.Size = new Size(61, 19);
        lblProfileCurrency.TabIndex = 7;
        lblProfileCurrency.Text = "Currency";
        // 
        // cboProfileCurrency
        // 
        cboProfileCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProfileCurrency.FormattingEnabled = true;
        cboProfileCurrency.Location = new Point(170, 197);
        cboProfileCurrency.Name = "cboProfileCurrency";
        cboProfileCurrency.Size = new Size(250, 25);
        cboProfileCurrency.TabIndex = 8;
        // 
        // btnSaveProfile
        // 
        btnSaveProfile.Location = new Point(20, 250);
        btnSaveProfile.Name = "btnSaveProfile";
        btnSaveProfile.Size = new Size(200, 40);
        btnSaveProfile.TabIndex = 9;
        btnSaveProfile.Text = "Save profile";
        // 
        // btnLogout
        // 
        btnLogout.Location = new Point(20, 305);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(200, 40);
        btnLogout.TabIndex = 10;
        btnLogout.Text = "Log out";
        btnLogout.UseVisualStyleBackColor = true;
        // 
        // picProfile
        // 
        picProfile.BorderStyle = BorderStyle.FixedSingle;
        picProfile.Location = new Point(430, 62);
        picProfile.Name = "picProfile";
        picProfile.Size = new Size(220, 220);
        picProfile.SizeMode = PictureBoxSizeMode.Zoom;
        picProfile.TabIndex = 11;
        picProfile.TabStop = false;
        // 
        // btnBrowsePhoto
        // 
        btnBrowsePhoto.Location = new Point(430, 295);
        btnBrowsePhoto.Name = "btnBrowsePhoto";
        btnBrowsePhoto.Size = new Size(220, 32);
        btnBrowsePhoto.TabIndex = 12;
        btnBrowsePhoto.Text = "Choose photo...";
        btnBrowsePhoto.UseVisualStyleBackColor = true;
        // 
        // lblProfileHint
        // 
        lblProfileHint.AutoSize = true;
        lblProfileHint.Font = new Font("Segoe UI", 8.5F);
        lblProfileHint.Location = new Point(20, 425);
        lblProfileHint.Name = "lblProfileHint";
        lblProfileHint.Size = new Size(366, 30);
        lblProfileHint.TabIndex = 13;
        lblProfileHint.Text = "The photo is optional. The currency you choose is used on the dashboard\r\nand in every amount shown by the application.";
        // 
        // lblMemberSince
        // 
        lblMemberSince.AutoSize = true;
        lblMemberSince.Font = new Font("Segoe UI", 8.5F);
        lblMemberSince.Location = new Point(20, 370);
        lblMemberSince.Name = "lblMemberSince";
        lblMemberSince.Size = new Size(97, 15);
        lblMemberSince.TabIndex = 14;
        lblMemberSince.Text = "Member since ...";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1120, 780);
        Controls.Add(lblLoggedIn);
        Controls.Add(lblHeader);
        Controls.Add(tabMain);
        MinimumSize = new Size(1140, 820);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ExpenseTrack System";
        tabMain.ResumeLayout(false);
        tabDashboard.ResumeLayout(false);
        tabDashboard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numDashYear).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
        tabExpenses.ResumeLayout(false);
        tabExpenses.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
        tabCategories.ResumeLayout(false);
        tabCategories.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
        tabBudgets.ResumeLayout(false);
        tabBudgets.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numBudgetYear).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvBudgets).EndInit();
        tabProfile.ResumeLayout(false);
        tabProfile.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picProfile).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblHeader;
    private Label lblLoggedIn;
    private TabControl tabMain;
    private TabPage tabDashboard;
    private Label lblDashMonth;
    private ComboBox cboDashMonth;
    private Label lblDashYear;
    private NumericUpDown numDashYear;
    private Label lblSpentCaption;
    private Label lblSpentValue;
    private Label lblBudgetCaption;
    private Label lblBudgetValue;
    private Label lblRemainingCaption;
    private Label lblRemainingValue;
    private Label lblChartTitle;
    private Panel panelChart;
    private Label lblRecentTitle;
    private DataGridView dgvRecent;
    private DataGridViewTextBoxColumn colRecentTitle;
    private DataGridViewTextBoxColumn colRecentCategory;
    private DataGridViewTextBoxColumn colRecentAmount;
    private DataGridViewTextBoxColumn colRecentDate;
    private DataGridViewTextBoxColumn colRecentTags;
    private TabPage tabExpenses;
    private Label lblExpenseTitle;
    private TextBox txtExpenseTitle;
    private Label lblExpenseAmount;
    private TextBox txtExpenseAmount;
    private Label lblExpenseDate;
    private DateTimePicker dtpExpenseDate;
    private Label lblExpenseCategory;
    private ComboBox cboExpenseCategory;
    private Label lblExpenseTags;
    private CheckedListBox clbTags;
    private Button btnSaveExpense;
    private Button btnUpdateExpense;
    private Button btnDeleteExpense;
    private Label lblNewTag;
    private TextBox txtNewTag;
    private Button btnAddTag;
    private Label lblFilterTag;
    private CheckedListBox clbFilterTags;
    private Button btnClearFilter;
    private DataGridView dgvExpenses;
    private DataGridViewTextBoxColumn colExpenseTitle;
    private DataGridViewTextBoxColumn colExpenseCategory;
    private DataGridViewTextBoxColumn colExpenseAmount;
    private DataGridViewTextBoxColumn colExpenseDate;
    private DataGridViewTextBoxColumn colExpenseTags;
    private Label lblExpenseHint;
    private TabPage tabCategories;
    private Label lblCategoryName;
    private TextBox txtCategoryName;
    private Button btnAddCategory;
    private Button btnUpdateCategory;
    private Button btnDeleteCategory;
    private DataGridView dgvCategories;
    private DataGridViewTextBoxColumn colCategoryName;
    private TabPage tabBudgets;
    private Label lblBudgetCategory;
    private ComboBox cboBudgetCategory;
    private Label lblBudgetMonth;
    private ComboBox cboBudgetMonth;
    private Label lblBudgetYear;
    private NumericUpDown numBudgetYear;
    private Label lblBudgetLimit;
    private TextBox txtBudgetLimit;
    private Button btnSaveBudget;
    private Button btnDeleteBudget;
    private DataGridView dgvBudgets;
    private DataGridViewTextBoxColumn colBudgetCategory;
    private DataGridViewTextBoxColumn colBudgetMonth;
    private DataGridViewTextBoxColumn colBudgetYear;
    private DataGridViewTextBoxColumn colBudgetLimit;
    private DataGridViewTextBoxColumn colBudgetSpent;
    private DataGridViewTextBoxColumn colBudgetRemaining;
    private Label lblBudgetHint;
    private TabPage tabProfile;
    private Label lblProfileHeading;
    private Label lblProfileFullName;
    private TextBox txtProfileFullName;
    private Label lblProfileUsername;
    private TextBox txtProfileUsername;
    private Label lblProfilePhone;
    private TextBox txtProfilePhone;
    private Label lblProfileCurrency;
    private ComboBox cboProfileCurrency;
    private Button btnSaveProfile;
    private Button btnLogout;
    private PictureBox picProfile;
    private Button btnBrowsePhoto;
    private Label lblProfileHint;
    private Label lblMemberSince;
}
