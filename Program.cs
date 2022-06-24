using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CinemaTicketing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConnectionForm newconnection = new ConnectionForm();
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");
        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //  OneTimequery();
            // Application.Run(new CINEMAHOME());

            connect.Open();
            string login = "SELECT COUNT(Username) FROM Tbl_Account";
            OleDbCommand ocmd = new OleDbCommand(login, connect);
            ocmd.ExecuteScalar();
            Int32 rowcount = Convert.ToInt32(ocmd.ExecuteScalar());

            if (rowcount == 0)
            {
                GlobalVariable gv = new GlobalVariable();
                //MessageBox.Show("WELCOME");
                Application.Run(new RegForm ());

                new Portals().Show();
                connect.Close();

            }
            else
            {
                Application.Run(new Portals());
                connect.Close();
                
            }
        }
    }
}
