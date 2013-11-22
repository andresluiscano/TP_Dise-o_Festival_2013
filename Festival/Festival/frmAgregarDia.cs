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
    public partial class frmAgregarDia : Form
    {
        frmMenu2 menuAnterior;
        public static DataTable TablaFestival= new DataTable();
        bool modificacion = false;

        public frmAgregarDia(frmMenu2 sender)
        {
            InitializeComponent();
            menuAnterior = sender;
            menuAnterior.Visible = false;
            this.Visible = true;
            cargarFestivales();

        }

        private void frmAgregarDia_Load(object sender, EventArgs e)
        {

        }

        private void cargarFestivales()
        {
            string myQuery = "SELECT id_festival FROM Festival ORDER BY 1";
            SqlConnection myConnection;
            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaFestival = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }
            for (int i = 0; i < Convert.ToInt32(TablaFestival.Rows.Count.ToString()); i++)
            {
                this.cboFestival.Items.Add(TablaFestival.Rows[i][0]);
            }
            myConnection.Close();
        }
        
        private void cboFestival_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            DateTime fechaFestival = Convert.ToDateTime(this.dateFecha.Text);
            int fechaInt = 10000 * fechaFestival.Year + 100 * fechaFestival.Month + fechaFestival.Day;

            SqlCommand consulta = new SqlCommand("SELECT f_inicio FROM Festival WHERE f_inicio='" + fechaInt.ToString() + "'", conexion);
            SqlDataReader ejecuta = consulta.ExecuteReader();

            if (modificacion == false)
            {
                if (ejecuta.HasRows == true || algunCampoVacio())
                {
                    MessageBox.Show("El día ingresado ya existe o le faltaron ingresar datos. Ingrese los datos correctamente.");
                    this.cboFestival.Text = "";
                    this.txtDia.Text = "";
                    this.txtPrecio.Text = "";
                    
                }
                else
                {
                    ejecuta.Close();
                    SqlCommand comando = new SqlCommand("agregarDia", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@id_festival", SqlDbType.Int).Value = Convert.ToInt32(this.cboFestival.Text);
                    comando.Parameters.Add("@dia", SqlDbType.Int).Value = Convert.ToInt32(this.txtDia.Text);
                    comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(this.dateFecha.Text);
                    comando.Parameters.Add("@precio", SqlDbType.Float).Value = 15;//PENDIENTE POR FALTA DE ENTRADA
                    comando.Parameters.Add("@fec_vec", SqlDbType.DateTime).Value = Convert.ToDateTime(this.dateFecVec.Text);
                    SqlDataReader dr = comando.ExecuteReader();
                    MessageBox.Show("El día se ingresó correctamente.");
                    this.cboFestival.Text = "";
                    this.txtDia.Text = "";
                    this.txtPrecio.Text = "";
                    
                }
            }
            conexion.Close();    
        }
            
        
        
        
        private bool algunCampoVacio()
        {
            bool condicion = false;

            if (this.cboFestival.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.txtDia.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.txtPrecio.Text.Trim() == "")
            {
                condicion = true;
            }
            return condicion;
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menuAnterior.Visible = true;
        }

    }
}
