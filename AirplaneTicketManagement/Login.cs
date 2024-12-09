namespace AirplaneTicketManagement
{
    public partial class Login : Form
    {
        private Dictionary<string, string> account = new Dictionary<string, string>();
        private String userName = "";
        private String password = "";
        private List<User> users = new List<User>();


        public Login()
        {
            InitializeComponent();

            account.Add("test", "test");
            account.Add("username", "password");
            account.Add("", "");
        }

        public void clearFields()
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        public void addtoDictionary(string key, string value)
        {
            account.Add(key, value);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            userName = txtUserName.Text;
            password = txtPassword.Text;

            if (!account.ContainsKey(userName))
            {
                lblLoginFailed.Text = "Your Username is not exist";
            }
            else if (account.ContainsKey(userName) && account[userName] == password)
            {
                
            }
            else
            {
                lblLoginFailed.Text = "Login Failed !";
                txtPassword.Clear();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration(this);
            reg.Show();
            Hide();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
