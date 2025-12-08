using System.Text;
using GSB2.DAO;
using System.Security.Cryptography;
using GSB_C_.Forms;
using GSB_C_.Models;
namespace GSB_C_
{
    public partial class Form1 : Form
    {
        public Form1()

        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDAO userDao = new UserDAO();
            User user = userDao.Login(textBoxLoginEmail.Text, textBoxLoginPassword.Text);
            if (user != null && user.Role == true)

            {
                //User test = user;
                UserSession.CurrentUser = user;
                this.Hide();
                FormAdmin formAdmin = new FormAdmin();
                MessageBox.Show("Login successful! Welcome " + user);
                formAdmin.ShowDialog();

            }
            else if (user != null && user.Role == false)
            {
                UserSession.CurrentUser = user;
                this.Hide();
                FormDoctor formUser = new FormDoctor();
                MessageBox.Show("Login successful! Welcome " + user);
                formUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login failed! Invalid email or password.");
            }

        }

        private void linkLabelCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
