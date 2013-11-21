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
    public partial class frmModBajaFestival : Form
    {
        frmMenu2 menu;

        public frmModBajaFestival(frmMenu2 sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            DateTime fechaFestival = Convert.ToDateTime(this.fechaFestival.Text);
            int fechaInt = 10000 * fechaFestival.Year + 100 * fechaFestival.Month + fechaFestival.Day;

            SqlCommand consulta = new SqlCommand("SELECT f_inicio FROM Festival WHERE f_inicio='" + fechaInt.ToString() + "'", conexion);
            SqlDataReader ejecuta = consulta.ExecuteReader();
            if (ejecuta.HasRows == true)
            {
                ejecuta.Close();
                SqlCommand comando2 = new SqlCommand("eliminarFestival", conexion);
                comando2.CommandType = CommandType.StoredProcedure;
                comando2.Parameters.Add("@fech", SqlDbType.DateTime).Value = Convert.ToDateTime(fechaFestival);
                SqlDataReader dr = comando2.ExecuteReader();
                MessageBox.Show("El festival fue eliminado correctamente.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            DateTime fechaFestival = Convert.ToDateTime(this.fechaFestival.Text);
            int fechaInt = 10000 * fechaFestival.Year + 100 * fechaFestival.Month + fechaFestival.Day;

            SqlCommand consulta = new SqlCommand("SELECT f_inicio FROM Festival WHERE f_inicio='" + fechaInt.ToString() + "'", conexion);
            SqlDataReader ejecuta = consulta.ExecuteReader();
            if (ejecuta.HasRows == true)
            {
                new frmAgregarFestival(menu, true, this.fechaFestival.Text);
            }
            else
            {
                MessageBox.Show("El festival que quiere modificar o elminar no existe.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }
    }
}
