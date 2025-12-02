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
            comboBoxGender = new ComboBox();
            buttonaddPatient = new Button();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            textBoxfirstnamePatient = new TextBox();
            textBoxnamePatient = new TextBox();
            textBoxagePatient = new TextBox();
            label7 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxGender
            // 
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Femme", "Homme" });
            comboBoxGender.Location = new Point(239, 203);
            comboBoxGender.Margin = new Padding(3, 4, 3, 4);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(119, 28);
            comboBoxGender.TabIndex = 40;
            // 
            // buttonaddPatient
            // 
            buttonaddPatient.BackColor = Color.Gold;
            buttonaddPatient.Location = new Point(135, 302);
            buttonaddPatient.Name = "buttonaddPatient";
            buttonaddPatient.Size = new Size(113, 57);
            buttonaddPatient.TabIndex = 39;
            buttonaddPatient.Text = "Add";
            buttonaddPatient.UseVisualStyleBackColor = false;
            buttonaddPatient.Click += buttonaddPatient_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(420, 234);
            label13.Name = "label13";
            label13.Size = new Size(0, 20);
            label13.TabIndex = 38;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(239, 174);
            label12.Name = "label12";
            label12.Size = new Size(57, 20);
            label12.TabIndex = 37;
            label12.Text = "Gender";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(250, 91);
            label11.Name = "label11";
            label11.Size = new Size(36, 20);
            label11.TabIndex = 36;
            label11.Text = "Age";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(27, 174);
            label10.Name = "label10";
            label10.Size = new Size(73, 20);
            label10.TabIndex = 35;
            label10.Text = "Firstname";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 91);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 34;
            label9.Text = "Name";
            // 
            // textBoxfirstnamePatient
            // 
            textBoxfirstnamePatient.Location = new Point(27, 203);
            textBoxfirstnamePatient.Name = "textBoxfirstnamePatient";
            textBoxfirstnamePatient.Size = new Size(118, 27);
            textBoxfirstnamePatient.TabIndex = 33;
            // 
            // textBoxnamePatient
            // 
            textBoxnamePatient.Location = new Point(27, 131);
            textBoxnamePatient.Name = "textBoxnamePatient";
            textBoxnamePatient.Size = new Size(118, 27);
            textBoxnamePatient.TabIndex = 32;
            // 
            // textBoxagePatient
            // 
            textBoxagePatient.Location = new Point(250, 131);
            textBoxagePatient.Name = "textBoxagePatient";
            textBoxagePatient.Size = new Size(118, 27);
            textBoxagePatient.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Gold;
            label7.Location = new Point(108, 53);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 30;
            label7.Text = "PATIENT";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(400, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(378, 362);
            dataGridView1.TabIndex = 41;
            // 
            // FormAddpatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(comboBoxGender);
            Controls.Add(buttonaddPatient);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(textBoxfirstnamePatient);
            Controls.Add(textBoxnamePatient);
            Controls.Add(textBoxagePatient);
            Controls.Add(label7);
            Name = "FormAddpatient";
            Text = "FormAddpatient";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxGender;
        private Button buttonaddPatient;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox textBoxfirstnamePatient;
        private TextBox textBoxnamePatient;
        private TextBox textBoxagePatient;
        private Label label7;
        private DataGridView dataGridView1;
    }
}