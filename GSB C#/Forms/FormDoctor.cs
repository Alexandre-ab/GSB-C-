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

        private void FormDoctor_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridViewDoctorListListMedecine_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MedicineDAO medDAO = new MedicineDAO();
            List<Medicine> medlist = medDAO.GetAll();

            FormDetailMedecine formDetailMedicine = new FormDetailMedecine();
            formDetailMedicine.dataGridViewDetailMedicine.DataSource = medlist;
            formDetailMedicine.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPrescription formPrescription = new FormPrescription();
            formPrescription.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
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


