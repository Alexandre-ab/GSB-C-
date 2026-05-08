using GSB_C_.Models;
using GSB2.DAO;
using MySql.Data.MySqlClient;

public class RapportDao
{
    private readonly Database db = new Database();

    public List<Rapport> GetByUser(int idUsers)
    {
        List<Rapport> rapports = new List<Rapport>();
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Rapport WHERE id_users = @idUsers ORDER BY date_visite DESC";
                cmd.Parameters.AddWithValue("@idUsers", idUsers);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rapports.Add(new Rapport(
                        reader.GetInt32("id_rapport"),
                        reader.GetInt32("id_users"),
                        reader.GetInt32("id_patients"),
                        reader.GetDateTime("date_visite"),
                        reader.IsDBNull(reader.GetOrdinal("bilan")) ? "" : reader.GetString("bilan"),
                        reader.GetString("motif")
                    ));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur récupération rapports: " + ex.Message);
            }
        }
        return rapports;
    }

    public List<Rapport> GetAll()
    {
        List<Rapport> rapports = new List<Rapport>();
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Rapport ORDER BY date_visite DESC";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rapports.Add(new Rapport(
                        reader.GetInt32("id_rapport"),
                        reader.GetInt32("id_users"),
                        reader.GetInt32("id_patients"),
                        reader.GetDateTime("date_visite"),
                        reader.IsDBNull(reader.GetOrdinal("bilan")) ? "" : reader.GetString("bilan"),
                        reader.GetString("motif")
                    ));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur récupération rapports: " + ex.Message);
            }
        }
        return rapports;
    }

    public bool Add(Rapport rapport)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO Rapport (id_users, id_patients, date_visite, motif, bilan)
                                    VALUES (@idUsers, @idPatients, @dateVisite, @motif, @bilan)";
                cmd.Parameters.AddWithValue("@idUsers", rapport.IdUsers);
                cmd.Parameters.AddWithValue("@idPatients", rapport.IdPatients);
                cmd.Parameters.AddWithValue("@dateVisite", rapport.DateVisite);
                cmd.Parameters.AddWithValue("@motif", rapport.Motif);
                cmd.Parameters.AddWithValue("@bilan", rapport.Bilan);
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur ajout rapport: " + ex.Message);
            }
        }
    }

    public bool Update(Rapport rapport)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"UPDATE Rapport SET id_patients = @idPatients, date_visite = @dateVisite,
                                    motif = @motif, bilan = @bilan WHERE id_rapport = @idRapport";
                cmd.Parameters.AddWithValue("@idPatients", rapport.IdPatients);
                cmd.Parameters.AddWithValue("@dateVisite", rapport.DateVisite);
                cmd.Parameters.AddWithValue("@motif", rapport.Motif);
                cmd.Parameters.AddWithValue("@bilan", rapport.Bilan);
                cmd.Parameters.AddWithValue("@idRapport", rapport.IdRapport);
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur modification rapport: " + ex.Message);
            }
        }
    }

    public bool Delete(int idRapport)
    {
        using (var connection = db.GetConnection())
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"DELETE FROM Rapport WHERE id_rapport = @idRapport";
                cmd.Parameters.AddWithValue("@idRapport", idRapport);
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur suppression rapport: " + ex.Message);
            }
        }
    }
}
