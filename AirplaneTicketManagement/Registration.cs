﻿using System;
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
        string startUpPath;
        string avatarPath;
        Login LoginForm = new Login();

        public Registration(Login LoginForm)
        {
            InitializeComponent();

            this.LoginForm = LoginForm;
            this.startUpPath = this.LoginForm.startupPath;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            dtpBirthday.Value = new DateTime(2000, 1, 1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm.Show();
            LoginForm.clearFields();
            Hide();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = startUpPath;
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    avatarPath = openFileDialog.FileName;
                    picAvatar.Image = Image.FromFile(avatarPath);
                }
            }
        }

        private void lblRemoveImg_Click(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Registration));
            picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate username
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                lblRegisterFailed.ForeColor = Color.Red;
                lblRegisterFailed.Text = "Username cannot be blank.";
                return;
            }

            // Validate passwords
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                lblRegisterFailed.ForeColor = Color.Red;
                lblRegisterFailed.Text = "Password cannot be blank.";
                return;
            }

            if (!LoginForm.isValidUsername(txtUsername.Text))
            {
                lblRegisterFailed.ForeColor = Color.Red;
                lblRegisterFailed.Text = "Username already exists";
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblRegisterFailed.ForeColor = Color.Red;
                lblRegisterFailed.Text = "Passwords do not match.";
                return;
            }

            // Validate other fields
            if (string.IsNullOrEmpty(txtPassportNbr.Text))
            {
                lblRegisterFailed.ForeColor = Color.Red;
                lblRegisterFailed.Text = "Passport number cannot be blank.";
                return;
            }

            if (string.IsNullOrEmpty(txtNationality.Text))
            {
                lblRegisterFailed.ForeColor = Color.Red;
                lblRegisterFailed.Text = "Nationality cannot be blank.";
                return;
            }

            if (picAvatar.Image == null)
            {
                lblRegisterFailed.ForeColor = Color.Red;
                lblRegisterFailed.Text = "Please select an avatar.";
                return;
            }

            Customer newCustomer = new Customer(
                txtUsername.Text.Trim(),
                DateOnly.FromDateTime(dtpBirthday.Value),
                txtPassportNbr.Text.Trim(),
                txtNationality.Text.Trim(),
                picAvatar.Image
            );

            LoginForm.addUser(newCustomer, txtPassword.Text);

            lblRegisterFailed.Text = "Registration successful!";
            lblRegisterFailed.ForeColor = Color.Blue;

            LoginForm.clearFields();

            for (int i = 3; i > 0; i--)
            {
                lblRegisterFailed.Text = $"Redirecting in {i}...";
                await Task.Delay(1000); // Wait 1 second
            }

            LoginForm.Show();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
