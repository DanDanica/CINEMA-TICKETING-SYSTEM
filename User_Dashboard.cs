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
    public partial class User_Dashboard : Form
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
        public User_Dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            curtain = Properties.Resources.curtain;
        }

        int place = 0;
        GlobalVariable mcode = new GlobalVariable();
        ConnectionForm newconnection = new ConnectionForm();
        private Image curtain;
        string cinemacode = string.Empty;
        DateTime datenow = DateTime.Now;
        string NowDate;
        string tblmoviesstring = "SELECT t1.CinemaCode,t2.moviecode, IIF( StatusCode is Null,0,1) AS status FROM Tbl_CinemaCode AS t1 LEFT JOIN Tbl_CinemaAssignment AS t2 ON(t1.CinemaCode = t2.CinemaCode And t2.StatusCode = '1')group by t1.CinemaCode,moviecode,StatusCode";

        //MAIN
        private void User_Dashboard_Load(object sender, EventArgs e)
        {
            pnl_movie1.Visible = false;
            pnl_movie2.Visible = false;
            pnl_movie3.Visible = false;
            lbl_buttonclick.Text = "";
            btn_TopGrossing.PerformClick();

            shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 18, 18));
            pnl_movie1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_movie1.Width, pnl_movie1.Height, 18, 18));
            shadow2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow2.Width, shadow2.Height, 18, 18));
            pnl_movie2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_movie2.Width, pnl_movie2.Height, 18, 18));
            shadow3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow3.Width, shadow3.Height, 18, 18));
            pnl_movie3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_movie3.Width, pnl_movie3.Height, 18, 18));
            pnl_Movies.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_Movies.Width, pnl_Movies.Height, 50, 50));
            btn_TopGrossing.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_TopGrossing.Width, btn_TopGrossing.Height, 25, 25));
            ////NOW SHOWING 
            btn_NowShowing.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_NowShowing.Width, btn_NowShowing.Height, 25, 25));
            ////MORE 
            btn_More.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_More.Width, btn_More.Height, 25, 25));
            btn_TopGrossing.BackColor = Color.FromArgb(24, 18, 20);
            update();
        }

        //PANELS FOR CINEMAS
        #region movie panel click
        private void pnl_movie1_Click(object sender, EventArgs e)
        {
            panel1();
        }
        private void pnl_movie2_Click(object sender, EventArgs e)
        {
            panel2();
        }
        private void pnl_movie3_Click(object sender, EventArgs e)
        {
            panel3();
        }
        #endregion

        #region button

        //BUTTON TOP GROSSING CLICK AND LEAVE
        private void btn_TopGrossing_Click(object sender, EventArgs e)
        {
            btn_TopGrossing.BackColor = Color.FromArgb(24, 18, 20);
            pnl_movie1.Visible = true;
            pnl_movie2.Visible = true;
            pnl_movie3.Visible = true;
            place = 1;
            showpanel();
        }

        private void btn_TopGrossing_Leave(object sender, EventArgs e)
        {
            btn_TopGrossing.BackColor = Color.FromArgb(26, 26, 28);
        }

        //BUTTON NOW SHOWING CLICK AND LEAVE
        private void btn_NowShowing_Click(object sender, EventArgs e)
        {
            pnl_movie1.Visible = true;
            pnl_movie2.Visible = true;
            pnl_movie3.Visible = true;
            btn_NowShowing.BackColor = Color.FromArgb(24, 18, 20);
            place = 2;
            showpanel();
        }
        private void btn_NowShowing_Leave(object sender, EventArgs e)
        {
            btn_NowShowing.BackColor = Color.FromArgb(26, 26, 28);
        }

        //BUTTON MORE CLICK AND LEAVE
        private void btn_More_Click(object sender, EventArgs e)
        {
            pnl_movie1.Visible = true;
            pnl_movie2.Visible = true;
            pnl_movie3.Visible = true;
            btn_More.BackColor = Color.FromArgb(24, 18, 20);
            place = 3;
            showpanel();
        }
        private void btn_More_Leave(object sender, EventArgs e)
        {
            btn_More.BackColor = Color.FromArgb(26, 26, 28);
        }
        #endregion

        //SHOWPANEL METHOD
        private void showpanel()
        {
            newconnection.OpenConnection();
            //OleDbCommand tblmoviesCommand = new OleDbCommand("SELECT * FROM Tbl_CinemaAssignment AS tbl1 LEFT JOIN Tbl_Movies AS tbl2 ON tbl1.moviecode = tbl2.moviecode", newconnection.connection);

            OleDbCommand tblmoviesCommand = new OleDbCommand("SELECT t1.CinemaCode,t2.moviecode, IIF( StatusCode is Null,0,1) AS status,t3.movieposter,t3.movietitle,t3.moviegenre,t3.moviedirector,t3.movieprice FROM(( Tbl_CinemaCode AS t1 LEFT JOIN Tbl_CinemaAssignment AS t2 ON(t1.CinemaCode = t2.CinemaCode And t2.StatusCode = '1')) LEFT JOIN Tbl_Movies AS t3 ON t2.moviecode = t3.moviecode)", newconnection.connection);
            DataSet dstblmovies = new DataSet();
            OleDbDataAdapter datblmovies = new OleDbDataAdapter(tblmoviesCommand);
            datblmovies.Fill(dstblmovies, "table1");
            newconnection.connection.Close();
            DataTable dttblmovies = dstblmovies.Tables[0];
            foreach (DataRow dr in dttblmovies.Rows)
            {
                if (place == 1)
                {
                    lbl_buttonclick.Text = "Cinema 1-3";
                    if (dr["CinemaCode"].ToString() == "C1")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie1.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle1.Text = dr["movietitle"].ToString();
                            lbl_genre1.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector1.Text = dr["moviedirector"].ToString();
                            lbl_price1.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie1.Image = curtain;
                            lbl_MovieTitle1.Text = "";
                            lbl_genre1.Text = "";
                            lbl_MovieDirector1.Text = "";
                            lbl_price1.Text = "";
                        }
                    }
                    else if (dr["CinemaCode"].ToString() == "C2")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie2.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle2.Text = dr["movietitle"].ToString();
                            lbl_genre2.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector2.Text = dr["moviedirector"].ToString();
                            lbl_price2.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie2.Image = curtain;
                            lbl_MovieTitle2.Text = "";
                            lbl_genre2.Text = "";
                            lbl_MovieDirector2.Text = "";
                            lbl_price2.Text = "";
                        }
                    }
                    else if (dr["CinemaCode"].ToString() == "C3")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie3.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle3.Text = dr["movietitle"].ToString();
                            lbl_genre3.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector3.Text = dr["moviedirector"].ToString();
                            lbl_price3.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie3.Image = curtain;
                            lbl_MovieTitle3.Text = "";
                            lbl_genre3.Text = "";
                            lbl_MovieDirector3.Text = "";
                            lbl_price3.Text = "";
                        }
                    }

                }
                else if (place == 2)
                {
                    lbl_buttonclick.Text = "Cinema 4-6";
                    if (dr["CinemaCode"].ToString() == "C4")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie1.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle1.Text = dr["movietitle"].ToString();
                            lbl_genre1.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector1.Text = dr["moviedirector"].ToString();
                            lbl_price1.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie1.Image = curtain;
                            lbl_MovieTitle1.Text = "";
                            lbl_genre1.Text = "";
                            lbl_MovieDirector1.Text = "";
                            lbl_price1.Text = "";
                        }
                    }
                    else if (dr["CinemaCode"].ToString() == "C5")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie2.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle2.Text = dr["movietitle"].ToString();
                            lbl_genre2.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector2.Text = dr["moviedirector"].ToString();
                            lbl_price2.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie2.Image = curtain;
                            lbl_MovieTitle2.Text = "";
                            lbl_genre2.Text = "";
                            lbl_MovieDirector2.Text = "";
                            lbl_price2.Text = "";
                        }
                    }
                    else if (dr["CinemaCode"].ToString() == "C6")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie3.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle3.Text = dr["movietitle"].ToString();
                            lbl_genre3.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector3.Text = dr["moviedirector"].ToString();
                            lbl_price3.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie3.Image = curtain;
                            lbl_MovieTitle3.Text = "";
                            lbl_genre3.Text = "";
                            lbl_MovieDirector3.Text = "";
                            lbl_price3.Text = "";
                        }
                    }
                }
                else if (place == 3)
                {
                    lbl_buttonclick.Text = "Cinema 7-9";
                    if (dr["CinemaCode"].ToString() == "C7")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie1.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle1.Text = dr["movietitle"].ToString();
                            lbl_genre1.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector1.Text = dr["moviedirector"].ToString();
                            lbl_price1.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie1.Image = curtain;
                            lbl_MovieTitle1.Text = "";
                            lbl_genre1.Text = "";
                            lbl_MovieDirector1.Text = "";
                            lbl_price1.Text = "";
                        }
                    }
                    else if (dr["CinemaCode"].ToString() == "C8")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie2.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle2.Text = dr["movietitle"].ToString();
                            lbl_genre2.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector2.Text = dr["moviedirector"].ToString();
                            lbl_price2.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie2.Image = curtain;
                            lbl_MovieTitle2.Text = "";
                            lbl_genre2.Text = "";
                            lbl_MovieDirector2.Text = "";
                            lbl_price2.Text = "";
                        }
                    }
                    else if (dr["CinemaCode"].ToString() == "C9")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            pbx_movie3.Image = Image.FromFile(dr["movieposter"].ToString());
                            lbl_MovieTitle3.Text = dr["movietitle"].ToString();
                            lbl_genre3.Text = dr["moviegenre"].ToString();
                            lbl_MovieDirector3.Text = dr["moviedirector"].ToString();
                            lbl_price3.Text = "P " + Convert.ToDecimal(dr["movieprice"].ToString()).ToString("#,###.00");
                        }
                        else
                        {
                            pbx_movie3.Image = curtain;
                            lbl_MovieTitle3.Text = "";
                            lbl_genre3.Text = "";
                            lbl_MovieDirector3.Text = "";
                            lbl_price3.Text = "";
                        }
                    }
                }
            }//row loop end
        }
        //UPDATE METHOD
        private void update()
        {
            NowDate = datenow.ToString("MM/dd/yy");
            newconnection.OpenConnection();
            OleDbCommand tblmoviesCommand = new OleDbCommand("SELECT * FROM (SELECT IIF( #" + NowDate + "# between StartShowing and EndShowing,1,0) AS ex, * FROM Tbl_CinemaAssignment AS tbl1 LEFT JOIN Tbl_Movies AS tbl2 ON tbl1.moviecode = tbl2.moviecode)", newconnection.connection);
            DataSet dstblmovies = new DataSet();
            OleDbDataAdapter datblmovies = new OleDbDataAdapter(tblmoviesCommand);
            datblmovies.Fill(dstblmovies, "table1");
            newconnection.connection.Close();
            DataTable dttblmovies = dstblmovies.Tables["table1"];
            foreach (DataRow dr in dttblmovies.Rows)
            {
                cinemacode = dr["AssignCode"].ToString();

                if (dr["ex"].ToString() == "0" && dr["StatusCode"].ToString() == "1")
                {
                    newconnection.OpenConnection();
                    OleDbCommand cmdupdate = new OleDbCommand("UPDATE Tbl_CinemaAssignment SET StatusCode = '2' WHERE AssignCode = '" + cinemacode + "' ", newconnection.connection);
                    cmdupdate.ExecuteNonQuery();
                    newconnection.connection.Close();
                }
                else if (dr["ex"].ToString() == "1" && dr["StatusCode"].ToString() == "0")
                {
                    newconnection.OpenConnection();
                    OleDbCommand cmdupdate = new OleDbCommand("UPDATE Tbl_CinemaAssignment SET StatusCode = '1' WHERE AssignCode = '" + cinemacode + "' ", newconnection.connection);
                    cmdupdate.ExecuteNonQuery();
                    newconnection.connection.Close();
                }
            }


        }
        #region getmoviecode
        //PANEL 1 METHOD
        private void panel1()
        {
            //NowDate = datenow.ToString("MM/dd/yy");
            newconnection.OpenConnection();
            OleDbCommand tblmoviesCommand = new OleDbCommand(tblmoviesstring, newconnection.connection);
            //OleDbCommand tblmoviesCommand = new OleDbCommand("SELECT * FROM (SELECT IIF( #" + NowDate + "# between StartShowing and EndShowing,1,0) AS ex, * FROM Tbl_CinemaAssignment AS tbl1 LEFT JOIN Tbl_Movies AS tbl2 ON tbl1.moviecode = tbl2.moviecode)", newconnection.connection);
            DataSet dstblmovies = new DataSet();
            OleDbDataAdapter datblmovies = new OleDbDataAdapter(tblmoviesCommand);
            datblmovies.Fill(dstblmovies, "table1");
            newconnection.connection.Close();
            DataTable dttblmovies = dstblmovies.Tables[0];
            foreach (DataRow dr in dttblmovies.Rows)
            {
                if (place == 1)
                {
                    if (dr["CinemaCode"].ToString() == "C1")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MOVIE UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }
                else if (place == 2)
                {
                    if (dr["CinemaCode"].ToString() == "C4")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MOVIE UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }
                else
                {
                    if (dr["CinemaCode"].ToString() == "C7")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MOVIE UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }

            }

            //MessageBox.Show(mcode.Moviecode);
            User_BookingOfTicket user = new User_BookingOfTicket();
            user.Show();
            this.Hide();
        }
        //PANEL 2 METHOD
        private void panel2()
        {
            newconnection.OpenConnection();
            OleDbCommand tblmoviesCommand = new OleDbCommand(tblmoviesstring, newconnection.connection);
            DataSet dstblmovies = new DataSet();
            OleDbDataAdapter datblmovies = new OleDbDataAdapter(tblmoviesCommand);
            datblmovies.Fill(dstblmovies, "table1");
            newconnection.connection.Close();
            DataTable dttblmovies = dstblmovies.Tables[0];
            foreach (DataRow dr in dttblmovies.Rows)
            {
                if (place == 1)
                {
                    if (dr["CinemaCode"].ToString() == "C2")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("CINEMA UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }
                else if (place == 2)
                {
                    if (dr["CinemaCode"].ToString() == "C5")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MOVIE UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }
                else
                {
                    if (dr["CinemaCode"].ToString() == "C8")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MOVIE UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }

            }
            //MessageBox.Show(mcode.Moviecode);
            User_BookingOfTicket user = new User_BookingOfTicket();
            user.Show();
            this.Hide();
        }
        //PANEL 3 METHOD
        private void panel3()
        {
            newconnection.OpenConnection();
            OleDbCommand tblmoviesCommand = new OleDbCommand(tblmoviesstring, newconnection.connection);
            DataSet dstblmovies = new DataSet();
            OleDbDataAdapter datblmovies = new OleDbDataAdapter(tblmoviesCommand);
            datblmovies.Fill(dstblmovies, "table1");
            newconnection.connection.Close();
            DataTable dttblmovies = dstblmovies.Tables[0];
            foreach (DataRow dr in dttblmovies.Rows)
            {
                if (place == 1)
                {
                    if (dr["CinemaCode"].ToString() == "C3")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MOVIE UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }
                else if (place == 2)
                {
                    if (dr["CinemaCode"].ToString() == "C6")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MOVIE UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }
                else
                {
                    if (dr["CinemaCode"].ToString() == "C9")
                    {
                        if (dr["status"].ToString() == "1")
                        {
                            mcode.Moviecode = dr["moviecode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("MOVIE UNAVAILABLE AT THIS MOMENT. PLEASE SELECT OTHER CINEMAS");
                            return;
                        }
                    }
                }

            }
            //MessageBox.Show(mcode.Moviecode);
            User_BookingOfTicket user = new User_BookingOfTicket();
            user.Show();
            this.Hide();
        }

        #endregion

        //Hovering panels
        private void pnl_movie1_MouseMove(object sender, MouseEventArgs e)
        {
            shadow1.Visible = true;
        }
        private void pnl_movie1_MouseLeave(object sender, EventArgs e)
        {
            shadow1.Visible = false;
        }
        private void pnl_movie2_MouseMove(object sender, MouseEventArgs e)
        {
            shadow2.Visible = true;
        }
        private void pnl_movie2_MouseLeave(object sender, EventArgs e)
        {
            shadow2.Visible = false;
        }
        private void pnl_movie3_MouseMove(object sender, MouseEventArgs e)
        {
            shadow3.Visible = true;
        }
        private void pnl_movie3_MouseLeave(object sender, EventArgs e)
        {
            shadow3.Visible = false;
        }
    }//
}//
