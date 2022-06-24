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
    public partial class Admin_EditMovie : Form
    {
        //int count;
        //int code1 = 0;
        //string asscode = "";
        //string mindate;
        //String Ascode, Mcode, TimeS, StartS, EndS;
        //string assigncode = "0";
        DataTable dts = new DataTable();
        DataSet ds = new DataSet();
        GlobalVariable gv = new GlobalVariable();


        ConnectionForm newconnection = new ConnectionForm();
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");
        public string picpath, ticket;
        string genre1;
        public static string movieID;

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



        public Admin_EditMovie()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            //panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 30, 30));
            btn_Edit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Edit.Width, btn_Edit.Height, 9, 9));
            btn_Cancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Cancel.Width, btn_Cancel.Height, 9, 9));
        }
        //BUTTON EDIT FILM CODES
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (txtbx_Description.Text == null || txtbx_MovieDirector.Text == null || lstbx_MovieGenre.SelectedIndex == -1 || txtbx_MovieTitle.Text == null || txtbx_MoviePrice.Text == null)
            {
                MessageBox.Show("Please fill the missing details");
            }

        else if (picpath == null){
                MessageBox.Show("Choose Image to Update");
            }

        else if (MessageBox.Show("Are you sure you want to update this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            String strItem;

            foreach (Object selecteditem in lstbx_MovieGenre.SelectedItems) //FORLISTBOX
            {
                strItem = selecteditem as String;
                genre1 += strItem + "|";

            }
            connect.Open();
            string query = "select * from Tbl_Movies where moviecode='" + cmb_MovieID.Text + "'"; //GET THE CURRENT TICKETSALE
            OleDbCommand ocmd = new OleDbCommand(query, connect);
            OleDbDataReader sss = ocmd.ExecuteReader();
            sss.Read();
            string ticketsale = sss["movieticketsale"].ToString();

            //MessageBox.Show(ticketsale);

            string updateMovie = "UPDATE Tbl_Movies SET [movietitle]='" + txtbx_MovieTitle.Text + "',[movieposter]='" + picpath + "',[moviedirector]='" + txtbx_MovieDirector.Text + "',[moviedescription]='" + txtbx_Description.Text + "',[moviegenre]='" + genre1 + "',[movieticketsale]='" + ticketsale + "',[movieprice]='" + txtbx_MoviePrice.Text + "' WHERE [moviecode]='" + cmb_MovieID.Text + "'";
            OleDbCommand updating = new OleDbCommand(updateMovie, connect); //UPDATE THE MOVIE
            updating.ExecuteNonQuery();
            MessageBox.Show("UPDATED SALE UPDATED");
            connect.Close();

            movieID = cmb_MovieID.Text;
            gv.EditorAdd = 0;
            //new code
            //connect.Open();
            //int rowIndex = dgv_sched.CurrentCell.RowIndex;
            //String Ascode = dgv_sched.Rows[rowIndex].Cells[0].Value.ToString();
            //cmb_Cinema.Text = dgv_sched.Rows[rowIndex].Cells[1].Value.ToString();
            //MessageBox.Show(dgv_sched.Rows[rowIndex].Cells[1].Value.ToString());
            //string updatedb = "UPDATE Tbl_CinemaAssignment SET [TimeSlot]='" + cmb_Timeslot.Text + "',[StartShowing]='" + txtbx_Start.Text + "',[EndShowing]='" + txtbx_End.Text + "' WHERE [AssignCode]='" + Ascode + "'";
            //OleDbCommand cmd = new OleDbCommand(updatedb, connect);

            //cmd.ExecuteNonQuery();

            //connect.Close();

            //MessageBox.Show("UPDATED");
            ////end
            //new Admin_Dashboard().Show();
            this.Hide();
            if (MessageBox.Show("Do you want to edit this Movie Schedule?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new MovieScheduling_Calendar().Show();
            }
            else
            {
                new Admin_Dashboard().Show();
            }
            }


            else
            {
                MessageBox.Show("Movie is not Updated");
            }

            //new MovieScheduling().Show();

        }

        //COMBO BOX OF MOVIE CODES
        public void Fillcombobox()
        {
            connect.Open();
            OleDbCommand cmd = new OleDbCommand("select moviecode from Tbl_Movies", connect);
            OleDbDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    cmb_MovieID.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            connect.Close();
        }
        //FORM LOAD
        private void Admin_EditMovie_Load(object sender, EventArgs e)
        {
            Fillcombobox();
        }
        //PICTURE BOX CLICK
        private void picbx_EditPic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "png files(.png)|.png|jpg files(.jpg)|.jng|All files(.)|*.*";
                dialog.ShowDialog();
                picbx_EditPic.BackgroundImage = Image.FromFile(dialog.FileName);
                picpath = dialog.FileName.ToString();
                //   txtbx_PATH.Text = picpath;
                picbx_EditPic.ImageLocation = picpath;
                label8.Text = picpath;
                if (picpath != null)
                {
                    connect.Open();
                    string query = "SELECT COUNT(moviecode) From Tbl_Movies";
                    OleDbCommand ocmd = new OleDbCommand(query, connect);
                    string a = ocmd.ExecuteScalar().ToString();
                    int b = int.Parse(a);
                    int c = b + 1;
                    connect.Close();
                }
            }
            catch { }
        }
        //BUTTON CANCEL
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            new Admin_Dashboard().Show();
            this.Hide();
        }
        public void Viewer()
        {
            //  GlobalVariable gv = new GlobalVariable();
            connect.Open();
            string query = "select * from Tbl_Movies where moviecode='" + cmb_MovieID.Text + "'"; //GET THE CURRENT TICKETSALE
            OleDbCommand ocmd = new OleDbCommand(query, connect);
            OleDbDataReader sss = ocmd.ExecuteReader();
            sss.Read();
            txtbx_MovieTitle.Text = sss["movietitle"].ToString();
            string PASSimage = sss["movieposter"].ToString();
            txtbx_MovieDirector.Text = sss["moviedirector"].ToString();
            txtbx_Description.Text = sss["moviedescription"].ToString();
            txtbx_MovieGenre.Text = sss["moviegenre"].ToString();
            txtbx_MoviePrice.Text = sss["movieprice"].ToString();
            picbx_EditPic.ImageLocation = PASSimage;

            connect.Close();
        }

        private void cmb_MovieID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Viewer();
        }

        private void txtbx_MoviePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtbx_MovieTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtbx_MovieDirector_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtbx_Description_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        //private void showdatagridadd()
        //{
        //    connect.Open();
        //    string querysched = "SELECT * FROM Tbl_CinemaAssignment";

        //    OleDbCommand cmd = new OleDbCommand(querysched, connect);
        //    cmd.ExecuteNonQuery();
        //    OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    oda.Fill(dt);
        //    dgv_sched.DataSource = dt;
        //    connect.Close();
        //}

        //private void dgv_sched_MouseClick(object sender, MouseEventArgs e)
        //{
        //    int rowIndex = dgv_sched.CurrentCell.RowIndex;
        //    cmb_Cinema.Text = dgv_sched.Rows[rowIndex].Cells[1].Value.ToString();
        //}

        //private void btn_Add_Click(object sender, EventArgs e)
        //{
        //    connect.Open();
        //    string addAssigncode = "INSERT INTO Tbl_CinemaAssignment(Assigncode,CinemaCode) Values('" + asscode + "','" + cmb_Cinema.Text + "')";
        //    OleDbCommand cmd = new OleDbCommand(addAssigncode, connect);
        //    cmd.ExecuteNonQuery();

        //    MessageBox.Show("Datas Saved Successfully");

        //    connect.Close();
        //    label5.Text = "";
        //    cmb_Cinema.Text = "";



        //    String Time, Start, End;

        //    Time = cmb_Timeslot.Text;
        //    Start = txtbx_Start.Text;
        //    End = txtbx_End.Text;

        //    dts.Rows.Add(Time, asscode, Start, End);


        //    dgv_sched.DataSource = dts;



    }
}

