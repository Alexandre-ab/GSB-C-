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
    public partial class Alert : Form
    {
        public Alert()
        {
            InitializeComponent();
            PrescriptionDAO presDAO = new PrescriptionDAO();
            

        }
    }
}
