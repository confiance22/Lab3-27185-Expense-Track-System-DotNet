namespace ExpenseTrackSystem;

public partial class LoginForm : Form
{
    private readonly UserController userController = new UserController();
    private readonly ProfileController profileController = new ProfileController();

    public LoginForm()
    {
        InitializeComponent();
        btnLogin.Click += BtnLogin_Click;
        btnRegister.Click += BtnRegister_Click;
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        if (username == "" || password == "")
        {
            MessageBox.Show("Enter your username and password.", "Login",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            User? user = userController.Login(username, password);
            if (user == null)
            {
                MessageBox.Show("Wrong username or password.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            UserProfile? profile = profileController.GetByUserId(user.UserId);
            if (profile == null)
            {
                MessageBox.Show("This account has no profile. Please register again.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Session.CurrentUser = user;
            Session.CurrentProfile = profile;

            Hide();
            using MainForm main = new MainForm();
            main.ShowDialog();

            if (main.LoggedOut)
            {
                Session.CurrentUser = null;
                Session.CurrentProfile = null;
                txtPassword.Clear();
                txtUsername.Focus();
                Show();
            }
            else
            {
                Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not log in.\n\n" + ex.Message +
                "\n\nCheck that XAMPP MySQL is running and the database was imported.",
                "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnRegister_Click(object? sender, EventArgs e)
    {
        using RegisterForm registerForm = new RegisterForm();
        if (registerForm.ShowDialog(this) == DialogResult.OK)
        {
            txtUsername.Text = registerForm.NewUsername;
            txtPassword.Clear();
            txtPassword.Focus();
        }
    }
}
