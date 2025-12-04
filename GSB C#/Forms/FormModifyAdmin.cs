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

namespace GSB_C_.Forms
{
    public partial class FormModifyAdmin : Form
    {
        private User selectedUser;
        private Patients selectedPatient;
        public FormModifyAdmin()
        {
            InitializeComponent();
        }

        private void FormModifyAdmin_Load(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            List<User> userlist = userDAO.GetAll();
            dataGridViewUser.DataSource = userlist;

            PatientsDAO patientsDAO = new PatientsDAO();
            List<Patients> patientlist = patientsDAO.GetAll();
            dataGridViewPatient.DataSource = patientlist;
        }

        private void dataGridViewUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUser.SelectedRows.Count > 0)
            {
                dataGridViewPatient.ClearSelection();
                selectedPatient = null;
                selectedUser = (User)dataGridViewUser.SelectedRows[0].DataBoundItem;

                textBoxnameUser.Text = selectedUser.Name;
                textBoxfirstnameUser.Text = selectedUser.Firstname;
                textBoxemailUser.Text = selectedUser.Email;
                textBoxpasswordUser.Text = ""; // Ne pas afficher le mot de passe
            }
        }

        private void dataGridViewPatient_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPatient.SelectedRows.Count > 0)
            {
                dataGridViewUser.ClearSelection();
                selectedUser = null;
                selectedPatient = (Patients)dataGridViewPatient.SelectedRows[0].DataBoundItem;

                textBoxnamePatient.Text = selectedPatient.Name;
                textBoxfirstnamePatient.Text = selectedPatient.Firstname;
                textBoxagePatient.Text = selectedPatient.Age.ToString();
                comboBoxGender.SelectedIndex = selectedPatient.Gender ? 1 : 0; // 1 pour Homme, 0 pour Femme
            }
        }

        private void buttonModify_Click(object sender, EventArgs e) // Modification d'un utilisateur ou patient
        {
            try
            {
                if (selectedUser != null)
                {
                    selectedUser.Name = textBoxnameUser.Text;
                    selectedUser.Firstname = textBoxfirstnameUser.Text;
                    selectedUser.Email = textBoxemailUser.Text;
                    // Ne met à jour le mot de passe que s'il est modifié
                    if (!string.IsNullOrWhiteSpace(textBoxpasswordUser.Text))
                    {
                        selectedUser.Password = textBoxpasswordUser.Text;
                    }

                    UserDAO userDAO = new UserDAO();
                    userDAO.update(selectedUser);
                    MessageBox.Show("Utilisateur modifié avec succès !");
                }
                else if (selectedPatient != null)
                {
                    selectedPatient.Name = textBoxnamePatient.Text;
                    selectedPatient.Firstname = textBoxfirstnamePatient.Text;
                    selectedPatient.Age = int.Parse(textBoxagePatient.Text);
                    selectedPatient.Gender = comboBoxGender.SelectedIndex == 1;

                    PatientsDAO patientsDAO = new PatientsDAO();
                    patientsDAO.Update(selectedPatient);
                    MessageBox.Show("Patient modifié avec succès !");
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un utilisateur ou un patient à modifier.");
                    return;
                }

                // Recharger les données
                FormModifyAdmin_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) // Suppression d'un utilisateur ou patient
        {
            try
            {
                if (selectedUser == null && selectedPatient == null)
                {
                    MessageBox.Show("Veuillez sélectionner un utilisateur ou un patient à supprimer.");
                    return;
                }
                // Confirmation de la suppression
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (selectedUser != null)
                    {
                        UserDAO userDAO = new UserDAO();
                        userDAO.Delete(selectedUser.UserId);
                        MessageBox.Show("Utilisateur supprimé avec succès !");
                    }
                    else if (selectedPatient != null)
                    {
                        PatientsDAO patientsDAO = new PatientsDAO();
                        patientsDAO.Delete(selectedPatient.PatientID);
                        MessageBox.Show("Patient supprimé avec succès !");
                    }

                    // Recharger les données
                    FormModifyAdmin_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
        }
    }
}
