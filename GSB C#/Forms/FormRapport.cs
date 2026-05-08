using GSB_C_.Models;

namespace GSB_C_.Forms
{
    public partial class FormRapport : Form
    {
        private readonly RapportDao rapportDao = new RapportDao();
        private readonly PatientsDAO patientsDao = new PatientsDAO();
        private List<Rapport> rapports = new List<Rapport>();
        private List<Patients> patients = new List<Patients>();

        public FormRapport()
        {
            InitializeComponent();
            ChargerPatients();
            ChargerRapports();
        }

        private void ChargerPatients()
        {
            patients = patientsDao.GetAll();
            comboBoxPatient.DataSource = patients;
            comboBoxPatient.DisplayMember = "Name";
            comboBoxPatient.ValueMember = "PatientID";
        }

        private void ChargerRapports()
        {
            bool isAdmin = UserSession.CurrentUser.Role;
            if (isAdmin)
                rapports = rapportDao.GetAll();
            else
                rapports = rapportDao.GetByUser(UserSession.CurrentUser.UserId);

            dataGridViewRapports.DataSource = null;
            dataGridViewRapports.DataSource = rapports;
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMotif.Text))
            {
                MessageBox.Show("Le motif est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Rapport r = new Rapport(
                0,
                UserSession.CurrentUser.UserId,
                (int)comboBoxPatient.SelectedValue,
                dateTimePickerVisite.Value.Date,
                textBoxBilan.Text,
                textBoxMotif.Text
            );
            rapportDao.Add(r);
            ChargerRapports();
            ViderChamps();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (dataGridViewRapports.CurrentRow == null) return;
            if (string.IsNullOrWhiteSpace(textBoxMotif.Text))
            {
                MessageBox.Show("Le motif est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Rapport r = rapports[dataGridViewRapports.CurrentRow.Index];
            r.IdPatients = (int)comboBoxPatient.SelectedValue;
            r.DateVisite = dateTimePickerVisite.Value.Date;
            r.Motif = textBoxMotif.Text;
            r.Bilan = textBoxBilan.Text;
            rapportDao.Update(r);
            ChargerRapports();
            ViderChamps();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridViewRapports.CurrentRow == null) return;

            DialogResult confirm = MessageBox.Show("Supprimer ce rapport ?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            Rapport r = rapports[dataGridViewRapports.CurrentRow.Index];
            rapportDao.Delete(r.IdRapport);
            ChargerRapports();
            ViderChamps();
        }

        private void dataGridViewRapports_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRapports.CurrentRow == null || rapports.Count == 0) return;
            int index = dataGridViewRapports.CurrentRow.Index;
            if (index < 0 || index >= rapports.Count) return;

            Rapport r = rapports[index];
            comboBoxPatient.SelectedValue = r.IdPatients;
            dateTimePickerVisite.Value = r.DateVisite;
            textBoxMotif.Text = r.Motif;
            textBoxBilan.Text = r.Bilan;
        }

        private void buttonRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViderChamps()
        {
            textBoxMotif.Text = "";
            textBoxBilan.Text = "";
            dateTimePickerVisite.Value = DateTime.Today;
            if (patients.Count > 0)
                comboBoxPatient.SelectedIndex = 0;
        }
    }
}
