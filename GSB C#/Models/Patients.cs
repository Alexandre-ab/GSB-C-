using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_C_.Models
{
    public class Patients
    {
        public int PatientID { get; set; }
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string? Firstname { get; set; }


        public string? Lastname { get; set; }

        public int Age { get; set; }


        public bool Gender { get; set; }


        public Patients() { }

        public Patients(int patient, int user, string name, string firstname, string lastname, int age, bool gender) {


            this.PatientID = patient;
            this.UserId = user;
            this.Name = name;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Gender = gender;


        }

            


            }
        }
    

