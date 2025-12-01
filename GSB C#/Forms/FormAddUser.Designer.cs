namespace GSB_C_.Forms
{
    partial class FormAddUser
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
            textBoxnameUser = new TextBox();
            textBoxfirstnameUser = new TextBox();
            textBoxemailUser = new TextBox();
            textBoxpasswordUser = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBoxagePatient = new TextBox();
            textBoxnamePatient = new TextBox();
            textBoxgenderPatient = new TextBox();
            textBoxfirstnamePatient = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            buttonaddUser = new Button();
            buttonaddPatient = new Button();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            comboBoxroleUser = new ComboBox();
            SuspendLayout();
            // 
            // textBoxnameUser
            // 
            textBoxnameUser.Location = new Point(31, 85);
            textBoxnameUser.Margin = new Padding(3, 2, 3, 2);
            textBoxnameUser.Name = "textBoxnameUser";
            textBoxnameUser.Size = new Size(110, 23);
            textBoxnameUser.TabIndex = 0;
            // 
            // textBoxfirstnameUser
            // 
            textBoxfirstnameUser.Location = new Point(31, 132);
            textBoxfirstnameUser.Margin = new Padding(3, 2, 3, 2);
            textBoxfirstnameUser.Name = "textBoxfirstnameUser";
            textBoxfirstnameUser.Size = new Size(110, 23);
            textBoxfirstnameUser.TabIndex = 1;
            // 
            // textBoxemailUser
            // 
            textBoxemailUser.Location = new Point(31, 184);
            textBoxemailUser.Margin = new Padding(3, 2, 3, 2);
            textBoxemailUser.Name = "textBoxemailUser";
            textBoxemailUser.Size = new Size(110, 23);
            textBoxemailUser.TabIndex = 2;
            // 
            // textBoxpasswordUser
            // 
            textBoxpasswordUser.Location = new Point(219, 85);
            textBoxpasswordUser.Margin = new Padding(3, 2, 3, 2);
            textBoxpasswordUser.Name = "textBoxpasswordUser";
            textBoxpasswordUser.Size = new Size(110, 23);
            textBoxpasswordUser.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 60);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 115);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 6;
            label2.Text = "Firstname";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 167);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 7;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(219, 60);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 8;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(219, 115);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 9;
            label5.Text = "Rôle ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Chocolate;
            label6.Location = new Point(137, 38);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 10;
            label6.Text = "USER";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Gold;
            label7.Location = new Point(539, 38);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 11;
            label7.Text = "PATIENT";
            // 
            // textBoxagePatient
            // 
            textBoxagePatient.Location = new Point(586, 100);
            textBoxagePatient.Margin = new Padding(3, 2, 3, 2);
            textBoxagePatient.Name = "textBoxagePatient";
            textBoxagePatient.Size = new Size(104, 23);
            textBoxagePatient.TabIndex = 13;
            // 
            // textBoxnamePatient
            // 
            textBoxnamePatient.Location = new Point(449, 100);
            textBoxnamePatient.Margin = new Padding(3, 2, 3, 2);
            textBoxnamePatient.Name = "textBoxnamePatient";
            textBoxnamePatient.Size = new Size(104, 23);
            textBoxnamePatient.TabIndex = 14;
            // 
            // textBoxgenderPatient
            // 
            textBoxgenderPatient.Location = new Point(586, 154);
            textBoxgenderPatient.Margin = new Padding(3, 2, 3, 2);
            textBoxgenderPatient.Name = "textBoxgenderPatient";
            textBoxgenderPatient.Size = new Size(104, 23);
            textBoxgenderPatient.TabIndex = 15;
            // 
            // textBoxfirstnamePatient
            // 
            textBoxfirstnamePatient.Location = new Point(449, 154);
            textBoxfirstnamePatient.Margin = new Padding(3, 2, 3, 2);
            textBoxfirstnamePatient.Name = "textBoxfirstnamePatient";
            textBoxfirstnamePatient.Size = new Size(104, 23);
            textBoxfirstnamePatient.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(449, 70);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 19;
            label9.Text = "Name";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(449, 135);
            label10.Name = "label10";
            label10.Size = new Size(59, 15);
            label10.TabIndex = 20;
            label10.Text = "Firstname";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(595, 70);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 21;
            label11.Text = "Age";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(586, 132);
            label12.Name = "label12";
            label12.Size = new Size(45, 15);
            label12.TabIndex = 22;
            label12.Text = "Gender";
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(586, 177);
            label13.Name = "label13";
            label13.Size = new Size(0, 15);
            label13.TabIndex = 23;
            // 
            // buttonaddUser
            // 
            buttonaddUser.BackColor = Color.Chocolate;
            buttonaddUser.Location = new Point(137, 260);
            buttonaddUser.Margin = new Padding(3, 2, 3, 2);
            buttonaddUser.Name = "buttonaddUser";
            buttonaddUser.Size = new Size(108, 43);
            buttonaddUser.TabIndex = 24;
            buttonaddUser.Text = " Add";
            buttonaddUser.UseVisualStyleBackColor = false;
            buttonaddUser.Click += button1_Click;
            // 
            // buttonaddPatient
            // 
            buttonaddPatient.BackColor = Color.Gold;
            buttonaddPatient.Location = new Point(528, 260);
            buttonaddPatient.Margin = new Padding(3, 2, 3, 2);
            buttonaddPatient.Name = "buttonaddPatient";
            buttonaddPatient.Size = new Size(99, 43);
            buttonaddPatient.TabIndex = 25;
            buttonaddPatient.Text = "Add";
            buttonaddPatient.UseVisualStyleBackColor = false;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // comboBoxroleUser
            // 
            comboBoxroleUser.FormattingEnabled = true;
            comboBoxroleUser.Items.AddRange(new object[] { "Utilisateur", "Administrateur" });
            comboBoxroleUser.Location = new Point(220, 132);
            comboBoxroleUser.Name = "comboBoxroleUser";
            comboBoxroleUser.Size = new Size(105, 23);
            comboBoxroleUser.TabIndex = 28;
            comboBoxroleUser.SelectedIndexChanged += comboBoxroleUser_SelectedIndexChanged;
            // 
            // FormAddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(comboBoxroleUser);
            Controls.Add(buttonaddPatient);
            Controls.Add(buttonaddUser);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(textBoxfirstnamePatient);
            Controls.Add(textBoxgenderPatient);
            Controls.Add(textBoxnamePatient);
            Controls.Add(textBoxagePatient);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxpasswordUser);
            Controls.Add(textBoxemailUser);
            Controls.Add(textBoxfirstnameUser);
            Controls.Add(textBoxnameUser);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormAddUser";
            Load += FormAddUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxnameUser;
        private TextBox textBoxfirstnameUser;
        private TextBox textBoxemailUser;
        private TextBox textBoxpasswordUser;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxagePatient;
        private TextBox textBoxnamePatient;
        private TextBox textBoxgenderPatient;
        private TextBox textBoxfirstnamePatient;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button buttonaddUser;
        private Button buttonaddPatient;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private ComboBox comboBoxroleUser;
    }
}