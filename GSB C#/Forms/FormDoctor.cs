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
            List<Medicine> medlist= medDAO.GetAll();
            MessageBox.Show(medlist.ElementAt(0).Molecule);
        }
    }
}
