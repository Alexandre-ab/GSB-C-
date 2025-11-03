using GSB_C_.Models;
using GSB2.DAO;
using MySql.Data.MySqlClient;

public class AppartientDAO
{
    private readonly Database db = new Database();

    // Récupérer toutes les associations
    public List<Appartient> GetAll()
    {
        List<Appartient> appartients = new List<Appartient>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM appartient;";

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int prescriptionId = myReader.GetInt32("prescription_id");
                        int medicineId = myReader.GetInt32("medicine_id");

                        Appartient appartient = new Appartient(prescriptionId, medicineId);
                        appartients.Add(appartient);
                    }
                }

                connection.Close();
                return appartients;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving appartient records: " + ex.Message);
            }
        }
    }

    // Récupérer les médicaments d'une prescription
    public List<int> GetMedicinesByPrescriptionId(int prescriptionId)
    {
        List<int> medicineIds = new List<int>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT medicine_id FROM appartient WHERE prescription_id = @prescriptionId;";
                myCommand.Parameters.AddWithValue("@prescriptionId", prescriptionId);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int medicineId = myReader.GetInt32("medicine_id");
                        medicineIds.Add(medicineId);
                    }
                }

                connection.Close();
                return medicineIds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving medicines by prescription: " + ex.Message);
            }
        }
    }

    // Récupérer les prescriptions d'un médicament
    public List<int> GetPrescriptionsByMedicineId(int medicineId)
    {
        List<int> prescriptionIds = new List<int>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT prescription_id FROM appartient WHERE medicine_id = @medicineId;";
                myCommand.Parameters.AddWithValue("@medicineId", medicineId);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int prescriptionId = myReader.GetInt32("prescription_id");
                        prescriptionIds.Add(prescriptionId);
                    }
                }

                connection.Close();
                return prescriptionIds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving prescriptions by medicine: " + ex.Message);
            }
        }
    }

    // Ajouter une association
    public bool Add(Appartient appartient)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"INSERT INTO appartient (prescription_id, medicine_id) 
                                         VALUES (@prescriptionId, @medicineId);";
                myCommand.Parameters.AddWithValue("@prescriptionId", appartient.PrescriptionId);
                myCommand.Parameters.AddWithValue("@medicineId", appartient.MedicineId);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding appartient record: " + ex.Message);
            }
        }
    }

    // Supprimer une association spécifique
    public bool Delete(int prescriptionId, int medicineId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"DELETE FROM appartient 
                                         WHERE prescription_id = @prescriptionId AND medicine_id = @medicineId;";
                myCommand.Parameters.AddWithValue("@prescriptionId", prescriptionId);
                myCommand.Parameters.AddWithValue("@medicineId", medicineId);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting appartient record: " + ex.Message);
            }
        }
    }

    // Supprimer toutes les associations d'une prescription
    public bool DeleteByPrescriptionId(int prescriptionId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "DELETE FROM appartient WHERE prescription_id = @prescriptionId;";
                myCommand.Parameters.AddWithValue("@prescriptionId", prescriptionId);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting appartient records by prescription: " + ex.Message);
            }
        }
    }

    // Supprimer toutes les associations d'un médicament
    public bool DeleteByMedicineId(int medicineId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "DELETE FROM appartient WHERE medicine_id = @medicineId;";
                myCommand.Parameters.AddWithValue("@medicineId", medicineId);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting appartient records by medicine: " + ex.Message);
            }
        }
    }
}