using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            PatientsDAO patDAO = new PatientsDAO();
            List<Patients> patlist = patDAO.GetAll();

            this.dataGridViewAdmin.DataSource = patlist;
        }

        private void dataGridViewAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAdUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAddUser formAddUser = new FormAddUser();
            formAddUser.ShowDialog();




        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void Deconnexion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
