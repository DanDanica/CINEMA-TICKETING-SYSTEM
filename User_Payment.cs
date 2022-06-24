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
    public partial class User_Payment : Form
    {
        //RECTANGULAR SIDES
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );
        public User_Payment()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        ConnectionForm newconnection = new ConnectionForm();
        GlobalVariable gv = new GlobalVariable();
        double total = 0;
        string price = "0";
        //string code = "001";

        //FORM LOAD
        private void Admin_Payment_Load(object sender, EventArgs e)
        {
            txtbx_Price.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Price.Width, txtbx_Price.Height, 18, 18));
            txtbx_NumberOfTickets.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_NumberOfTickets.Width, txtbx_NumberOfTickets.Height, 18, 18));
            txtbx_Discount.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Discount.Width, txtbx_Discount.Height, 18, 18));
            txtbx_Change.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Change.Width, txtbx_Change.Height, 18, 18));
            shadow3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow3.Width, shadow3.Height, 18, 18));
            shadow4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow4.Width, shadow4.Height, 18, 18));
            shadow5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow5.Width, shadow5.Height, 18, 18));
            shadow6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow6.Width, shadow6.Height, 18, 18));
            shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 18, 18));
            shadow2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow2.Width, shadow2.Height, 18, 18));
            txtbx_Total.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Total.Width, txtbx_Total.Height, 18, 18));
            txtbx_Amount.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Amount.Width, txtbx_Amount.Height, 18, 18));
            //btn_Pay.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Pay.Width, btn_Pay.Height, 18, 18));
            //txtbx_Amount.Text = txtbx_Amount.Text.PadLeft(txtbx_Amount.Text.Length + 2);
            txtbx_NumberOfTickets.Text = gv.CountOfTicket.ToString();

            newconnection.OpenConnection();
            OleDbCommand cmdmovie = new OleDbCommand("SELECT * FROM Tbl_Movies WHERE moviecode = '" + gv.Moviecode + "' ", newconnection.connection);
            //OleDbCommand cmdmovie = new OleDbCommand("SELECT * FROM Tbl_Movies WHERE moviecode = '" + code + "' ", newconnection.connection);

            DataSet dsMovie = new DataSet();
            OleDbDataAdapter daMovie = new OleDbDataAdapter(cmdmovie);
            daMovie.Fill(dsMovie, "tblMovie");
            newconnection.connection.Close();
            DataTable dtMovie = dsMovie.Tables[0];

            foreach (DataRow drMovie in dtMovie.Rows)
            {
                lbl_MovieTitle.Text = drMovie["movietitle"].ToString();
                //txtbx_Price.Text = drMovie["movieprice"].ToString();
                price = drMovie["movieprice"].ToString();
            }
            ////MessageBox.Show(price.ToString());

            newconnection.OpenConnection();
            //OleDbCommand cmdpickup = new OleDbCommand("SELECT * FROM Tbl_PickupSeat AS t1 LEFT JOIN Tbl_Information AS t2 ON t1.PickupCode= t2.PickupCode WHERE t1.PickupCode = (SELECT MAX(PickupCode) from Tbl_PIckupSeat)", newconnection.connection);
            OleDbCommand cmdpickup = new OleDbCommand(" SELECT * FROM(( Tbl_PickupSeat LEFT JOIN Tbl_Information ON Tbl_PickupSeat.PickupCode = Tbl_Information.PickupCode ) LEFT JOIN Tbl_Discount ON Tbl_Discount.DiscountCode = Tbl_Information.Discount) WHERE Tbl_PickupSeat.PickupCode = (SELECT MAX(PickupCode) from Tbl_PickupSeat) ", newconnection.connection);
            DataSet dspickup = new DataSet();
            OleDbDataAdapter dapickup = new OleDbDataAdapter(cmdpickup);
            dapickup.Fill(dspickup, "tblpick");
            newconnection.connection.Close();
            DataTable dtpickup = dspickup.Tables[0];

            double discount = 0;
            //double sdis = 0;
            //double tdis = 0;

            foreach (DataRow drpickup in dtpickup.Rows)
            {
                discount = Convert.ToDouble(drpickup["DPercentage"]);
            }
            total = (Convert.ToDouble(price) * gv.CountOfTicket) - ((Convert.ToDouble(price) * gv.CountOfTicket) * (discount / 100));
            txtbx_Price.Text = price;
            txtbx_Discount.Text = discount.ToString();
            txtbx_NumberOfTickets.Text = gv.CountOfTicket.ToString();
            //txtbx_NumberOfTickets.Text = "3";
            txtbx_Total.Text = Convert.ToDecimal(total.ToString()).ToString("#,###.00");
        }

        //BUTTON PAY CODES
        private void btn_Pay_Click(object sender, EventArgs e)
        {
            if(txtbx_Amount.Text == null || txtbx_Amount.Text == ""){
                MessageBox.Show("Payment Invalid.");
                return;
            }
            double cash = 0;
            double change = 0;
            cash = Convert.ToDouble(txtbx_Amount.Text);
            //change = Convert.ToDouble(txtbx_Change.Text);
            if (cash < total)
            {
                MessageBox.Show("Invalid Amount");
                return;
            }
                
            else
            {
                change = cash - total;
                txtbx_Change.Text = change.ToString();
            }
            OrderNumber();
            Printing frmtickets = new Printing();
            frmtickets.Show();
            this.Close();
            //MessageBox.Show(year);

            InsertTicketSaleinDb();
        }

        //ORDER NUMBER CODES
        private void OrderNumber()
        {
            string year = string.Empty;
            string datenow = string.Empty;
            DateTime now = DateTime.Now;
            year = now.ToString("yyyy");
            datenow = now.ToString("dd/MM/yyyy");
            string cinemacode = string.Empty;
            string ticketnumber = string.Empty;
            //max of pickupcode
            string maxpickupcode = "0";
            newconnection.OpenConnection();
            //OleDbCommand maxcode = new OleDbCommand("SELECT MAX(PickupCode) AS pickupcode FROM Tbl_PickupSeat", newconnection.connection);
            OleDbCommand maxcode = new OleDbCommand("SELECT * FROM Tbl_PickupSeat AS t1 LEFT JOIN Tbl_CinemaAssignment AS t2 ON t1.AssignCode = t2.AssignCode WHERE t1.Pickupcode = (SELECT MAX(Pickupcode) FROM Tbl_PickupSeat)", newconnection.connection);
            OleDbDataReader maxread = maxcode.ExecuteReader();
            if (maxread != null)
            {
                if (maxread.HasRows)
                {
                    maxread.Read();
                    maxpickupcode = object.ReferenceEquals(maxread["pickupcode"], DBNull.Value) ? "0" : maxread["pickupcode"].ToString();
                    cinemacode = maxread["CinemaCode"].ToString();
                }
            }
            newconnection.connection.Close();
            //

            // max of order number
            string currentcode = "0";
            string newcode = "";
            string ordernum = "0";

            newconnection.OpenConnection();
            OleDbCommand cmdordernum = new OleDbCommand("SELECT RIGHT(MAX (OrderNumber),4) AS ordernum FROM Tbl_Payment", newconnection.connection);
            OleDbDataReader readpayment = cmdordernum.ExecuteReader();
            if (readpayment != null)
            {
                if (readpayment.HasRows)
                {
                    readpayment.Read();
                    currentcode = object.ReferenceEquals(readpayment["ordernum"], DBNull.Value) ? "0" : readpayment["ordernum"].ToString();
                }
            }
            newconnection.connection.Close();
            double code = 0;
            code = Convert.ToDouble(currentcode) + 1;
            newcode = code.ToString("0000");

            ordernum = year + newcode.ToString();

            double ticketcode = 0;
            string newticketnum = "";
            string currentticket = "0";


            newconnection.OpenConnection();
            OleDbCommand cmdpayment = new OleDbCommand(" INSERT INTO Tbl_Payment (OrderNumber, Pickupcode, TicketQuantity,Discount,Total,Cash,Change,OrderDate) VALUES ('" + ordernum + "','" + maxpickupcode + "','" + gv.CountOfTicket + "','" + txtbx_Discount.Text + "','" + txtbx_Total.Text + "','" + txtbx_Amount.Text + "','" + txtbx_Change.Text + "','" + datenow + "')", newconnection.connection);
            cmdpayment.ExecuteNonQuery();
            newconnection.connection.Close();

            string seatcode = string.Empty;

            newconnection.OpenConnection();
            OleDbCommand cmdseatcode = new OleDbCommand("SELECT * FROM Tbl_PickupSeat AS t1 LEFT JOIN Tbl_CinemaAssignment AS t2 ON t1.AssignCode = t2.AssignCode WHERE t1.Pickupcode = (SELECT MAX(Pickupcode) FROM Tbl_PickupSeat)", newconnection.connection);
            DataSet dsseatcode = new DataSet();
            OleDbDataAdapter daseatcode = new OleDbDataAdapter(cmdseatcode);
            daseatcode.Fill(dsseatcode, "tblseatcode");
            newconnection.connection.Close();
            DataTable dtseatcode = dsseatcode.Tables["tblseatcode"];
            foreach (DataRow drseatcode in dtseatcode.Rows)
            {
                //for (int i = 0; i <= Convert.ToInt16(seatcode[gv.CountOfTicket]); i ++)
                //{
                seatcode = drseatcode["SeatCode"].ToString();
                //}
                newconnection.OpenConnection();
                OleDbCommand cmdticketnum = new OleDbCommand("SELECT RIGHT(MAX (Ticketcode),5) AS ticketnum FROM Tbl_TicketNumber WHERE (SELECT LEFT(MAX(TicketCode), 2) AS leftstring FROM Tbl_TicketNumber) = '" + cinemacode + "'", newconnection.connection);
                OleDbDataReader readticket = cmdticketnum.ExecuteReader();
                if (readticket != null)
                {
                    if (readticket.HasRows)
                    {
                        readticket.Read();
                        currentticket = object.ReferenceEquals(readticket["ticketnum"], DBNull.Value) ? "0" : readticket["ticketnum"].ToString();
                    }
                }
                newconnection.connection.Close();
                ticketcode = Convert.ToDouble(currentticket) + 1;
                newticketnum = ticketcode.ToString("000000000");

                ticketnumber = cinemacode + year + newticketnum;

                newconnection.OpenConnection();
                OleDbCommand cmdticket = new OleDbCommand(" INSERT INTO Tbl_TicketNumber (TicketCode, OrderNumber,SeatCode) VALUES ('" + ticketnumber + "','" + ordernum + "','" + seatcode + "')", newconnection.connection);
                cmdticket.ExecuteNonQuery();
                newconnection.connection.Close();
            }
            //for (int i = 1; i <= gv.CountOfTicket; i++)
            //{
            //    newconnection.OpenConnection();
            //    OleDbCommand cmdticketnum = new OleDbCommand("SELECT RIGHT(MAX (Ticketcode),5) AS ticketnum FROM Tbl_TicketNumber WHERE (SELECT LEFT(MAX(TicketCode), 2) AS leftstring FROM Tbl_TicketNumber) = '" + cinemacode + "'", newconnection.connection);
            //    OleDbDataReader readticket = cmdticketnum.ExecuteReader();
            //    if (readticket != null)
            //    {
            //        if (readticket.HasRows)
            //        {
            //            readticket.Read();
            //            currentticket = object.ReferenceEquals(readticket["ticketnum"], DBNull.Value) ? "0" : readticket["ticketnum"].ToString();
            //        }
            //    }
            //    newconnection.connection.Close();
            //    ticketcode = Convert.ToDouble(currentticket) + 1;
            //    newticketnum = ticketcode.ToString("000000000");

            //    ticketnumber = cinemacode + year + newticketnum;

            //    newconnection.OpenConnection();
            //    OleDbCommand cmdticket = new OleDbCommand(" INSERT INTO Tbl_TicketNumber (TicketCode, OrderNumber,SeatCode) VALUES ('" + ticketnumber + "','" + ordernum + "','" + seatcode[i] + "')", newconnection.connection);
            //        cmdticket.ExecuteNonQuery();
            //    newconnection.connection.Close();
            //}
        }

        //AMOUNT TXTBOX VALIDATION
        private void txtbx_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //INSERT TICKET SALES IN DATABASE
        public void InsertTicketSaleinDb()
        {
            newconnection.connection.Open();
            string queryforgettingcurrentsale = "SELECT * FROM Tbl_Movies WHERE moviecode='" + gv.Moviecode + "'";
            OleDbCommand getticketsale = new OleDbCommand(queryforgettingcurrentsale, newconnection.connection);
            OleDbDataReader odr = getticketsale.ExecuteReader();
            odr.Read();

            string sale = odr["movieticketsale"].ToString();
            int tick = int.Parse(sale);
            int adding = tick + gv.CountOfTicket;


            string ticketsale1 = "UPDATE Tbl_Movies SET [movieticketsale]='" + adding + "' WHERE [moviecode]='" + gv.Moviecode + "'";
            OleDbCommand ticketsale = new OleDbCommand(ticketsale1, newconnection.connection);
            ticketsale.ExecuteNonQuery();
            newconnection.connection.Close();
        }

        private void txtbx_Amount_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        
    }//clss close
}//namespace close
