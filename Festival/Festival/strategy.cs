using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace Festival
{
    class strategy 
    {
        static public void cambiarButaca(Button unBoton, int [] vec, int pos)
        {
                     if (vec[pos] == 0)
            {
                unBoton.Image = Festival.Properties.Resources.butaca20x20roja;
                vec[pos]++;
            }
            else 
            {
                unBoton.Image = Festival.Properties.Resources.butaca20x20verde;
                vec[pos]= 0;
            }  
        }


    }
}


