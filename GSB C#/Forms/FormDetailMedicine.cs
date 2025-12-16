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
    public partial class FormDetailMedicine : Form
    {
        public FormDetailMedicine()
        {
            InitializeComponent();
            MedicineDAO medDAO = new MedicineDAO();
            List<Medicine> medlist = medDAO.GetAll();
          


            this.dataGridViewDetailMedicine.DataSource = medlist;
        }

        private void FormDetailMedicine_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewDetailMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonTopMedicines_Click(object sender, EventArgs e)
        {
            // Période par défaut : année en cours
            DateTime dateDebut = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime dateFin = DateTime.Now;

            FormTopMedicines formTop = new FormTopMedicines(dateDebut, dateFin);
            formTop.ShowDialog();
        }


    }
}
