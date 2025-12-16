using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_C_.Models
{
   
        public class MedicineStats
        {
            public int MedicineId { get; set; }
            public string NomMedicament { get; set; }
            public int NombrePrescriptions { get; set; }  // Nombre de fois prescrit
            public int QuantiteTotale { get; set; }       // Quantité totale consommée

            public MedicineStats() { }

            public MedicineStats(int medicineId, string nom, int nombrePrescriptions, int quantiteTotale)
            {
                MedicineId = medicineId;
                NomMedicament = nom;
                NombrePrescriptions = nombrePrescriptions;
                QuantiteTotale = quantiteTotale;
            }
        }
    }

