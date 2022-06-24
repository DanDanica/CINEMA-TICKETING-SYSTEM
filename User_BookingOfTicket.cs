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
    public partial class User_BookingOfTicket : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );
        public User_BookingOfTicket()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
        }

        GlobalVariable newmcode = new GlobalVariable();
        ConnectionForm newconnection = new ConnectionForm();

        private void User_BookingOfTicket_Load(object sender, EventArgs e)
        {
            pnl_Description.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_Description.Width, pnl_Description.Height, 22, 22));
            pbx_moviepic.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pbx_moviepic.Width, pbx_moviepic.Height, 18, 18));
            shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 18, 18));
            btn_Book.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Book.Width, btn_Book.Height, 50, 50));
            ShowDetails();
        }

        private void btn_Book_Click(object sender, EventArgs e)
        {
            User_Seats seats = new User_Seats();
            seats.Show();
            this.Hide();
        }

        private void ShowDetails()
        {
            newconnection.OpenConnection();
            OleDbCommand tblmoviesCommand = new OleDbCommand("SELECT * FROM Tbl_Movies", newconnection.connection);
            DataSet dstblmovies = new DataSet();
            OleDbDataAdapter datblmovies = new OleDbDataAdapter(tblmoviesCommand);
            datblmovies.Fill(dstblmovies, "table1");
            newconnection.connection.Close();
            DataTable dttblmovies = dstblmovies.Tables[0];
            foreach (DataRow dr in dttblmovies.Rows)
            {
                if (dr["moviecode"].ToString() == newmcode.Moviecode)
                {
                    pbx_moviepic.Image = Image.FromFile(dr["movieposter"].ToString());
                    lbl_MovieTitle.Text = dr["movietitle"].ToString();
                    lbl_MovieGenre.Text = dr["moviegenre"].ToString();
                    lbl_MovieDirector.Text = dr["moviedirector"].ToString();
                    lbl_MovieDescription.Text = dr["moviedescription"].ToString();
                    newmcode.movietitle = dr["movietitle"].ToString();
                    newmcode.movieprice = dr["movieprice"].ToString();
                    newmcode.moviegenre = dr["moviegenre"].ToString();
                }
            }


        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new User_Dashboard().Show();
        }
        
    }//
}//
