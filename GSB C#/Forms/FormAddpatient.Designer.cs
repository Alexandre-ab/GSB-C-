namespace GSB_C_.Forms
{
    partial class FormAddpatient
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
            comboBoxGender = new ComboBox();
            buttonaddPatient = new Button();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            textBoxfirstnamePatient = new TextBox();
            textBoxnamePatient = new TextBox();
            textBoxagePatient = new TextBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Font = new Font("Segoe UI", 9.75F);
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Femme", "Homme" });
            comboBoxGender.Location = new Point(25, 200);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(250, 25);
            comboBoxGender.TabIndex = 3;
            // 
            // buttonaddPatient
            // 
            buttonaddPatient.BackColor = Color.FromArgb(40, 167, 69);
            buttonaddPatient.FlatAppearance.BorderSize = 0;
            buttonaddPatient.FlatStyle = FlatStyle.Flat;
            buttonaddPatient.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonaddPatient.ForeColor = Color.White;
            buttonaddPatient.Location = new Point(25, 250);
            buttonaddPatient.Name = "buttonaddPatient";
            buttonaddPatient.Size = new Size(250, 45);
            buttonaddPatient.TabIndex = 4;
            buttonaddPatient.Text = "Add Patient";
            buttonaddPatient.UseVisualStyleBackColor = false;
            buttonaddPatient.Click += buttonaddPatient_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(25, 180);
            label12.Name = "label12";
            label12.Size = new Size(49, 15);
            label12.TabIndex = 37;
            label12.Text = "Gender";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(165, 120);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 36;
            label11.Text = "Age";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(25, 120);
            label10.Name = "label10";
            label10.Size = new Size(67, 15);
            label10.TabIndex = 35;
            label10.Text = "First Name";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(25, 60);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 34;
            label9.Text = "Last Name";
            // 
            // textBoxfirstnamePatient
            // 
            textBoxfirstnamePatient.Font = new Font("Segoe UI", 9.75F);
            textBoxfirstnamePatient.Location = new Point(25, 140);
            textBoxfirstnamePatient.Name = "textBoxfirstnamePatient";
            textBoxfirstnamePatient.Size = new Size(120, 25);
            textBoxfirstnamePatient.TabIndex = 1;
            // 
            // textBoxnamePatient
            // 
            textBoxnamePatient.Font = new Font("Segoe UI", 9.75F);
            textBoxnamePatient.Location = new Point(25, 80);
            textBoxnamePatient.Name = "textBoxnamePatient";
            textBoxnamePatient.Size = new Size(250, 25);
            textBoxnamePatient.TabIndex = 0;
            // 
            // textBoxagePatient
            // 
            textBoxagePatient.Font = new Font("Segoe UI", 9.75F);
            textBoxagePatient.Location = new Point(165, 140);
            textBoxagePatient.Name = "textBoxagePatient";
            textBoxagePatient.Size = new Size(110, 25);
            textBoxagePatient.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(245, 245, 245);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(40, 167, 69);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(212, 237, 218);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(320, 20);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(460, 410);
            dataGridView1.TabIndex = 41;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxnamePatient);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(comboBoxGender);
            panel1.Controls.Add(textBoxagePatient);
            panel1.Controls.Add(buttonaddPatient);
            panel1.Controls.Add(textBoxfirstnamePatient);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 450);
            panel1.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(184, 30);
            label1.TabIndex = 0;
            label1.Text = "Add New Patient";
            // 
            // FormAddpatient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormAddpatient";
            Text = "Add Patient";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxGender;
        private Button buttonaddPatient;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox textBoxfirstnamePatient;
        private TextBox textBoxnamePatient;
        private TextBox textBoxagePatient;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label1;
    }
}