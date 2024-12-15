using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AirplaneTicketManagement
{
    public partial class Login : Form
    {
        public static Login OriginalForm;
        public string startupPath;
        private string username = "";
        private string password = "";
        private List<Flight> flights = new List<Flight>();
        private List<Customer> customers = new List<Customer>();
        private List<User> users = new List<User>();
        private User currentUser;
        public bool ResetLogin;

        public Login()
        {
            InitializeComponent();

            OriginalForm = this;
            startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            User testUser = new User(" ", " ", "testID");
            users.Add(testUser);

            txtUsername.Focus();
        }

        public void clearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        public bool isValidUsername(string username)
        {
            User duplicate = users.Find(x => (x.getUsername() == username));
            if (duplicate == null)
            {
                return true;
            }
            else return false;
        }

        public void addUser(Customer c, string password)
        {
            customers.Add(c);
            User u = new User(c.getUsername(), password, c.getUserId());
            users.Add(u);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblLoginFailed.Text = "Please enter both Username and Password.";
                txtUsername.Focus();
                return;
            }

            currentUser = users.Find(x => (x.getUsername() == txtUsername.Text) && (x.getPassword() == txtPassword.Text));

            if (currentUser != null)
            {
                lblLoginFailed.ForeColor = Color.Blue;
                lblLoginFailed.Text = "Login Success";

                await Task.Delay(1000);

                // Change to another form
                Booking boo = new Booking();
                boo.Show();
                Hide();
            }
            else
            {
                lblLoginFailed.ForeColor = Color.Red;
                lblLoginFailed.Text = "Login Failed! Invalid Username or Password.";
                txtPassword.Clear();
                txtPassword.Focus();
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
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
