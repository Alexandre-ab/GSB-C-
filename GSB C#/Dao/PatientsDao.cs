using GSB_C_.Models;
using GSB2.DAO;
using MySql.Data.MySqlClient;

public class PatientsDAO
{
    private readonly Database db = new Database();

    // Récupérer tous les patients
    public List<Patients> GetAll()
    {
        List<Patients> patients = new List<Patients>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Patients;";

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int patientId = myReader.GetInt32("id_patients");
                        int userId = myReader.GetInt32("id_users");
                        string name = myReader.GetString("name");
                        string firstname = myReader.GetString("firstname");
                        int age = myReader.GetInt32("age");
                        bool gender = myReader.GetBoolean("gender");

                        Patients patient = new Patients(patientId, userId, name, firstname, age, gender);
                        patients.Add(patient);
                    }
                }

                connection.Close();
                return patients;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving patients: " + ex.Message);
            }
        }
    }

    // Récupérer un patient par ID
    public Patients GetById(int patientId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Patients WHERE id_patients = @patientId;";
                myCommand.Parameters.AddWithValue("@patientId", patientId);

                using var myReader = myCommand.ExecuteReader();
                {
                    if (myReader.Read())
                    {
                        int userId = myReader.GetInt32("id_users");
                        string name = myReader.GetString("name");
                        string firstname = myReader.GetString("firstname");
                        int age = myReader.GetInt32("age");
                        bool gender = myReader.GetBoolean("gender");

                        return new Patients(patientId, userId, name, firstname,age, gender);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving patient: " + ex.Message);
            }
        }
    }

    // Récupérer les patients par utilisateur
    public List<Patients> GetByUserId(int userId)
    {
        List<Patients> patients = new List<Patients>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Patients WHERE id_users= @userId;";
                myCommand.Parameters.AddWithValue("@userId", userId);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int patientId = myReader.GetInt32("id_patients");
                        string name = myReader.GetString("name");
                        string firstname = myReader.GetString("firstname");
                        int age = myReader.GetInt32("age");
                        bool gender = myReader.GetBoolean("gender");

                        Patients patient = new Patients(patientId, userId, name, firstname, age, gender);
                        patients.Add(patient);
                    }
                }

                connection.Close();
                return patients;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving patients by user: " + ex.Message);
            }
        }
    }

    // Ajouter un patient
    public bool Add(Patients patient)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"INSERT INTO Patients ( id_users,name, firstname, age, gender) 
                                         VALUES ( @userID, @name, @firstname, @age, @gender);";
                myCommand.Parameters.AddWithValue("@userID", patient.UserId);
                myCommand.Parameters.AddWithValue("@name", patient.Name);
                myCommand.Parameters.AddWithValue("@firstname", patient.Firstname);
                myCommand.Parameters.AddWithValue("@age", patient.Age);
                myCommand.Parameters.AddWithValue("@gender", patient.Gender);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding patient: " + ex.Message);
            }
        }
    }

    // Mettre à jour un patient
    public bool Update(Patients patient)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"UPDATE Patients SET id_users = @userId, name = @name, 
                                         firstname = @firstname, age = @age, gender = @gender 
                                         WHERE patient_id = @patientId;";
                myCommand.Parameters.AddWithValue("@patientId", patient.PatientID);
                myCommand.Parameters.AddWithValue("@userId", patient.UserId);
                myCommand.Parameters.AddWithValue("@name", patient.Name);
                myCommand.Parameters.AddWithValue("@firstname", patient.Firstname);
                myCommand.Parameters.AddWithValue("@age", patient.Age);
                myCommand.Parameters.AddWithValue("@gender", patient.Gender);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating patient: " + ex.Message);
            }
        }
    }

    // Supprimer un patient
    public bool Delete(int patientId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "DELETE FROM Patients WHERE id_patients = @patientId;";
                myCommand.Parameters.AddWithValue("@patientId", patientId);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting patient: " + ex.Message);
            }
        }
    }
}