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
    public partial class Admin_Dashboard : Form
    {
        GlobalVariable Global = new GlobalVariable();
        string pass;
        int count, position = 0, a; 
        DataTable table1 = new DataTable();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        ConnectionForm newconnection = new ConnectionForm();
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + Application.StartupPath + @"\CinemaTicketing.mdb");
        OleDbCommand cmd = new OleDbCommand();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );
        public Admin_Dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            pnl_Movies.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_Movies.Width, pnl_Movies.Height, 50, 50));
            pnl_Admin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_Admin.Width, pnl_Admin.Height, 50, 50));
            pnl_CreateAcc.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_CreateAcc.Width, pnl_CreateAcc.Height, 50, 50));
            pnl_DGV.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_DGV.Width, pnl_DGV.Height, 50, 50));
            pcbx_User1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pcbx_User1.Width, pcbx_User1.Height, 50, 50));
            
        }

        //DASHBOARD LOAD
        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {
            LoadImagePath();
            Savatar();
            //MessageBox.Show(Global.SA);
            if (Global.SA == "Admin")
            {
                hidebutton();
                btn_LogOutAdmin.Visible = false;
                pnl_Accounts.Visible = false;
                btn_ContactTracing.Visible = false;
                pnl_Contact.Visible = false;
            }
            
            avatar();
            btn_Movies.PerformClick();
            
            submenu();
            loadAccount();
            loadmovies();
            //PANEL DESIGN
            //btn_LogOutAdmin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_LogOutAdmin.Width, btn_LogOutAdmin.Height, 25, 25));
            shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 18, 18));
            pnl_movie1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_movie1.Width, pnl_movie1.Height, 18, 18));
            shadow2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow2.Width, shadow2.Height, 18, 18));
            pnl_movie2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_movie2.Width, pnl_movie2.Height, 18, 18));
            shadow3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow3.Width, shadow3.Height, 18, 18));
            pnl_movie3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_movie3.Width, pnl_movie3.Height, 18, 18));
            btn_EditFilm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_EditFilm.Width, btn_EditFilm.Height, 20, 20));
            shadow_EditFilm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow_EditFilm.Width, shadow_EditFilm.Height, 20, 20));
            btn_UploadFilm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_UploadFilm.Width, btn_UploadFilm.Height, 20, 20));
            shadow_UploadFilm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow_UploadFilm.Width, shadow_UploadFilm.Height, 20, 20));
           
            //RECTANGULAR SIDES FOR OBJECTS
            btn_Next.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Next.Width, btn_Next.Height, 20, 20));
            btn_Previous.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Previous.Width, btn_Previous.Height, 20, 20));
            shadowNext.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadowNext.Width, shadowNext.Height, 20, 20));
            shadowPrevious.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadowPrevious.Width, shadowPrevious.Height, 20, 20));
            
            btn_SaveChanges.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_SaveChanges.Width, btn_SaveChanges.Height, 9, 9));
            btn_Avatar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Avatar.Width, btn_Avatar.Height, 9, 9));

            txtbxRegUser.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbxRegUser.Width, txtbxRegUser.Height, 9, 9));
            txtbxRegPass.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbxRegPass.Width, txtbxRegPass.Height, 9, 9));
            txtbxConfirmPass.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbxConfirmPass.Width, txtbxConfirmPass.Height, 9, 9));
            
        }
        //SUB MENUS
        private void submenu()
        {
            pnl_User.Visible = false;
            pnl_Movie.Visible = true;
        }
        private void adminmenu()
        {
            pnl_User.Visible = true;
            pnl_Movie.Visible = false;
        }
        private void hidemenus()
        {
            pnl_Movie.Visible = false;
            pnl_User.Visible = false;
        }
        private void EditProfile()
        {
            pnl_Movies.Visible  = false;
            pnl_Admin.Visible = true;
            pnl_DGV.Visible = false ;
            pnl_CreateAcc.Visible  = false;
           
        }
        private void CreateAcc()
        {
            pnl_Movies.Visible = false;
            pnl_Admin.Visible = false ;
            pnl_DGV.Visible = false;
            pnl_CreateAcc.Visible = true;
        }
        private void Movies()
        {
            pnl_Movies.Visible = true;
            pnl_Admin.Visible  = false;
            pnl_DGV.Visible = false;
            pnl_CreateAcc.Visible = false;
        }
        private void DataGridViews()
        {
            pnl_Movies.Visible = false ;
            pnl_Admin.Visible = false;
            pnl_DGV.Visible = true;
            pnl_CreateAcc.Visible = false;
            btn_UploadFilm.Visible = false;
            shadow_UploadFilm.Visible = false;
            btn_EditFilm.Visible = false;
            shadow_EditFilm.Visible = false;
        }
        private void hidebutton()
        {
            btn_AddNew.Visible = false;
            pnl_User.Visible = false;
            pnl_Movie.Visible = true;
            //pnl_CreateAcc.Visible = false;
        }

        //METHODS FOR SPANELS
        private void sPanelname()
        {
            sPanel_name.Visible = true;
            sPanel_Addnew.Visible = false;
            sPanel_Movies.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = false;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = false;
            sPanel_Payment.Visible = false;
            sPanel_Sales.Visible = false;
            sPanel_name.Top = btn_EditProfile.Top;
            sPanel_Accounts.Visible = false;
        }
        private void sPanelEditProfile()
    {
        sPanel_name.Visible = true;
        sPanel_Addnew.Visible = false;
        sPanel_Movies.Visible = false;
        sPanel_TopG.Visible = false;
        sPanel_Now.Visible = false;
        sPanel_More.Visible = false;
        sPanel_Transaction.Visible = false;
        sPanel_Contact.Visible = false;
        sPanel_Payment.Visible = false;
        sPanel_Sales.Visible = false;
        sPanel_name.Top = btn_EditProfile.Top;
        sPanel_Accounts.Visible = false;
    }
        private void sPanelAddNew()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = true;
            sPanel_Movies.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = false;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = false;
            sPanel_Addnew.Top = btn_AddNew.Top;
            sPanel_Accounts.Visible = false;
        }
        private void sPanelTopG()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = false;
            sPanel_TopG.Visible = true;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = false;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = false;
            sPanel_Payment.Visible = false;
            sPanel_Sales.Visible = false;
            sPanel_TopG.Top = btn_TopGrossing.Top;
            sPanel_Accounts.Visible = false;
        }
        private void sPanelNowShowing()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = true;
            sPanel_More.Visible = false;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = false;
            sPanel_Payment.Visible = false;
            sPanel_Sales.Visible = false;
            sPanel_Now.Top = btn_NowShowing.Top;
            sPanel_Accounts.Visible = false;
        }
        private void sPanelMore()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = true;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = false;
            sPanel_Payment.Visible = false;
            sPanel_Sales.Visible = false;
            sPanel_More.Top = btn_More.Top;
            //sPanel_More.BackColor = Color.LightGray;
            sPanel_Accounts.Visible = false;
            //sPanel_Movies.Visible = true;
            //sPanel_Movies.Top = btn_Movies.Top;
            //sPanel_Movies.BackColor = Color.DimGray;
        }
        private void sPanelTransaction()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = false;
            sPanel_Movies.Visible = false;
            sPanel_Transaction.Visible = true;
            sPanel_Contact.Visible = false;
            sPanel_Payment.Visible = false;
            sPanel_Sales.Visible = false;
            sPanel_Accounts.Visible = false;
            sPanel_Transaction.Top = btn_Transaction.Top;
        }
        private void sPanelContact()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = false;
            sPanel_Movies.Visible = false;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = true;
            sPanel_Payment.Visible = false;
            sPanel_Sales.Visible = false;
            sPanel_Contact.Top = btn_ContactTracing.Top;
            sPanel_Accounts.Visible = false;
        }
        private void sPanelPayment()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = false;
            sPanel_Movies.Visible = false;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = false;
            sPanel_Payment.Visible = true;
            sPanel_Sales.Visible = false;
            sPanel_Payment.Top = btn_Payment.Top;
            sPanel_Accounts.Visible = false;
        }
        private void sPanelSales()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = false;
            sPanel_Movies.Visible = false;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = false;
            sPanel_Payment.Visible = false;
            sPanel_Sales.Visible = true;
            sPanel_Sales.Top = btn_SalesReport.Top;
            sPanel_Accounts.Visible = false;
        }
        private void sPanelAccounts()
        {
            sPanel_name.Visible = false;
            sPanel_Addnew.Visible = false;
            sPanel_TopG.Visible = false;
            sPanel_Now.Visible = false;
            sPanel_More.Visible = false;
            sPanel_Movies.Visible = false;
            sPanel_Transaction.Visible = false;
            sPanel_Contact.Visible = false;
            sPanel_Payment.Visible = false;
            sPanel_Sales.Visible = false;
            sPanel_Accounts.Top = btn_Accounts.Top;
            sPanel_Accounts.Visible = true;
        }

        //PICTUREBOX FOR MOVIES
        private void pbxRatingFalse() 
        {
            pbx_First.Visible = false;
            pbx_Second.Visible = false;
            pbx_Third.Visible = false;
        }
        private void pbxRatingTrue()
        {
            pbx_First.Visible = true;
            pbx_Second.Visible = true;
            pbx_Third.Visible = true;
        }
        private void pbxCinemaFalse() {
            pbx_Cinema1.Visible = false;
            pbx_Cinema2.Visible = false;
            pbx_Cinema3.Visible = false;
        }
        private void pbxCinemaTrue() {
            pbx_Cinema1.Visible = true;
            pbx_Cinema2.Visible = true;
            pbx_Cinema3.Visible = true;
        }

        //BUTTON ADMIN CLICK AND LEAVE
        private void btn_Admin_Click(object sender, EventArgs e)
        {
            sPanelname();
            sPanel_Movies.Visible = false;
            btn_EditProfile.PerformClick();
            btn_EditProfile.BackColor = Color.FromArgb(24, 18, 20);
            adminmenu();
            EditProfile();
            sPanel_name.Visible = true;
            sPanel_Addnew.Visible = false;
            sPanel_name.Top = btn_EditProfile.Top;
            sPanel_Accounts.Visible = false;
        }
        private void btn_Admin_Leave(object sender, EventArgs e)
        {
            btn_Admin.BackColor = Color.FromArgb(26, 26, 28);
            btn_EditProfile.BackColor = Color.FromArgb(26, 26, 28);
            sPanel_name.Visible = true;
        }
        //EDIT PROFILE
        private void btn_EditProfile_Click(object sender, EventArgs e)
        {
            btn_EditProfile.BackColor = Color.FromArgb(24, 18, 20);
            EditProfile();
            avatar();
            sPanelEditProfile();
        }
        private void btn_EditProfile_Leave(object sender, EventArgs e)
        {
            btn_EditProfile.BackColor = Color.FromArgb(26, 26, 28);
        }
        //ADD NEW USER
        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            btn_AddNew.BackColor = Color.FromArgb(128, 128, 255);
            EditProfile();
            CreateAcc();
            sPanelAddNew();
            txtbxClear();
        }
        private void btn_AddNew_Leave(object sender, EventArgs e)
        {
            btn_AddNew.BackColor = Color.FromArgb(26, 26, 28);
            sPanel_Addnew.Visible = true;
            
        }

        //BUTTON MOVIES CLICK AND LEAVE
        private void btn_Movies_Click(object sender, EventArgs e)
        {
            btn_TopGrossing.PerformClick();
            btn_TopGrossing.BackColor = Color.FromArgb(24, 18, 20);
            submenu();
            Movies();
            sPanelTopG();
            pbxRatingTrue();
            pbxCinemaFalse();
            btn_Next.Visible = false;
            btn_Previous.Visible = false;
            shadowPrevious.Visible = false;
            shadowNext.Visible = false;
        }
        private void btn_Movies_Leave(object sender, EventArgs e)
        {
            //sPanel_TopG.BackColor = Color.LightGray;
            btn_Movies.BackColor = Color.FromArgb(26, 26, 28);
            btn_TopGrossing.BackColor = Color.FromArgb(26, 26, 28);
        }
        //TOP GROSSING
        private void btn_TopGrossing_Click(object sender, EventArgs e)
        {
            topGrossing();
            sPanelTopG();
            pbxRatingTrue();
            pbxCinemaFalse();
            btn_TopGrossing.BackColor = Color.FromArgb(24, 18, 20);
            btn_EditFilm.Visible = false;
            shadow_EditFilm.Visible = false;
            btn_UploadFilm.Visible = false;
            shadow_UploadFilm.Visible = false;
            btn_Next.Visible = false;
            btn_Previous.Visible = false;
            shadowNext.Visible = false;
            shadowPrevious.Visible = false;
            
        }
        private void btn_TopGrossing_Leave(object sender, EventArgs e)
        {
            btn_TopGrossing.BackColor = Color.FromArgb(26, 26, 28);
            //sPanel_TopG.BackColor = Color.DimGray;
        }
        //NOW SHOWING
        private void btn_NowShowing_Click(object sender, EventArgs e)
        {
            nowShowing();
            sPanelNowShowing();
            pbxRatingFalse();
            //pbxCinemaTrue();
            btn_NowShowing.BackColor = Color.FromArgb(24, 18, 20);
            //btn_TopGrossing.BackColor = Color.DimGray;
            btn_EditFilm.Visible = true;
            shadow_EditFilm.Visible = true;
            btn_UploadFilm.Visible = true ;
            shadow_UploadFilm.Visible = true;
            btn_Next.Visible = false;
            btn_Previous.Visible = false;
            shadowNext.Visible = false;
            shadowPrevious.Visible = false;
            
        }
        private void btn_NowShowing_Leave(object sender, EventArgs e)
        {
            btn_NowShowing.BackColor = Color.FromArgb(26, 26, 28);
            //sPanel_Now.BackColor = Color.DimGray;
        }
        //MORE MOVIES
        private void btn_More_Click(object sender, EventArgs e)
        {
            loadmovies();
            sPanelMore();
            pbxRatingFalse();
            pbxCinemaFalse();
            btn_More.BackColor = Color.FromArgb(24, 18, 20);
            btn_EditFilm.Visible = false;
            shadow_EditFilm.Visible = false;
            btn_UploadFilm.Visible = false;
            shadow_UploadFilm.Visible = false;
            btn_Next.Visible = true;
            btn_Previous.Visible = true;
            shadowNext.Visible = true;
            shadowPrevious.Visible = true;
        }
        private void btn_More_Leave(object sender, EventArgs e)
        {
            btn_More.BackColor = Color.FromArgb(26, 26, 28);
        }

        //BUTTON TRANSACTION CLICK AND LEAVE
        private void btn_Transaction_Click(object sender, EventArgs e)
        {
            sPanelTransaction();
            dgv_load();
            DataGridViews();
            btn_Transaction.BackColor = Color.FromArgb(24, 18, 20);
            hidemenus();
            lbl_Title.Text = "TRANSACTION";
            dgv_Account.Visible = false;
            btn_DeleteAcc.Visible = false;
            btn_Search.Visible = false;
            txtbx_Search.Visible = false;

        }
        private void btn_Transaction_Leave(object sender, EventArgs e)
        {
            btn_Transaction.BackColor = Color.FromArgb(26, 26, 28);
        }
        
        //BUTTON CONTACT TRACING CLICK AND LEAVE
        private void btn_ContactTracing_Click(object sender, EventArgs e)
        {
            refreshtable();
            sPanelContact();
            btn_ContactTracing.BackColor = Color.FromArgb(24, 18, 20);
            hidemenus();
            DataGridViews();
            lbl_Title.Text = "CONTACT TRACING";
            dgv_Account.Visible = false;
            btn_DeleteAcc.Visible = false;
            btn_Search.Visible = true;
            txtbx_Search.Visible = true;
            
        }
        private void btn_ContactTracing_Leave(object sender, EventArgs e)
        {
            btn_ContactTracing.BackColor = Color.FromArgb(26, 26, 28);
        }
       
        //BUTTON PAYMENT CLICK AND LEAVE
        private void btn_Payment_Click(object sender, EventArgs e)
        {
            dgv_paymentHistoryLoad();
            sPanelPayment();
            btn_Payment.BackColor = Color.FromArgb(24, 18, 20);
            hidemenus();
            DataGridViews();
            lbl_Title.Text = "PAYMENT";
            dgv_Account.Visible = false;
            btn_DeleteAcc.Visible = false;
            btn_Search.Visible = false;
            txtbx_Search.Visible = false;
        }
        private void btn_Payment_Leave(object sender, EventArgs e)
        {
            btn_Payment.BackColor = Color.FromArgb(26, 26, 28);
        }
        
        //BUTTON SALES REPORT CLICK AND LEAVE
        private void btn_SalesReport_Click(object sender, EventArgs e)
        {
            sales();
            sPanelSales();
            btn_SalesReport.BackColor = Color.FromArgb(24, 18, 20);
            hidemenus();
            DataGridViews();
            lbl_Title.Text = "SALES REPORT";
            dgv_Account.Visible = false;
            btn_DeleteAcc.Visible = false;
            btn_Search.Visible = false;
            txtbx_Search.Visible = false;
            
        }
        private void btn_SalesReport_Leave(object sender, EventArgs e)
        {
            btn_SalesReport.BackColor = Color.FromArgb(26, 26, 28);
        }
        //BUTTON ACCOUNTS
        private void btn_Accounts_Click(object sender, EventArgs e)
        {
            LoadAccount();
            hidemenus();
            sPanelAccounts();
            DataGridViews();
            sPanel_Movies.Visible = false;
            btn_Accounts.BackColor = Color.FromArgb(24, 18, 20);
            lbl_Title.Text = "ACCOUNTS";
            //sPanel_Accounts.Visible = true;
            dgv_Account.Visible = true;
            btn_DeleteAcc.Visible = true;
            lbl_Filter.Visible = false;
            cmb_Filter.Visible = false;
            btn_Search.Visible = false;
            txtbx_Search.Visible = false;
        }
        private void btn_Accounts_Leave(object sender, EventArgs e)
        {
            btn_Accounts.BackColor = Color.FromArgb(26, 26, 28);
        }


        //BUTTON AVATAR
        private void btn_Avatar_Click(object sender, EventArgs e)
        {
            Admin_Avatars avatar = new Admin_Avatars();
            avatar.Show();
            this.Hide();
        }

        //BUTTON CREATE NEW ACCOUNT
        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (txtbxRegUser.Text == "" || txtbxRegPass.Text == "" || txtbxConfirmPass.Text == "")
            {
                MessageBox.Show("Fields are Empty", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtbxRegPass.Text == txtbxConfirmPass.Text)
            {
                connect.Open();
                string register = "INSERT INTO Tbl_Account ([Username],[Password],[Avatar],[Description]) VALUES('" + txtbxRegUser.Text + "','" + txtbxRegPass.Text + "','1','Admin')";
                OleDbCommand ocmd = new OleDbCommand(register, connect);
                ocmd.ExecuteNonQuery();
                connect.Close();
                regclear();
                MessageBox.Show("SUCCESSFULLY CREATED", "Register added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password does not match", "Register Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtbxRegPass.Text = "";
                txtbxConfirmPass.Text = "";
            }

        }
        
        //method for clearing textboxes
        public void regclear()  
        {
            txtbxRegUser.Text = "";
            txtbxRegPass.Text = "";
            txtbxConfirmPass.Text = "";
}

        //CONFIRM PASSWORD
        private void txtbxConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (txtbxRegPass.Text == txtbxConfirmPass.Text)
            {

                lblMatched.Text = "Matched";
                lblMatched.ForeColor = Color.Purple;

            }
              
            else if(txtbxConfirmPass.Text == null){
                lblMatched.Text = " ";
                lblMatched.ForeColor = Color.Red;
            }
            else{
                
                lblMatched.Text = "UnMatched";
                lblMatched.ForeColor = Color.Red;
            }
        }
        //AVATAR CODES
        public void avatar()
        {
            connect.Open();
            GlobalVariable gv = new GlobalVariable();
            btn_Admin.Text = gv.usernameLogin; // GLOBAL VARIABLE FOR GETTING THE LOGIN USERNAME

            string getAvatar = "SELECT Tbl_Avatar.Avatar FROM (Tbl_Account INNER JOIN Tbl_Avatar ON tbl_Account.Avatar=Tbl_Avatar.Number) WHERE username='" + btn_Admin.Text + "'";
            OleDbCommand ocmd = new OleDbCommand(getAvatar, connect);
            OleDbDataReader odrs = ocmd.ExecuteReader();
            if (odrs.Read())
            {
                picbx_User.ImageLocation = (odrs["Avatar"].ToString());
                pcbx_User1.ImageLocation = (odrs["Avatar"].ToString());
                gv.getpic = (odrs["Avatar"].ToString());
            }
            connect.Close();
        }

        //BUTTON SAVE CHANGES IN AVATAR
        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            if (txtbx_NewPass.TextLength == 0) // IF NUMBER OF AVATAR IS EMPTY OR NEW PASS IS EMPTY 
            {
                MessageBox.Show("Fill Needed Details", "Changes Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                resettxxbox();
            }
            else if (txtbx_NewPass.Text == txtbx_OldPass.Text) // IF NEW PASS AND OLD PASS IS SAME
            {
                MessageBox.Show("You type the old password", "Changes Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                resettxxbox();
            }
            else if (txtbx_NewPass.Text != txtbx_OldPass.Text || lblMatched.Text == "Matched") // IF NEW PASS AND OLD PASS IS NOT SAME OR OLD PASS IS MATCHED TO THE DATABASE PASSWORD
            {

                string findpass = "UPDATE Tbl_Account SET [Password]='" + txtbx_NewPass.Text + "'WHERE [Username]='" + txtbx_Username.Text + "'";
                connect.Open();
                OleDbCommand ocmd = new OleDbCommand(findpass, connect);
                ocmd.ExecuteNonQuery();
                connect.Close();
                resettxxbox();
                MessageBox.Show("PASSWORD UPDATED");
                lbl_Matched.Text = " ";
            }


            else
            {
                MessageBox.Show("Account does not match", "Changes Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                resettxxbox();
                connect.Close();
            }

            connect.Close();

        }
        private void resettxxbox()
        {
            txtbx_OldPass.Clear();
            txtbx_NewPass.Clear();
        }

        //ACCOUNT OF ADMINS
        private void loadAccount()
    {
        connect.Open();
        GlobalVariable gv = new GlobalVariable();
        txtbx_Username.Text = gv.usernameLogin;
        string changepass = "SELECT * FROM Tbl_Account WHERE Username='" + txtbx_Username.Text + "'";
        OleDbCommand ocmd = new OleDbCommand(changepass, connect);
        OleDbDataReader odrs = ocmd.ExecuteReader();

        if (odrs.Read())
        {
            pass = (odrs["password"].ToString()); //FIND THE PASSWORD OF USER TXTBX USERNAME

        }
        connect.Close();
    }

        //OLD PASSWORD MATCH
        private void txtbx_OldPass_TextChanged(object sender, EventArgs e)
        {
            if (pass == txtbx_OldPass.Text)
            {

                lbl_Matched.Text = "Matched";
                lbl_Matched.ForeColor = Color.Green;

            }
            else
            {
                lbl_Matched.Text = "UnMatched";
                lbl_Matched.ForeColor = Color.Red;
            }
        }
       
        //BUTTON PREVIOUS
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            btn_Next.Enabled = true;
            position--; // NUMBER OF POSITION
            if (position >= 0)
            {
                showMovie();
            }
            else
            {
                btn_Previous.Enabled = false;
                position = 1;
            }
        }
        //BUTTON NEXT
        private void btn_Next_Click(object sender, EventArgs e)
        {
            btn_Previous.Enabled = true;

            position++; //POSITION
            a = position + 1;
            if (a <= count)
            {
                showMovie();

            }
            else
            {
                btn_Next.Enabled = false;
                position = count - 1;
            }
        }
        
        private void LoadAccount()
        {
            connect.Open();
            string query1 = "select Username,Password from Tbl_Account where Description = 'Admin'"; // QUERY FOR MOVIES
            OleDbCommand ocmd1 = new OleDbCommand(query1, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd1);
            DataTable dtTable = new DataTable();
            DataSet dsSet = new DataSet();
            oda.Fill(dtTable);
            oda.Fill(dsSet);

            dgv_Account.DataSource = dtTable;
            connect.Close();
        }
        //LOAD MOVIES
        private void loadmovies()
        {
            table1.Rows.Clear();
            connect.Open();
            string query1 = "select * from Tbl_Movies"; // QUERY FOR MOVIES
            OleDbCommand ocmd1 = new OleDbCommand(query1, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd1);
            DataTable dt = new DataTable();

            oda.Fill(dt);
            oda.Fill(ds2);
            count = dt.Rows.Count;
            connect.Close();
        }
        //SHOW MOVIES
        public void showMovie()
        {

            for (int i = 0; i < position; i++) // LOOP FOR NEXT ROWS
            {
                string Top1Movie = ds2.Tables[0].Rows[i][3].ToString();
                pbx_movie1.ImageLocation = Top1Movie;
                string moviename = ds2.Tables[0].Rows[i][1].ToString();
                lbl_MovieTitle1.Text = moviename;
                string moviedirector = ds2.Tables[0].Rows[i][4].ToString();
                lbl_MovieDirector1.Text = moviedirector;
                string moviegenre = ds2.Tables[0].Rows[i][2].ToString();
                lbl_genre1.Text = moviegenre;
                label9.Text = i.ToString();
                
                int b = i;
                b++;
                string Top2Movie = ds2.Tables[0].Rows[b][3].ToString();
                pbx_movie2.ImageLocation = Top2Movie;
                string moviename2 = ds2.Tables[0].Rows[b][1].ToString();
                lbl_MovieTitle2.Text = moviename2;
                string moviedirector2 = ds2.Tables[0].Rows[b][4].ToString();
                lbl_MovieDirector2.Text = moviedirector2;
                string moviegenre2 = ds2.Tables[0].Rows[b][2].ToString();
                lbl_genre2.Text = moviegenre2;
                label10.Text = b.ToString();
                int k = b;
                k++;
                string Top3Movie = ds2.Tables[0].Rows[k][3].ToString();
                pbx_movie3.ImageLocation = Top3Movie;
                string moviename3 = ds2.Tables[0].Rows[k][1].ToString();
                lbl_MovieTitle3.Text = moviename3;
                string moviedirector3 = ds2.Tables[0].Rows[k][4].ToString();
                lbl_MovieDirector3.Text = moviedirector3;
                string moviegenre3 = ds2.Tables[0].Rows[k][2].ToString();
                lbl_genre3.Text = moviegenre3;
                label11.Text = k.ToString();
            }
        }

        //BUTTON UPLOAD NEW MOVIE
        private void btn_UploadFilm_Click(object sender, EventArgs e)
        {
            new Admin_UploadMovie().Show();
            this.Hide();
        }

        //TOP GROSSING CODES
        private void topGrossing()
        {
            string query1 = "select TOP 3 * from Tbl_Movies ORDER BY movieticketsale DESC";

            OleDbCommand ocmd1 = new OleDbCommand(query1, connect);

            DataTable table1 = new DataTable();
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd1);
            oda.Fill(table1);
            oda.Fill(ds1);

            string Top1GrossMovie = ds1.Tables[0].Rows[0][3].ToString();
            pbx_movie1.ImageLocation = Top1GrossMovie;
            string Top1GrossMovieTitle = ds1.Tables[0].Rows[0][1].ToString();
            lbl_MovieTitle1.Text = Top1GrossMovieTitle;
            string Top1GrossMovieDirector = ds1.Tables[0].Rows[0][4].ToString();
            lbl_MovieDirector1.Text = Top1GrossMovieDirector;
            string Top1GrossMovieGenre1 = ds1.Tables[0].Rows[0][2].ToString();
            lbl_genre1.Text = Top1GrossMovieGenre1;


            string Top2GrossMovie = ds1.Tables[0].Rows[1][3].ToString();
            pbx_movie2.ImageLocation = Top2GrossMovie;
            string Top1GrossMovieTitle2 = ds1.Tables[0].Rows[1][1].ToString();
            lbl_MovieTitle2.Text = Top1GrossMovieTitle2;
            string Top1GrossMovieDirector2 = ds1.Tables[0].Rows[1][4].ToString();
            lbl_MovieDirector2.Text = Top1GrossMovieDirector2;
            string Top1GrossMovieGenre2 = ds1.Tables[0].Rows[1][2].ToString();
            lbl_genre2.Text = Top1GrossMovieGenre2;

            string Top3GrossMovie = ds1.Tables[0].Rows[2][3].ToString();
            pbx_movie3.ImageLocation = Top3GrossMovie;
            string Top1GrossMovieTitle3 = ds1.Tables[0].Rows[2][1].ToString();
            lbl_MovieTitle3.Text = Top1GrossMovieTitle3;
            string Top1GrossMovieDirector3 = ds1.Tables[0].Rows[2][4].ToString();
            lbl_MovieDirector3.Text = Top1GrossMovieDirector3;
            string Top1GrossMovieGenre3 = ds1.Tables[0].Rows[2][2].ToString();
            lbl_genre3.Text = Top1GrossMovieGenre3;
        }
        //NOW SHOWING CODES
        private void nowShowing()
        {
            newconnection.OpenConnection();
            OleDbCommand tblmoviesCommand = new OleDbCommand("SELECT * FROM Tbl_Movies", newconnection.connection);
            DataSet dstblmovies = new DataSet();
            OleDbDataAdapter datblmovies = new OleDbDataAdapter(tblmoviesCommand);
            datblmovies.Fill(dstblmovies, "table1");
            newconnection.connection.Close();
            DataTable dttblmovies = dstblmovies.Tables[0];
            foreach (DataRow dr in dttblmovies.Rows)

                if (dr["moviecode"].ToString() == "001")
                {
                    pbx_movie1.Image = Image.FromFile(dr["movieposter"].ToString());
                    lbl_MovieTitle1.Text = dr["movietitle"].ToString();
                    lbl_genre1.Text = dr["moviegenre"].ToString();
                    lbl_MovieDirector1.Text = dr["moviedirector"].ToString();
                }
                else if (dr["moviecode"].ToString() == "004")
                {
                    pbx_movie2.Image = Image.FromFile(dr["movieposter"].ToString());
                    lbl_MovieTitle2.Text = dr["movietitle"].ToString();
                    lbl_genre2.Text = dr["moviegenre"].ToString();
                    lbl_MovieDirector2.Text = dr["moviedirector"].ToString();
                }
                else if (dr["moviecode"].ToString() == "007")
                {
                    pbx_movie3.Image = Image.FromFile(dr["movieposter"].ToString());
                    lbl_MovieTitle3.Text = dr["movietitle"].ToString();
                    lbl_genre3.Text = dr["moviegenre"].ToString();
                    lbl_MovieDirector3.Text = dr["moviedirector"].ToString();
                }
        }

        //CONTACT TRACING
        public void refreshtable() //METHOD TO LOAD THE TABLE
        {
            connect.Open();
            string query = "select Tbl_Information.PickupCode,Name,ContactNumber,Address,Companion1,Companion2,Tbl_Payment.Discount,Tbl_Payment.OrderDate from Tbl_Information LEFT JOIN Tbl_Payment ON Tbl_Information.PickupCode = Tbl_Payment.PickupCode";
            OleDbCommand ocmd = new OleDbCommand(query, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataTable  ds2 = new DataTable ();
            oda.Fill(ds2);
            DGV.DataSource = ds2.DefaultView ;
            connect.Close();

            DGV2.Visible = false;
            DGV.Visible = true;
            DGV3.Visible = false;
            DGV4.Visible = false;
            lbl_Filter.Visible = false;
            cmb_Filter.Visible = false;
        }
        //SALES REPORT
        public void sales()
        {
            connect.Open();
            string query = "select moviecode,movietitle,moviedirector,movieprice,movieticketsale from Tbl_Movies";
            OleDbCommand ocmd = new OleDbCommand(query, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataTable ds2 = new DataTable();
            oda.Fill(ds2);
            DGV2.DataSource = ds2.DefaultView ;
            connect.Close();
            DGV2.Visible = true;
            DGV.Visible = false;
            DGV3.Visible = false;
            DGV4.Visible = false;
            lbl_Filter.Visible = false;
            cmb_Filter.Visible = false;
        }
        //PAYMENT
        public void dgv_paymentHistoryLoad()
        {
            string query = "SELECT * FROM Tbl_Payment";
            OleDbCommand ocmd = new OleDbCommand(query, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataTable dtCustomerHistory1 = new DataTable();
            oda.Fill(dtCustomerHistory1);
            DGV3.DataSource = dtCustomerHistory1;
            connect.Close();
            DGV2.Visible = false;
            DGV.Visible = false;
            DGV3.Visible = true;
            DGV4.Visible = false;
            lbl_Filter.Visible = false;
            cmb_Filter.Visible = false;
        }
        //TRANSACTION
        private void dgv_load()
        {
            connect.Open();
            string query = "SELECT Tbl_Payment.OrderNumber,TicketCode,SeatCode,OrderDate FROM Tbl_Payment INNER JOIN Tbl_TicketNumber ON Tbl_Payment.OrderNumber = Tbl_TicketNumber.OrderNumber";
            OleDbCommand ocmd = new OleDbCommand(query, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataTable dtCustomerHistory1 = new DataTable();

            oda.Fill(dtCustomerHistory1);
            DGV4.DataSource = dtCustomerHistory1;

            connect.Close();
            DGV2.Visible = false;
            DGV.Visible = false;
            DGV3.Visible = false;
            DGV4.Visible = true;
            lbl_Filter.Visible = true;
            cmb_Filter.Visible = true;
        }

        //COMBO BOX FILTER FOR TRANSACTION
        private void cmb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Rows.Clear();

            connect.Open();
            // string ticketsale1 = "SELECT ";
            string query = "SELECT Tbl_Payment.OrderNumber,TicketCode,SeatCode,OrderDate FROM Tbl_Payment INNER JOIN Tbl_TicketNumber ON Tbl_Payment.OrderNumber = Tbl_TicketNumber.OrderNumber WHERE TicketCode LIKE '" + cmb_Filter.Text + "%'";
            OleDbCommand ocmd = new OleDbCommand(query, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            oda.Fill(dt2 );
            DGV4.DataSource = dt2;

            connect.Close();
        }

        //BUTTON EDIT FILM
        private void btn_EditFilm_Click(object sender, EventArgs e)
        {
            new Admin_EditMovie().Show();
            this.Hide();
        }

        //private void btn_Movies_MouseMove(object sender, MouseEventArgs e)
        //{
        //    sPanel_Movies.BackColor = Color.FromArgb(151, 151, 151);
        //    btn_Movies.BackColor = Color.FromArgb(126, 126, 126);

        //}

        //private void btn_Movies_MouseLeave(object sender, EventArgs e)
        //{
        //    sPanel_Movies.BackColor = Color.DimGray;
        //    btn_Movies.BackColor = Color.DimGray;
            
        //}

        private void btn_Movies_MouseClick(object sender, MouseEventArgs e)
        {
            sPanel_Movies.BackColor = Color.FromArgb(171, 171, 171);
        }

        private void btn_LogOutAdmin_Click(object sender, EventArgs e)
        {
            new Admin_LogoutCofirmation().Show();
            this.Hide();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            new Admin_LogoutCofirmation().Show();
            this.Hide();
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            if (txtbx_OldPass.UseSystemPasswordChar == true)
            {
                txtbx_OldPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtbx_OldPass.UseSystemPasswordChar = true;
            }
        }

        private void btn_Show2_Click(object sender, EventArgs e)
        {
            if (txtbx_NewPass.UseSystemPasswordChar == true)
            {
                txtbx_NewPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtbx_NewPass.UseSystemPasswordChar = true;
            }
        }

        private void btn_DeleteAcc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {

                connect.Open();
                int rowIndex = dgv_Account.CurrentRow.Index;
                string usnm = dgv_Account.Rows[rowIndex].Cells[0].Value.ToString();


                //MessageBox.Show(rowIndex.ToString());
                string querydelete = "DELETE FROM Tbl_Account WHERE [Username] ='" + usnm + "'";
                cmd = new OleDbCommand(querydelete, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("ACCOUNT DELETED");
                dgv_Account.Rows.RemoveAt(rowIndex);

            }
            else
            {
                //MessageBox.Show("Account not deleted");
            }
        }

        private void txtbxClear() {
            txtbxRegUser.Text = "";
            txtbxRegPass.Text = "";
            txtbxConfirmPass.Text = "";
            lblMatched.Text = "";
        }

        private void LoadImagePath()
        {
            //try
            //{
            connect.Open();
                string ImagePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string sqlquery = "Select * From Tbl_Movies";
                //string avatarquery = "Select * From Tbl_Avatar";
                OleDbCommand ocmd = new OleDbCommand(sqlquery, connect);
                //OleDbCommand avatarocmd = new OleDbCommand(sqlquery, connect);
                OleDbDataReader odr2 = ocmd.ExecuteReader();


                //    MessageBox.Show(ImagePath);

                while (odr2.Read())
                {
                    string mID = odr2["moviecode"].ToString();
                    string imageName = odr2["movieposter"].ToString();
                    string imgnm = System.IO.Path.GetFileName(imageName);
                    string path2 = System.IO.Path.Combine(ImagePath.Substring(6), imgnm);

                    string updateImagePath = "UPDATE Tbl_Movies SET [movieposter]='" + path2 + "' WHERE [moviecode]='" + mID + "'";
                    OleDbCommand updatepath = new OleDbCommand(updateImagePath, connect);
                    updatepath.ExecuteNonQuery();
                    //MessageBox.Show(path2);
                }
                //MessageBox.Show("LOAD IMAGES");

                connect.Close();

            //}
            //catch (Exception) { }


        }

        private void Savatar() {
            connect.Open();
            string avatarquery = "Select * From Tbl_Avatar";
            string ImagePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            OleDbCommand avatarocmd = new OleDbCommand(avatarquery, connect);
            OleDbDataReader odr2 = avatarocmd.ExecuteReader();


            while (odr2.Read())
            {
                string mID = odr2["Number"].ToString();
                string imageName = odr2["Avatar"].ToString();
                string imgnm = System.IO.Path.GetFileName(imageName);
                string path2 = System.IO.Path.Combine(ImagePath.Substring(6), imgnm);


                string updateImagePath = "UPDATE Tbl_Avatar SET [Avatar]='" + path2 + "' WHERE [Number]='" + mID + "'";
                OleDbCommand updatepath = new OleDbCommand(updateImagePath, connect);
                updatepath.ExecuteNonQuery();
                

            }
            //MessageBox.Show("LOAD IMAGES");

            connect.Close();

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            connect.Open();
            string query = "select * from Tbl_Information where Address LIKE '%" + txtbx_Search.Text + "%'";
            OleDbCommand ocmd = new OleDbCommand(query, connect);
            OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);
            DataTable ds2 = new DataTable();
            oda.Fill(ds2);
            DGV.DataSource = ds2.DefaultView;
            connect.Close();
        }

        private void txtbx_Search_Enter(object sender, EventArgs e)
        {
            if (txtbx_Search.Text == "Search Address")
            {
                txtbx_Search.Text = "";
                //txtbx_Username.Text = txtbx_Username.Text.PadLeft(txtbx_Username.Text.Length + 2);
                txtbx_Search.ForeColor = Color.White;

            }
        }

        private void txtbx_Search_Leave(object sender, EventArgs e)
        {
            if (txtbx_Search.Text == "")
            {
                txtbx_Search.Text = "Search Address";

                txtbx_Search.ForeColor = Color.Gray;
            }
        }

    }
}
