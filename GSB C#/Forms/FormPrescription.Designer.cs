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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            buttonFIlter = new Button();
            dateTimePickerFin = new DateTimePicker();
            dateTimePickerDebut = new DateTimePicker();
            labelTitle = new Label();
            panelActions = new Panel();
            button1 = new Button();
            buttonStats = new Button();
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
            buttonAdd.Location = new Point(14, 16);
            buttonAdd.Margin = new Padding(3, 4, 3, 4);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(206, 53);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(29, 80);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 1;
            label1.Text = "Patient ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(29, 160);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 2;
            label2.Text = "User ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(29, 240);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 3;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(29, 320);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 4;
            label4.Text = "Validity";
            // 
            // textUserID
            // 
            textUserID.Font = new Font("Segoe UI", 9.75F);
            textUserID.Location = new Point(29, 187);
            textUserID.Margin = new Padding(3, 4, 3, 4);
            textUserID.Name = "textUserID";
            textUserID.Size = new Size(285, 29);
            textUserID.TabIndex = 6;
            // 
            // textQuantity
            // 
            textQuantity.Font = new Font("Segoe UI", 9.75F);
            textQuantity.Location = new Point(29, 267);
            textQuantity.Margin = new Padding(3, 4, 3, 4);
            textQuantity.Name = "textQuantity";
            textQuantity.Size = new Size(285, 29);
            textQuantity.TabIndex = 7;
            // 
            // textValidity
            // 
            textValidity.Font = new Font("Segoe UI", 9.75F);
            textValidity.Location = new Point(29, 347);
            textValidity.Margin = new Padding(3, 4, 3, 4);
            textValidity.Name = "textValidity";
            textValidity.Size = new Size(285, 29);
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1Prescription.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1Prescription.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1Prescription.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1Prescription.Dock = DockStyle.Right;
            dataGridView1Prescription.EnableHeadersVisualStyles = false;
            dataGridView1Prescription.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView1Prescription.Location = new Point(370, 0);
            dataGridView1Prescription.Margin = new Padding(3, 4, 3, 4);
            dataGridView1Prescription.Name = "dataGridView1Prescription";
            dataGridView1Prescription.ReadOnly = true;
            dataGridView1Prescription.RowHeadersVisible = false;
            dataGridView1Prescription.RowHeadersWidth = 51;
            dataGridView1Prescription.RowTemplate.Height = 25;
            dataGridView1Prescription.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1Prescription.Size = new Size(544, 521);
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
            buttonModify.Location = new Point(238, 16);
            buttonModify.Margin = new Padding(3, 4, 3, 4);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(206, 53);
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
            buttonDelete.Location = new Point(462, 16);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(206, 53);
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
            buttonPDF.Location = new Point(695, 16);
            buttonPDF.Margin = new Padding(3, 4, 3, 4);
            buttonPDF.Name = "buttonPDF";
            buttonPDF.Size = new Size(206, 53);
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
            comboBoxpatientID.Location = new Point(29, 107);
            comboBoxpatientID.Margin = new Padding(3, 4, 3, 4);
            comboBoxpatientID.Name = "comboBoxpatientID";
            comboBoxpatientID.Size = new Size(285, 29);
            comboBoxpatientID.TabIndex = 13;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.Controls.Add(buttonStats);
            panelInput.Controls.Add(button1);
            panelInput.Controls.Add(buttonFIlter);
            panelInput.Controls.Add(dateTimePickerFin);
            panelInput.Controls.Add(dateTimePickerDebut);
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
            panelInput.Margin = new Padding(3, 4, 3, 4);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(343, 521);
            panelInput.TabIndex = 14;
            // 
            // buttonFIlter
            // 
            buttonFIlter.Location = new Point(29, 489);
            buttonFIlter.Name = "buttonFIlter";
            buttonFIlter.Size = new Size(79, 25);
            buttonFIlter.TabIndex = 17;
            buttonFIlter.Text = "Filter";
            buttonFIlter.UseVisualStyleBackColor = true;
            buttonFIlter.Click += buttonFIlter_Click;
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Location = new Point(29, 447);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(251, 27);
            dateTimePickerFin.TabIndex = 16;
            // 
            // dateTimePickerDebut
            // 
            dateTimePickerDebut.Location = new Point(29, 403);
            dateTimePickerDebut.Name = "dateTimePickerDebut";
            dateTimePickerDebut.Size = new Size(251, 27);
            dateTimePickerDebut.TabIndex = 15;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            labelTitle.Location = new Point(29, 27);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(269, 37);
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
            panelActions.Location = new Point(0, 521);
            panelActions.Margin = new Padding(3, 4, 3, 4);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(914, 80);
            panelActions.TabIndex = 15;
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 18;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // buttonStats
            // 
            buttonStats.Location = new Point(114, 489);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(90, 25);
            buttonStats.TabIndex = 19;
            buttonStats.Text = "Statistique";
            buttonStats.UseVisualStyleBackColor = true;
            buttonStats.Click += buttonStats_Click;
            // 
            // FormPrescription
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(914, 601);
            Controls.Add(dataGridView1Prescription);
            Controls.Add(panelInput);
            Controls.Add(panelActions);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
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
        private DateTimePicker dateTimePickerFin;
        private DateTimePicker dateTimePickerDebut;
        private Button buttonFIlter;
        private Button buttonStats;
        private Button button1;
    }

        }

        