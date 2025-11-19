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
            buttonDeleteUser = new Button();
            buttonModifyUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAdmin).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAdmin
            // 
            dataGridViewAdmin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAdmin.Location = new Point(25, 25);
            dataGridViewAdmin.Name = "dataGridViewAdmin";
            dataGridViewAdmin.RowHeadersWidth = 51;
            dataGridViewAdmin.Size = new Size(752, 317);
            dataGridViewAdmin.TabIndex = 0;
            dataGridViewAdmin.CellContentClick += dataGridViewAdmin_CellContentClick;
            // 
            // buttonAdUser
            // 
            buttonAdUser.BackColor = Color.Green;
            buttonAdUser.Location = new Point(359, 396);
            buttonAdUser.Name = "buttonAdUser";
            buttonAdUser.Size = new Size(117, 42);
            buttonAdUser.TabIndex = 1;
            buttonAdUser.Text = "ADD";
            buttonAdUser.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteUser
            // 
            buttonDeleteUser.BackColor = Color.Red;
            buttonDeleteUser.Location = new Point(672, 392);
            buttonDeleteUser.Name = "buttonDeleteUser";
            buttonDeleteUser.Size = new Size(116, 42);
            buttonDeleteUser.TabIndex = 2;
            buttonDeleteUser.Text = "Delete";
            buttonDeleteUser.UseVisualStyleBackColor = false;
            // 
            // buttonModifyUser
            // 
            buttonModifyUser.BackColor = Color.DodgerBlue;
            buttonModifyUser.Location = new Point(40, 392);
            buttonModifyUser.Name = "buttonModifyUser";
            buttonModifyUser.Size = new Size(89, 42);
            buttonModifyUser.TabIndex = 3;
            buttonModifyUser.Text = "Modifiy";
            buttonModifyUser.UseVisualStyleBackColor = false;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonModifyUser);
            Controls.Add(buttonDeleteUser);
            Controls.Add(buttonAdUser);
            Controls.Add(dataGridViewAdmin);
            Name = "FormAdmin";
            Text = "FormAdmin";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAdmin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewAdmin;
        private Button buttonAdUser;
        private Button buttonDeleteUser;
        private Button buttonModifyUser;
    }
}