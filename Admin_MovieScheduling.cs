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
    public partial class Admin_MovieScheduling : Form
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

        public Admin_MovieScheduling()
        {
            InitializeComponent();
            btn_C1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C1.Width, btn_C1.Height, 65, 65));
            btn_C2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C2.Width, btn_C2.Height, 65, 65));
            btn_C3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C3.Width, btn_C3.Height, 65, 65));
            btn_C4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C4.Width, btn_C4.Height, 65, 65));
            btn_C5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C5.Width, btn_C5.Height, 65, 65));
            btn_C6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C6.Width, btn_C6.Height, 65, 65));
            btn_C7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C7.Width, btn_C7.Height, 65, 65));
            btn_C8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C8.Width, btn_C8.Height, 65, 65));
            btn_C9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_C9.Width, btn_C9.Height, 65, 65));
            shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 60, 60));
            shadow2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow2.Width, shadow1.Height, 60, 60));
            shadow3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow3.Width, shadow1.Height, 60, 60));
            shadow4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow4.Width, shadow1.Height, 60, 60));
            shadow5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow5.Width, shadow1.Height, 60, 60));
            shadow6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow6.Width, shadow1.Height, 60, 60));
            shadow7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow7.Width, shadow1.Height, 60, 60));
            shadow8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow8.Width, shadow1.Height, 60, 60));
            shadow9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow9.Width, shadow1.Height, 60, 60));
        }

        public string check = "";
        public static string calendar;

        OleDbCommand cmd = new OleDbCommand();

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");

        DataTable dts = new DataTable();
        DataSet ds = new DataSet();

        int code1 = 0;
        string asscode = "";
        string assigncode = "0";
        public String[] time = new String[6];
        public int con = 0;
        public int m = 0;
        public String Mcode = Admin_UploadMovie.moviec;
        GlobalVariable gv = new GlobalVariable();




        System.Text.StringBuilder strb = new System.Text.StringBuilder();

        public void Timeslot()
        {
            connect.Open();

            string viewtimeslot = "SELECT time FROM Tbl_Timeslot";
            OleDbCommand cmd = new OleDbCommand(viewtimeslot, connect);

            OleDbDataReader Sdr = cmd.ExecuteReader();


            while (Sdr.Read())
            {

                for (int i = 0; i < Sdr.FieldCount; i++)
                {

                    time[con] = Sdr.GetString(i);

                    con++;
                    //       MessageBox.Show(time[i]);


                }

            }
            Sdr.Close();





            //   MessageBox.Show(strb.ToString());


            connect.Close();
        }
        private void MaxAssignCode()
        {


            connect.Open();


            string viewMaxassigncode = "SELECT Max(Right(Assigncode,2)) AS Asscode FROM Tbl_CinemaAssignment WHERE Cinemacode='" + check + "'";
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

                asscode = code1.ToString(check + "0000");

                odr1.Close();

                // label5.Text = asscode;





            }
            connect.Close();


        }



        //private void query()
        //{

        //    try
        //    {
        //        do
        //        {
        //            Timeslot();
        //            foreach (string item in time)
        //            {
        //                MaxAssignCode();

        //                connect.Open();
        //                string addAssigncode = "INSERT INTO Tbl_CinemaAssignment(Assigncode,CinemaCode,TimeSlot,moviecode,StatusCode) Values('" + asscode + "','" + check + "','" + item + "','" + Mcode + "','0')";
        //                cmd = new OleDbCommand(addAssigncode, connect);
        //                cmd.ExecuteNonQuery();
        //                connect.Close();
        //                //       MessageBox.Show("SUCCESSFUL");
        //                m++;
        //            }
        //        }
        //        while (m <= 5);
        //    }
        //    catch (Exception) { }

        //    gv.EditorAdd = 1;
        //    this.Hide();
        //    new MovieScheduling().Show();
        //}

        private void query()
        {
             if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


 
            try
            {
                do
                {
                    Timeslot();
                    foreach (string item in time)
                    {
                        MaxAssignCode();

                        connect.Open();
                        string addAssigncode = "INSERT INTO Tbl_CinemaAssignment(Assigncode,CinemaCode,TimeSlot,moviecode,StatusCode) Values('" + asscode + "','" + check + "','" + item + "','" + Mcode + "','0')";
                        cmd = new OleDbCommand(addAssigncode, connect);
                        cmd.ExecuteNonQuery();
                        connect.Close();

                        m++;
                    }
                }
                while (m <= 5);
            }
            catch (Exception) { }

            gv.EditorAdd = 1;
            calendar = check; // this is needed!!!!!!!!!!!!!!!!!!!!!!!!!! new code

            this.Hide();
            new MovieScheduling_Calendar().Show();
             }
             else
            {
                MessageBox.Show("...");
            }
        }

        public void obj(object pb) // METHOD TO CINEMA
        {
            switch (check) // CHECK CINEMA
            {
                case "C1":
                    query();

                    break;
                case "C2":
                    query();
                    break;
                case "C3":
                    query();
                    break;
                case "C4":
                    query();
                    break;
                case "C5":
                    query();
                    break;
                case "C6":
                    query();
                    break;
                case "C7":
                    query();
                    break;
                case "C8":
                    query();
                    break;
                case "C9":
                    query();
                    break;
            }
        }

        private void btn_C1_Click(object sender, EventArgs e)
        {
            check = "C1";
            obj(sender);

        }

        private void btn_C2_Click(object sender, EventArgs e)
        {
            check = "C2";
            obj(sender);
        }

        private void btn_C3_Click(object sender, EventArgs e)
        {
            check = "C3";
            obj(sender);
        }

        private void btn_C4_Click(object sender, EventArgs e)
        {
            check = "C4";
            obj(sender);
        }

        private void btn_C5_Click(object sender, EventArgs e)
        {
            check = "C5";
            obj(sender);
        }

        private void btn_C6_Click(object sender, EventArgs e)
        {
            check = "C6";
            obj(sender);
        }

        private void btn_C7_Click(object sender, EventArgs e)
        {
            check = "C7";
            obj(sender);
        }

        private void btn_C8_Click(object sender, EventArgs e)
        {
            check = "C8";
            obj(sender);
        }

        private void btn_C9_Click(object sender, EventArgs e)
        {
            check = "C9";
            obj(sender);
        }

        private void btn_C1_MouseMove(object sender, MouseEventArgs e)
        {
            shadow1.Visible = true;
        }

        private void btn_C1_MouseLeave(object sender, EventArgs e)
        {
            shadow1.Visible = false;
        }

        private void btn_C2_MouseMove(object sender, MouseEventArgs e)
        {
            shadow2.Visible = true;
        }

        private void btn_C2_MouseLeave(object sender, EventArgs e)
        {
            shadow2.Visible = false;
        }

        private void btn_C3_MouseMove(object sender, MouseEventArgs e)
        {
            shadow3.Visible = true;
        }

        private void btn_C3_MouseLeave(object sender, EventArgs e)
        {
            shadow3.Visible = false;
        }

        private void btn_C4_MouseMove(object sender, MouseEventArgs e)
        {
            shadow4.Visible = true;
        }

        private void btn_C4_MouseLeave(object sender, EventArgs e)
        {
            shadow4.Visible = false;
        }

        private void btn_C5_MouseMove(object sender, MouseEventArgs e)
        {
            shadow5.Visible = true;
        }

        private void btn_C5_MouseLeave(object sender, EventArgs e)
        {
            shadow5.Visible = false;
        }

        private void btn_C6_MouseMove(object sender, MouseEventArgs e)
        {
            shadow6.Visible = true;
        }

        private void btn_C6_MouseLeave(object sender, EventArgs e)
        {
            shadow6.Visible = false;
        }

        private void btn_C7_MouseMove(object sender, MouseEventArgs e)
        {
            shadow7.Visible = true;
        }

        private void btn_C7_MouseLeave(object sender, EventArgs e)
        {
            shadow7.Visible = false;
        }

        private void btn_C8_MouseMove(object sender, MouseEventArgs e)
        {
            shadow8.Visible = true;
        }

        private void btn_C8_MouseLeave(object sender, EventArgs e)
        {
            shadow8.Visible = false;
        }

        private void btn_C9_MouseMove(object sender, MouseEventArgs e)
        {
            shadow9.Visible = true;
        }

        private void btn_C9_MouseLeave(object sender, EventArgs e)
        {
            shadow9.Visible = false;
        }




        
    }
}
