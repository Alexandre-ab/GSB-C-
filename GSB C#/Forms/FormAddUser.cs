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
            MessageBox.Show("Bienvenue sur la page de création de compte.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roleIndex = comboBoxroleUser.SelectedIndex; // Récupérer l'index sélectionné dans le ComboBox


            string name = textBoxnameUser.Text;
            string firstname = textBoxfirstnameUser.Text;
            string email = textBoxemailUser.Text;
            string password = textBoxpasswordUser.Text;
            int role = comboBoxroleUser.SelectedIndex;
            bool isAdmin = (roleIndex == 1); // bien respecter le sens des rôles dans le combobox, 0 = utilisateur, 1 = administrateur


            User newUser = new User(0, name, firstname, email, password, role == 1);
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

        private void comboBoxroleUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
