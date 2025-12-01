using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GSB_C_.Models
{
   public static  class UserSession // static  = unique et accessible dans toute l'application
    {
        // propriété statique pour stocker l'utilisateur actuellement connecté
        public static User CurrentUser { get; set; }
    }
}
