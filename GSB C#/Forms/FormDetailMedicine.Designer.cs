namespace GSB_C_.Forms
﻿{
﻿    partial class FormDetailMedicine
﻿    {
﻿        /// <summary>
﻿        /// Required designer variable.
﻿        /// </summary>
﻿        private System.ComponentModel.IContainer components = null;
﻿
﻿        /// <summary>
﻿        /// Clean up any resources being used.
﻿        /// </summary>
﻿        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
﻿        protected override void Dispose(bool disposing)
﻿        {
﻿            if (disposing && (components != null))
﻿            {
﻿                components.Dispose();
﻿            }
﻿            base.Dispose(disposing);
﻿        }
﻿
﻿        #region Windows Form Designer generated code
﻿
﻿        /// <summary>
﻿        /// Required method for Designer support - do not modify
﻿        /// the contents of this method with the code editor.
﻿        /// </summary>
﻿        private void InitializeComponent()
﻿        {
﻿            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
﻿            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
﻿            dataGridViewDetailMedicine = new DataGridView();
﻿            panelHeader = new Panel();
﻿            labelTitle = new Label();
﻿            ((System.ComponentModel.ISupportInitialize)dataGridViewDetailMedicine).BeginInit();
﻿            panelHeader.SuspendLayout();
﻿            SuspendLayout();
﻿            // 
﻿            // dataGridViewDetailMedicine
﻿            // 
﻿            dataGridViewDetailMedicine.AllowUserToAddRows = false;
﻿            dataGridViewDetailMedicine.AllowUserToDeleteRows = false;
﻿            dataGridViewDetailMedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
﻿            dataGridViewDetailMedicine.BackgroundColor = Color.White;
﻿            dataGridViewDetailMedicine.BorderStyle = BorderStyle.None;
﻿            dataGridViewDetailMedicine.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
﻿            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
﻿            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 123, 255);
﻿            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
﻿            dataGridViewCellStyle1.ForeColor = Color.White;
﻿            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 123, 255);
﻿            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
﻿            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
﻿            dataGridViewDetailMedicine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
﻿            dataGridViewDetailMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
﻿            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
﻿            dataGridViewCellStyle2.BackColor = SystemColors.Window;
﻿            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
﻿            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
﻿            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);
﻿            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
﻿            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
﻿            dataGridViewDetailMedicine.DefaultCellStyle = dataGridViewCellStyle2;
﻿            dataGridViewDetailMedicine.Dock = DockStyle.Fill;
﻿            dataGridViewDetailMedicine.EnableHeadersVisualStyles = false;
﻿            dataGridViewDetailMedicine.GridColor = Color.FromArgb(224, 224, 224);
﻿            dataGridViewDetailMedicine.Location = new Point(0, 60);
﻿            dataGridViewDetailMedicine.Name = "dataGridViewDetailMedicine";
﻿            dataGridViewDetailMedicine.ReadOnly = true;
﻿            dataGridViewDetailMedicine.RowHeadersVisible = false;
﻿            dataGridViewDetailMedicine.RowTemplate.Height = 25;
﻿            dataGridViewDetailMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
﻿            dataGridViewDetailMedicine.Size = new Size(800, 390);
﻿            dataGridViewDetailMedicine.TabIndex = 0;
﻿            dataGridViewDetailMedicine.CellContentClick += dataGridViewDetailMedicine_CellContentClick;
﻿            // 
﻿            // panelHeader
﻿            // 
﻿            panelHeader.BackColor = Color.White;
﻿            panelHeader.Controls.Add(labelTitle);
﻿            panelHeader.Dock = DockStyle.Top;
﻿            panelHeader.Location = new Point(0, 0);
﻿            panelHeader.Name = "panelHeader";
﻿            panelHeader.Size = new Size(800, 60);
﻿            panelHeader.TabIndex = 1;
﻿            // 
﻿            // labelTitle
﻿            // 
﻿            labelTitle.AutoSize = true;
﻿            labelTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
﻿            labelTitle.Location = new Point(12, 15);
﻿            labelTitle.Name = "labelTitle";
﻿            labelTitle.Size = new Size(181, 30);
﻿            labelTitle.TabIndex = 0;
﻿            labelTitle.Text = "Medicine Details";
﻿            // 
﻿            // FormDetailMedicine
﻿            // 
﻿            AutoScaleDimensions = new SizeF(7F, 15F);
﻿            AutoScaleMode = AutoScaleMode.Font;
﻿            ClientSize = new Size(800, 450);
﻿            Controls.Add(dataGridViewDetailMedicine);
﻿            Controls.Add(panelHeader);
﻿            Font = new Font("Segoe UI", 9F);
﻿                        Name = "FormDetailMedicine";
﻿                        Text = "Medicine Details";
﻿                        Load += FormDetailMedicine_Load;﻿            ((System.ComponentModel.ISupportInitialize)dataGridViewDetailMedicine).EndInit();
﻿            panelHeader.ResumeLayout(false);
﻿            panelHeader.PerformLayout();
﻿            ResumeLayout(false);
﻿        }
﻿
﻿        #endregion
﻿
﻿        public DataGridView dataGridViewDetailMedicine;
﻿        private Panel panelHeader;
﻿        private Label labelTitle;
﻿    }
﻿}
﻿