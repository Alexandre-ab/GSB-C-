using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSB_C_.Models;
using GSB2.DAO;
namespace GSB_C_.Forms
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            UserDAO userDAO = new UserDAO();
            List<User> patlist = userDAO.GetAll();

            this.dataGridViewAdmin.DataSource = patlist;
        }

        private void buttonAdUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAddUser formAddUser = new FormAddUser();
            formAddUser.ShowDialog();
            this.Show();



        }

        private void Deconnexion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }


        private int idSelectedUser = 0;
        private void dataGridViewAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void buttonModifySuppUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormModifyAdmin formModifyAdmin = new FormModifyAdmin();
            formModifyAdmin.ShowDialog();
            this.Show();
        }
    }
}
    
           
                
    