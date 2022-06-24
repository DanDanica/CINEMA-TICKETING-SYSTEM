using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace CinemaTicketing
{
    public partial class MovieScheduling_Calendar : Form
    {
        //RECTANGULAR DESIGNS
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );

        public MovieScheduling_Calendar()
        {
            InitializeComponent();
            btn_Save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 9, 9));
        }
        OleDbCommand cmd = new OleDbCommand();

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");

        DataTable dts = new DataTable();
        DataSet ds = new DataSet();
        GlobalVariable GLOBALV = new GlobalVariable();
        string movie1;
        string cinemacode;
        string mindate;
        public String[] time = new String[6];
        public int con = 0;

        private void MovieScheduling_Calendar_Load(object sender, EventArgs e)
        {
            //monthCalendar1.Header.BackColor = ColorTranslator.FromHtml("FF555555");
            showdatagridadd();
        }
        

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtbx_Start.Text = monthCalendar1.SelectionRange.Start.Date.ToString("MM-dd-yyyy");
            txtbx_End.Text = monthCalendar1.SelectionRange.End.Date.ToString("MM-dd-yyyy");
        }

        private void showdatagridadd() //method
        {

            if (GLOBALV.EditorAdd == 0)
            {
                mindateforEdit();
                FINDassigncodeforEdit();


            }

            if (GLOBALV.EditorAdd == 1)
            {
                minimumdate(); //date
                btn_Cancel.Visible = false;

                FINDassigncode();

            }

        }



        private void minimumdate()
        {
            connect.Open();
            string cal = Admin_MovieScheduling.calendar;

            string viewtimes = "SELECT EndShowing AS ES FROM Tbl_CinemaAssignment WHERE Cinemacode='" + cal + "' ORDER BY EndShowing DESC";
            OleDbCommand cmd1 = new OleDbCommand(viewtimes, connect);
            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            da1.Fill(ds1);

            OleDbDataReader odr1 = cmd1.ExecuteReader();

            if (odr1.ToString() != null)
            {
                if (odr1.HasRows)
                {
                    odr1.Read();
                    mindate = odr1["ES"].ToString();
                    if (odr1["ES"] == DBNull.Value)
                    {
                        monthCalendar1.MinDate = DateTime.Today;

                    }
                }

                monthCalendar1.MinDate = DateTime.Parse(mindate).AddDays(1);
                monthCalendar1.MaxDate = DateTime.Parse(mindate).AddDays(30);
                monthCalendar1.MaxSelectionCount = 30;

                connect.Close();


            }
        }


        private void GETcinemacode()
        {
            connect.Open();
            movie1 = Admin_EditMovie.movieID;


            string viewtimeslot = "SELECT CinemaCode FROM Tbl_CinemaAssignment WHERE moviecode='" + movie1 + "'";
            OleDbCommand cmd = new OleDbCommand(viewtimeslot, connect);

            OleDbDataReader Sdr = cmd.ExecuteReader();
            Sdr.Read();


            cinemacode = Sdr["CinemaCode"].ToString();

            connect.Close();
        }

        public void mindateforEdit()
        {

            GETcinemacode();
            connect.Open();


            string viewtimes = "SELECT EndShowing AS ES FROM Tbl_CinemaAssignment WHERE Cinemacode='" + cinemacode + "' ORDER BY EndShowing DESC";
            OleDbCommand cmd1 = new OleDbCommand(viewtimes, connect);
            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            da1.Fill(ds1);

            OleDbDataReader odr1 = cmd1.ExecuteReader();

            if (odr1.ToString() != null)
            {
                if (odr1.HasRows)
                {
                    odr1.Read();
                    mindate = odr1["ES"].ToString();
                    if (odr1["ES"] == DBNull.Value)
                    {
                        monthCalendar1.MinDate = DateTime.Today;

                    }
                }

                monthCalendar1.MinDate = DateTime.Parse(mindate).AddDays(1);
                monthCalendar1.MaxDate = DateTime.Parse(mindate).AddDays(30);
                monthCalendar1.MaxSelectionCount = 30;

                connect.Close();
            }
        }


        public void FINDassigncodeforEdit()
        {
            string movie;

            connect.Open();


            movie = Admin_EditMovie.movieID;



            string viewassigncode = "SELECT AssignCode FROM Tbl_CinemaAssignment WHERE moviecode='" + movie + "'";
            OleDbCommand cmd = new OleDbCommand(viewassigncode, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            DataSet ds2 = new DataSet();
            oda.Fill(dt2);

            // dataGridView1.DataSource = dt2;

            OleDbDataReader Sdr = cmd.ExecuteReader();
            try
            {

                while (Sdr.Read())
                {

                    for (int i = 0; i < Sdr.FieldCount; ++i)
                    {

                        time[con] = Sdr.GetString(i);

                        con++;
                        //     MessageBox.Show(time[i]);


                    }

                }
                Sdr.Close();



            }
            catch { }




            connect.Close();
        }


        public void FINDassigncode()
        {
            string movie;

            connect.Open();


            movie = Admin_UploadMovie.moviec;



            string viewassigncode = "SELECT AssignCode FROM Tbl_CinemaAssignment WHERE moviecode='" + movie + "'";
            OleDbCommand cmd = new OleDbCommand(viewassigncode, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            DataSet ds2 = new DataSet();
            oda.Fill(dt2);

            //    dataGridView1.DataSource = dt2;

            OleDbDataReader Sdr = cmd.ExecuteReader();
            try
            {

                while (Sdr.Read())
                {

                    for (int i = 0; i < Sdr.FieldCount; ++i)
                    {

                        time[con] = Sdr.GetString(i);

                        con++;
                        //     MessageBox.Show(time[i]);


                    }

                }
                Sdr.Close();



            }
            catch { }




            connect.Close();
        }
        private void query2()
        {
            if (MessageBox.Show("Are you sure you want to save this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {

                    FINDassigncodeforEdit();
                    foreach (string item in time)
                    {
                        connect.Open();

                        string updatedb = "UPDATE Tbl_CinemaAssignment SET [StartShowing]='" + txtbx_Start.Text + "',[EndShowing]='" + txtbx_End.Text + "' WHERE [AssignCode]='" + item + "'";
                        cmd = new OleDbCommand(updatedb, connect);

                        cmd.ExecuteNonQuery();



                        connect.Close();

                    }

                }
                catch (Exception) { }

                //gv.EditorAdd = 1;
                // calendar = check; // this is needed!!!!!!!!!!!!!!!!!!!!!!!!!! new code

                this.Hide();
                new Admin_Dashboard().Show();
            }
            else
            {
                MessageBox.Show("Movie schedule remains the same");
            }
        }


        private void query()
        {
            if (MessageBox.Show("Are you sure you want to save this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {

                    FINDassigncode();
                    foreach (string item in time)
                    {
                        connect.Open();

                        string updatedb = "UPDATE Tbl_CinemaAssignment SET [StartShowing]='" + txtbx_Start.Text + "',[EndShowing]='" + txtbx_End.Text + "' WHERE [AssignCode]='" + item + "'";
                        cmd = new OleDbCommand(updatedb, connect);

                        cmd.ExecuteNonQuery();



                        connect.Close();

                    }

                }
                catch (Exception) { }

                //gv.EditorAdd = 1;
                // calendar = check; // this is needed!!!!!!!!!!!!!!!!!!!!!!!!!! new code

                this.Hide();
                new Admin_Dashboard().Show();
            }
            else
            {
                MessageBox.Show("Movie schedule remains the same");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            showdatagridadd();

            if (GLOBALV.EditorAdd == 0)
            {
                query2();
            }
            if (GLOBALV.EditorAdd == 1)
            {
                query();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel editing?", "You are about to cancel editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new Admin_Dashboard().Show();
                this.Hide();
            }
            
        }

    }
}
