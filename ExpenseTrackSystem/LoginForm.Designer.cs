namespace ExpenseTrackSystem;

partial class LoginForm
{
    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        btnLogin = new Button();
        btnRegister = new Button();
        lblHint = new Label();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitle.Location = new Point(30, 25);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(176, 37);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "ExpenseTrack";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 10F);
        lblSubtitle.Location = new Point(33, 68);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(265, 19);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Personal Expense & Budget Management";
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Segoe UI", 10F);
        lblUsername.Location = new Point(33, 120);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(72, 19);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "Username";
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(33, 145);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(340, 23);
        txtUsername.TabIndex = 3;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font("Segoe UI", 10F);
        lblPassword.Location = new Point(33, 190);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(67, 19);
        lblPassword.TabIndex = 4;
        lblPassword.Text = "Password";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(33, 215);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(340, 23);
        txtPassword.TabIndex = 5;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(33, 270);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(160, 40);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "Login";
        // 
        // btnRegister
        // 
        btnRegister.Location = new Point(213, 270);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(160, 40);
        btnRegister.TabIndex = 7;
        btnRegister.Text = "Create account";
        // 
        // lblHint
        // 
        lblHint.AutoSize = true;
        lblHint.Font = new Font("Segoe UI", 8.5F);
        lblHint.Location = new Point(33, 335);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(270, 15);
        lblHint.TabIndex = 8;
        lblHint.Text = "Start by creating an account if you are new here.";
        // 
        // LoginForm
        // 
        AcceptButton = btnLogin;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(410, 380);
        Controls.Add(lblHint);
        Controls.Add(btnRegister);
        Controls.Add(btnLogin);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtUsername);
        Controls.Add(lblUsername);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ExpenseTrack - Login";
    }

    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private Button btnLogin;
    private Button btnRegister;
    private Label lblHint;
}
