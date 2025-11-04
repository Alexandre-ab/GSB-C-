using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSB_C_.Models;

namespace GSB_C_.Forms
{
    public partial class FormDoctor : Form
    {
        public FormDoctor()
        {
            InitializeComponent();
            MedicineDAO medDAO = new MedicineDAO();
            List<Medicine> medlist = medDAO.GetAll();

            this.dataGridViewDoctorListListMedecine.DataSource = medlist;

        }

        private void FormDoctor_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewDoctorListListMedecine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
