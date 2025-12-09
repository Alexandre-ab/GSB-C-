namespace GSB_C_.Forms
{
    partial class FormAdmin
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
            dataGridViewAdmin = new DataGridView();
            buttonAdUser = new Button();
            buttonModifySuppUser = new Button();
            Deconnexion = new Button();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelFooter = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAdmin).BeginInit();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewAdmin
            // 
            dataGridViewAdmin.AllowUserToAddRows = false;
            dataGridViewAdmin.AllowUserToDeleteRows = false;
            dataGridViewAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAdmin.BackgroundColor = Color.White;
            dataGridViewAdmin.BorderStyle = BorderStyle.None;
            dataGridViewAdmin.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewAdmin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewAdmin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewAdmin.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewAdmin.Dock = DockStyle.Fill;
            dataGridViewAdmin.EnableHeadersVisualStyles = false;
            dataGridViewAdmin.GridColor = Color.FromArgb(224, 224, 224);
            dataGridViewAdmin.Location = new Point(0, 60);
            dataGridViewAdmin.MultiSelect = false;
            dataGridViewAdmin.Name = "dataGridViewAdmin";
            dataGridViewAdmin.ReadOnly = true;
            dataGridViewAdmin.RowHeadersVisible = false;
            dataGridViewAdmin.RowTemplate.Height = 25;
            dataGridViewAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAdmin.Size = new Size(800, 330);
            dataGridViewAdmin.TabIndex = 0;
            dataGridViewAdmin.CellContentClick += dataGridViewAdmin_CellContentClick;
            // 
            // buttonAdUser
            // 
            buttonAdUser.BackColor = Color.FromArgb(40, 167, 69);
            buttonAdUser.FlatAppearance.BorderSize = 0;
            buttonAdUser.FlatStyle = FlatStyle.Flat;
            buttonAdUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonAdUser.ForeColor = Color.White;
            buttonAdUser.Location = new Point(12, 12);
            buttonAdUser.Name = "buttonAdUser";
            buttonAdUser.Size = new Size(180, 40);
            buttonAdUser.TabIndex = 1;
            buttonAdUser.Text = "Add User";
            buttonAdUser.UseVisualStyleBackColor = false;
            buttonAdUser.Click += buttonAdUser_Click;
            // 
            // buttonModifySuppUser
            // 
            buttonModifySuppUser.BackColor = Color.FromArgb(0, 123, 255);
            buttonModifySuppUser.FlatAppearance.BorderSize = 0;
            buttonModifySuppUser.FlatStyle = FlatStyle.Flat;
            buttonModifySuppUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonModifySuppUser.ForeColor = Color.White;
            buttonModifySuppUser.Location = new Point(210, 12);
            buttonModifySuppUser.Name = "buttonModifySuppUser";
            buttonModifySuppUser.Size = new Size(180, 40);
            buttonModifySuppUser.TabIndex = 3;
            buttonModifySuppUser.Text = "Modify / Delete User";
            buttonModifySuppUser.UseVisualStyleBackColor = false;
            buttonModifySuppUser.Click += buttonModifySuppUser_Click;
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
            Deconnexion.TabIndex = 4;
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
            panelHeader.TabIndex = 5;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            labelTitle.Location = new Point(12, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(247, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Administration Dashboard";
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(buttonModifySuppUser);
            panelFooter.Controls.Add(buttonAdUser);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 390);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(800, 60);
            panelFooter.TabIndex = 6;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewAdmin);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "FormAdmin";
            Text = "Administration Dashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAdmin).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewAdmin;
        private Button buttonAdUser;
        private Button buttonModifySuppUser;
        private Button Deconnexion;
        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelFooter;
    }
}