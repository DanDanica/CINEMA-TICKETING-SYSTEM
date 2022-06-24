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
    public partial class MovieScheduling : Form
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

        int count;
        int code1 = 0;
        string asscode = "";
        string mindate;
        String Ascode;
        string assigncode = "0";
        string cinemacode;
        string movie1;

        OleDbCommand cmd = new OleDbCommand();

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");

        DataTable dts = new DataTable();
        DataSet ds = new DataSet();
        GlobalVariable GLOBALV = new GlobalVariable();

        public MovieScheduling()
        {
            InitializeComponent();
            btn_Save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Save.Width, btn_Save.Height, 9, 9));
            btn_Update.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Update.Width, btn_Update.Height, 9, 9));
            btn_Cancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Cancel.Width, btn_Cancel.Height, 9, 9));
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            connect.Open();

            if (txtbx_Start.Text == "" || txtbx_End.Text == "" || cmb_Cinema.Text == "" || cmb_Timeslot.Text == "")
            {
                MessageBox.Show("Fill all the details needed", "NOTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string addAssigncode = "INSERT INTO Tbl_CinemaAssignment(Assigncode,CinemaCode) Values('" + asscode + "','" + cmb_Cinema.Text + "')";
                cmd = new OleDbCommand(addAssigncode, connect);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Datas Saved Successfully");
                connect.Close();

                String Time, Start, End;

                Time = cmb_Timeslot.Text;
                Start = txtbx_Start.Text;
                End = txtbx_End.Text;
                dts.Rows.Add(Time, asscode, Start, End);
                dgv_sched.DataSource = dts;
                methodclear();
            }
        }
        //METHOD FOR CLEARING TEXTBOXES
        private void methodclear()
        {
            cmb_Cinema.SelectedIndex = -1;
            cmb_Timeslot.SelectedIndex = -1;
            txtbx_Start.Text = "";
            txtbx_End.Text = "";
        }

        private void MovieScheduling_Load(object sender, EventArgs e)
        {
           
            Timeslot();
            cinemanumber();
            showdatagridadd();
            dgv_sched.Columns[3].DefaultCellStyle.Format = "HH:mm:tt";
            count = 0;
        }
        //timeslot

        private void Timeslot()
        {
            connect.Open();
            string viewtimeslot = "SELECT time FROM Tbl_Timeslot";
            OleDbCommand cmd = new OleDbCommand(viewtimeslot, connect);
            OleDbDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    cmb_Timeslot.Items.Add(Sdr.GetString(i));

                }
            }
            Sdr.Close();

            connect.Close();
        }

        //GET CINEMA CODE FOR EDIT
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

        //method for mindate EDIT FORM
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

        //MINIMUM DATE METHOD
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

        //SHOW DATA GRID ADD METHOD
        private void showdatagridadd()
        {
            if (GLOBALV.EditorAdd == 0)
            {
                mindateforEdit();
                hideobjects();
                btn_Save.Visible = true;
                btn_Update.Visible = false;
                showingEdit();
            }

            if (GLOBALV.EditorAdd == 1)
            {
                minimumdate(); //date
                hideobjects();
                showing();
            }

           // dgv_sched.Columns[3].DefaultCellStyle.Format = "HH:mm:tt";

        }

        //HIDE OBJECTS METHOD
        private void hideobjects()
        {
            btn_Cancel.Visible = true;
            btn_Save.Visible = false;
            cmb_Cinema.Visible = false;
            cmb_Timeslot.Visible = false;
        }

        //SHOWING EDIT METHOD
        private void showingEdit()
        {
            dts.Clear();
            string movie;
            movie = Admin_EditMovie.movieID;
            connect.Open();
            string querysched = "SELECT  Assigncode,StartShowing,EndShowing,TimeSlot FROM Tbl_CinemaAssignment WHERE moviecode='" + movie + "'";
            cmd = new OleDbCommand(querysched, connect);
            cmd.ExecuteNonQuery();
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dgv_sched.DataSource = dt;
            connect.Close();
        }

        //SHOWING METHOD
        private void showing()
        {
            dts.Clear();
            string movie;
            movie = Admin_UploadMovie.moviec;

            connect.Open();
            string querysched = "SELECT RIGHT ((TimeSlot),11) AS TimeSlot,Assigncode,StartShowing,EndShowing FROM Tbl_CinemaAssignment WHERE moviecode='" + movie + "'";

            cmd = new OleDbCommand(querysched, connect);
            cmd.ExecuteNonQuery();
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dgv_sched.DataSource = dt;
            connect.Close();
        }

        //METHOD CINEMA NUMBER
        private void cinemanumber()
        {
            connect.Open();

            string viewcinema = "Select CinemaCode From Tbl_CinemaCode";
            OleDbCommand cmd = new OleDbCommand(viewcinema, connect);
            OleDbDataReader Sdr1 = cmd.ExecuteReader();

            while (Sdr1.Read())
            {
                for (int i = 0; i < Sdr1.FieldCount; i++)
                {
                    cmb_Cinema.Items.Add(Sdr1.GetString(i));

                }
            }
            Sdr1.Close();

            connect.Close();
        }


        //METHOD MAX ASSIGN CODE
        private void MaxAssignCode()
        {
            connect.Open();

            string viewMaxassigncode = "SELECT Max(Right(Assigncode,2)) AS Asscode FROM Tbl_CinemaAssignment WHERE Cinemacode='" + cmb_Cinema.Text + "'";
            OleDbCommand cmd = new OleDbCommand(viewMaxassigncode, connect);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            OleDbDataReader odr1 = cmd.ExecuteReader();

            if (odr1.ToString() != null)
            {
                if (odr1.HasRows)
                {
                    odr1.Read();
                    assigncode = odr1["Asscode"].ToString();
                    if (odr1["Asscode"] == DBNull.Value)
                    {

                        assigncode = "0";
                    }
                }


                code1 = int.Parse(assigncode) + 1;

                asscode = code1.ToString(cmb_Cinema.Text + "0000");

                odr1.Close();

                label5.Text = asscode;

                connect.Close();
            }
        }

        private void cmb_Cinema_SelectedIndexChanged(object sender, EventArgs e)
        {
            minimumdate();
            MaxAssignCode();
        }
        //BUTTON REMOVE 
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgv_sched.CurrentCell.RowIndex;
                connect.Open();

                Ascode = dgv_sched.Rows[rowIndex].Cells[1].Value.ToString();

                MessageBox.Show(Ascode);
                string querydelete = "DELETE FROM Tbl_CinemaAssignment WHERE [AssignCode] LIKE '%" + Ascode + "%'";
                cmd = new OleDbCommand(querydelete, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("DELETED");
                dgv_sched.Rows.RemoveAt(rowIndex);
            }
            catch (Exception)
            {
                MessageBox.Show("Fill all the details needed", "NOTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //BUTTON SAVE
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveindb();

                showingEdit();
            }
            else
            {
                MessageBox.Show("NOT UPDATED");
            }

        }
        //METHOD FOR SAVING IN DATABASE
        private void saveindb()
        {
            connect.Open();
            int rowIndex = dgv_sched.CurrentCell.RowIndex;
            Ascode = dgv_sched.Rows[rowIndex].Cells[0].Value.ToString();

            string updatedb = "UPDATE Tbl_CinemaAssignment SET [StartShowing]='" + txtbx_Start.Text + "',[EndShowing]='" + txtbx_End.Text + "' WHERE [AssignCode]='" + Ascode + "'";
            cmd = new OleDbCommand(updatedb, connect);

            cmd.ExecuteNonQuery();

            connect.Close();
            MessageBox.Show("UPDATED");
        }
        //MONTH CALENDAR
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // CALENDAR CHANGED

            txtbx_Start.Text = monthCalendar1.SelectionRange.Start.Date.ToString("MM-dd-yyyy");
            txtbx_End.Text = monthCalendar1.SelectionRange.End.Date.ToString("MM-dd-yyyy");
        }
        //BUTTON UPDATE
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                saveindb();


                //      showing();
                showing();



            }
            else
            {
                MessageBox.Show("NOT UPDATED");
            }
        }
        //BUTTPN CANCEL
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin_Dashboard().Show();
        }
    }
}
