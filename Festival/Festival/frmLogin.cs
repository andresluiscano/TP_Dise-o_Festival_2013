using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Festival
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection miConexion = new SqlConnection (@"Data Source=WOLF\SQLSERVER2008; Initial Catalog=Festival; Integrated Security=true");
 
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Form Form2 = new frmMenu2();
            miConexion.Open();
            SqlCommand consulta= new SqlCommand("SELECT * FROM usuarios WHERE usuario='"+txtUser.Text+"' and password='"+txtPass.Text+"'", miConexion);
            SqlDataReader ejecuta = consulta.ExecuteReader();

            if (ejecuta.Read() == true)
            {
                MessageBox.Show("Bienvenido: "+ txtUser.Text, "Login");
                this.Hide();
                Form2.Show();
            }
            else
            {
                MessageBox.Show("Ingrese correctamente los datos", "ERROR");
                txtUser.Text = "";
                txtPass.Text = "";
                txtUser.Focus();
             }
            miConexion.Close();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
