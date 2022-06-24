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
    public partial class RegForm : Form
    {

        public RegForm()
        {
            InitializeComponent();
        }
        ConnectionForm newconnection = new ConnectionForm();
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");
        OleDbCommand ocmd = new OleDbCommand();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );
        private void btn_CreateOT_Click(object sender, EventArgs e)
        {


            if (txtbx_Username.Text == "" || txtbx_Password.Text == "" || txtbx_ConfirmPass.Text == "")
            {
                MessageBox.Show("Fields are Empty", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtbx_Password.Text == txtbx_ConfirmPass.Text)
            {


                connect.Open();
                string onetime = "INSERT INTO Tbl_Account ([Username],[Password],[Avatar],[Description]) VALUES('" + txtbx_Username.Text + "','" + txtbx_Password.Text + "','1','Superadmin')";
                 ocmd = new OleDbCommand(onetime, connect);
                ocmd.ExecuteNonQuery();
                connect.Close();
                this.Hide();
                new Portals().Show();
                MessageBox.Show("ACCOUNT SUCCESSFULLY CREATED", "Register added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Password does not match", "Register Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                connect.Close();
            }


        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            btn_Create.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Create.Width, btn_Create.Height, 50, 50));
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            if (txtbx_Password.UseSystemPasswordChar == true)
            {
                txtbx_Password.UseSystemPasswordChar = false;
            }
            else
            {
                txtbx_Password.UseSystemPasswordChar = true;
            }
        }


    }
}
