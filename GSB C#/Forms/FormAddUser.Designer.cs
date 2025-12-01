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
            textBoxfirstnamePatient = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            buttonaddUser = new Button();
            buttonaddPatient = new Button();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            comboBoxGender = new ComboBox();
            checkBoxadminUser = new CheckBox();
            SuspendLayout();
            // 
            // textBoxnameUser
            // 
            textBoxnameUser.Location = new Point(35, 113);
            textBoxnameUser.Name = "textBoxnameUser";
            textBoxnameUser.Size = new Size(125, 27);
            textBoxnameUser.TabIndex = 0;
            // 
            // textBoxfirstnameUser
            // 
            textBoxfirstnameUser.Location = new Point(35, 176);
            textBoxfirstnameUser.Name = "textBoxfirstnameUser";
            textBoxfirstnameUser.Size = new Size(125, 27);
            textBoxfirstnameUser.TabIndex = 1;
            // 
            // textBoxemailUser
            // 
            textBoxemailUser.Location = new Point(35, 245);
            textBoxemailUser.Name = "textBoxemailUser";
            textBoxemailUser.Size = new Size(125, 27);
            textBoxemailUser.TabIndex = 2;
            // 
            // textBoxpasswordUser
            // 
            textBoxpasswordUser.Location = new Point(250, 113);
            textBoxpasswordUser.Name = "textBoxpasswordUser";
            textBoxpasswordUser.Size = new Size(125, 27);
            textBoxpasswordUser.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 80);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 5;
            label1.Text = "Name";
            
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 153);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 6;
            label2.Text = "Firstname";
            
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 223);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 7;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(250, 80);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 8;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 153);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 9;
            label5.Text = "Rôle ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Chocolate;
            label6.Location = new Point(157, 51);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 10;
            label6.Text = "USER";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Gold;
            label7.Location = new Point(616, 51);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 11;
            label7.Text = "PATIENT";
            // 
            // textBoxagePatient
            // 
            textBoxagePatient.Location = new Point(670, 133);
            textBoxagePatient.Name = "textBoxagePatient";
            textBoxagePatient.Size = new Size(118, 27);
            textBoxagePatient.TabIndex = 13;
            // 
            // textBoxnamePatient
            // 
            textBoxnamePatient.Location = new Point(513, 133);
            textBoxnamePatient.Name = "textBoxnamePatient";
            textBoxnamePatient.Size = new Size(118, 27);
            textBoxnamePatient.TabIndex = 14;
            // 
            // textBoxfirstnamePatient
            // 
            textBoxfirstnamePatient.Location = new Point(513, 205);
            textBoxfirstnamePatient.Name = "textBoxfirstnamePatient";
            textBoxfirstnamePatient.Size = new Size(118, 27);
            textBoxfirstnamePatient.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(513, 93);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 19;
            label9.Text = "Name";
           
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(513, 180);
            label10.Name = "label10";
            label10.Size = new Size(73, 20);
            label10.TabIndex = 20;
            label10.Text = "Firstname";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(680, 93);
            label11.Name = "label11";
            label11.Size = new Size(36, 20);
            label11.TabIndex = 21;
            label11.Text = "Age";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(670, 176);
            label12.Name = "label12";
            label12.Size = new Size(57, 20);
            label12.TabIndex = 22;
            label12.Text = "Gender";
           
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(670, 236);
            label13.Name = "label13";
            label13.Size = new Size(0, 20);
            label13.TabIndex = 23;
            // 
            // buttonaddUser
            // 
            buttonaddUser.BackColor = Color.Chocolate;
            buttonaddUser.Location = new Point(157, 347);
            buttonaddUser.Name = "buttonaddUser";
            buttonaddUser.Size = new Size(123, 57);
            buttonaddUser.TabIndex = 24;
            buttonaddUser.Text = " Add";
            buttonaddUser.UseVisualStyleBackColor = false;
            buttonaddUser.Click += button1_Click;
            // 
            // buttonaddPatient
            // 
            buttonaddPatient.BackColor = Color.Gold;
            buttonaddPatient.Location = new Point(603, 347);
            buttonaddPatient.Name = "buttonaddPatient";
            buttonaddPatient.Size = new Size(113, 57);
            buttonaddPatient.TabIndex = 25;
            buttonaddPatient.Text = "Add";
            buttonaddPatient.UseVisualStyleBackColor = false;
            buttonaddPatient.Click += buttonaddPatient_Click;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // comboBoxGender
            // 
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Femme", "Homme" });
            comboBoxGender.Location = new Point(669, 204);
            comboBoxGender.Margin = new Padding(3, 4, 3, 4);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(119, 28);
            comboBoxGender.TabIndex = 29;
            // 
            // checkBoxadminUser
            // 
            checkBoxadminUser.AutoSize = true;
            checkBoxadminUser.Location = new Point(250, 180);
            checkBoxadminUser.Name = "checkBoxadminUser";
            checkBoxadminUser.Size = new Size(129, 24);
            checkBoxadminUser.TabIndex = 30;
            checkBoxadminUser.Text = "Administrateur";
            checkBoxadminUser.UseVisualStyleBackColor = false;
            // 
            // FormAddUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(checkBoxadminUser);
            Controls.Add(comboBoxGender);
            Controls.Add(buttonaddPatient);
            Controls.Add(buttonaddUser);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(textBoxfirstnamePatient);
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
            Name = "FormAddUser";
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
        private TextBox textBoxfirstnamePatient;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button buttonaddUser;
        private Button buttonaddPatient;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private ComboBox comboBoxGender;
        private CheckBox checkBoxadminUser;
    }
}