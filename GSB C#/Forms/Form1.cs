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

    private void button1_Click(object sender, EventArgs e)
    {
        UserDAO userDao = new UserDAO();
        User user = userDao.Login(textBoxLoginEmail.Text, textBoxLoginPassword.Text);
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

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }
}
