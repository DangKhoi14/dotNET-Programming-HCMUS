namespace AirplaneTicketManagement
{
    partial class Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            pictureBox1 = new PictureBox();
            lblRegistration = new Label();
            label1 = new Label();
            panel1 = new Panel();
            txtUsername = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            txtPassword = new TextBox();
            label3 = new Label();
            panel3 = new Panel();
            txtConfirmPassword = new TextBox();
            label4 = new Label();
            panel4 = new Panel();
            dtpBirthday = new DateTimePicker();
            label5 = new Label();
            panel5 = new Panel();
            txtPassportNbr = new TextBox();
            label6 = new Label();
            panel6 = new Panel();
            txtNationality = new TextBox();
            picAvatar = new PictureBox();
            btnBrowse = new Button();
            lblRemoveImg = new Label();
            lblRegisterFailed = new Label();
            btnRegister = new Button();
            btnLogin = new Button();
            label7 = new Label();
            btnExit = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(194, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(93, 89);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblRegistration
            // 
            lblRegistration.AutoSize = true;
            lblRegistration.Font = new Font("Bauhaus 93", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistration.ForeColor = Color.FromArgb(0, 117, 214);
            lblRegistration.Location = new Point(155, 198);
            lblRegistration.Name = "lblRegistration";
            lblRegistration.Size = new Size(171, 30);
            lblRegistration.TabIndex = 1;
            lblRegistration.Text = "Registration";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(11, 242);
            label1.Name = "label1";
            label1.Size = new Size(82, 16);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 117, 214);
            panel1.Location = new Point(16, 272);
            panel1.Name = "panel1";
            panel1.Size = new Size(455, 1);
            panel1.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(99, 240);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(372, 23);
            txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(11, 290);
            label2.Name = "label2";
            label2.Size = new Size(79, 16);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 117, 214);
            panel2.Location = new Point(16, 320);
            panel2.Name = "panel2";
            panel2.Size = new Size(455, 1);
            panel2.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(152, 288);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(319, 23);
            txtPassword.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.FromArgb(0, 117, 214);
            label3.Location = new Point(11, 338);
            label3.Name = "label3";
            label3.Size = new Size(135, 16);
            label3.TabIndex = 2;
            label3.Text = "Confirm Password:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 117, 214);
            panel3.Location = new Point(16, 368);
            panel3.Name = "panel3";
            panel3.Size = new Size(455, 1);
            panel3.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(152, 336);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(319, 23);
            txtConfirmPassword.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.ForeColor = Color.FromArgb(0, 117, 214);
            label4.Location = new Point(11, 386);
            label4.Name = "label4";
            label4.Size = new Size(68, 16);
            label4.TabIndex = 2;
            label4.Text = "Birthday:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 117, 214);
            panel4.Location = new Point(16, 416);
            panel4.Name = "panel4";
            panel4.Size = new Size(455, 1);
            panel4.TabIndex = 3;
            // 
            // dtpBirthday
            // 
            dtpBirthday.Location = new Point(99, 381);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(372, 23);
            dtpBirthday.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.ForeColor = Color.FromArgb(0, 117, 214);
            label5.Location = new Point(11, 434);
            label5.Name = "label5";
            label5.Size = new Size(131, 16);
            label5.TabIndex = 2;
            label5.Text = "Passport Number:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(0, 117, 214);
            panel5.Location = new Point(16, 464);
            panel5.Name = "panel5";
            panel5.Size = new Size(455, 1);
            panel5.TabIndex = 3;
            // 
            // txtPassportNbr
            // 
            txtPassportNbr.Location = new Point(152, 432);
            txtPassportNbr.Name = "txtPassportNbr";
            txtPassportNbr.Size = new Size(319, 23);
            txtPassportNbr.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label6.ForeColor = Color.FromArgb(0, 117, 214);
            label6.Location = new Point(11, 482);
            label6.Name = "label6";
            label6.Size = new Size(85, 16);
            label6.TabIndex = 2;
            label6.Text = "Nationality:";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(0, 117, 214);
            panel6.Location = new Point(16, 512);
            panel6.Name = "panel6";
            panel6.Size = new Size(455, 1);
            panel6.TabIndex = 3;
            // 
            // txtNationality
            // 
            txtNationality.Location = new Point(102, 480);
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(369, 23);
            txtNationality.TabIndex = 4;
            // 
            // picAvatar
            // 
            picAvatar.Image = (Image)resources.GetObject("picAvatar.Image");
            picAvatar.Location = new Point(11, 528);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(103, 101);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 6;
            picAvatar.TabStop = false;
            // 
            // btnBrowse
            // 
            btnBrowse.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnBrowse.Location = new Point(21, 639);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 7;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // lblRemoveImg
            // 
            lblRemoveImg.AutoSize = true;
            lblRemoveImg.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblRemoveImg.ForeColor = Color.Black;
            lblRemoveImg.Location = new Point(31, 670);
            lblRemoveImg.Name = "lblRemoveImg";
            lblRemoveImg.Size = new Size(59, 16);
            lblRemoveImg.TabIndex = 8;
            lblRemoveImg.Text = "Remove";
            lblRemoveImg.Click += lblRemoveImg_Click;
            // 
            // lblRegisterFailed
            // 
            lblRegisterFailed.AutoSize = true;
            lblRegisterFailed.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblRegisterFailed.ForeColor = Color.Red;
            lblRegisterFailed.Location = new Point(136, 533);
            lblRegisterFailed.Name = "lblRegisterFailed";
            lblRegisterFailed.Size = new Size(0, 16);
            lblRegisterFailed.TabIndex = 9;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 117, 214);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(136, 599);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(335, 30);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 117, 214);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(127, 137);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(236, 30);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "LOG IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label7.Location = new Point(226, 178);
            label7.Name = "label7";
            label7.Size = new Size(26, 17);
            label7.TabIndex = 12;
            label7.Text = "OR";
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.FromArgb(0, 117, 214);
            btnExit.Location = new Point(284, 650);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(32, 16);
            btnExit.TabIndex = 13;
            btnExit.Text = "Exit";
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 700);
            Controls.Add(btnExit);
            Controls.Add(label7);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(lblRegisterFailed);
            Controls.Add(lblRemoveImg);
            Controls.Add(btnBrowse);
            Controls.Add(picAvatar);
            Controls.Add(dtpBirthday);
            Controls.Add(panel4);
            Controls.Add(txtConfirmPassword);
            Controls.Add(panel3);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(txtNationality);
            Controls.Add(txtPassportNbr);
            Controls.Add(panel6);
            Controls.Add(txtUsername);
            Controls.Add(panel5);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(lblRegistration);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            Load += Registration_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblRegistration;
        private Label label1;
        private Panel panel1;
        private TextBox txtUsername;
        private Label label2;
        private Panel panel2;
        private TextBox txtPassword;
        private Label label3;
        private Panel panel3;
        private TextBox txtConfirmPassword;
        private Label label4;
        private Panel panel4;
        private DateTimePicker dtpBirthday;
        private Label label5;
        private Panel panel5;
        private TextBox txtPassportNbr;
        private Label label6;
        private Panel panel6;
        private TextBox txtNationality;
        private PictureBox picAvatar;
        private Button btnBrowse;
        private Label lblRemoveImg;
        private Label lblRegisterFailed;
        private Button btnRegister;
        private Button btnLogin;
        private Label label7;
        private Label btnExit;
    }
}