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
                myCommand.CommandText = @"SELECT p.*, pat.name as NomDuPatient 
                          FROM Prescription p
                          JOIN Patients pat ON p.id_patients = pat.id_patients";

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
                        prescription.NomAffichage = myReader.GetString("NomDuPatient");
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

    // Récupérer les prescriptions sur une période donnée
    public List<Prescription> GetByDateRange(DateTime dateDebut, DateTime dateFin)
    {
        List<Prescription> prescriptions = new List<Prescription>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"SELECT p.*, pat.name as NomDuPatient 
                      FROM Prescription p
                      JOIN Patients pat ON p.id_patients = pat.id_patients
                      WHERE p.validity >= @dateDebut AND p.validity <= @dateFin
                      ORDER BY p.validity DESC";

                myCommand.Parameters.AddWithValue("@dateDebut", dateDebut);
                myCommand.Parameters.AddWithValue("@dateFin", dateFin);

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
                        prescription.NomAffichage = myReader.GetString("NomDuPatient");
                        prescriptions.Add(prescription);
                    }
                }

                connection.Close();
                return prescriptions;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving prescriptions by date range: " + ex.Message);
            }
        }
    }

    // 1. Nombre total de prescriptions sur une période
    public int GetCountByDateRange(DateTime dateDebut, DateTime dateFin)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"SELECT COUNT(*) 
                      FROM Prescription 
                      WHERE validity >= @dateDebut AND validity <= @dateFin";

                myCommand.Parameters.AddWithValue("@dateDebut", dateDebut);
                myCommand.Parameters.AddWithValue("@dateFin", dateFin);

                int count = Convert.ToInt32(myCommand.ExecuteScalar());
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting prescriptions: " + ex.Message);
            }
        }
    }

    // 2. Nombre de prescriptions par patient (sur une période)
    public Dictionary<string, int> GetCountByPatient(DateTime dateDebut, DateTime dateFin)
    {
        Dictionary<string, int> stats = new Dictionary<string, int>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"SELECT 
                      CONCAT(pat.firstname, ' ', pat.name) as NomComplet,
                      COUNT(*) as NbPrescriptions
                      FROM Prescription p
                      JOIN Patients pat ON p.id_patients = pat.id_patients
                      WHERE p.validity >= @dateDebut AND p.validity <= @dateFin
                      GROUP BY p.id_patients, pat.firstname, pat.name
                      ORDER BY NbPrescriptions DESC";

                myCommand.Parameters.AddWithValue("@dateDebut", dateDebut);
                myCommand.Parameters.AddWithValue("@dateFin", dateFin);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        string nomComplet = myReader.GetString("NomComplet");
                        int nbPrescriptions = myReader.GetInt32("NbPrescriptions");
                        stats.Add(nomComplet, nbPrescriptions);
                    }
                }

                connection.Close();
                return stats;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting prescriptions by patient: " + ex.Message);
            }
        }
    }

    // 3. Nombre de prescriptions par praticien (utilisateur/docteur) sur une période
    public Dictionary<string, int> GetCountByPractitioner(DateTime dateDebut, DateTime dateFin)
    {
        Dictionary<string, int> stats = new Dictionary<string, int>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"SELECT 
                      CONCAT(u.firstname, ' ', u.name) as NomComplet,
                      COUNT(*) as NbPrescriptions
                      FROM Prescription p
                      JOIN Users u ON p.id_users = u.id_users
                      WHERE p.validity >= @dateDebut AND p.validity <= @dateFin
                      GROUP BY p.id_users, u.firstname, u.name
                      ORDER BY NbPrescriptions DESC";

                myCommand.Parameters.AddWithValue("@dateDebut", dateDebut);
                myCommand.Parameters.AddWithValue("@dateFin", dateFin);

                using var myReader = myCommand.ExecuteReader();
                {
                    while (myReader.Read())
                    {
                        string nomComplet = myReader.GetString("NomComplet");
                        int nbPrescriptions = myReader.GetInt32("NbPrescriptions");
                        stats.Add(nomComplet, nbPrescriptions);
                    }
                }

                connection.Close();
                return stats;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting prescriptions by practitioner: " + ex.Message);
            }
        }
    }

    // 4. Nombre moyen de médicaments par ordonnance (sur une période)
    public double GetAverageMedicinesPerPrescription(DateTime dateDebut, DateTime dateFin)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;

                // On compte le nombre de lignes dans Appartient pour chaque prescription sur la période
                myCommand.CommandText = @"
                SELECT AVG(nb_medicines) as moyenne
                FROM (
                    SELECT p.id_prescription, COUNT(a.id_medicine) as nb_medicines
                    FROM Prescription p
                    LEFT JOIN Appartient a ON p.id_prescription = a.id_prescription
                    WHERE p.validity >= @dateDebut AND p.validity <= @dateFin
                    GROUP BY p.id_prescription
                ) as sub";

                myCommand.Parameters.AddWithValue("@dateDebut", dateDebut);
                myCommand.Parameters.AddWithValue("@dateFin", dateFin);

                var result = myCommand.ExecuteScalar();
                connection.Close();

                // Si aucune prescription, retourner 0
                if (result == DBNull.Value || result == null)
                    return 0;

                return Convert.ToDouble(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating average medicines per prescription: " + ex.Message);
            }
        }
    }

    // 5. Quantité totale prescrite (sur une période)
    public int GetTotalQuantityPrescribed(DateTime dateDebut, DateTime dateFin)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"SELECT IFNULL(SUM(quantity), 0) 
                      FROM Prescription 
                      WHERE validity >= @dateDebut AND validity <= @dateFin";

                myCommand.Parameters.AddWithValue("@dateDebut", dateDebut);
                myCommand.Parameters.AddWithValue("@dateFin", dateFin);

                int total = Convert.ToInt32(myCommand.ExecuteScalar());
                connection.Close();
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating total quantity: " + ex.Message);
            }
        }

    }

    // Récupérer les prescriptions sans médicaments (anomalies) sur une période
    public List<Prescription> GetPrescriptionsWithoutMedicines(DateTime dateDebut, DateTime dateFin)
    {
        List<Prescription> prescriptions = new List<Prescription>();

        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"
                SELECT p.*, pat.name as NomDuPatient, pat.firstname as PrenomDuPatient,
                       u.name as NomDocteur, u.firstname as PrenomDocteur
                FROM Prescription p
                JOIN Patients pat ON p.id_patients = pat.id_patients
                JOIN Users u ON p.id_users = u.id_users
                LEFT JOIN Appartient a ON p.id_prescription = a.id_prescription
                WHERE p.validity >= @dateDebut 
                  AND p.validity <= @dateFin
                  AND a.id_medicine IS NULL
                ORDER BY p.validity DESC";

                myCommand.Parameters.AddWithValue("@dateDebut", dateDebut);
                myCommand.Parameters.AddWithValue("@dateFin", dateFin);

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
                        prescription.NomAffichage = myReader.GetString("PrenomDuPatient") + " " + myReader.GetString("NomDuPatient");
                        prescriptions.Add(prescription);
                    }
                }

                connection.Close();
                return prescriptions;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving prescriptions without medicines: " + ex.Message);
            }
        }
    }

    // Compter le nombre total d'ordonnances sans médicaments
    public int GetCountPrescriptionsWithoutMedicines(DateTime dateDebut, DateTime dateFin)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();

                MySqlCommand myCommand = new MySqlCommand();
                myCommand.Connection = connection;
                myCommand.CommandText = @"
                SELECT COUNT(DISTINCT p.id_prescription) as total
                FROM Prescription p
                LEFT JOIN Appartient a ON p.id_prescription = a.id_prescription
                WHERE p.validity >= @dateDebut 
                  AND p.validity <= @dateFin
                  AND a.id_medicine IS NULL";

                myCommand.Parameters.AddWithValue("@dateDebut", dateDebut);
                myCommand.Parameters.AddWithValue("@dateFin", dateFin);

                int count = Convert.ToInt32(myCommand.ExecuteScalar());
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting prescriptions without medicines: " + ex.Message);
            }
        }
    }
}

