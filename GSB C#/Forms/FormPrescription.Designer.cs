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

                    DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();

                    DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();

                    buttonAdd = new Button();

                    label1 = new Label();

                    label2 = new Label();

                    label3 = new Label();

                    label4 = new Label();

                    textUserID = new TextBox();

                    textQuantity = new TextBox();

                    textValidity = new TextBox();

                    dataGridView1Prescription = new DataGridView();

                    buttonModify = new Button();

                    buttonDelete = new Button();

                    buttonPDF = new Button();

                    comboBoxpatientID = new ComboBox();

                    panelInput = new Panel();

                    labelTitle = new Label();

                    panelActions = new Panel();

                    ((System.ComponentModel.ISupportInitialize)dataGridView1Prescription).BeginInit();

                    panelInput.SuspendLayout();

                    panelActions.SuspendLayout();

                    SuspendLayout();

                    // 

                    // buttonAdd

                    // 

                    buttonAdd.BackColor = Color.FromArgb(40, 167, 69);

                    buttonAdd.FlatAppearance.BorderSize = 0;

                    buttonAdd.FlatStyle = FlatStyle.Flat;

                    buttonAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

                    buttonAdd.ForeColor = Color.White;

                    buttonAdd.Location = new Point(12, 12);

                    buttonAdd.Name = "buttonAdd";

                    buttonAdd.Size = new Size(180, 40);

                    buttonAdd.TabIndex = 0;

                    buttonAdd.Text = "Add";

                    buttonAdd.UseVisualStyleBackColor = false;

                    buttonAdd.Click += button1_Click;

                    // 

                    // label1

                    // 

                    label1.AutoSize = true;

                    label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    label1.Location = new Point(25, 60);

                    label1.Name = "label1";

                    label1.Size = new Size(62, 15);

                    label1.TabIndex = 1;

                    label1.Text = "Patient ID";

                    // 

                    // label2

                    // 

                    label2.AutoSize = true;

                    label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    label2.Location = new Point(25, 120);

                    label2.Name = "label2";

                    label2.Size = new Size(49, 15);

                    label2.TabIndex = 2;

                    label2.Text = "User ID";

                    // 

                    // label3

                    // 

                    label3.AutoSize = true;

                    label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    label3.Location = new Point(25, 180);

                    label3.Name = "label3";

                    label3.Size = new Size(55, 15);

                    label3.TabIndex = 3;

                    label3.Text = "Quantity";

                    // 

                    // label4

                    // 

                    label4.AutoSize = true;

                    label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    label4.Location = new Point(25, 240);

                    label4.Name = "label4";

                    label4.Size = new Size(47, 15);

                    label4.TabIndex = 4;

                    label4.Text = "Validity";

                    // 

                    // textUserID

                    // 

                    textUserID.Font = new Font("Segoe UI", 9.75F);

                    textUserID.Location = new Point(25, 140);

                    textUserID.Name = "textUserID";

                    textUserID.Size = new Size(250, 25);

                    textUserID.TabIndex = 6;

                    // 

                    // textQuantity

                    // 

                    textQuantity.Font = new Font("Segoe UI", 9.75F);

                    textQuantity.Location = new Point(25, 200);

                    textQuantity.Name = "textQuantity";

                    textQuantity.Size = new Size(250, 25);

                    textQuantity.TabIndex = 7;

                    // 

                    // textValidity

                    // 

                    textValidity.Font = new Font("Segoe UI", 9.75F);

                    textValidity.Location = new Point(25, 260);

                    textValidity.Name = "textValidity";

                    textValidity.Size = new Size(250, 25);

                    textValidity.TabIndex = 8;

                    // 

                    // dataGridView1Prescription

                    // 

                    dataGridView1Prescription.AllowUserToAddRows = false;

                    dataGridView1Prescription.AllowUserToDeleteRows = false;

                    dataGridView1Prescription.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dataGridView1Prescription.BackgroundColor = Color.White;

                    dataGridView1Prescription.BorderStyle = BorderStyle.None;

                    dataGridView1Prescription.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

                    dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 123, 255);

                    dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

                    dataGridViewCellStyle1.ForeColor = Color.White;

                    dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 123, 255);

                    dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;

                    dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;

                    dataGridView1Prescription.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

                    dataGridView1Prescription.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                    dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    dataGridViewCellStyle2.BackColor = SystemColors.Window;

                    dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);

                    dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;

                    dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);

                    dataGridViewCellStyle2.SelectionForeColor = Color.Black;

                    dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;

                    dataGridView1Prescription.DefaultCellStyle = dataGridViewCellStyle2;

                    dataGridView1Prescription.Dock = DockStyle.Right;

                    dataGridView1Prescription.EnableHeadersVisualStyles = false;

                    dataGridView1Prescription.GridColor = Color.FromArgb(224, 224, 224);

                    dataGridView1Prescription.Location = new Point(324, 0);

                    dataGridView1Prescription.Name = "dataGridView1Prescription";

                    dataGridView1Prescription.ReadOnly = true;

                    dataGridView1Prescription.RowHeadersVisible = false;

                    dataGridView1Prescription.RowTemplate.Height = 25;

                    dataGridView1Prescription.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1Prescription.Size = new Size(476, 391);

                    dataGridView1Prescription.TabIndex = 9;

                    dataGridView1Prescription.CellContentClick += dataGridView1_CellContentClick;

                    // 

                    // buttonModify

                    // 

                    buttonModify.BackColor = Color.FromArgb(0, 123, 255);

                    buttonModify.FlatAppearance.BorderSize = 0;

                    buttonModify.FlatStyle = FlatStyle.Flat;

                    buttonModify.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

                    buttonModify.ForeColor = Color.White;

                    buttonModify.Location = new Point(208, 12);

                    buttonModify.Name = "buttonModify";

                    buttonModify.Size = new Size(180, 40);

                    buttonModify.TabIndex = 10;

                    buttonModify.Text = "Modify";

                    buttonModify.UseVisualStyleBackColor = false;

                    buttonModify.Click += button2_Click;

                    // 

                    // buttonDelete

                    // 

                    buttonDelete.BackColor = Color.FromArgb(220, 53, 69);

                    buttonDelete.FlatAppearance.BorderSize = 0;

                    buttonDelete.FlatStyle = FlatStyle.Flat;

                    buttonDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

                    buttonDelete.ForeColor = Color.White;

                    buttonDelete.Location = new Point(404, 12);

                    buttonDelete.Name = "buttonDelete";

                    buttonDelete.Size = new Size(180, 40);

                    buttonDelete.TabIndex = 11;

                    buttonDelete.Text = "Delete";

                    buttonDelete.UseVisualStyleBackColor = false;

                    buttonDelete.Click += button3_Click;

                    // 

                    // buttonPDF

                    // 

                    buttonPDF.BackColor = Color.FromArgb(255, 193, 7);

                    buttonPDF.FlatAppearance.BorderSize = 0;

                    buttonPDF.FlatStyle = FlatStyle.Flat;

                    buttonPDF.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

                    buttonPDF.ForeColor = Color.White;

                    buttonPDF.Location = new Point(608, 12);

                    buttonPDF.Name = "buttonPDF";

                    buttonPDF.Size = new Size(180, 40);

                    buttonPDF.TabIndex = 12;

                    buttonPDF.Text = "Export PDF";

                    buttonPDF.UseVisualStyleBackColor = false;

                    buttonPDF.Click += button4_Click;

                    // 

                    // comboBoxpatientID

                    // 

                    comboBoxpatientID.DropDownStyle = ComboBoxStyle.DropDownList;

                    comboBoxpatientID.Font = new Font("Segoe UI", 9.75F);

                    comboBoxpatientID.FormattingEnabled = true;

                    comboBoxpatientID.Location = new Point(25, 80);

                    comboBoxpatientID.Name = "comboBoxpatientID";

                    comboBoxpatientID.Size = new Size(250, 25);

                    comboBoxpatientID.TabIndex = 13;

                    // 

                    // panelInput

                    // 

                    panelInput.BackColor = Color.White;

                    panelInput.Controls.Add(labelTitle);

                    panelInput.Controls.Add(label1);

                    panelInput.Controls.Add(comboBoxpatientID);

                    panelInput.Controls.Add(label2);

                    panelInput.Controls.Add(textUserID);

                    panelInput.Controls.Add(label3);

                    panelInput.Controls.Add(textQuantity);

                    panelInput.Controls.Add(textValidity);

                    panelInput.Controls.Add(label4);

                    panelInput.Dock = DockStyle.Left;

                    panelInput.Location = new Point(0, 0);

                    panelInput.Name = "panelInput";

                    panelInput.Size = new Size(300, 391);

                    panelInput.TabIndex = 14;

                    // 

                    // labelTitle

                    // 

                    labelTitle.AutoSize = true;

                    labelTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);

                    labelTitle.Location = new Point(25, 20);

                    labelTitle.Name = "labelTitle";

                    labelTitle.Size = new Size(212, 30);

                    labelTitle.TabIndex = 14;

                    labelTitle.Text = "Prescription Details";

                    // 

                    // panelActions

                    // 

                    panelActions.BackColor = Color.White;

                    panelActions.Controls.Add(buttonAdd);

                    panelActions.Controls.Add(buttonModify);

                    panelActions.Controls.Add(buttonPDF);

                    panelActions.Controls.Add(buttonDelete);

                    panelActions.Dock = DockStyle.Bottom;

                    panelActions.Location = new Point(0, 391);

                    panelActions.Name = "panelActions";

                    panelActions.Size = new Size(800, 60);

                    panelActions.TabIndex = 15;

                    // 

                    // FormPrescription

                    // 

                    AutoScaleDimensions = new SizeF(7F, 15F);

                    AutoScaleMode = AutoScaleMode.Font;

                    BackColor = Color.FromArgb(245, 245, 245);

                    ClientSize = new Size(800, 451);

                    Controls.Add(dataGridView1Prescription);

                    Controls.Add(panelInput);

                    Controls.Add(panelActions);

                    Font = new Font("Segoe UI", 9F);

                    Name = "FormPrescription";

                    Text = "Prescription Management";

                    ((System.ComponentModel.ISupportInitialize)dataGridView1Prescription).EndInit();

                    panelInput.ResumeLayout(false);

                    panelInput.PerformLayout();

                    panelActions.ResumeLayout(false);

                    ResumeLayout(false);

                }

        

                #endregion

        

                private Button buttonAdd;

                private Label label1;

                private Label label2;

                private Label label3;

                private Label label4;

                private TextBox textUserID;

                private TextBox textQuantity;

                private TextBox textValidity;

                private DataGridView dataGridView1Prescription;

                private Button buttonModify;

                private Button buttonDelete;

                private Button buttonPDF;

                private ComboBox comboBoxpatientID;

                private Panel panelInput;

                private Label labelTitle;

                private Panel panelActions;

            }

        }

        