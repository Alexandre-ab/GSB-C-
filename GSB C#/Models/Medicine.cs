using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_C_.Models
{
   public class Medicine
    {
        public int MedecineId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Molecule{ get; set; }

        public string Dosage { get; set; }

        public string Description { get; set; }

        public Medicine() { }


        public Medicine(int medecine, int user,  string name, string molecule, string dosage, string description)
        {
            this.MedecineId = medecine;
            this.UserId = user;
            this.Name = name;
            this.Molecule = molecule;
            this.Dosage = dosage;
            this.Description = description;
            
        }











       
    }

}

