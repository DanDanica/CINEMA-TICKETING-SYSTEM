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
    public partial class CovidInfo : Form
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
        public CovidInfo()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
        }

        private void CovidInfo_Load(object sender, EventArgs e)
        {
            shadow.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow.Width, shadow.Height, 18, 18));
            shadow2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow2.Width, shadow2.Height, 30, 30));
            questions.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, questions.Width, questions.Height, 18, 18));
            btn_Proceed.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_Proceed.Width, btn_Proceed.Height, 30, 30));
        }

        private void btn_Proceed_Click(object sender, EventArgs e)
        {
            User_Information information = new User_Information();
            information.Show();
            this.Close();
        }

    }
}
