using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneTicketManagement
{
    public partial class Registration : Form
    {
        Login LoginForm = new Login();

        public Registration(Login LoginForm)
        {
            InitializeComponent();
            this.LoginForm = LoginForm;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            dtpBirthday.Value = new DateTime(2000, 1, 1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm.Show();
            Hide();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }

        private void lblRemoveImg_Click(object sender, EventArgs e)
        {

        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    LoginForm.addtoDictionary(txtName.Text, txtPassword.Text); // Use the passed Login instance
                    lblRegisterFailed.Text = "Registration successful!";
                    lblRegisterFailed.BackColor = Color.Blue;
                    lblRegisterFailed.Text = "Registration successful!";

                    LoginForm.clearFields();

                    await Task.Delay(3000);
                    // Make a count down here then change to another form

                    LoginForm.Show();
                    Hide();
                }
                else
                {
                    lblRegisterFailed.Text = "Password does not match";
                }
            }
            else
            {
                lblRegisterFailed.Text = "Username cannot be blank";
            }
        }
    }
}
