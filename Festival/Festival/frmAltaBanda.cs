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
    public partial class frmAltaBanda : Form
    {
        frmMenu2 menu;
        bool modificar = false;
        string bandaAModificar = null;
        public frmAltaBanda(frmMenu2 sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            this.nombreBanda.Select();
        }
        public frmAltaBanda(frmMenu2 sender, bool modificacion, string banda)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            this.nombreBanda.Select();
            modificar = modificacion;
            bandaAModificar = banda;
            this.nombreBanda.Text = bandaAModificar;
            this.cantIntegrantes.Select();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            SqlCommand consulta = new SqlCommand("SELECT nombre FROM GrupoMusical WHERE nombre='" + nombreBanda.Text + "'", conexion);
            SqlDataReader ejecuta = consulta.ExecuteReader();
            if (modificar == false)
            {
                if (ejecuta.HasRows == true || algunCampoVacio())
                {
                    MessageBox.Show("La banda ingresada ya existe o le faltaron ingresar datos. Ingrese correctamente los datos.");
                    nombreBanda.Text = "";
                    cantIntegrantes.Text = "";
                    this.nombreBanda.Select();
                }
                else
                {
                    ejecuta.Close();
                    SqlCommand comando = new SqlCommand("insertarBanda", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@nom", SqlDbType.VarChar, 100).Value = nombreBanda.Text;
                    comando.Parameters.Add("@cint", SqlDbType.Int).Value = Convert.ToInt32(cantIntegrantes.Text);
                    SqlDataReader dr = comando.ExecuteReader();
                    MessageBox.Show("La banda se ingresó correctamente.");
                    nombreBanda.Text = "";
                    cantIntegrantes.Text = "";
                    this.nombreBanda.Select();
                }
            }
            else
            {
                if (algunCampoVacio())
                {
                    MessageBox.Show("Le faltaron ingresar datos. Ingrese correctamente los datos.");
                    nombreBanda.Text = bandaAModificar;
                    cantIntegrantes.Text = "";
                    this.nombreBanda.Select();
                }
                else
                {
                    ejecuta.Close();
                    SqlCommand comando = new SqlCommand("insertarBanda", conexion);
                    SqlCommand comando2 = new SqlCommand("eliminarBanda", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando2.CommandType = CommandType.StoredProcedure;
                    comando2.Parameters.Add("@nom", SqlDbType.VarChar, 100).Value = bandaAModificar;
                    SqlDataReader dr2 = comando2.ExecuteReader();
                    dr2.Close();
                    comando.Parameters.Add("@nom", SqlDbType.VarChar, 100).Value = nombreBanda.Text;
                    comando.Parameters.Add("@cint", SqlDbType.Int).Value = Convert.ToInt32(cantIntegrantes.Text);
                    SqlDataReader dr = comando.ExecuteReader();
                    MessageBox.Show("La banda se modificó correctamente.");
                    menu.Visible = true;
                    this.Dispose();
                }
            }
            conexion.Close();
        }

        private bool algunCampoVacio()
        {
            bool condicion = false;
            if (this.nombreBanda.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.cantIntegrantes.Text.Trim() == "")
            {
                condicion = true;
            }
            return condicion;
        }
    }
}
