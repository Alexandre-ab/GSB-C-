using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_C_.Models
{

    public class User
    {

        public int UserId { get; set; }
        public string Name { get; set; }

        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Role {  get; set; }

        //ceci est le constructeur par défaut
        //il permet de créer une instance de la classe qui nous permettra d'acceder
        //aux méthodes et propriétés de celle ci 
        public User() { }
        //ceci est une surcharge du constructeur, elle permettra la création d'objet User
        //qui sera instancié avec les variables passées en parametres

        public User(int id, string name, string firstname,string email ,string password ,bool role)
        {
            this.UserId = id;
           this.Name = name;
            this.Email = email;
            this.Firstname = firstname;
           this.Password = password;
            this.Role = role;

        }
        
        }
    }

