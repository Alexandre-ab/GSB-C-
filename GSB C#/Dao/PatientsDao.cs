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
                myCommand.CommandText = "SELECT * FROM patients;";

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int patientId = myReader.GetInt32("patient_id");
                        int userId = myReader.GetInt32("user_id");
                        string name = myReader.GetString("name");
                        string firstname = myReader.GetString("firstname");
                        string lastname = myReader.GetString("lastname");
                        int age = myReader.GetInt32("age");
                        bool gender = myReader.GetBoolean("gender");

                        Patients patient = new Patients(patientId, userId, name, firstname, lastname, age, gender);
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
                myCommand.CommandText = "SELECT * FROM patients WHERE patient_id = @patientId;";
                myCommand.Parameters.AddWithValue("@patientId", patientId);

                using var myReader = myCommand.ExecuteReader();
                {
                    if (myReader.Read())
                    {
                        int userId = myReader.GetInt32("user_id");
                        string name = myReader.GetString("name");
                        string firstname = myReader.GetString("firstname");
                        string lastname = myReader.GetString("lastname");
                        int age = myReader.GetInt32("age");
                        bool gender = myReader.GetBoolean("gender");

                        return new Patients(patientId, userId, name, firstname, lastname, age, gender);
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
                myCommand.CommandText = "SELECT * FROM patients WHERE user_id = @userId;";
                myCommand.Parameters.AddWithValue("@userId", userId);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int patientId = myReader.GetInt32("patient_id");
                        string name = myReader.GetString("name");
                        string firstname = myReader.GetString("firstname");
                        string lastname = myReader.GetString("lastname");
                        int age = myReader.GetInt32("age");
                        bool gender = myReader.GetBoolean("gender");

                        Patients patient = new Patients(patientId, userId, name, firstname, lastname, age, gender);
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
                myCommand.CommandText = @"INSERT INTO patients (user_id, name, firstname, lastname, age, gender) 
                                         VALUES (@userId, @name, @firstname, @lastname, @age, @gender);";
                myCommand.Parameters.AddWithValue("@userId", patient.UserId);
                myCommand.Parameters.AddWithValue("@name", patient.Name);
                myCommand.Parameters.AddWithValue("@firstname", patient.Firstname);
                myCommand.Parameters.AddWithValue("@lastname", patient.Lastname);
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
                myCommand.CommandText = @"UPDATE patients SET user_id = @userId, name = @name, 
                                         firstname = @firstname, lastname = @lastname, age = @age, gender = @gender 
                                         WHERE patient_id = @patientId;";
                myCommand.Parameters.AddWithValue("@patientId", patient.PatientID);
                myCommand.Parameters.AddWithValue("@userId", patient.UserId);
                myCommand.Parameters.AddWithValue("@name", patient.Name);
                myCommand.Parameters.AddWithValue("@firstname", patient.Firstname);
                myCommand.Parameters.AddWithValue("@lastname", patient.Lastname);
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
                myCommand.CommandText = "DELETE FROM patients WHERE patient_id = @patientId;";
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