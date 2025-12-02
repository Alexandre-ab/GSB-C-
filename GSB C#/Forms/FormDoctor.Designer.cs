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
            prescription = new Button();
            buttonPatient = new Button();
            Deconnexion = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctorListListMedecine).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDoctorListListMedecine
            // 
            dataGridViewDoctorListListMedecine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDoctorListListMedecine.Location = new Point(33, 54);
            dataGridViewDoctorListListMedecine.Name = "dataGridViewDoctorListListMedecine";
            dataGridViewDoctorListListMedecine.RowHeadersWidth = 51;
            dataGridViewDoctorListListMedecine.Size = new Size(755, 329);
            dataGridViewDoctorListListMedecine.TabIndex = 0;
            dataGridViewDoctorListListMedecine.CellContentDoubleClick += dataGridViewDoctorListListMedecine_CellContentDoubleClick;
            // 
            // prescription
            // 
            prescription.Location = new Point(12, 402);
            prescription.Name = "prescription";
            prescription.Size = new Size(182, 34);
            prescription.TabIndex = 1;
            prescription.Text = "Prescription ";
            prescription.UseVisualStyleBackColor = true;
            prescription.Click += button1_Click;
            // 
            // buttonPatient
            // 
            buttonPatient.Location = new Point(596, 402);
            buttonPatient.Name = "buttonPatient";
            buttonPatient.Size = new Size(182, 36);
            buttonPatient.TabIndex = 2;
            buttonPatient.Text = "Patient ";
            buttonPatient.UseVisualStyleBackColor = true;
            buttonPatient.Click += buttonPatient_Click;
            // 
            // Deconnexion
            // 
            Deconnexion.BackColor = Color.Crimson;
            Deconnexion.Location = new Point(646, 10);
            Deconnexion.Name = "Deconnexion";
            Deconnexion.Size = new Size(142, 38);
            Deconnexion.TabIndex = 5;
            Deconnexion.Text = "Déconnexion";
            Deconnexion.UseVisualStyleBackColor = false;
            Deconnexion.Click += Deconnexion_Click;
            // 
            // FormDoctor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Deconnexion);
            Controls.Add(buttonPatient);
            Controls.Add(prescription);
            Controls.Add(dataGridViewDoctorListListMedecine);
            Name = "FormDoctor";
            Text = "FormDoctor";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDoctorListListMedecine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewDoctorListListMedecine;
        private Button prescription;
        private Button buttonPatient;
        private Button Deconnexion;
    }
}