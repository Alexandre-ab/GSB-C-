namespace GSB_C_.Forms
{
    partial class FormDetailMedecine
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
            dataGridViewDetailMedicine = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetailMedicine).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDetailMedicine
            // 
            dataGridViewDetailMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetailMedicine.Location = new Point(69, 47);
            dataGridViewDetailMedicine.Name = "dataGridViewDetailMedicine";
            dataGridViewDetailMedicine.RowHeadersWidth = 51;
            dataGridViewDetailMedicine.Size = new Size(686, 326);
            dataGridViewDetailMedicine.TabIndex = 0;
            // 
            // FormDetailMedecine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewDetailMedicine);
            Name = "FormDetailMedecine";
            Text = "DetailMedicine";
            Load += FormDetailMedecine_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetailMedicine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public DataGridView dataGridViewDetailMedicine;
    }
}