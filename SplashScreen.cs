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
    public partial class SplashScreen : Form
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

        GlobalVariable gv = new GlobalVariable();
        public SplashScreen()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            
        }
        int loadingspeed = 4;
        float initialpercent = 0;

        int a = 100;

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();

            //panel1.Visible = false;
            //panel2.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            initialpercent += loadingspeed;

            a += 3;
            float percent = initialpercent / a * 93;

            label1.Text = (int)percent + "%";


            if (a >= 537)
            {
                if (gv.Port == 0)
                {
                    label1.Text = "100%";
                    timer1.Stop();
                    new Admin_LoginForm().Show();
                    this.Hide();
                }
                if (gv.Port == 1)
                {
                    label1.Text = "100%";
                    timer1.Stop();
                    new User_Dashboard().Show();
                    this.Hide();
                }
            }
        }
    }
        }
    

