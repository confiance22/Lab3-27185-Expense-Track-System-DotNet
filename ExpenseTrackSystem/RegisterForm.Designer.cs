namespace ExpenseTrackSystem;

partial class RegisterForm
{
    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblFullName = new Label();
        txtFullName = new TextBox();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        lblConfirm = new Label();
        txtConfirm = new TextBox();
        btnRegister = new Button();
        btnCancel = new Button();
        lblHint = new Label();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.Location = new Point(30, 22);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(185, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Create account";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Location = new Point(33, 60);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(252, 15);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Fill in the details below to create your account.";
        // 
        // lblFullName
        // 
        lblFullName.AutoSize = true;
        lblFullName.Location = new Point(33, 100);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(59, 15);
        lblFullName.TabIndex = 2;
        lblFullName.Text = "Full name";
        // 
        // txtFullName
        // 
        txtFullName.Location = new Point(33, 123);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(380, 23);
        txtFullName.TabIndex = 3;
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(33, 165);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(60, 15);
        lblUsername.TabIndex = 4;
        lblUsername.Text = "Username";
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(33, 188);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(380, 23);
        txtUsername.TabIndex = 5;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(33, 230);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(57, 15);
        lblPassword.TabIndex = 6;
        lblPassword.Text = "Password";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(33, 253);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(380, 23);
        txtPassword.TabIndex = 7;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // lblConfirm
        // 
        lblConfirm.AutoSize = true;
        lblConfirm.Location = new Point(33, 295);
        lblConfirm.Name = "lblConfirm";
        lblConfirm.Size = new Size(104, 15);
        lblConfirm.TabIndex = 8;
        lblConfirm.Text = "Confirm password";
        // 
        // txtConfirm
        // 
        txtConfirm.Location = new Point(33, 318);
        txtConfirm.Name = "txtConfirm";
        txtConfirm.Size = new Size(380, 23);
        txtConfirm.TabIndex = 9;
        txtConfirm.UseSystemPasswordChar = true;
        // 
        // btnRegister
        // 
        btnRegister.Location = new Point(33, 370);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(180, 40);
        btnRegister.TabIndex = 10;
        btnRegister.Text = "Register";
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(233, 370);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(180, 40);
        btnCancel.TabIndex = 11;
        btnCancel.Text = "Cancel";
        // 
        // lblHint
        // 
        lblHint.AutoSize = true;
        lblHint.Location = new Point(33, 430);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(316, 15);
        lblHint.TabIndex = 12;
        lblHint.Text = "Your password is saved as a salted hash, never as plain text.";
        // 
        // RegisterForm
        // 
        AcceptButton = btnRegister;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(450, 470);
        Controls.Add(lblHint);
        Controls.Add(btnCancel);
        Controls.Add(btnRegister);
        Controls.Add(txtConfirm);
        Controls.Add(lblConfirm);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtUsername);
        Controls.Add(lblUsername);
        Controls.Add(txtFullName);
        Controls.Add(lblFullName);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "RegisterForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "ExpenseTrack - Register";
        Load += RegisterForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private Label lblConfirm;
    private TextBox txtConfirm;
    private Button btnRegister;
    private Button btnCancel;
    private Label lblHint;
}
