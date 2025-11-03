using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_C_.Models
{
    public class Prescription
    {
		public int prescriptionId {  get; set; }
		public int patientId { get; set; }
		public int UserId { get; set; }
		public int Quantity { get; set; }
		public bool Validity { get; set; }

		public Prescription() { }

		public Prescription(int prescription, int patients, int User, int Quantity, bool Validity)
		{
			this.prescriptionId = prescription;
			this.patientId = patients;
			this.UserId = User;
			this.Quantity = Quantity;
			this.Validity = Validity;
		}

    }
}

