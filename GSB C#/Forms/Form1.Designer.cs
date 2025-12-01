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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            textBoxLoginPassword = new TextBox();
            textBoxLoginEmail = new TextBox();
            pictureBox1 = new PictureBox();
            buttonCreationCompte = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(130, 357);
            button1.Name = "button1";
            button1.Size = new Size(88, 43);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Location = new Point(84, 324);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PlaceholderText = "Password";
            textBoxLoginPassword.Size = new Size(186, 27);
            textBoxLoginPassword.TabIndex = 1;
            textBoxLoginPassword.UseSystemPasswordChar = true;
       
            // 
            // textBoxLoginEmail
            // 
            textBoxLoginEmail.Location = new Point(84, 121);
            textBoxLoginEmail.Name = "textBoxLoginEmail";
            textBoxLoginEmail.PlaceholderText = "Email";
            textBoxLoginEmail.Size = new Size(186, 27);
            textBoxLoginEmail.TabIndex = 2;
            
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(341, 474);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
          
          
            // 
            // buttonCreationCompte
            // 
            buttonCreationCompte.Location = new Point(107, 406);
            buttonCreationCompte.Name = "buttonCreationCompte";
            buttonCreationCompte.Size = new Size(139, 44);
            buttonCreationCompte.TabIndex = 4;
            buttonCreationCompte.Text = "Créer un compte";
            buttonCreationCompte.UseVisualStyleBackColor = true;
            buttonCreationCompte.Click += buttonCreationCompte_Click;
            // 
            // Form1
            // 
            BackColor = Color.Azure;
            ClientSize = new Size(341, 474);
            Controls.Add(buttonCreationCompte);
            Controls.Add(textBoxLoginEmail);
            Controls.Add(textBoxLoginPassword);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBoxLoginPassword;
        protected internal TextBox textBoxLoginEmail;
        private PictureBox pictureBox1;
        private Button buttonCreationCompte;
    }
}
