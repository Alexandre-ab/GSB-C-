using System.Security.Cryptography.X509Certificates;
using System.Text;
using GSB_C_.Models;
using GSB2.DAO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

public class UserDAO
{
    private readonly Database db = new Database();
    public User Login(string email, string password)
    {
        int id = 0;
        string name = string.Empty;
        string firstname = string.Empty;
        bool role = false;

        using (var connection = db.GetConnection())
        {
            try { 

             SHA256 sha256 = SHA256.Create();
            byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashString = BitConverter.ToString(hashValue).Replace("-", "").ToLowerInvariant();
            connection.Open();

                // create a MySQL command and set the SQL statement with parameters
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"SELECT * FROM users WHERE email = @email AND password = @password;";
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.Parameters.AddWithValue("@password", password);


                // execute the command and read the results
                using var myReader = myCommand.ExecuteReader();
                {
                    if (myReader.Read())
                    {
                        id = myReader.GetInt32("user_id");
                        name = myReader.GetString("name");
                        firstname = myReader.GetString("firstname");
                        role = myReader.GetBoolean("role");

                    }
                    else
                    {
                        return null;
                    }


                }

                connection.Close();


                User user = new User(id, name, firstname, role);
                return user;
            }
            catch (Exception ex)

            {
                throw new Exception("Error retrieving user: " + ex.Message);
            }
        }
    }

    }


        
    
