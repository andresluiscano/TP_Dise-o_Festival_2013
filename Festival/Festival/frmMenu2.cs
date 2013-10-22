using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Festival
{
    public partial class frmMenu2 : Form
    {
        public frmMenu2()
        {
            InitializeComponent();
        }

        
        private void pantallaPrincipal_Load(object sender, EventArgs e)
        {
            
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form1 = new frmLogin();
            Form1.Show();
            this.Close();
        }

        private void ventaDeEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAgregar = new frmAltaBanda();
            this.Hide();
            frmAgregar.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmModBajaBanda = new frmModBajaBanda();
            this.Hide();
            frmModBajaBanda.Show();

        }

        private void bandasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generarDiagramaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frmAgregarFestival = new frmAgregarFestival();
            this.Hide();
            frmAgregarFestival.Show();
        }

        private void modificarEliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frmModBajaFestival = new frmModBajaFestival();
            this.Hide();
            frmModBajaFestival.Show();
        }

        private void ventaDeEntradasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form frmVentaEntradas = new frmVentaEntradas();
            frmVentaEntradas.Show();
        }
    }
}
