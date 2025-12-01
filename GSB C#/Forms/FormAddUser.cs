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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) // ajout user
        {
            string name = textBoxnameUser.Text;
            string firstname = textBoxfirstnameUser.Text;
            string email = textBoxemailUser.Text;
            string password = textBoxpasswordUser.Text;
            bool role = checkBoxadminUser.Checked;

            User newUser = new User(0, name, firstname, email, password, role);
            UserDAO userDAO = new UserDAO();
            bool success = userDAO.Add(newUser);
            if (success)
            {
                MessageBox.Show("Utilisateur ajouté avec succès !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Échec de l'ajout de l'utilisateur.");
            }

        }
        private void buttonaddPatient_Click(object sender, EventArgs e) // ajout patient
        {
            int selectIndex = comboBoxGender.SelectedIndex;
            int idUserConnect = UserSession.CurrentUser.UserId;

            string name = textBoxnamePatient.Text;
            string firstname = textBoxfirstnamePatient.Text;
            int age = int.Parse(textBoxagePatient.Text);
            int gender = comboBoxGender.SelectedIndex;

            bool isMale = (selectIndex == 1); // bien respecter le sens des rôles dans le combobox, 0 = féminin, 1 = masculin
            
            Patients newPatient = new Patients(0, idUserConnect, name, firstname, age, isMale);
            PatientsDAO patientDAO = new PatientsDAO();
            bool success = patientDAO.Add(newPatient);
            if (success)
            {
                MessageBox.Show("Patient ajouté avec succès !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Échec de l'ajout du patient.");
            }
        }
    }
}
