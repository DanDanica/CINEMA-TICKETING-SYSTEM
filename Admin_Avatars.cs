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
    public partial class Admin_Avatars : Form
    {
        string Avatar1, Avatar2, Avatar3, Avatar4, Avatar5, Avatar6, Avatar7, Avatar8;
        ConnectionForm newconnection = new ConnectionForm();
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");
        GlobalVariable gv = new GlobalVariable ();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );

        public string number;
        public Admin_Avatars()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            btn_Confirm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Confirm.Width, btn_Confirm.Height, 9, 9));
            btn_Cancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Cancel.Width, btn_Cancel.Height, 9, 9));
        }

        private void Admin_Avatars_Load(object sender, EventArgs e)
        {
            //shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 100, 100));
            picbx_Admin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, picbx_Admin.Width, picbx_Admin.Height, 100, 100));
            //panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            //CONNECTION QUERY FOR TABLE AVATAR 

            connect.Open();
            string query2 = "SELECT  * FROM Tbl_Avatar";
            OleDbCommand ocmd = new OleDbCommand(query2, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataSet ds1 = new DataSet();
            oda.Fill(ds1);


             Avatar1 = ds1.Tables[0].Rows[0][0].ToString(); // GET THE AVATAR LINK IN DATABASE
            picbx_Avatar1.ImageLocation = Avatar1;  //DISPLAY THE LINK GET IN DB

             Avatar2 = ds1.Tables[0].Rows[1][0].ToString();
            picbx_Avatar2.ImageLocation = Avatar2;
             Avatar3 = ds1.Tables[0].Rows[2][0].ToString();
            picbx_Avatar3.ImageLocation = Avatar3;
             Avatar4 = ds1.Tables[0].Rows[3][0].ToString();
            picbx_Avatar4.ImageLocation = Avatar4;
             Avatar5 = ds1.Tables[0].Rows[4][0].ToString();
            picbx_Avatar5.ImageLocation = Avatar5;
             Avatar6 = ds1.Tables[0].Rows[5][0].ToString();
            picbx_Avatar6.ImageLocation = Avatar6;
             Avatar7 = ds1.Tables[0].Rows[6][0].ToString();
            picbx_Avatar7.ImageLocation = Avatar7;
             Avatar8 = ds1.Tables[0].Rows[7][0].ToString();
            picbx_Avatar8.ImageLocation = Avatar8;

            connect.Close();

            GlobalVariable gv = new GlobalVariable();
            picbx_Admin.ImageLocation = gv.getpic;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin_Dashboard().Show();
        }

        private void picbx_Avatar1_MouseClick(object sender, MouseEventArgs e)
        {
            number = "1";
            obj(sender); // METHOD TO HIGHLIGHT AVATAR CLICKED
        }

        private void picbx_Avatar2_MouseClick(object sender, MouseEventArgs e)
        {
            number = "2";
            obj(sender); // METHOD TO HIGHLIGHT AVATAR CLICKED

        }

        private void picbx_Avatar3_MouseClick(object sender, MouseEventArgs e)
        {
            number = "3";
            obj(sender); // METHOD TO HIGHLIGHT AVATAR CLICKED

        }

        private void picbx_Avatar4_MouseClick(object sender, MouseEventArgs e)
        {
            number = "4";
            obj(sender); // METHOD TO HIGHLIGHT AVATAR CLICKED

        }

        private void picbx_Avatar5_MouseClick(object sender, MouseEventArgs e)
        {
            number = "5";
            obj(sender); // METHOD TO HIGHLIGHT AVATAR CLICKED

        }

        private void picbx_Avatar6_MouseClick(object sender, MouseEventArgs e)
        {
            number = "6";
            obj(sender); // METHOD TO HIGHLIGHT AVATAR CLICKED

        }

        private void picbx_Avatar7_MouseClick(object sender, MouseEventArgs e)
        {
            number = "7";
            obj(sender); // METHOD TO HIGHLIGHT AVATAR CLICKED

        }

        private void picbx_Avatar8_MouseClick(object sender, MouseEventArgs e)
        {
            number = "8";
            obj(sender); // METHOD TO HIGHLIGHT AVATAR CLICKED

        }
        public void obj(object pb) // METHOD TO HIGHLIGHT AVATAR CLICKED
        {
            switch (number) // NUMBER OF AVATAR CLICKED
            {
                case "1":
                    picbx_Avatar1.BorderStyle = BorderStyle.Fixed3D;
                    picbx_Avatar2.BorderStyle = BorderStyle.None;
                    picbx_Avatar3.BorderStyle = BorderStyle.None;
                    picbx_Avatar4.BorderStyle = BorderStyle.None;
                    picbx_Avatar5.BorderStyle = BorderStyle.None;
                    picbx_Avatar6.BorderStyle = BorderStyle.None;
                    picbx_Avatar7.BorderStyle = BorderStyle.None;
                    picbx_Avatar8.BorderStyle = BorderStyle.None;
                    picbx_Admin.ImageLocation = Avatar1;
                    gv.avatars = Avatar1;
                    break;

                case "2":
                    picbx_Avatar1.BorderStyle = BorderStyle.None;
                    picbx_Avatar2.BorderStyle = BorderStyle.Fixed3D;
                    picbx_Avatar3.BorderStyle = BorderStyle.None;
                    picbx_Avatar4.BorderStyle = BorderStyle.None;
                    picbx_Avatar5.BorderStyle = BorderStyle.None;
                    picbx_Avatar6.BorderStyle = BorderStyle.None;
                    picbx_Avatar7.BorderStyle = BorderStyle.None;
                    picbx_Avatar8.BorderStyle = BorderStyle.None;
                    picbx_Admin.ImageLocation = Avatar2;
                    break;

                case "3":

                    picbx_Avatar1.BorderStyle = BorderStyle.None;
                    picbx_Avatar2.BorderStyle = BorderStyle.None;
                    picbx_Avatar3.BorderStyle = BorderStyle.Fixed3D;
                    picbx_Avatar4.BorderStyle = BorderStyle.None;
                    picbx_Avatar5.BorderStyle = BorderStyle.None;
                    picbx_Avatar6.BorderStyle = BorderStyle.None;
                    picbx_Avatar7.BorderStyle = BorderStyle.None;
                    picbx_Avatar8.BorderStyle = BorderStyle.None;
                    picbx_Admin.ImageLocation = Avatar3;
                    break;

                   

                case "4":

                    picbx_Avatar1.BorderStyle = BorderStyle.None;
                    picbx_Avatar2.BorderStyle = BorderStyle.None;
                    picbx_Avatar3.BorderStyle = BorderStyle.None;
                    picbx_Avatar4.BorderStyle = BorderStyle.Fixed3D;
                    picbx_Avatar5.BorderStyle = BorderStyle.None;
                    picbx_Avatar6.BorderStyle = BorderStyle.None;
                    picbx_Avatar7.BorderStyle = BorderStyle.None;
                    picbx_Avatar8.BorderStyle = BorderStyle.None;
                    picbx_Admin.ImageLocation = Avatar4;
                    break;
                case "5":

                    picbx_Avatar1.BorderStyle = BorderStyle.None;
                    picbx_Avatar2.BorderStyle = BorderStyle.None;
                    picbx_Avatar3.BorderStyle = BorderStyle.None;
                    picbx_Avatar4.BorderStyle = BorderStyle.None;
                    picbx_Avatar5.BorderStyle = BorderStyle.Fixed3D;
                    picbx_Avatar6.BorderStyle = BorderStyle.None;
                    picbx_Avatar7.BorderStyle = BorderStyle.None;
                    picbx_Avatar8.BorderStyle = BorderStyle.None;
                    picbx_Admin.ImageLocation = Avatar5;
                    break;

                case "6":

                    picbx_Avatar1.BorderStyle = BorderStyle.None;
                    picbx_Avatar2.BorderStyle = BorderStyle.None;
                    picbx_Avatar3.BorderStyle = BorderStyle.None;
                    picbx_Avatar4.BorderStyle = BorderStyle.None;
                    picbx_Avatar5.BorderStyle = BorderStyle.None;
                    picbx_Avatar6.BorderStyle = BorderStyle.Fixed3D;
                    picbx_Avatar7.BorderStyle = BorderStyle.None;
                    picbx_Avatar8.BorderStyle = BorderStyle.None;
                    picbx_Admin.ImageLocation = Avatar6;
                    break;

                case "7":

                    picbx_Avatar1.BorderStyle = BorderStyle.None;
                    picbx_Avatar2.BorderStyle = BorderStyle.None;
                    picbx_Avatar3.BorderStyle = BorderStyle.None;
                    picbx_Avatar4.BorderStyle = BorderStyle.None;
                    picbx_Avatar5.BorderStyle = BorderStyle.None;
                    picbx_Avatar6.BorderStyle = BorderStyle.None;
                    picbx_Avatar7.BorderStyle = BorderStyle.Fixed3D;
                    picbx_Avatar8.BorderStyle = BorderStyle.None;
                    picbx_Admin.ImageLocation = Avatar7;
                    break;
                case "8":

                    picbx_Avatar1.BorderStyle = BorderStyle.None;
                    picbx_Avatar2.BorderStyle = BorderStyle.None;
                    picbx_Avatar3.BorderStyle = BorderStyle.None;
                    picbx_Avatar4.BorderStyle = BorderStyle.None;
                    picbx_Avatar5.BorderStyle = BorderStyle.None;
                    picbx_Avatar6.BorderStyle = BorderStyle.None;
                    picbx_Avatar7.BorderStyle = BorderStyle.None;
                    picbx_Avatar8.BorderStyle = BorderStyle.Fixed3D;
                    picbx_Admin.ImageLocation = Avatar8;
                    break;
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            string avatar = "UPDATE tbl_Account SET [Avatar]='" + number + "'WHERE [username]='" + gv.usernameLogin + "'";
            connect.Open();
            OleDbCommand ocmd = new OleDbCommand(avatar, connect);
            ocmd.ExecuteNonQuery();
            connect.Close();


            MessageBox.Show("AVATAR SUCCESSFULLY CHANGED!");
            this.Hide();
            new Admin_Dashboard().Show(); 
        }
    }
}
