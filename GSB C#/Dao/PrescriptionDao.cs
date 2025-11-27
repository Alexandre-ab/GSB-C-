using GSB_C_.Models;
using GSB2.DAO;
using MySql.Data.MySqlClient;

public class PrescriptionDAO
{
    private readonly Database db = new Database();

    // Récupérer toutes les prescriptions
    public List<Prescription> GetAll()
    {
        List<Prescription> prescriptions = new List<Prescription>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Prescription;";

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int prescriptionId = myReader.GetInt32("id_prescription");
                        int patientId = myReader.GetInt32("id_patients");
                        int userId = myReader.GetInt32("id_users");
                        int quantity = myReader.GetInt32("quantity");
                        DateTime validity = myReader.GetDateTime("validity");

                        Prescription prescription = new Prescription(prescriptionId, patientId, userId, quantity, validity);
                        prescriptions.Add(prescription);
                    }
                }

                connection.Close();
                return prescriptions;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving prescriptions: " + ex.Message);
            }
        }
    }

    // Récupérer une prescription par ID
    public Prescription GetById(int prescriptionId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Prescription WHERE id_prescription = @prescriptionId;";
                myCommand.Parameters.AddWithValue("@prescriptionId", prescriptionId);

                using var myReader = myCommand.ExecuteReader();
                {
                    if (myReader.Read())
                    {
                        int patientId = myReader.GetInt32("id_patients");
                        int userId = myReader.GetInt32("users_id");
                        int quantity = myReader.GetInt32("quantity");
                        DateTime validity = myReader.GetDateTime("validity");

                        return new Prescription(prescriptionId, patientId, userId, quantity, validity);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving prescription: " + ex.Message);
            }
        }
    }

    // Récupérer les prescriptions par patient
    public List<Prescription> GetByPatientId(int patientId)
    {
        List<Prescription> prescriptions = new List<Prescription>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Prescriptions WHERE id_patients= @patientId;";
                myCommand.Parameters.AddWithValue("@patientId", patientId);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int prescriptionId = myReader.GetInt32("id_prescription");
                        int userId = myReader.GetInt32("id_users");
                        int quantity = myReader.GetInt32("quantity");
                        DateTime validity = myReader.GetDateTime("validity");

                        Prescription prescription = new Prescription(prescriptionId, patientId, userId, quantity, validity);
                        prescriptions.Add(prescription);
                    }
                }

                connection.Close();
                return prescriptions;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving prescriptions by patient: " + ex.Message);
            }
        }
    }

    // Récupérer les prescriptions par utilisateur
    public List<Prescription> GetByUserId(int userId)
    {
        List<Prescription> prescriptions = new List<Prescription>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Prescription WHERE id_users = @userId;";
                myCommand.Parameters.AddWithValue("@userId", userId);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int prescriptionId = myReader.GetInt32("id_prescription");
                        int patientId = myReader.GetInt32("id_patients");
                        int quantity = myReader.GetInt32("quantity");
                        DateTime validity = myReader.GetDateTime("validity");

                        Prescription prescription = new Prescription(prescriptionId, patientId, userId, quantity, validity);
                        prescriptions.Add(prescription);
                    }
                }

                connection.Close();
                return prescriptions;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving prescriptions by user: " + ex.Message);
            }
        }
    }

    // Ajouter une prescription
    public bool Add(Prescription prescription)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"INSERT INTO Prescription (id_patients, id_users, quantity, validity) 
                                         VALUES (@patientId, @userId, @quantity, @validity);";
                myCommand.Parameters.AddWithValue("@patientId", prescription.patientId);
                myCommand.Parameters.AddWithValue("@userId", prescription.UserId);
                myCommand.Parameters.AddWithValue("@quantity", prescription.Quantity);
                myCommand.Parameters.AddWithValue("@validity", prescription.Validity);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding prescription: " + ex.Message);
            }
        }
    }

    // Mettre à jour une prescription
    public bool Update(Prescription prescription)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"UPDATE Prescription SET id_patients = @patientId, id_users = @userId, 
                                         quantity = @quantity, validity = @validity 
                                         WHERE id_prescription = @prescriptionId;";
                myCommand.Parameters.AddWithValue("@prescriptionId", prescription.prescriptionId);
                myCommand.Parameters.AddWithValue("@patientId", prescription.patientId);
                myCommand.Parameters.AddWithValue("@userId", prescription.UserId);
                myCommand.Parameters.AddWithValue("@quantity", prescription.Quantity);
                myCommand.Parameters.AddWithValue("@validity", prescription.Validity);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating prescription: " + ex.Message);
            }
        }
    }

    // Supprimer une prescription
    public bool Delete(int prescriptionId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "DELETE FROM Prescription WHERE id_prescription = @prescriptionId;";
                myCommand.Parameters.AddWithValue("@prescriptionId", prescriptionId);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting prescription: " + ex.Message);
            }
        }
    }
}