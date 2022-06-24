using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;

namespace CinemaTicketing
{
    public partial class Printing : Form
    {
        public Printing()
        {
            InitializeComponent();
        }
        //var rpt =  CrystalDecisions.CrystalReports.Engine.ReportDocument;
        private ReportDocument rpt;
        GlobalVariable gv = new GlobalVariable();
        ConnectionForm newconnection = new ConnectionForm();

        
        public void RptTicket()
        {
            //DataTable dtticket = new DataTable("DtTicketing");
            //dtticket.Columns.Add();
            rpt = new CRTickets();


            newconnection.OpenConnection();
            OleDbCommand cmdticket = new OleDbCommand("SELECT t5.movietitle as MovieTitle, t4.CinemaCode as Cinema, t2.OrderDate as DD, t3.SeatCode as SeatCode, t5.movieprice as Price,t1.TicketCode as TicketNumber,RIGHT((t4.TimeSlot),11) AS PickTime FROM((((Tbl_TicketNumber AS t1 INNER JOIN Tbl_Payment AS t2 ON t1.OrderNumber = t2.OrderNumber) INNER JOIN Tbl_PickupSeat AS t3 ON t2.PickupCode = t3.PickupCode And t1.SeatCode = t3.SeatCode) LEFT JOIN Tbl_CinemaAssignment AS t4 ON t3.AssignCode = t4.AssignCode) LEFT JOIN Tbl_Movies AS t5 ON t4.moviecode = t5.moviecode) WHERE t1.OrderNumber = (SELECT MAX(OrderNumber) FROM Tbl_TicketNumber)", newconnection.connection);
            DataSet dsticket = new DataSet();
            OleDbDataAdapter daticket = new OleDbDataAdapter(cmdticket);
            daticket.Fill(dsticket, "dbtickets");
            newconnection.connection.Close();
            DataTable dtticket = dsticket.Tables["dbtickets"];

            //string MovieTitle

            //foreach (DataRow drtickets in dtticket.Rows)
            //{

            //}

            rpt.SetDataSource(dtticket);

            crptviewer.ReportSource = rpt;
            crptviewer.Refresh();
            crptviewer.Zoom(1);

        }

        private void crptviewer_Load(object sender, EventArgs e)
        {
            RptTicket();
        }

        private void Printing_Load(object sender, EventArgs e)
        {
            RptTicket();
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            new User_Dashboard().Show();
            this.Hide();
        }
    }
}
