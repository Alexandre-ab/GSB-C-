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
                myCommand.CommandText = "SELECT * FROM prescriptions;";

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int prescriptionId = myReader.GetInt32("prescription_id");
                        int patientId = myReader.GetInt32("patient_id");
                        int userId = myReader.GetInt32("user_id");
                        int quantity = myReader.GetInt32("quantity");
                        bool validity = myReader.GetBoolean("validity");

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
                myCommand.CommandText = "SELECT * FROM prescriptions WHERE prescription_id = @prescriptionId;";
                myCommand.Parameters.AddWithValue("@prescriptionId", prescriptionId);

                using var myReader = myCommand.ExecuteReader();
                {
                    if (myReader.Read())
                    {
                        int patientId = myReader.GetInt32("patient_id");
                        int userId = myReader.GetInt32("user_id");
                        int quantity = myReader.GetInt32("quantity");
                        bool validity = myReader.GetBoolean("validity");

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
                myCommand.CommandText = "SELECT * FROM prescriptions WHERE patient_id = @patientId;";
                myCommand.Parameters.AddWithValue("@patientId", patientId);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int prescriptionId = myReader.GetInt32("prescription_id");
                        int userId = myReader.GetInt32("user_id");
                        int quantity = myReader.GetInt32("quantity");
                        bool validity = myReader.GetBoolean("validity");

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
                myCommand.CommandText = "SELECT * FROM prescriptions WHERE user_id = @userId;";
                myCommand.Parameters.AddWithValue("@userId", userId);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int prescriptionId = myReader.GetInt32("prescription_id");
                        int patientId = myReader.GetInt32("patient_id");
                        int quantity = myReader.GetInt32("quantity");
                        bool validity = myReader.GetBoolean("validity");

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
                myCommand.CommandText = @"INSERT INTO prescriptions (patient_id, user_id, quantity, validity) 
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
                myCommand.CommandText = @"UPDATE prescriptions SET patient_id = @patientId, user_id = @userId, 
                                         quantity = @quantity, validity = @validity 
                                         WHERE prescription_id = @prescriptionId;";
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
                myCommand.CommandText = "DELETE FROM prescriptions WHERE prescription_id = @prescriptionId;";
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