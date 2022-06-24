using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CinemaTicketing
{
    public partial class Admin_LogoutCofirmation : Form
    {
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

        public Admin_LogoutCofirmation()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            btn_Logout.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Logout.Width, btn_Logout.Height, 9, 9));
            btn_Cancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Cancel.Width, btn_Cancel.Height, 9, 9));
        }

        private void Admin_LogoutCofirmation_Load(object sender, EventArgs e)
        {

        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin_LoginForm().Show(); 
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin_Dashboard().Show();
        }
    }
}
