using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;


namespace CinemaTicketing
{
    //database connection
    class ConnectionForm
    {
        public string connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb";
        public OleDbConnection connection = new OleDbConnection();

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.ConnectionString = connstring;
                connection.Open();
            }
        }
    }//class close
}//namespace close
