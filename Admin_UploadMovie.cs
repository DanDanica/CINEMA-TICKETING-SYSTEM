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
    public partial class Admin_UploadMovie : Form
    {
        ConnectionForm newconnection = new ConnectionForm();
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");
        public string picpath, ticket;
        string genre1;
        public static string moviec = "";

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
        //MAIN
        private void Admin_UploadMovie_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 30, 30));
            btn_Upload.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Upload.Width, btn_Upload.Height, 9, 9));
            btn_Cancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Cancel.Width, btn_Cancel.Height, 9, 9));
        }
        public Admin_UploadMovie()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        //CANCEL BUTTON
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            new Admin_Dashboard().Show();
            this.Close();
        }
        //POSTER UPLOAD
        private void picbx_MoviePoster_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "png files(.png)|.png|jpg files(.jpg)|.jng|All files(.)|*.*";
                dialog.ShowDialog();
                picbx_MoviePoster.BackgroundImage = Image.FromFile(dialog.FileName);
                picpath = dialog.FileName.ToString();
                //   txtbx_PATH.Text = picpath;

                picbx_MoviePoster.ImageLocation = picpath;

                if (picpath != null)
                {


                    connect.Open();

                    string query = "SELECT COUNT(moviecode) From Tbl_Movies";

                    OleDbCommand ocmd = new OleDbCommand(query, connect);
                    string a = ocmd.ExecuteScalar().ToString();
                    int b = int.Parse(a);
                    int c = b + 1;

                    txtbx_MovieID.Text = "0" + c;
                    connect.Close();

                }
                else
                {
                    txtbx_MovieID.Text = "0";
                }

            }
            catch { }
        }
        //UPLOAD BUTTON
        private void btn_Upload_Click(object sender, EventArgs e)
        {
            if (txtbx_MovieTitle.Text == null || txtbx_MovieDirector.Text == null || picpath == null || txtbx_MovieDescription.Text == null || lstbx_MovieGenre.SelectedIndex == -1)
            {

                MessageBox.Show("Please fill the missing details");

            }
            else if (MessageBox.Show("Are you sure you want to upload this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                String strItem;

                foreach (Object selecteditem in lstbx_MovieGenre.SelectedItems)
                {
                    strItem = selecteditem as String;

                    genre1 += strItem + "|";

                }

                connect.Open();
                string query = "Insert into Tbl_Movies(moviecode,movietitle,movieposter,moviedirector,moviedescription,moviegenre,movieticketsale,movieprice) Values('" + txtbx_MovieID.Text + "','" + txtbx_MovieTitle.Text + "','" + picpath + "','" + txtbx_MovieDirector.Text + "','" + txtbx_MovieDescription.Text + "','" + genre1 + "','0','" + txtbx_MoviePrice.Text + "')";
                OleDbCommand ocmd = new OleDbCommand(query, connect);
                ocmd.ExecuteNonQuery();

                connect.Close();

                MessageBox.Show("Data has been saved successfully");
                this.Hide();
                moviec = txtbx_MovieID.Text;
                GlobalVariable gv = new GlobalVariable();
                gv.EditorAdd = 0;
                Admin_MovieScheduling ms = new Admin_MovieScheduling();
                ms.ShowDialog();

                ClearTextboxes();

            }
            else {
                MessageBox.Show("Movie not uploaded");
            }

        }

        //METHOD FOR CLEARING OF TEXTBOXES
        public void ClearTextboxes()
        {
            //    txtbx_MovieID.Text = "";
            txtbx_MovieTitle.Text = "";
            txtbx_MovieDirector.Text = "";
            txtbx_MovieDescription.Text = "";
            picpath = "";
            picbx_MoviePoster.Dispose();
            lstbx_MovieGenre.ClearSelected();
        }

        //KEYPRESS VALIDATION
        private void txtbx_MovieDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtbx_MovieTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtbx_MovieDirector_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtbx_MoviePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
