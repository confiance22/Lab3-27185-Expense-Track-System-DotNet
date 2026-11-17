namespace ExpenseTrackSystem;

public partial class RegisterForm : Form
{
    private readonly UserController userController = new UserController();

    public string NewUsername { get; private set; } = "";

    public RegisterForm()
    {
        InitializeComponent();
        btnRegister.Click += BtnRegister_Click;
        btnCancel.Click += (_, _) => Close();
    }

    private void BtnRegister_Click(object? sender, EventArgs e)
    {
        string fullName = txtFullName.Text.Trim();
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;
        string confirm = txtConfirm.Text;

        if (fullName == "" || username == "")
        {
            MessageBox.Show("Enter your full name and username.", "Register",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (username.Length < 3)
        {
            MessageBox.Show("Username must have at least 3 characters.", "Register",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (password.Length < 6)
        {
            MessageBox.Show("Password must have at least 6 characters.", "Register",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (password != confirm)
        {
            MessageBox.Show("The two passwords do not match.", "Register",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            userController.Register(fullName, username, password);
            NewUsername = username;
            MessageBox.Show("Account created. You can now log in.", "Register",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Register",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void RegisterForm_Load(object sender, EventArgs e)
    {

    }
}
