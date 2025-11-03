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
            button1 = new Button();
            textBoxLoginPassword = new TextBox();
            textBoxLoginEmail = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(132, 346);
            button1.Name = "button1";
            button1.Size = new Size(112, 56);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Location = new Point(84, 228);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PlaceholderText = "Password";
            textBoxLoginPassword.Size = new Size(186, 27);
            textBoxLoginPassword.TabIndex = 1;
            textBoxLoginPassword.UseSystemPasswordChar = true;
            textBoxLoginPassword.TextChanged += textBoxLoginPassword_TextChanged;
            // 
            // textBoxLoginEmail
            // 
            textBoxLoginEmail.Location = new Point(84, 135);
            textBoxLoginEmail.Name = "textBoxLoginEmail";
            textBoxLoginEmail.PlaceholderText = "Email";
            textBoxLoginEmail.Size = new Size(186, 27);
            textBoxLoginEmail.TabIndex = 2;
            textBoxLoginEmail.TextChanged += textBox2_TextChanged;
            // 
            // Form1
            // 
            ClientSize = new Size(341, 474);
            Controls.Add(textBoxLoginEmail);
            Controls.Add(textBoxLoginPassword);
            Controls.Add(button1);
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBoxLoginPassword;
        protected internal TextBox textBoxLoginEmail;
    }
}
