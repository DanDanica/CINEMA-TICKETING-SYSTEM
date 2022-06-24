using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinemaTicketing
{
    public partial class Portals : Form
    {
        GlobalVariable gv = new GlobalVariable();
        public Portals()
        {
            InitializeComponent();
        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            gv.Port = 0;
            new SplashScreen().Show();
            this.Hide();
        }

        private void btn_User_Click(object sender, EventArgs e)
        {
            gv.Port = 1;
            new SplashScreen().Show();
            this.Hide();
        }
    }
}
