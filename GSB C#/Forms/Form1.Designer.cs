namespace GSB_C_
{

    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxLoginPassword = new TextBox();
            textBoxLoginEmail = new TextBox();
            button1 = new Button();
            label1 = new Label();
            labelEmail = new Label();
            labelPassword = new Label();
            labelTitle = new Label();
            linkLabelCreateAccount = new LinkLabel();
            SuspendLayout();
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Font = new Font("Segoe UI", 12F);
            textBoxLoginPassword.Location = new Point(40, 230);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PasswordChar = '●';
            textBoxLoginPassword.Size = new Size(260, 29);
            textBoxLoginPassword.TabIndex = 1;
            // 
            // textBoxLoginEmail
            // 
            textBoxLoginEmail.Font = new Font("Segoe UI", 12F);
            textBoxLoginEmail.Location = new Point(40, 160);
            textBoxLoginEmail.Name = "textBoxLoginEmail";
            textBoxLoginEmail.Size = new Size(260, 29);
            textBoxLoginEmail.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 123, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(40, 290);
            button1.Name = "button1";
            button1.Size = new Size(260, 45);
            button1.TabIndex = 2;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(40, 90);
            label1.Name = "label1";
            label1.Size = new Size(183, 17);
            label1.TabIndex = 4;
            label1.Text = "Please enter your details below";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEmail.Location = new Point(40, 140);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(40, 17);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Email";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPassword.Location = new Point(40, 210);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(66, 17);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "Password";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelTitle.Location = new Point(35, 40);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(268, 45);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "Welcome Back!";
            // 
            // linkLabelCreateAccount
            // 
            linkLabelCreateAccount.AutoSize = true;
            linkLabelCreateAccount.Font = new Font("Segoe UI", 9F);
            linkLabelCreateAccount.Location = new Point(100, 350);
            linkLabelCreateAccount.Name = "linkLabelCreateAccount";
            linkLabelCreateAccount.Size = new Size(144, 15);
            linkLabelCreateAccount.TabIndex = 3;
            linkLabelCreateAccount.TabStop = true;
            linkLabelCreateAccount.Text = "Don't have an account yet?";
            linkLabelCreateAccount.LinkClicked += linkLabelCreateAccount_LinkClicked;
            // 
            // Form1
            // 
            BackColor = Color.White;
            ClientSize = new Size(341, 474);
            Controls.Add(linkLabelCreateAccount);
            Controls.Add(labelTitle);
            Controls.Add(labelPassword);
            Controls.Add(labelEmail);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBoxLoginEmail);
            Controls.Add(textBoxLoginPassword);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBoxLoginPassword;
        protected internal TextBox textBoxLoginEmail;
        private Label label1;
        private Label labelEmail;
        private Label labelPassword;
        private Label labelTitle;
        private LinkLabel linkLabelCreateAccount;
    }
}
