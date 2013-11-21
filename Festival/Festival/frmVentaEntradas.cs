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
    public partial class frmVentaEntradas : Form
    {
        public int[] vectorButacas = new int[50];
        public frmVentaEntradas()
        {
            InitializeComponent();
            vectorButacas[1] = 0;
        }
        
       
        private void button1_Click(object sender, EventArgs e)
        {
            strategy.cambiarButaca(button1, vectorButacas, 1);
          
        }
    }
}
