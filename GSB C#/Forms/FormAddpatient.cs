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
using GSB2.DAO; 







namespace GSB_C_.Forms
{
    public partial class FormAddpatient : Form
    {
        public FormAddpatient()
        {
            InitializeComponent();
            PatientsDAO patientDAO = new PatientsDAO();
            List<Patients> patlist = patientDAO.GetAll();
            this.dataGridView1.DataSource = patlist;

        }

        private void buttonaddPatient_Click(object sender, EventArgs e)
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

