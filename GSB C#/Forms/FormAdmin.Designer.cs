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
            dataGridViewAdmin = new DataGridView();
            buttonAdUser = new Button();
            buttonModifySuppUser = new Button();
            Deconnexion = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAdmin).BeginInit();
            SuspendLayout();
            buttonAdUser.BackColor = Color.DodgerBlue;
            buttonAdUser.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAdUser.ForeColor = Color.White;
            buttonAdUser.Location = new Point(401, 291);
            buttonAdUser.Margin = new Padding(3, 2, 3, 2);
            buttonAdUser.Name = "buttonAdUser";
            buttonAdUser.Size = new Size(277, 35);
            buttonAdUser.TabIndex = 1;
            buttonAdUser.Text = "ADD";
            buttonAdUser.UseVisualStyleBackColor = false;
            buttonAdUser.Click += buttonAdUser_Click;
            // 
            // buttonModifySuppUser
            // 
            buttonModifySuppUser.BackColor = Color.DodgerBlue;
            buttonModifySuppUser.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonModifySuppUser.ForeColor = Color.White;
            buttonModifySuppUser.Location = new Point(12, 292);
            buttonModifySuppUser.Margin = new Padding(3, 2, 3, 2);
            buttonModifySuppUser.Name = "buttonModifySuppUser";
            buttonModifySuppUser.Size = new Size(290, 32);
            buttonModifySuppUser.TabIndex = 3;
            buttonModifySuppUser.Text = "Modifiy / Delete";
            buttonModifySuppUser.UseVisualStyleBackColor = false;
            buttonModifySuppUser.Click += buttonModifySuppUser_Click;
            // 
            // Deconnexion
            // 
            Deconnexion.BackColor = Color.Crimson;
            Deconnexion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Deconnexion.ForeColor = Color.White;
            Deconnexion.Location = new Point(565, 9);
            Deconnexion.Margin = new Padding(3, 2, 3, 2);
            Deconnexion.Name = "Deconnexion";
            Deconnexion.Size = new Size(124, 28);
            Deconnexion.TabIndex = 4;
            Deconnexion.Text = "Déconnexion";
            Deconnexion.UseVisualStyleBackColor = false;
            Deconnexion.Click += Deconnexion_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(700, 338);
            Controls.Add(Deconnexion);
            Controls.Add(buttonModifySuppUser);
            Controls.Add(buttonAdUser);
            Controls.Add(dataGridViewAdmin);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormAdmin";
            Text = "Administration Dashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAdmin).EndInit();
            ResumeLayout(false);
            // 
            // dataGridViewAdmin
            // 
            dataGridViewAdmin.BackgroundColor = Color.White;
            dataGridViewAdmin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAdmin.ColumnHeadersVisible = true;
            dataGridViewAdmin.Location = new Point(12, 41);
            dataGridViewAdmin.Margin = new Padding(3, 2, 3, 2);
            dataGridViewAdmin.Name = "dataGridViewAdmin";
            dataGridViewAdmin.RowHeadersWidth = 51;
            dataGridViewAdmin.Size = new Size(678, 237);
            dataGridViewAdmin.TabIndex = 0;
            dataGridViewAdmin.CellContentClick += dataGridViewAdmin_CellContentClick;
        }


        #endregion

        private DataGridView dataGridViewAdmin;
        private Button buttonAdUser;
        
        private Button buttonModifySuppUser;
        private Button Deconnexion;
    }
}