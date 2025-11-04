using GSB_C_.Models;
using GSB2.DAO;
using MySql.Data.MySqlClient;

public class MedicineDAO
{
    private readonly Database db = new Database();

    // Récupérer tous les médicaments
    public List<Medicine> GetAll()
    {
        List<Medicine> medicines = new List<Medicine>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Medicine;";

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int medicineId = myReader.GetInt32("id_medicine");
                        int userId = myReader.GetInt32("id_users");
                        string name = myReader.GetString("name");
                        string molecule = myReader.GetString("molecule");
                        string dosage = myReader.GetString("dosage");
                        string description = myReader.GetString("description");

                        Medicine medicine = new Medicine(medicineId, userId, name, molecule, dosage, description);
                        medicines.Add(medicine);
                    }
                }

                connection.Close();
                return medicines;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving medicines: " + ex.Message);
            }
        }
    }

    // Récupérer un médicament par ID
    public Medicine GetById(int medicineId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Medicine WHERE id_medicine = @medicineId;";
                myCommand.Parameters.AddWithValue("@medicineId", medicineId);

                using var myReader = myCommand.ExecuteReader();
                {
                    if (myReader.Read())
                    {
                        int userId = myReader.GetInt32("id_users");
                        string name = myReader.GetString("name");
                        string molecule = myReader.GetString("molecule");
                        string dosage = myReader.GetString("dosage");
                        string description = myReader.GetString("description");

                        return new Medicine(medicineId, userId, name, molecule, dosage, description);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving medicine: " + ex.Message);
            }
        }
    }

    // Récupérer les médicaments par utilisateur
    public List<Medicine> GetByUserId(int userId)
    {
        List<Medicine> medicines = new List<Medicine>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "SELECT * FROM Medicine WHERE id_users = @userId;";
                myCommand.Parameters.AddWithValue("@userId", userId);
                    
                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        int medicineId = myReader.GetInt32("id_medicine");
                        string name = myReader.GetString("name");
                        string molecule = myReader.GetString("molecule");
                        string dosage = myReader.GetString("dosage");
                        string description = myReader.GetString("description");

                        Medicine medicine = new Medicine(medicineId, userId, name, molecule, dosage, description);
                        medicines.Add(medicine);
                    }
                }

                connection.Close();
                return medicines;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving medicines by user: " + ex.Message);
            }
        }
    }

    // Ajouter un médicament
    public bool Add(Medicine medicine)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"INSERT INTO Medicine (id_users, name, molecule, dosage, description) 
                                         VALUES (@userId, @name, @molecule, @dosage, @description);";
                myCommand.Parameters.AddWithValue("@userId", medicine.UserId);
                myCommand.Parameters.AddWithValue("@name", medicine.Name);
                myCommand.Parameters.AddWithValue("@molecule", medicine.Molecule);
                myCommand.Parameters.AddWithValue("@dosage", medicine.Dosage);
                myCommand.Parameters.AddWithValue("@description", medicine.Description);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding medicine: " + ex.Message);
            }
        }
    }

    // Mettre à jour un médicament
    public bool Update(Medicine medicine)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"UPDATE Medicine SET id_users = @userId, name = @name, 
                                         molecule = @molecule, dosage = @dosage, description = @description 
                                         WHERE id_medecine = @medicineId;";
                myCommand.Parameters.AddWithValue("@medicineId", medicine.MedecineId);
                myCommand.Parameters.AddWithValue("@userId", medicine.UserId);
                myCommand.Parameters.AddWithValue("@name", medicine.Name);
                myCommand.Parameters.AddWithValue("@molecule", medicine.Molecule);
                myCommand.Parameters.AddWithValue("@dosage", medicine.Dosage);
                myCommand.Parameters.AddWithValue("@description", medicine.Description);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating medicine: " + ex.Message);
            }
        }
    }

    // Supprimer un médicament
    public bool Delete(int medicineId)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = "DELETE FROM Medicine WHERE id_medicine = @medicineId;";
                myCommand.Parameters.AddWithValue("@medicineId", medicineId);

                int rowsAffected = myCommand.ExecuteNonQuery();
                connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting medicine: " + ex.Message);
            }
        }
    }
}