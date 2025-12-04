namespace GSB_C_.Forms
{
    partial class FormModifyAdmin
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridViewUser = new DataGridView();
            dataGridViewPatient = new DataGridView();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxpasswordUser = new TextBox();
            textBoxemailUser = new TextBox();
            textBoxfirstnameUser = new TextBox();
            textBoxnameUser = new TextBox();
            comboBoxGender = new ComboBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            textBoxfirstnamePatient = new TextBox();
            textBoxnamePatient = new TextBox();
            textBoxagePatient = new TextBox();
            label7 = new Label();
            buttonModify = new Button();
            buttonDelete = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatient).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewUser
            // 
            dataGridViewUser.AllowUserToAddRows = false;
            dataGridViewUser.AllowUserToDeleteRows = false;
            dataGridViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUser.BackgroundColor = Color.FromArgb(245, 245, 245);
            dataGridViewUser.BorderStyle = BorderStyle.None;
            dataGridViewUser.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 229, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewUser.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewUser.EnableHeadersVisualStyles = false;
            dataGridViewUser.Location = new Point(12, 12);
            dataGridViewUser.MultiSelect = false;
            dataGridViewUser.Name = "dataGridViewUser";
            dataGridViewUser.ReadOnly = true;
            dataGridViewUser.RowHeadersVisible = false;
            dataGridViewUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUser.Size = new Size(370, 200);
            dataGridViewUser.TabIndex = 0;
            dataGridViewUser.SelectionChanged += dataGridViewUser_SelectionChanged;
            // 
            // dataGridViewPatient
            // 
            dataGridViewPatient.AllowUserToAddRows = false;
            dataGridViewPatient.AllowUserToDeleteRows = false;
            dataGridViewPatient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPatient.BackgroundColor = Color.FromArgb(245, 245, 245);
            dataGridViewPatient.BorderStyle = BorderStyle.None;
            dataGridViewPatient.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(40, 167, 69);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewPatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(212, 237, 218);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewPatient.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewPatient.EnableHeadersVisualStyles = false;
            dataGridViewPatient.Location = new Point(418, 12);
            dataGridViewPatient.MultiSelect = false;
            dataGridViewPatient.Name = "dataGridViewPatient";
            dataGridViewPatient.ReadOnly = true;
            dataGridViewPatient.RowHeadersVisible = false;
            dataGridViewPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPatient.Size = new Size(370, 200);
            dataGridViewPatient.TabIndex = 2;
            dataGridViewPatient.SelectionChanged += dataGridViewPatient_SelectionChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(0, 123, 255);
            label6.Location = new Point(12, 11);
            label6.Name = "label6";
            label6.Size = new Size(130, 25);
            label6.TabIndex = 40;
            label6.Text = "USER DETAILS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(190, 50);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 38;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(12, 110);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 37;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(190, 110);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 36;
            label2.Text = "First Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 35;
            label1.Text = "Last Name";
            // 
            // textBoxpasswordUser
            // 
            textBoxpasswordUser.Font = new Font("Segoe UI", 9F);
            textBoxpasswordUser.Location = new Point(190, 70);
            textBoxpasswordUser.Margin = new Padding(3, 2, 3, 2);
            textBoxpasswordUser.Name = "textBoxpasswordUser";
            textBoxpasswordUser.PasswordChar = '●';
            textBoxpasswordUser.Size = new Size(160, 23);
            textBoxpasswordUser.TabIndex = 34;
            // 
            // textBoxemailUser
            // 
            textBoxemailUser.Font = new Font("Segoe UI", 9F);
            textBoxemailUser.Location = new Point(12, 130);
            textBoxemailUser.Margin = new Padding(3, 2, 3, 2);
            textBoxemailUser.Name = "textBoxemailUser";
            textBoxemailUser.Size = new Size(160, 23);
            textBoxemailUser.TabIndex = 33;
            // 
            // textBoxfirstnameUser
            // 
            textBoxfirstnameUser.Font = new Font("Segoe UI", 9F);
            textBoxfirstnameUser.Location = new Point(190, 130);
            textBoxfirstnameUser.Margin = new Padding(3, 2, 3, 2);
            textBoxfirstnameUser.Name = "textBoxfirstnameUser";
            textBoxfirstnameUser.Size = new Size(160, 23);
            textBoxfirstnameUser.TabIndex = 32;
            // 
            // textBoxnameUser
            // 
            textBoxnameUser.Font = new Font("Segoe UI", 9F);
            textBoxnameUser.Location = new Point(12, 70);
            textBoxnameUser.Margin = new Padding(3, 2, 3, 2);
            textBoxnameUser.Name = "textBoxnameUser";
            textBoxnameUser.Size = new Size(160, 23);
            textBoxnameUser.TabIndex = 31;
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Font = new Font("Segoe UI", 9F);
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Femme", "Homme" });
            comboBoxGender.Location = new Point(191, 130);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(160, 23);
            comboBoxGender.TabIndex = 50;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(191, 110);
            label12.Name = "label12";
            label12.Size = new Size(45, 15);
            label12.TabIndex = 49;
            label12.Text = "Gender";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(12, 110);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 48;
            label11.Text = "Age";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.Location = new Point(191, 50);
            label10.Name = "label10";
            label10.Size = new Size(62, 15);
            label10.TabIndex = 47;
            label10.Text = "First Name";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F);
            label9.Location = new Point(12, 50);
            label9.Name = "label9";
            label9.Size = new Size(61, 15);
            label9.TabIndex = 46;
            label9.Text = "Last Name";
            // 
            // textBoxfirstnamePatient
            // 
            textBoxfirstnamePatient.Font = new Font("Segoe UI", 9F);
            textBoxfirstnamePatient.Location = new Point(191, 70);
            textBoxfirstnamePatient.Margin = new Padding(3, 2, 3, 2);
            textBoxfirstnamePatient.Name = "textBoxfirstnamePatient";
            textBoxfirstnamePatient.Size = new Size(160, 23);
            textBoxfirstnamePatient.TabIndex = 45;
            // 
            // textBoxnamePatient
            // 
            textBoxnamePatient.Font = new Font("Segoe UI", 9F);
            textBoxnamePatient.Location = new Point(12, 70);
            textBoxnamePatient.Margin = new Padding(3, 2, 3, 2);
            textBoxnamePatient.Name = "textBoxnamePatient";
            textBoxnamePatient.Size = new Size(160, 23);
            textBoxnamePatient.TabIndex = 44;
            // 
            // textBoxagePatient
            // 
            textBoxagePatient.Font = new Font("Segoe UI", 9F);
            textBoxagePatient.Location = new Point(12, 130);
            textBoxagePatient.Margin = new Padding(3, 2, 3, 2);
            textBoxagePatient.Name = "textBoxagePatient";
            textBoxagePatient.Size = new Size(160, 23);
            textBoxagePatient.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(40, 167, 69);
            label7.Location = new Point(12, 11);
            label7.Name = "label7";
            label7.Size = new Size(155, 25);
            label7.TabIndex = 42;
            label7.Text = "PATIENT DETAILS";
            // 
            // buttonModify
            // 
            buttonModify.BackColor = Color.FromArgb(0, 123, 255);
            buttonModify.FlatAppearance.BorderSize = 0;
            buttonModify.FlatStyle = FlatStyle.Flat;
            buttonModify.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonModify.ForeColor = Color.White;
            buttonModify.Location = new Point(12, 456);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(370, 40);
            buttonModify.TabIndex = 51;
            buttonModify.Text = "Modify";
            buttonModify.UseVisualStyleBackColor = false;
            buttonModify.Click += buttonModify_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(220, 53, 69);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(418, 456);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(370, 40);
            buttonDelete.TabIndex = 52;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBoxnameUser);
            panel1.Controls.Add(textBoxfirstnameUser);
            panel1.Controls.Add(textBoxemailUser);
            panel1.Controls.Add(textBoxpasswordUser);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 232);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 197);
            panel1.TabIndex = 53;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBoxagePatient);
            panel2.Controls.Add(textBoxnamePatient);
            panel2.Controls.Add(comboBoxGender);
            panel2.Controls.Add(textBoxfirstnamePatient);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label9);
            panel1.Controls.Add(label6);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Location = new Point(418, 232);
            panel2.Name = "panel2";
            panel2.Size = new Size(370, 197);
            panel2.TabIndex = 54;
            // 
            // FormModifyAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(800, 522);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(buttonDelete);
            Controls.Add(buttonModify);
            Controls.Add(dataGridViewPatient);
            Controls.Add(dataGridViewUser);
            Font = new Font("Segoe UI", 9F);
            Name = "FormModifyAdmin";
            Text = "Admin Management";
            Load += FormModifyAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPatient).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewUser;
        private DataGridView dataGridViewPatient;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxpasswordUser;
        private TextBox textBoxemailUser;
        private TextBox textBoxfirstnameUser;
        private TextBox textBoxnameUser;
        private ComboBox comboBoxGender;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox textBoxfirstnamePatient;
        private TextBox textBoxnamePatient;
        private TextBox textBoxagePatient;
        private Label label7;
        private Button buttonModify;
        private Button buttonDelete;
        private Panel panel1;
        private Panel panel2;
    }
}