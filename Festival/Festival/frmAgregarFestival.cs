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
    public partial class frmAgregarFestival : Form
    {
        frmMenu2 menuAnterior;
        bool modificacion = false;
        string fechaModFestival = null;

        public frmAgregarFestival(frmMenu2 sender)
        {
            InitializeComponent();
            menuAnterior = sender;
            menuAnterior.Visible = false;
            this.Visible = true;
            agregarHorasInicio();
            this.numDia.Select();
        }

        public frmAgregarFestival(frmMenu2 sender, bool modificar, string fechaAModificar)
        {
            InitializeComponent();
            menuAnterior = sender;
            menuAnterior.Visible = false;
            this.Visible = true;
            agregarHorasInicio();
            modificacion = modificar;
            fechaModFestival = fechaAModificar;
            this.fechaFestival.Text = fechaAModificar;
            this.numDia.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menuAnterior.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            DateTime fechaFestival = Convert.ToDateTime(this.fechaFestival.Text);
            int fechaInt = 10000 * fechaFestival.Year + 100 * fechaFestival.Month + fechaFestival.Day;

            SqlCommand consulta = new SqlCommand("SELECT f_inicio FROM Festival WHERE f_inicio='" + fechaInt.ToString() + "'", conexion);
            SqlDataReader ejecuta = consulta.ExecuteReader();

            if (modificacion == false)
            {
                if (ejecuta.HasRows == true || algunCampoVacio())
                {
                    MessageBox.Show("El festival ingresado ya existe o le faltaron ingresar datos. Ingrese los datos correctamente.");
                    this.fechaFestival.Text = "";
                    this.numDia.Text = "";
                    this.cantBandas.Text = "";
                    this.horaInicio.Text = "";
                    this.duracion.Text = "";
                }
                else
                {
                    ejecuta.Close();
                    SqlCommand comando = new SqlCommand("insertarFestival", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@anio", SqlDbType.Int).Value = 1;
                    comando.Parameters.Add("@dto", SqlDbType.Int).Value = 15;
                    comando.Parameters.Add("@dia", SqlDbType.Int).Value = Convert.ToInt32(this.numDia.Text);
                    comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(this.fechaFestival.Text);
                    comando.Parameters.Add("@dev", SqlDbType.Float).Value = 15;
                    SqlDataReader dr = comando.ExecuteReader();
                    MessageBox.Show("El festival se ingresó correctamente.");
                    this.fechaFestival.Text = "";
                    this.numDia.Text = "";
                    this.cantBandas.Text = "";
                    this.horaInicio.Text = "";
                    this.duracion.Text = "";
                }
            }
            else
            {
                if (algunCampoVacio())
                {
                    MessageBox.Show("Le faltaron ingresar datos. Ingrese los datos correctamente.");
                    this.fechaFestival.Text = fechaModFestival;
                    this.numDia.Text = "";
                    this.cantBandas.Text = "";
                    this.horaInicio.Text = "";
                    this.duracion.Text = "";
                    this.numDia.Select();
                }
                else
                {
                    ejecuta.Close();
                    
                    SqlCommand comando = new SqlCommand("insertarFestival", conexion);
                    SqlCommand comando2 = new SqlCommand("eliminarFestival", conexion);
                    
                    comando.CommandType = CommandType.StoredProcedure;
                    comando2.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@anio", SqlDbType.Int).Value = 1;
                    comando.Parameters.Add("@dto", SqlDbType.Int).Value = 15;
                    comando.Parameters.Add("@dia", SqlDbType.Int).Value = Convert.ToInt32(this.numDia.Text);
                    comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(this.fechaFestival.Text);
                    comando.Parameters.Add("@dev", SqlDbType.Float).Value = 15;

                    comando2.Parameters.Add("@fech", SqlDbType.DateTime).Value = Convert.ToDateTime(fechaModFestival);

                    SqlDataReader dr = comando2.ExecuteReader();
                    dr.Close();
                    SqlDataReader dr2 = comando.ExecuteReader();

                    MessageBox.Show("El festival se modificó correctamente.");
                    menuAnterior.Visible = true;
                    this.Dispose();
                }
            }
            conexion.Close();
        }
        private bool algunCampoVacio()
        {
            bool condicion = false;

            if (this.fechaFestival.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.numDia.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.cantBandas.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.horaInicio.Text.Trim() == "")
            {
                condicion = true;
            }
            if (this.duracion.Text.Trim() == "")
            {
                condicion = true;
            }

            return condicion;
        }
        private void agregarHorasInicio()
        {
            this.horaInicio.Items.Add("18:00");
            this.horaInicio.Items.Add("18:30");
            this.horaInicio.Items.Add("19:00");
            this.horaInicio.Items.Add("19:30");
            this.horaInicio.Items.Add("20:00");
            this.horaInicio.Items.Add("20:30");
            this.horaInicio.Items.Add("21:00");
        }

        private void frmAgregarFestival_Load(object sender, EventArgs e)
        {

        }

        private void horaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fechaFestival_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
