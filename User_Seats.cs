
using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;

namespace CinemaTicketing
{

    public partial class User_Seats : Form
    {
        private Image available1;
        private Image selected1;
        private Image taken;
        private Image restricted1;
        DateTime datenow = DateTime.Now;
        string time;
        ConnectionForm newconnection = new ConnectionForm();
        GlobalVariable mcode = new GlobalVariable();
        int CountingPick;
        int numberofticks = 0;
        string TimeSlot;
        string assigncode;
        int countseats;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );
        public User_Seats()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            available1 = Properties.Resources.available1;
            selected1 = Properties.Resources.selected1;
            taken = Properties.Resources.taken;
            restricted1 = Properties.Resources.restricted1;
        }

        //MAIN
        private void User_Seats_Load(object sender, EventArgs e)
        {
            shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 25, 25));
            pnl_Seats.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_Seats.Width, pnl_Seats.Height, 25, 25));
            //btn_Book.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Book.Width, btn_Book.Height, 18, 18));
            btn_add.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_add.Width, btn_add.Height, 30, 30));
            btn_minus.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_minus.Width, btn_minus.Height, 30, 30));
            PopulateTimeslot();
            Resetpicturebox();
            lbl_MovieTitle.Text = mcode.movietitle;
            lbl_MoviePrice.Text = mcode.movieprice;
            lbl_Genre.Text = mcode.moviegenre;
        }
        //FOR RESTRICTED SEATS
        private void Resetpicturebox()
        {
            newconnection.OpenConnection();
            OleDbCommand seatscommand = new OleDbCommand("SELECT * FROM Tbl_Seats", newconnection.connection);
            DataSet seatDS = new DataSet();
            OleDbDataAdapter seatsDA = new OleDbDataAdapter(seatscommand);
            seatsDA.Fill(seatDS, "TblSeats");
            newconnection.connection.Close();
            DataTable seatDT = seatDS.Tables[0];

            foreach (DataRow drseat in seatDT.Rows)
            {
                if (drseat[3].ToString() == "1")
                {
                    foreach (Control c in pnl_Seats.Controls)
                    {
                        if (c is PictureBox)
                        {
                            if (drseat[0].ToString() == ((PictureBox)c).Name)
                            {
                                ((PictureBox)c).Image = restricted1;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Control c in pnl_Seats.Controls)
                    {
                        if (c is PictureBox)
                        {
                            if (drseat[0].ToString() == ((PictureBox)c).Name)
                            {
                                ((PictureBox)c).Image = available1;
                                ((PictureBox)c).Click -= new EventHandler(A1_Click);
                                ((PictureBox)c).Click += new EventHandler(A1_Click);
                            }
                        }
                    }
                }
            }
        }
        //BUTTON BOOK
        private void btn_Book_Click(object sender, EventArgs e)
        {

            if (cmb_TimeSlot.SelectedIndex == -1 || txtbx_NumberOfTickets.Text == "0")
            {
                MessageBox.Show("Please check your timeslot and number of tickets");
                CountingPick = 0;
                return;
            }

            if (CountingPick != int.Parse(txtbx_NumberOfTickets.Text))
            {
                MessageBox.Show("Please select seat/s that are equal to the number of tickets");
                return;
            }


            string seatcode;
            bool bselected = false;

            foreach (Control ctrl in pnl_Seats.Controls)
            {
                if (ctrl is PictureBox)
                {
                    if (((PictureBox)ctrl).Image == selected1)
                    {
                        bselected = true;
                        break;
                    }
                }
            }

            if (bselected == false)
            {
                MessageBox.Show("PLEASE SELECT ATLEAST ONE SEAT TO BOOK"); ;
                return;
            }
            if (MessageBox.Show("Are you sure you want to proceed booking?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string currentcode = "0";
                string newcode = "";

                newconnection.OpenConnection();
                OleDbCommand maxcode = new OleDbCommand("SELECT MAX(PickupCode) AS pickupcode FROM Tbl_PickupSeat", newconnection.connection);
                OleDbDataReader maxread = maxcode.ExecuteReader();
                if (maxread != null)
                {
                    if (maxread.HasRows)
                    {
                        maxread.Read();
                        currentcode = object.ReferenceEquals(maxread["pickupcode"], DBNull.Value) ? "0" : maxread["pickupcode"].ToString();
                    }
                }
                newconnection.connection.Close();
                int code = 0;
                code = Convert.ToInt16(currentcode) + 1;
                newcode = code.ToString("00000");


                newconnection.OpenConnection();
                foreach (Control c in pnl_Seats.Controls)
                {
                    if (c is PictureBox)
                    {
                        if (((PictureBox)c).Image == selected1)
                        {
                            seatcode = ((PictureBox)c).Name;
                            OleDbCommand Pickseatcmd = new OleDbCommand("INSERT INTO Tbl_PickupSeat (PickupCode, AssignCode, SeatCode) VALUES ('" + newcode.ToString() + "', '" + assigncode + "','" + seatcode + "')", newconnection.connection);
                            Pickseatcmd.ExecuteNonQuery();
                        }
                    }
                }
                newconnection.connection.Close();

                //mcode.CountOfTicket = int.Parse(cmb_NumberOfSeats.SelectedItem.ToString());
                mcode.CountOfTicket = int.Parse(txtbx_NumberOfTickets.Text);
                //MessageBox.Show(mcode.CountOfTicket.ToString());
                SeatAvailability();

                User_Information Info = new User_Information();
                //User_Payment Info = new User_Payment();
                Info.Show();
                this.Close();
            }
        }
        //SEATS BOOKING
        private void A1_Click(object sender, EventArgs e)
        {

            countseats = Convert.ToInt16(txtbx_NumberOfTickets.Text);
            PictureBox ctrlsender = sender as PictureBox;
            if (ctrlsender.Image == available1)
            {
                ctrlsender.Image = selected1;
                CountingPick += 1;
                if (CountingPick > countseats)
                {
                    MessageBox.Show("Exceed Number of Seats Selected");
                    ctrlsender.Image = available1;
                    CountingPick -= 1;
                }
            }
            else if (ctrlsender.Image == selected1)
            {
                ctrlsender.Image = available1;
                CountingPick -= 1;
            }
            else if (ctrlsender.Image == taken)
            {
                MessageBox.Show("This seat is already occupied, Please Choose other seat");
                return;
            }
        }
        //METHOD POPULATE TIMESLOT
        public void PopulateTimeslot()
        {
            time = datenow.ToString("hh:mm tt");
            newconnection.OpenConnection();
            OleDbCommand timecommand = new OleDbCommand("SELECT RIGHT((TimeSlot),11) AS timeslot,moviecode,StatusCode FROM Tbl_CinemaAssignment WHERE moviecode = '" + mcode.Moviecode + "' AND TimeSlot > #" + time + "#", newconnection.connection);
            DataSet timeDS = new DataSet();
            OleDbDataAdapter timeDA = new OleDbDataAdapter(timecommand);
            timeDA.Fill(timeDS, "TimeList");
            newconnection.connection.Close();
            DataTable timetbl = timeDS.Tables[0];
            foreach (DataRow timedr in timetbl.Rows)
            {
                if (timedr["StatusCode"].ToString() == "1")
                {
                    cmb_TimeSlot.Items.Add(timedr["timeslot"].ToString());
                }
            }

        }

        //METHOD FOR SEAT AVAILABILITY
        public void SeatAvailability()
        {
            newconnection.OpenConnection();
            OleDbCommand SeatsCommand = new OleDbCommand("SELECT * FROM Tbl_PickupSeat AS tbl1 LEFT JOIN Tbl_CinemaAssignment AS tbl2 ON tbl1.AssignCode = tbl2.Assigncode", newconnection.connection);
            DataSet SeatsDS = new DataSet();
            OleDbDataAdapter SeatsDA = new OleDbDataAdapter(SeatsCommand);
            SeatsDA.Fill(SeatsDS, "Seatstbl");
            newconnection.connection.Close();
            DataTable SeatsDT = SeatsDS.Tables[0];

            //    For Each row In t1.Rows
            //  If assigncode = row(1) Then
            //        CType(Controls(row(2)), PictureBox).BackgroundImage = occupied
            //        countingoccupied += 1
            //    End If
            //Next
            foreach (DataRow seatdr in SeatsDT.Rows)
            {
                if (assigncode.ToString() == seatdr[1].ToString())
                {
                    foreach (Control c in pnl_Seats.Controls)
                    {
                        if (c is PictureBox)
                        {
                            if (seatdr[2].ToString() == ((PictureBox)c).Name)
                            {
                                ((PictureBox)c).Image = taken;
                            }
                        }
                    }
                }
            }
        }

        private void cmb_TimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TimeSlot.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select TimeSlot");
                return;
            }
            Resetpicturebox();
            TimeSlot = cmb_TimeSlot.SelectedItem.ToString();
            newconnection.OpenConnection();
            OleDbCommand CinemaAssignCommand = new OleDbCommand("SELECT RIGHT ((TimeSlot),11) AS timeslot,moviecode,AssignCode FROM Tbl_CinemaAssignment", newconnection.connection);
            DataSet CinemaAssignDS = new DataSet();
            OleDbDataAdapter CinemaAssignDA = new OleDbDataAdapter(CinemaAssignCommand);
            CinemaAssignDA.Fill(CinemaAssignDS, "CinemaAssignTbl");
            newconnection.connection.Close();
            DataTable CinemaAssignDT = CinemaAssignDS.Tables[0];
            foreach (DataRow CinemaAssignDR in CinemaAssignDT.Rows)
            {
                if (CinemaAssignDR["moviecode"].ToString() == mcode.Moviecode && CinemaAssignDR["timeslot"].ToString() == TimeSlot)
                {
                    assigncode = CinemaAssignDR["AssignCode"].ToString();
                }
            }
            SeatAvailability();
        }

        #region numberoftickets
        private void User_Seats_Shown(object sender, EventArgs e)
        {
            txtbx_NumberOfTickets.Text = numberofticks.ToString();
        }
        //ADD TICKETS
        private void btn_add_Click(object sender, EventArgs e)
        {
            numberofticks += 1;
            txtbx_NumberOfTickets.Text = numberofticks.ToString();
            if (numberofticks > 3)
            {
                //btn_add.Visible = false;
                numberofticks -= 1;
                MessageBox.Show("Maximum Number for tickets is 3");
                txtbx_NumberOfTickets.Text = numberofticks.ToString();
                return;
            }
        }
        //MINUS TICKETS
        private void btn_minus_Click(object sender, EventArgs e)
        {
            numberofticks -= 1;
            txtbx_NumberOfTickets.Text = numberofticks.ToString();
            if (numberofticks <= 0)
            {
                numberofticks += 1;
                //btn_minus.Visible = false;
                MessageBox.Show("INVALID");
                txtbx_NumberOfTickets.Text = numberofticks.ToString();
                return;
            }
        }
        #endregion
        //BUTTON BACK
        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new User_BookingOfTicket().Show(); 
        }


        
    }//clss close
}//namespace close
