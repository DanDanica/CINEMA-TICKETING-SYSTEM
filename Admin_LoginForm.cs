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
    public partial class Admin_LoginForm : Form
    {
        ConnectionForm newconnection = new ConnectionForm();
        OleDbConnection connect = new OleDbConnection ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );
        public Admin_LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }
        
        private void Admin_LoginForm_Load(object sender, EventArgs e)
        {
            txtbx_Username.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Username.Width, txtbx_Username.Height, 15, 15));
            txtbx_Password.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Password.Width, txtbx_Password.Height, 15, 15));
            shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 18, 18));
            shadow2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow2.Width, shadow2.Height, 18, 18));
            shadow3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow3.Width, shadow3.Height, 18, 18));
            btn_Login.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Login.Width, btn_Login.Height, 18, 18));

        }
        private void txtbx_Username_Enter(object sender, EventArgs e)
        {
            if (txtbx_Username.Text  == "Username")
            {
                txtbx_Username.Text = "";
                //txtbx_Username.Text = txtbx_Username.Text.PadLeft(txtbx_Username.Text.Length + 2);
                txtbx_Username.ForeColor = Color.Black;
               
            }
        }

        private void txtbx_Username_Leave(object sender, EventArgs e)
        {
            if(txtbx_Username .Text == "")
            {
                txtbx_Username.Text = "Username";
                
                txtbx_Username.ForeColor = Color.Gray;
            }
        }

        private void txtbx_Password_Enter(object sender, EventArgs e)
        {
            if (txtbx_Password.Text == "Password")
            {
                txtbx_Password.Text = "";
                txtbx_Password.ForeColor = Color.Black;
                txtbx_Password.UseSystemPasswordChar = true;

            }
        }

        private void txtbx_Password_Leave(object sender, EventArgs e)
        {
            if (txtbx_Password.Text == "")
            {
                txtbx_Password.Text = "Password";
                txtbx_Password.ForeColor = Color.Gray;
                txtbx_Password.UseSystemPasswordChar = false;

            }
        }

        private void btn_ShowPass_Click(object sender, EventArgs e)
        {
            if (txtbx_Password.UseSystemPasswordChar == true)
            {
                txtbx_Password.UseSystemPasswordChar = false;
            }
            else {
                txtbx_Password.UseSystemPasswordChar = true;
            }
            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txtbx_Username.Text == null || txtbx_Password.Text == null || txtbx_Username.Text == "Username" || txtbx_Password.Text == "Passowrd")
            {
                MessageBox.Show("Username and Password required!");
            }
            else
            {


                //Admin_Dashboard adminDashboard = new Admin_Dashboard();
                //adminDashboard.Show();
                //this.Hide();
                connect.Open();
                string login = "SELECT * FROM Tbl_Account WHERE Username='" + txtbx_Username.Text + "' AND Password='" + txtbx_Password.Text + "'";
                OleDbCommand ocmd = new OleDbCommand(login, connect);
                OleDbDataReader odr = ocmd.ExecuteReader();

                string loginsuperadmin = "SELECT * FROM Tbl_Account WHERE Username='" + txtbx_Username.Text + "'AND Password='" + txtbx_Password.Text + "' AND Description='Superadmin'";
                OleDbCommand ocmd1 = new OleDbCommand(loginsuperadmin, connect);
                OleDbDataReader ods = ocmd1.ExecuteReader();

                if (ods.Read() == true)
                {
                    GlobalVariable gv = new GlobalVariable();
                    //MessageBox.Show("WELCOME");
                    gv.usernameLogin = txtbx_Username.Text;
                    this.Hide();
                    gv.SA = ods["Description"].ToString();

                    new Admin_Dashboard().Show();

                }
                else if (odr.Read() == true)
                {
                    GlobalVariable gv = new GlobalVariable();
                    gv.SA = "Admin";
                    //MessageBox.Show("WELCOME");
                    gv.usernameLogin = txtbx_Username.Text; //GLOBAL VARIABLE 
                    this.Hide();
                    new Admin_Dashboard().Show();
                }
                else
                {
                    MessageBox.Show("Account does not match", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    regclear();
                    txtbx_Username.Focus();
                    connect.Close();

                }
            }
        }

        public void regclear()
        {

            txtbx_Username.Text = "";
            txtbx_Password.Text = "";

        }
    }
}
