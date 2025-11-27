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
    public partial class FormDetailMedecine : Form
    {
        public FormDetailMedecine()
        {
            InitializeComponent();
            MedicineDAO medDAO = new MedicineDAO();
            List<Medicine> medlist = medDAO.GetAll();

            this.dataGridViewDetailMedicine.DataSource = medlist;
        }

        private void FormDetailMedecine_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewDetailMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
