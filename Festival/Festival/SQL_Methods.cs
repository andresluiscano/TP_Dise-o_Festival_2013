using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace Festival
{
    class SQL_Methods // Clase Abstracta. Nunca se instanciará
    {
        #region Variables de Clase
            public static bool DBConnectStatus = false;      
        #endregion

        static public SqlConnection IniciarConnection()
        {
            SqlConnection myConnection;
            string ConectionQuery = "user id=" + "gd" + ";" +
                                    "password=" + "gd2013" + ";" +
                                    "server=" + "localhost" + "\\" + "SQLSERVER2008" + ";" +
                                    "Trusted_Connection=no;" +
                                    "database=" + "TP-ROCK" + ";" +
                                    "connection timeout=5";

            myConnection = new SqlConnection(ConectionQuery);
            try
            {
                myConnection.Open();
                DBConnectStatus = true;
                return myConnection;
            }
            catch (Exception e)
            {
                DBConnectStatus = false;
                MessageBox.Show(ConectionQuery);
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        static public DataTable EjecutarProcedure(SqlConnection myConnection, string myQuery)
        {
            SqlDataAdapter miDataAdapter;
            DataSet miDataSet;
            DataTable unaDataTable = new DataTable();

            miDataAdapter = new SqlDataAdapter(myQuery, myConnection);
            miDataSet = new DataSet();
            miDataAdapter.Fill(miDataSet, "Tabla");
            unaDataTable = miDataSet.Tables["Tabla"];
            miDataSet.Dispose();
            miDataAdapter.Dispose();
            
            return unaDataTable;
        }
    }
}
