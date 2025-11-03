using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace GSB2.DAO
{
    public class Database
    {

        private readonly string myConnectionString = "server=localhost;port=3307;uid=root;pwd=rootpassword;database=bts-gsb";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(myConnectionString);
        }
    }
}