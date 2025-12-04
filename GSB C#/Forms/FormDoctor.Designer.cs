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

                    DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();

                    DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();

                    dataGridViewDoctorListListMedecine = new DataGridView();

                    prescription = new Button();

                    buttonPatient = new Button();

                    Deconnexion = new Button();

                    panelHeader = new Panel();

                    labelTitle = new Label();

                    panelFooter = new Panel();

                    ((System.ComponentModel.ISupportInitialize)dataGridViewDoctorListListMedecine).BeginInit();

                    panelHeader.SuspendLayout();

                    panelFooter.SuspendLayout();

                    SuspendLayout();

                    // 

                    // dataGridViewDoctorListListMedecine

                    // 

                    dataGridViewDoctorListListMedecine.AllowUserToAddRows = false;

                    dataGridViewDoctorListListMedecine.AllowUserToDeleteRows = false;

                    dataGridViewDoctorListListMedecine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dataGridViewDoctorListListMedecine.BackgroundColor = Color.White;

                    dataGridViewDoctorListListMedecine.BorderStyle = BorderStyle.None;

                    dataGridViewDoctorListListMedecine.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

                    dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 123, 255);

                    dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

                    dataGridViewCellStyle1.ForeColor = Color.White;

                    dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 123, 255);

                    dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;

                    dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;

                    dataGridViewDoctorListListMedecine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

                    dataGridViewDoctorListListMedecine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                    dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    dataGridViewCellStyle2.BackColor = SystemColors.Window;

                    dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);

                    dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;

                    dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);

                    dataGridViewCellStyle2.SelectionForeColor = Color.Black;

                    dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;

                    dataGridViewDoctorListListMedecine.DefaultCellStyle = dataGridViewCellStyle2;

                    dataGridViewDoctorListListMedecine.Dock = DockStyle.Fill;

                    dataGridViewDoctorListListMedecine.EnableHeadersVisualStyles = false;

                    dataGridViewDoctorListListMedecine.GridColor = Color.FromArgb(224, 224, 224);

                    dataGridViewDoctorListListMedecine.Location = new Point(0, 60);

                    dataGridViewDoctorListListMedecine.MultiSelect = false;

                    dataGridViewDoctorListListMedecine.Name = "dataGridViewDoctorListListMedecine";

                    dataGridViewDoctorListListMedecine.ReadOnly = true;

                    dataGridViewDoctorListListMedecine.RowHeadersVisible = false;

                    dataGridViewDoctorListListMedecine.RowTemplate.Height = 25;

                    dataGridViewDoctorListListMedecine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridViewDoctorListListMedecine.Size = new Size(800, 330);

                    dataGridViewDoctorListListMedecine.TabIndex = 0;

                    dataGridViewDoctorListListMedecine.CellContentDoubleClick += dataGridViewDoctorListListMedecine_CellContentDoubleClick;

                    // 

                    // prescription

                    // 

                    prescription.BackColor = Color.FromArgb(0, 123, 255);

                    prescription.FlatAppearance.BorderSize = 0;

                    prescription.FlatStyle = FlatStyle.Flat;

                    prescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

                    prescription.ForeColor = Color.White;

                    prescription.Location = new Point(12, 12);

                    prescription.Name = "prescription";

                    prescription.Size = new Size(180, 40);

                    prescription.TabIndex = 1;

                    prescription.Text = "Prescriptions";

                    prescription.UseVisualStyleBackColor = false;

                    prescription.Click += button1_Click;

                    // 

                    // buttonPatient

                    // 

                    buttonPatient.BackColor = Color.FromArgb(40, 167, 69);

                    buttonPatient.FlatAppearance.BorderSize = 0;

                    buttonPatient.FlatStyle = FlatStyle.Flat;

                    buttonPatient.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

                    buttonPatient.ForeColor = Color.White;

                    buttonPatient.Location = new Point(608, 12);

                    buttonPatient.Name = "buttonPatient";

                    buttonPatient.Size = new Size(180, 40);

                    buttonPatient.TabIndex = 2;

                    buttonPatient.Text = "Patients";

                    buttonPatient.UseVisualStyleBackColor = false;

                    buttonPatient.Click += buttonPatient_Click;

                    // 

                    // Deconnexion

                    // 

                    Deconnexion.BackColor = Color.White;

                    Deconnexion.FlatAppearance.BorderColor = Color.FromArgb(220, 53, 69);

                    Deconnexion.FlatAppearance.BorderSize = 2;

                    Deconnexion.FlatStyle = FlatStyle.Flat;

                    Deconnexion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    Deconnexion.ForeColor = Color.FromArgb(220, 53, 69);

                    Deconnexion.Location = new Point(684, 15);

                    Deconnexion.Name = "Deconnexion";

                    Deconnexion.Size = new Size(104, 30);

                    Deconnexion.TabIndex = 5;

                    Deconnexion.Text = "Logout";

                    Deconnexion.UseVisualStyleBackColor = false;

                    Deconnexion.Click += Deconnexion_Click;

                    // 

                    // panelHeader

                    // 

                    panelHeader.BackColor = Color.White;

                    panelHeader.Controls.Add(labelTitle);

                    panelHeader.Controls.Add(Deconnexion);

                    panelHeader.Dock = DockStyle.Top;

                    panelHeader.Location = new Point(0, 0);

                    panelHeader.Name = "panelHeader";

                    panelHeader.Size = new Size(800, 60);

                    panelHeader.TabIndex = 6;

                    // 

                    // labelTitle

                    // 

                    labelTitle.AutoSize = true;

                    labelTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);

                    labelTitle.Location = new Point(12, 15);

                    labelTitle.Name = "labelTitle";

                    labelTitle.Size = new Size(195, 30);

                    labelTitle.TabIndex = 0;

                    labelTitle.Text = "Doctor Dashboard";

                    // 

                    // panelFooter

                    // 

                    panelFooter.BackColor = Color.White;

                    panelFooter.Controls.Add(buttonPatient);

                    panelFooter.Controls.Add(prescription);

                    panelFooter.Dock = DockStyle.Bottom;

                    panelFooter.Location = new Point(0, 390);

                    panelFooter.Name = "panelFooter";

                    panelFooter.Size = new Size(800, 60);

                    panelFooter.TabIndex = 7;

                    // 

                    // FormDoctor

                    // 

                    AutoScaleDimensions = new SizeF(7F, 15F);

                    AutoScaleMode = AutoScaleMode.Font;

                    BackColor = Color.FromArgb(245, 245, 245);

                    ClientSize = new Size(800, 450);

                    Controls.Add(dataGridViewDoctorListListMedecine);

                    Controls.Add(panelFooter);

                    Controls.Add(panelHeader);

                    Font = new Font("Segoe UI", 9F);

                    Name = "FormDoctor";

                    Text = "Doctor Dashboard";

                    ((System.ComponentModel.ISupportInitialize)dataGridViewDoctorListListMedecine).EndInit();

                    panelHeader.ResumeLayout(false);

                    panelHeader.PerformLayout();

                    panelFooter.ResumeLayout(false);

                    ResumeLayout(false);

                }

        

                #endregion

        

                private DataGridView dataGridViewDoctorListListMedecine;

                private Button prescription;

                private Button buttonPatient;

                private Button Deconnexion;

                private Panel panelHeader;

                private Label labelTitle;

                private Panel panelFooter;

            }

        }

        