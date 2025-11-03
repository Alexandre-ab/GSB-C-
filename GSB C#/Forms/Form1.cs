using System.Text;
using GSB2.DAO;
using System.Security.Cryptography;
using GSB_C_.Forms;
using GSB_C_.Models;
namespace GSB_C_;

public partial class Form1 : Form
{
    public Form1()

    {
        InitializeComponent();

    }

    private void button1_Click(object sender, EventArgs e, UserDAO userDAO)
    {
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(this.textBoxLoginPassword.Text));
            string hashString = BitConverter.ToString(hashValue).Replace("-", "").ToLowerInvariant();
            MessageBox.Show("Login: " + this.textBoxLoginEmail.Text + " Password: " + this.textBoxLoginPassword.Text + " Hash: " + hashString);
            UserDAO userDao = new UserDAO();

            User user = userDAO.Login(textBoxLoginEmail.Text, hashString);

            if (user != null && user.Role == true)
                    
            {
                this.Hide();
                FormAdmin formAdmin = new FormAdmin();
                formAdmin.ShowDialog();
                MessageBox.Show("Login successful! Welcome " + user);
            }
            else if (user != null && user.Role == false)
            {
                this.Hide();
                FormDoctor formUser = new FormDoctor();
                formUser.ShowDialog();
                MessageBox.Show("Login successful! Welcome " + user);
            }
            else
            {
                MessageBox.Show("Login failed! Invalid email or password.");
            }

        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Ajoutez ici le code à exécuter lors du clic sur le bouton "Login"
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void textBoxLoginPassword_TextChanged(object sender, EventArgs e)
    {

    }
}
