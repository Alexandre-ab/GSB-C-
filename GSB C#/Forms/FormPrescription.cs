using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSB_C_.Models;
using GSB_C_.Utils;
using GSB2.DAO;
using iTextSharp.text.pdf.parser.clipper;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Bcpg.Sig;



namespace GSB_C_.Forms
{
    public partial class FormPrescription : Form
    {
        private int prescriptionId = 0;// Variable pour stocker l'ID de la prescription sélectionnée
        int idUserConnect = UserSession.CurrentUser.UserId;
        public FormPrescription()
        {
            InitializeComponent();
            PrescriptionDAO presDAO = new PrescriptionDAO();
            List<Prescription> preslist = presDAO.GetAll();


            PatientsDAO Dao = new PatientsDAO();
            List<Patients> patlist = Dao.GetAll();

            comboBoxpatientID.DataSource = patlist;
            comboBoxpatientID.DisplayMember = "Name";
            comboBoxpatientID.ValueMember = "PatientID";


            this.dataGridView1Prescription.DataSource = preslist;
            
        }

        private void FormPrescription_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                // On vérifie qu'on ne clique pas sur l'entête
                if (e.RowIndex >= 0)
                {
                    // On récupère la ligne
                    DataGridViewRow row = dataGridView1Prescription.Rows[e.RowIndex];

                    // ON MET À JOUR LA VARIABLE GLOBALE
                    // (Assure-toi que l'ID est bien dans la colonne 0, sinon change le 0)
                    this.prescriptionId = int.Parse(row.Cells[0].Value.ToString());

                    // On remplit les champs pour aider l'utilisateur
            
                    textUserID.Text = row.Cells[2].Value.ToString();
                    textQuantity.Text = row.Cells[3].Value.ToString();
                    textValidity.Text = row.Cells[4].Value.ToString();
                }// permet de vérifier si on sélectionne une ligne valide
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        // bouton de création d'une prescription 
        private void button1_Click(object sender, EventArgs e)
        {
           
            int userId = int.Parse(textUserID.Text);
            int quantity = int.Parse(textQuantity.Text);
            DateTime validity = DateTime.Parse(textValidity.Text);
            Prescription newPrescription = new Prescription(0,idUserConnect, userId, quantity, validity);
            PrescriptionDAO presDAO = new PrescriptionDAO();
            bool success = presDAO.Add(newPrescription);
            if (success)
            {
                MessageBox.Show("Prescription créée avec succès.");
            }
            else
            {
                MessageBox.Show("Échec de la création de la prescription.");
            }

        }
        // bouton de modification d'une prescription
        private void button2_Click(object sender, EventArgs e)
        {
            if (prescriptionId == 0)
            {
                MessageBox.Show("Veuillez sélectionner une prescription à modifier.");
                return;
            }

           
            int userId = int.Parse(textUserID.Text);
            int quantity = int.Parse(textQuantity.Text);
            DateTime validity = DateTime.Parse(textValidity.Text);
            Prescription updatedPrescription = new Prescription(prescriptionId, idUserConnect, userId, quantity, validity);
            PrescriptionDAO presDAO = new PrescriptionDAO();
            bool success = presDAO.Update(updatedPrescription);
            if (success)
            {
                MessageBox.Show("Prescription modifiée avec succès.");
            }
            else
            {
                MessageBox.Show("Échec de la modification de la prescription.");
            }
        }
        // delete d'une prescription
        private void button3_Click(object sender, EventArgs e)
        {
            if (prescriptionId == 0)
            {
                MessageBox.Show("Veuillez sélectionner une prescription à supprimer.");
                return;
            }
            PrescriptionDAO presDAO = new PrescriptionDAO();
            bool success = presDAO.Delete(prescriptionId);
            if (success)
            {
                MessageBox.Show("Prescription supprimée avec succès.");
            }
            else
            {
                MessageBox.Show("Échec de la suppression de la prescription.");
            }
        }
        //bouton export PDF 
        private void button4_Click(object sender, EventArgs e)

        {
            // 1. SÉCURITÉ
            if (this.prescriptionId == 0)
            {
                MessageBox.Show("Veuillez sélectionner une prescription dans le tableau.");
                return;
            }

            // 2. RÉCUPÉRATION (Avec int.Parse c'est risqué, mais gardons ta logique pour l'instant)
            
            int userId = int.Parse(textUserID.Text);
            int quantity = int.Parse(textQuantity.Text);
            DateTime validity = DateTime.Parse(textValidity.Text);

            // On crée l'objet (On met le vrai ID 'this.prescriptionId' au lieu de 0, c'est plus propre)
            Prescription maPrescription = new Prescription(this.prescriptionId,0, userId, quantity, validity);


            // 3. CALCUL DU CHEMIN "TÉLÉCHARGEMENTS"


            // A. Dossier "Downloads"
            string dossierUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string dossierDownload = Path.Combine(dossierUser, "Downloads");

            // B. Nom du fichier (JUSTE LE NOM, pas C:\\...)
            // J'ajoute un timestamp (date heure) pour ne pas écraser les anciens fichiers
            string nomFichier = $"Prescription_Patient_{userId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            // C. Chemin complet
            string cheminFinal = Path.Combine(dossierDownload, nomFichier);

            // -----------------------------------------------------------
            // 4. GÉNÉRATION
            // -----------------------------------------------------------

            // CORRECTION ICI : On instancie l'outil sans arguments
            ExporterPDF monOutilPdf = new ExporterPDF();

            // On appelle la méthode avec l'objet + le chemin
            bool success = monOutilPdf.ExporterPrescription(maPrescription, cheminFinal);

            if (success)
            {
                MessageBox.Show($"C'est fait !\nFichier enregistré ici :\n{cheminFinal}");

                // Petit bonus : Ouvrir le dossier ou le fichier

            }
            else
            {
                MessageBox.Show("Erreur : Impossible de créer le fichier PDF.");
            }
        }
    }
}




