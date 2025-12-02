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
            textUserID = new TextBox();
            textQuantity = new TextBox();
            textValidity = new TextBox();
            dataGridView1Prescription = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            comboBoxpatientID = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1Prescription).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(24, 387);
            button1.Name = "button1";
            button1.Size = new Size(117, 52);
            button1.TabIndex = 0;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 60);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 1;
            label1.Text = "PatientID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 121);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 2;
            label2.Text = "UserID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 180);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 3;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 245);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 4;
            label4.Text = "Validity";
            // 
            // textUserID
            // 
            textUserID.Location = new Point(165, 121);
            textUserID.Name = "textUserID";
            textUserID.Size = new Size(134, 27);
            textUserID.TabIndex = 6;
            // 
            // textQuantity
            // 
            textQuantity.Location = new Point(165, 177);
            textQuantity.Name = "textQuantity";
            textQuantity.Size = new Size(134, 27);
            textQuantity.TabIndex = 7;
            // 
            // textValidity
            // 
            textValidity.Location = new Point(165, 239);
            textValidity.Name = "textValidity";
            textValidity.Size = new Size(134, 27);
            textValidity.TabIndex = 8;
            // 
            // dataGridView1Prescription
            // 
            dataGridView1Prescription.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1Prescription.Location = new Point(333, 26);
            dataGridView1Prescription.Name = "dataGridView1Prescription";
            dataGridView1Prescription.RowHeadersWidth = 51;
            dataGridView1Prescription.Size = new Size(443, 307);
            dataGridView1Prescription.TabIndex = 9;
            dataGridView1Prescription.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(224, 387);
            button2.Name = "button2";
            button2.Size = new Size(128, 52);
            button2.TabIndex = 10;
            button2.Text = "Modify";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(427, 387);
            button3.Name = "button3";
            button3.Size = new Size(112, 53);
            button3.TabIndex = 11;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(632, 387);
            button4.Name = "button4";
            button4.Size = new Size(120, 52);
            button4.TabIndex = 12;
            button4.Text = "PDF";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBoxpatientID
            // 
            comboBoxpatientID.FormattingEnabled = true;
            comboBoxpatientID.Location = new Point(154, 52);
            comboBoxpatientID.Name = "comboBoxpatientID";
            comboBoxpatientID.Size = new Size(145, 28);
            comboBoxpatientID.TabIndex = 13;
            // 
            // FormPrescription
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(comboBoxpatientID);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1Prescription);
            Controls.Add(textValidity);
            Controls.Add(textQuantity);
            Controls.Add(textUserID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
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
        private TextBox textUserID;
        private TextBox textQuantity;
        private TextBox textValidity;
        private DataGridView dataGridView1Prescription;
        private Button button2;
        private Button button3;
        private Button button4;
        private ComboBox comboBoxpatientID;
    }
}