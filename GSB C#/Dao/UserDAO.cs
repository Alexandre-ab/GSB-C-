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


                User user = new User(id, name, firstname,email,password ,role);
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
    // récupérer tous les utilisateurs 
    public List<User> GetAll()
    {
        List<User> users = new List<User>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"SELECT * FROM Users";
                
                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int id = myReader.GetInt32("id_users");
                        string name = myReader.GetString("name");
                        string firstname = myReader.GetString("firstname");
                        string email = myReader.GetString("email");
                        string password = myReader.GetString("password");
                        bool role = myReader.GetBoolean("role");
                        User user = new User(id, name, firstname, email, password, role);
                        users.Add(user);
                    }
                }
                connection.Close();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users: " + ex.Message);
            }
        }   


    }


    public bool update (User user)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"UPDATE Users SET name = @name, firstname = @firstname, email = @email, password = SHA2(@password, 256), role = @role WHERE id_users = @userId";
                myCommand.Parameters.AddWithValue("@name", user.Name);
                myCommand.Parameters.AddWithValue("@firstname", user.Firstname);
                myCommand.Parameters.AddWithValue("@email", user.Email);
                myCommand.Parameters.AddWithValue("@password", user.Password);
                myCommand.Parameters.AddWithValue("@role", user.Role);
                myCommand.Parameters.AddWithValue("@userId", user.UserId);
                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user: " + ex.Message);
            }
        }
    }

    public bool Delete(int userId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"DELETE FROM Users WHERE id_users = @userId";
                myCommand.Parameters.AddWithValue("@userId", userId);
                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting user: " + ex.Message);
            }
        }
    }

}


        
    
