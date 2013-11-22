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
            new frmAltaBanda(this);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmModBajaBanda(this);
        }

        private void bandasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generarDiagramaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmAgregarFestival(this);
        }

        private void modificarEliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmModBajaFestival(this);
        }

        private void ventaDeEntradasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form frmVentaEntradas = new frmVentaEntradas();
            frmVentaEntradas.Show();
        }

        private void salirDeAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void verDiagramacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gboxDiagramcion.Visible = true;
            cboFestival.Visible = true;
            lblFestival.Visible = true;
            btnDiagramar.Visible = true;

        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmComprarEntradas(this);
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new frmAgregarDia(this);
        }

        private void cboFestival_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
