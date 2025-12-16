using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GSB_C_.Models;

namespace GSB_C_.Forms
{
    public partial class FormTopMedicines : Form
    {
        private DataGridView dataGridViewPrescribed;
        private DataGridView dataGridViewConsumed;
        private Label labelPrescribed;
        private Label labelConsumed;
        private Label labelPeriode;
        private Panel panelLeft;
        private Panel panelRight;

        public FormTopMedicines(DateTime dateDebut, DateTime dateFin)
        {
            InitializeComponent();

            // Configuration des labels
            labelPeriode.Text = $"Période : {dateDebut:dd/MM/yyyy} → {dateFin:dd/MM/yyyy}";
            labelPrescribed.Text = "🏆 TOP 10 - Plus Prescrits";
            labelConsumed.Text = "🏆 TOP 10 - Plus Consommés";

            // Récupération des données
            MedicineDAO medDAO = new MedicineDAO();
            List<MedicineStats> topPrescribed = medDAO.GetTop10MostPrescribed(dateDebut, dateFin);
            List<MedicineStats> topConsumed = medDAO.GetTop10MostConsumed(dateDebut, dateFin);

            // Affichage dans les DataGridView (SANS molécule)
            dataGridViewPrescribed.DataSource = topPrescribed
                .Select((m, index) => new {
                    Rang = index + 1,
                    Médicament = m.NomMedicament,
                    NbPrescriptions = m.NombrePrescriptions
                }).ToList();

            dataGridViewConsumed.DataSource = topConsumed
                .Select((m, index) => new {
                    Rang = index + 1,
                    Médicament = m.NomMedicament,
                    Quantité = m.QuantiteTotale
                }).ToList();

            // Style des DataGridView
            StyleDataGridView(dataGridViewPrescribed);
            StyleDataGridView(dataGridViewConsumed);
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            // Style de l'en-tête
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void InitializeComponent()
        {
            this.panelLeft = new Panel();
            this.panelRight = new Panel();
            this.labelPeriode = new Label();
            this.labelPrescribed = new Label();
            this.labelConsumed = new Label();
            this.dataGridViewPrescribed = new DataGridView();
            this.dataGridViewConsumed = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)this.dataGridViewPrescribed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewConsumed).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();

            // labelPeriode
            this.labelPeriode.AutoSize = true;
            this.labelPeriode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.labelPeriode.Location = new Point(20, 20);
            this.labelPeriode.Name = "labelPeriode";
            this.labelPeriode.Size = new Size(300, 25);
            this.labelPeriode.TabIndex = 0;

            // panelLeft
            this.panelLeft.BackColor = Color.White;
            this.panelLeft.Controls.Add(this.labelPrescribed);
            this.panelLeft.Controls.Add(this.dataGridViewPrescribed);
            this.panelLeft.Location = new Point(0, 60);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new Size(490, 500);
            this.panelLeft.TabIndex = 1;

            // labelPrescribed
            this.labelPrescribed.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.labelPrescribed.Location = new Point(20, 10);
            this.labelPrescribed.Name = "labelPrescribed";
            this.labelPrescribed.Size = new Size(400, 30);
            this.labelPrescribed.TabIndex = 0;

            // dataGridViewPrescribed
            this.dataGridViewPrescribed.Location = new Point(20, 50);
            this.dataGridViewPrescribed.Name = "dataGridViewPrescribed";
            this.dataGridViewPrescribed.Size = new Size(450, 430);
            this.dataGridViewPrescribed.TabIndex = 1;

            // panelRight
            this.panelRight.BackColor = Color.White;
            this.panelRight.Controls.Add(this.labelConsumed);
            this.panelRight.Controls.Add(this.dataGridViewConsumed);
            this.panelRight.Location = new Point(500, 60);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new Size(490, 500);
            this.panelRight.TabIndex = 2;

            // labelConsumed
            this.labelConsumed.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.labelConsumed.Location = new Point(20, 10);
            this.labelConsumed.Name = "labelConsumed";
            this.labelConsumed.Size = new Size(400, 30);
            this.labelConsumed.TabIndex = 0;

            // dataGridViewConsumed
            this.dataGridViewConsumed.Location = new Point(20, 50);
            this.dataGridViewConsumed.Name = "dataGridViewConsumed";
            this.dataGridViewConsumed.Size = new Size(450, 430);
            this.dataGridViewConsumed.TabIndex = 1;

            // FormTopMedicines
            this.ClientSize = new Size(1000, 580);
            this.Controls.Add(this.labelPeriode);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Text = "TOP 10 Médicaments";
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            ((System.ComponentModel.ISupportInitialize)this.dataGridViewPrescribed).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewConsumed).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}