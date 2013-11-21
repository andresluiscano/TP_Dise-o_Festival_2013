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
            this.txtUser.Select();
        }

        SqlConnection conexionAlternativa = SQL_Methods.IniciarConnection();

        // SqlConnection miConexion = new SqlConnection (@"Data Source=JOAQO-TOSHIBA\SQLSERVER2008; Initial Catalog=TP-ROCK; Integrated Security=true");
 
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Form Form2 = new frmMenu2();
            //miConexion.Open();
            //SqlCommand consulta= new SqlCommand("SELECT * FROM Usuario WHERE nombre='"+txtUser.Text+"' and password='"+txtPass.Text+"'", miConexion);
            SqlCommand consulta = new SqlCommand("SELECT * FROM Usuario WHERE nombre='" + txtUser.Text + "' and password='" + txtPass.Text + "'", conexionAlternativa);
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
                this.txtUser.Select();
             }
            //miConexion.Close();
            conexionAlternativa.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
