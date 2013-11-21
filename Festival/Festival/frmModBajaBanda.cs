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
    public partial class frmModBajaBanda : Form
    {
        frmMenu2 menu;
        public static DataTable TablaBandas = new DataTable();
        public frmModBajaBanda(frmMenu2 sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            this.comboBox1.Select();
            cargarBandas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            myConnection = SQL_Methods.IniciarConnection();
            SqlCommand consulta = new SqlCommand("SELECT nombre FROM GrupoMusical WHERE nombre ='" + comboBox1.Text + "'", myConnection);
            SqlDataReader ejecuta = consulta.ExecuteReader();
            if (ejecuta.HasRows == true)
            {
                new frmAltaBanda(menu, true, comboBox1.Text.ToString());
                this.Dispose();
            }
            else
            {
                MessageBox.Show("La banda que quiere modificar no existe. Ingrese correctamente la banda.");
                comboBox1.Text = "";
                comboBox1.Select();
            }
            myConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            SqlCommand comando = new SqlCommand("eliminarBanda", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@nom", SqlDbType.VarChar, 100).Value = comboBox1.Text;
            SqlDataReader dr = comando.ExecuteReader();
            MessageBox.Show("La banda se eliminó correctamente.");
            comboBox1.Text = "";
            comboBox1.Select();
            conexion.Close();
        }
        private void cargarBandas()
        {
            string myQuery = "SELECT nombre FROM GrupoMusical ORDER BY 1";
            SqlConnection myConnection;
            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaBandas = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }
            for (int i = 0; i < Convert.ToInt32(TablaBandas.Rows.Count.ToString()); i++)
            {
                this.comboBox1.Items.Add(TablaBandas.Rows[i][0]);
            }
            myConnection.Close();
        }
    }
}