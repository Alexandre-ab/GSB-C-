namespace GSB_C_.Models
{
    public class Rapport
    {
        public int IdRapport { get; set; }
        public int IdUsers { get; set; }
        public int IdPatients { get; set; }
        public DateTime DateVisite { get; set; }
        public string Bilan { get; set; }
        public string Motif { get; set; }

        public Rapport() { }

        public Rapport(int idRapport, int idUsers, int idPatients, DateTime dateVisite, string bilan, string motif)
        {
            IdRapport = idRapport;
            IdUsers = idUsers;
            IdPatients = idPatients;
            DateVisite = dateVisite;
            Bilan = bilan;
            Motif = motif;
        }
    }
}
