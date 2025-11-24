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
            try
            {


                connection.Open();

                // create a MySQL command and set the SQL statement with parameters
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"SELECT * FROM Users WHERE email = @email AND password = SHA2(@password, 256)";
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.Parameters.AddWithValue("@password", password);


                // execute the command and read the results
                using var myReader = myCommand.ExecuteReader();
                {
                    if (myReader.Read())
                    {
                        id = myReader.GetInt32("id_users");
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
    public bool Add(User user)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"INSERT INTO Users (id_users, name, firstname, email, password, role) 
                                          VALUES (@name, @firstname, @email, SHA2(@password, 256), false)";
                myCommand.Parameters.AddWithValue("@id_users", user.UserId);
                myCommand.Parameters.AddWithValue("@name", user.Name);
                myCommand.Parameters.AddWithValue("@firstname", user.Firstname);
                myCommand.Parameters.AddWithValue("@email", user.Email);
                myCommand.Parameters.AddWithValue("@password", user.Password);
                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering user: " + ex.Message);
            }
        }

    }
}


        
    
