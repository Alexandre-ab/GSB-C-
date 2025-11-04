namespace GSB_C_.Forms
{
    partial class FormDoctor
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
            dataGridViewDoctorListListMedecine = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctorListListMedecine).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDoctorListListMedecine
            // 
            dataGridViewDoctorListListMedecine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDoctorListListMedecine.Location = new Point(86, 48);
            dataGridViewDoctorListListMedecine.Name = "dataGridViewDoctorListListMedecine";
            dataGridViewDoctorListListMedecine.RowHeadersWidth = 51;
            dataGridViewDoctorListListMedecine.Size = new Size(606, 280);
            dataGridViewDoctorListListMedecine.TabIndex = 0;
            dataGridViewDoctorListListMedecine.CellContentClick += dataGridViewDoctorListListMedecine_CellContentClick;
            // 
            // FormDoctor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewDoctorListListMedecine);
            Name = "FormDoctor";
            Text = "FormDoctor";
            Load += FormDoctor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctorListListMedecine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewDoctorListListMedecine;
    }
}