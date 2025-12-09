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
            SuspendLayout();
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Font = new Font("Segoe UI", 12F);
            textBoxLoginPassword.Location = new Point(40, 230);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PasswordChar = '●';
            textBoxLoginPassword.Size = new Size(260, 34);
            textBoxLoginPassword.TabIndex = 1;
            // 
            // textBoxLoginEmail
            // 
            textBoxLoginEmail.Font = new Font("Segoe UI", 12F);
            textBoxLoginEmail.Location = new Point(40, 160);
            textBoxLoginEmail.Name = "textBoxLoginEmail";
            textBoxLoginEmail.Size = new Size(260, 34);
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
            label1.Size = new Size(188, 23);
            label1.TabIndex = 4;
            label1.Text = "Merci de vous identifier";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelEmail.Location = new Point(40, 140);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(54, 23);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Email";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelPassword.Location = new Point(40, 210);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(85, 23);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "Password";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelTitle.Location = new Point(35, 40);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(231, 54);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "Bienvenue ";
            // 
            // Form1
            // 
            BackColor = Color.White;
            ClientSize = new Size(341, 474);
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
    }
}
