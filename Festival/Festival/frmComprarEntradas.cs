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
    public partial class frmComprarEntradas : Form
    {
        frmMenu2 menu;
        public frmComprarEntradas(frmMenu2 sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            this.nombre.Select();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.nombre.Text = "";
            this.apellido.Text = "";
            this.dni.Text = "";
            this.edad.Text = "";
            this.nombre.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (algunCampoVacio() || Convert.ToInt32(this.edad.Text) < 12)
            {
                MessageBox.Show("El cliente es menor de 12 años o le faltaron ingresar datos. Ingrese correctamente los datos.");
                this.nombre.Text = "";
                this.apellido.Text = "";
                this.edad.Text = "";
                this.dni.Text = "";
                this.nombre.Select();
            }
            else
            {
                SqlConnection conexion = SQL_Methods.IniciarConnection();
                SqlCommand consulta = new SqlCommand("SELECT dni_cliente FROM Entrada WHERE dni_cliente='" + dni.Text + "'", conexion);
                SqlDataReader ejecuta = consulta.ExecuteReader();
                if (ejecuta.Read() == true)
                {
                    MessageBox.Show("El cliente ya compro una entrada; por cliente no se vende mas de 1 entrada. Ingrese datos nuevamente.");
                    this.nombre.Text = "";
                    this.apellido.Text = "";
                    this.edad.Text = "";
                    this.dni.Text = "";
                    this.nombre.Select();
                }
                else
                {
                    ejecuta.Close();
                    SqlCommand comando = new SqlCommand("comprarEntrada", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    int monto = 0;
                    if (Convert.ToInt32(edad.Text) < 70)
                    {
                        monto += 350;
                    }
                    else
                    {
                        monto += 120;
                    }
                    comando.Parameters.Add("@dni", SqlDbType.Int).Value = Convert.ToInt32(dni.Text.ToString());
                    comando.Parameters.Add("@mont", SqlDbType.Int).Value = monto;
                    comando.Parameters.Add("@fech", SqlDbType.DateTime).Value = DateTime.Today;
                    SqlDataReader dr = comando.ExecuteReader();
                    MessageBox.Show("La entrada se vendió correctamente.");
                    nombre.Text = "";
                    apellido.Text = "";
                    dni.Text = "";
                    edad.Text = "";
                    this.nombre.Select();
                }
            }
        }
        private bool algunCampoVacio()
        {
            bool condicion = false;
            if (this.nombre.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.apellido.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.edad.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.dni.Text.Trim() == "")
            {
                condicion = true;
            }
            return condicion;
        }
    }
}
