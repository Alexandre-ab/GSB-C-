namespace GSB_C_.Forms
{
    partial class FormPrescription
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textPatientID = new TextBox();
            textUserID = new TextBox();
            textQuantity = new TextBox();
            textValidity = new TextBox();
            dataGridView1Prescription = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1Prescription).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(21, 290);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(102, 39);
            button1.TabIndex = 0;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 45);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 1;
            label1.Text = "PatientID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 91);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "UserID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 135);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 3;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 184);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 4;
            label4.Text = "Validity";
            // 
            // textPatientID
            // 
            textPatientID.Location = new Point(144, 45);
            textPatientID.Margin = new Padding(3, 2, 3, 2);
            textPatientID.Name = "textPatientID";
            textPatientID.Size = new Size(118, 23);
            textPatientID.TabIndex = 5;
            textPatientID.TextChanged += textBox1_TextChanged;
            // 
            // textUserID
            // 
            textUserID.Location = new Point(144, 91);
            textUserID.Margin = new Padding(3, 2, 3, 2);
            textUserID.Name = "textUserID";
            textUserID.Size = new Size(118, 23);
            textUserID.TabIndex = 6;
            // 
            // textQuantity
            // 
            textQuantity.Location = new Point(144, 133);
            textQuantity.Margin = new Padding(3, 2, 3, 2);
            textQuantity.Name = "textQuantity";
            textQuantity.Size = new Size(118, 23);
            textQuantity.TabIndex = 7;
            // 
            // textValidity
            // 
            textValidity.Location = new Point(144, 179);
            textValidity.Margin = new Padding(3, 2, 3, 2);
            textValidity.Name = "textValidity";
            textValidity.Size = new Size(118, 23);
            textValidity.TabIndex = 8;
            // 
            // dataGridView1Prescription
            // 
            dataGridView1Prescription.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1Prescription.Location = new Point(301, 24);
            dataGridView1Prescription.Margin = new Padding(3, 2, 3, 2);
            dataGridView1Prescription.Name = "dataGridView1Prescription";
            dataGridView1Prescription.RowHeadersWidth = 51;
            dataGridView1Prescription.Size = new Size(388, 230);
            dataGridView1Prescription.TabIndex = 9;
            dataGridView1Prescription.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(196, 290);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(112, 39);
            button2.TabIndex = 10;
            button2.Text = "Modify";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(374, 290);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(98, 40);
            button3.TabIndex = 11;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(553, 290);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(105, 39);
            button4.TabIndex = 12;
            button4.Text = "PDF";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FormPrescription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1Prescription);
            Controls.Add(textValidity);
            Controls.Add(textQuantity);
            Controls.Add(textUserID);
            Controls.Add(textPatientID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPrescription";
            Text = "FormPrescription";
            Load += FormPrescription_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1Prescription).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textPatientID;
        private TextBox textUserID;
        private TextBox textQuantity;
        private TextBox textValidity;
        private DataGridView dataGridView1Prescription;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}