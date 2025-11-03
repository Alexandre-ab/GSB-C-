using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_C_.Models
{
    public class Appartient
    {
        public int PrescriptionId { get; set; }

        public int MedicineId { get; set; }

        public Appartient() { }



        public Appartient(int prescription, int medicine)
        {
            PrescriptionId = prescription;
            MedicineId = medicine;
        }
    }
}
