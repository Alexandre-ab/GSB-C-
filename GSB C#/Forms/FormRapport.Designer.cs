namespace GSB_C_.Forms
{
    partial class FormRapport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelLeft = new Panel();
            label1 = new Label();
            labelPraticien = new Label();
            comboBoxPatient = new ComboBox();
            labelDate = new Label();
            dateTimePickerVisite = new DateTimePicker();
            labelMotif = new Label();
            textBoxMotif = new TextBox();
            labelBilan = new Label();
            textBoxBilan = new TextBox();
            buttonAjouter = new Button();
            buttonModifier = new Button();
            buttonSupprimer = new Button();
            dataGridViewRapports = new DataGridView();
            panelHeader = new Panel();
            labelTitle = new Label();
            buttonRetour = new Button();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRapports).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            //
            // panelLeft
            //
            panelLeft.BackColor = Color.White;
            panelLeft.Controls.Add(label1);
            panelLeft.Controls.Add(labelPraticien);
            panelLeft.Controls.Add(comboBoxPatient);
            panelLeft.Controls.Add(labelDate);
            panelLeft.Controls.Add(dateTimePickerVisite);
            panelLeft.Controls.Add(labelMotif);
            panelLeft.Controls.Add(textBoxMotif);
            panelLeft.Controls.Add(labelBilan);
            panelLeft.Controls.Add(textBoxBilan);
            panelLeft.Controls.Add(buttonAjouter);
            panelLeft.Controls.Add(buttonModifier);
            panelLeft.Controls.Add(buttonSupprimer);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 60);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(300, 440);
            panelLeft.TabIndex = 0;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(220, 25);
            label1.TabIndex = 0;
            label1.Text = "Rapport de visite";
            //
            // labelPraticien
            //
            labelPraticien.AutoSize = true;
            labelPraticien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPraticien.Location = new Point(20, 55);
            labelPraticien.Name = "labelPraticien";
            labelPraticien.Size = new Size(100, 15);
            labelPraticien.TabIndex = 1;
            labelPraticien.Text = "Praticien visité";
            //
            // comboBoxPatient
            //
            comboBoxPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPatient.Font = new Font("Segoe UI", 9.75F);
            comboBoxPatient.Location = new Point(20, 75);
            comboBoxPatient.Name = "comboBoxPatient";
            comboBoxPatient.Size = new Size(255, 25);
            comboBoxPatient.TabIndex = 2;
            //
            // labelDate
            //
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelDate.Location = new Point(20, 115);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(85, 15);
            labelDate.TabIndex = 3;
            labelDate.Text = "Date de visite";
            //
            // dateTimePickerVisite
            //
            dateTimePickerVisite.Font = new Font("Segoe UI", 9.75F);
            dateTimePickerVisite.Format = DateTimePickerFormat.Short;
            dateTimePickerVisite.Location = new Point(20, 135);
            dateTimePickerVisite.Name = "dateTimePickerVisite";
            dateTimePickerVisite.Size = new Size(255, 25);
            dateTimePickerVisite.TabIndex = 4;
            //
            // labelMotif
            //
            labelMotif.AutoSize = true;
            labelMotif.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelMotif.Location = new Point(20, 175);
            labelMotif.Name = "labelMotif";
            labelMotif.Size = new Size(38, 15);
            labelMotif.TabIndex = 5;
            labelMotif.Text = "Motif";
            //
            // textBoxMotif
            //
            textBoxMotif.Font = new Font("Segoe UI", 9.75F);
            textBoxMotif.Location = new Point(20, 195);
            textBoxMotif.Name = "textBoxMotif";
            textBoxMotif.Size = new Size(255, 25);
            textBoxMotif.TabIndex = 6;
            //
            // labelBilan
            //
            labelBilan.AutoSize = true;
            labelBilan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelBilan.Location = new Point(20, 235);
            labelBilan.Name = "labelBilan";
            labelBilan.Size = new Size(32, 15);
            labelBilan.TabIndex = 7;
            labelBilan.Text = "Bilan";
            //
            // textBoxBilan
            //
            textBoxBilan.Font = new Font("Segoe UI", 9.75F);
            textBoxBilan.Location = new Point(20, 255);
            textBoxBilan.Multiline = true;
            textBoxBilan.Name = "textBoxBilan";
            textBoxBilan.Size = new Size(255, 60);
            textBoxBilan.TabIndex = 8;
            //
            // buttonAjouter
            //
            buttonAjouter.BackColor = Color.FromArgb(40, 167, 69);
            buttonAjouter.FlatAppearance.BorderSize = 0;
            buttonAjouter.FlatStyle = FlatStyle.Flat;
            buttonAjouter.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonAjouter.ForeColor = Color.White;
            buttonAjouter.Location = new Point(20, 335);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(120, 38);
            buttonAjouter.TabIndex = 9;
            buttonAjouter.Text = "Ajouter";
            buttonAjouter.UseVisualStyleBackColor = false;
            buttonAjouter.Click += buttonAjouter_Click;
            //
            // buttonModifier
            //
            buttonModifier.BackColor = Color.FromArgb(0, 123, 255);
            buttonModifier.FlatAppearance.BorderSize = 0;
            buttonModifier.FlatStyle = FlatStyle.Flat;
            buttonModifier.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonModifier.ForeColor = Color.White;
            buttonModifier.Location = new Point(155, 335);
            buttonModifier.Name = "buttonModifier";
            buttonModifier.Size = new Size(120, 38);
            buttonModifier.TabIndex = 10;
            buttonModifier.Text = "Modifier";
            buttonModifier.UseVisualStyleBackColor = false;
            buttonModifier.Click += buttonModifier_Click;
            //
            // buttonSupprimer
            //
            buttonSupprimer.BackColor = Color.FromArgb(220, 53, 69);
            buttonSupprimer.FlatAppearance.BorderSize = 0;
            buttonSupprimer.FlatStyle = FlatStyle.Flat;
            buttonSupprimer.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonSupprimer.ForeColor = Color.White;
            buttonSupprimer.Location = new Point(20, 385);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(255, 38);
            buttonSupprimer.TabIndex = 11;
            buttonSupprimer.Text = "Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = false;
            buttonSupprimer.Click += buttonSupprimer_Click;
            //
            // dataGridViewRapports
            //
            dataGridViewRapports.AllowUserToAddRows = false;
            dataGridViewRapports.AllowUserToDeleteRows = false;
            dataGridViewRapports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRapports.BackgroundColor = Color.White;
            dataGridViewRapports.BorderStyle = BorderStyle.None;
            dataGridViewRapports.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewRapports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewRapports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewRapports.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewRapports.Dock = DockStyle.Fill;
            dataGridViewRapports.EnableHeadersVisualStyles = false;
            dataGridViewRapports.GridColor = Color.FromArgb(224, 224, 224);
            dataGridViewRapports.Location = new Point(300, 60);
            dataGridViewRapports.MultiSelect = false;
            dataGridViewRapports.Name = "dataGridViewRapports";
            dataGridViewRapports.ReadOnly = true;
            dataGridViewRapports.RowHeadersVisible = false;
            dataGridViewRapports.RowTemplate.Height = 25;
            dataGridViewRapports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRapports.Size = new Size(600, 440);
            dataGridViewRapports.TabIndex = 1;
            dataGridViewRapports.SelectionChanged += dataGridViewRapports_SelectionChanged;
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(buttonRetour);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 60);
            panelHeader.TabIndex = 2;
            //
            // labelTitle
            //
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            labelTitle.Location = new Point(12, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(250, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Rapports de Visite";
            //
            // buttonRetour
            //
            buttonRetour.BackColor = Color.White;
            buttonRetour.FlatAppearance.BorderColor = Color.FromArgb(108, 117, 125);
            buttonRetour.FlatAppearance.BorderSize = 2;
            buttonRetour.FlatStyle = FlatStyle.Flat;
            buttonRetour.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonRetour.ForeColor = Color.FromArgb(108, 117, 125);
            buttonRetour.Location = new Point(784, 15);
            buttonRetour.Name = "buttonRetour";
            buttonRetour.Size = new Size(100, 30);
            buttonRetour.TabIndex = 1;
            buttonRetour.Text = "Retour";
            buttonRetour.UseVisualStyleBackColor = false;
            buttonRetour.Click += buttonRetour_Click;
            //
            // FormRapport
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(900, 500);
            Controls.Add(dataGridViewRapports);
            Controls.Add(panelLeft);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormRapport";
            Text = "Rapports de Visite";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRapports).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Label label1;
        private Label labelPraticien;
        private ComboBox comboBoxPatient;
        private Label labelDate;
        private DateTimePicker dateTimePickerVisite;
        private Label labelMotif;
        private TextBox textBoxMotif;
        private Label labelBilan;
        private TextBox textBoxBilan;
        private Button buttonAjouter;
        private Button buttonModifier;
        private Button buttonSupprimer;
        private DataGridView dataGridViewRapports;
        private Panel panelHeader;
        private Label labelTitle;
        private Button buttonRetour;
    }
}
