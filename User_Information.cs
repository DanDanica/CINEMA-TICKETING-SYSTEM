using System.Collections;
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
    public partial class User_Information : Form
    {
        //FOR ELLIPSE-SHAPED OBJECTS
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );
        public User_Information()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        GlobalVariable gv = new GlobalVariable();
        ConnectionForm newconnection = new ConnectionForm();
        string discount = string.Empty;

        //FORM OBEJCT SHADOWS AND MAIN CODES
        private void User_Information_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            shadow1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow1.Width, shadow1.Height, 18, 18));
            shadow2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow2.Width, shadow2.Height, 18, 18));
            shadow3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow3.Width, shadow3.Height, 18, 18));
            shadow4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow4.Width, shadow4.Height, 18, 18));
            shadow5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, shadow5.Width, shadow5.Height, 18, 18));
            txtbx_Name.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Name.Width, txtbx_Name.Height, 18, 18));
            txtbx_ContactNum.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_ContactNum.Width, txtbx_ContactNum.Height, 18, 18));
            txtbx_Address.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Address.Width, txtbx_Address.Height, 18, 18));
            txtbx_Companion1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Companion1.Width, txtbx_Companion1.Height, 18, 18));
            txtbx_Companion2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtbx_Companion2.Width, txtbx_Companion2.Height, 18, 18));

            cmbitems();

            if (gv.CountOfTicket == 1)
            {
                txtbx_Companion1.ReadOnly = true;
                txtbx_Companion2.ReadOnly = true;
                txtbx_Companion1.Text = "N/A";
                txtbx_Companion2.Text = "N/A";
            }
            else if (gv.CountOfTicket == 2)
            {
                txtbx_Companion2.ReadOnly = true;
                txtbx_Companion2.Text = "N/A";
            }
            else
            {
                txtbx_Companion1.ReadOnly = false;
                txtbx_Companion2.ReadOnly = false;
            }
        }

        #region textbox enter and leave
        //TEXTBOX PLACEHOLDERS ENTER AND LEAVE
        private void txtbx_Name_Enter(object sender, EventArgs e)
        {
            if (txtbx_Name.Text == "Name")
            {
                txtbx_Name.Text = "";
                txtbx_Name.ForeColor = Color.White;
            }
        }
        private void txtbx_Name_Leave(object sender, EventArgs e)
        {
            if (txtbx_Name.Text == "")
            {
                txtbx_Name.Text = "Name";
                txtbx_Name.ForeColor = Color.Gray;
            }
        }

        private void txtbx_ContactNum_Enter(object sender, EventArgs e)
        {
            if (txtbx_ContactNum.Text == "Contact Number")
            {
                txtbx_ContactNum.Text = "";
                txtbx_ContactNum.ForeColor = Color.White;
            }
        }

        private void txtbx_ContactNum_Leave(object sender, EventArgs e)
        {
            if (txtbx_ContactNum.Text == "")
            {
                txtbx_ContactNum.Text = "Contact Number";
                txtbx_ContactNum.ForeColor = Color.Gray;
            }
        }

        private void txtbx_Address_Enter(object sender, EventArgs e)
        {
            if (txtbx_Address.Text == "Location/Address")
            {
                txtbx_Address.Text = "";
                txtbx_Address.ForeColor = Color.White;
            }
        }

        private void txtbx_Address_Leave(object sender, EventArgs e)
        {
            if (txtbx_Address.Text == "")
            {
                txtbx_Address.Text = "Location/Address";
                txtbx_Address.ForeColor = Color.Gray;
            }
        }

        private void txtbx_Companion1_Enter(object sender, EventArgs e)
        {
            if (txtbx_Companion1.Text == "Name of Companion (1)")
            {
                txtbx_Companion1.Text = "";
                txtbx_Companion1.ForeColor = Color.White;
            }
        }

        private void txtbx_Companion1_Leave(object sender, EventArgs e)
        {
            if (txtbx_Companion1.Text == "")
            {
                txtbx_Companion1.Text = "Name of Companion (1)";
                txtbx_Companion1.ForeColor = Color.Gray;
            }
        }

        private void txtbx_Companion2_Enter(object sender, EventArgs e)
        {
            if (txtbx_Companion2.Text == "Name of Companion (2)")
            {
                txtbx_Companion2.Text = "";
                txtbx_Companion2.ForeColor = Color.White;
            }
        }

        private void txtbx_Companion2_Leave(object sender, EventArgs e)
        {
            if (txtbx_Companion2.Text == "")
            {
                txtbx_Companion2.Text = "Name of Companion (2)";
                txtbx_Companion2.ForeColor = Color.Gray;
            }
        }
        #endregion

        //ITEMS FOR COMBOBOX DISCOUNT
        private void cmbitems()
        {
            newconnection.OpenConnection();
            OleDbCommand cmdDiscount = new OleDbCommand("SELECT TypeOfDiscount FROM Tbl_Discount", newconnection.connection);
            DataSet dsDiscount = new DataSet();
            OleDbDataAdapter daDiscount = new OleDbDataAdapter(cmdDiscount);
            daDiscount.Fill(dsDiscount, "TblDiscount");
            newconnection.connection.Close();
            DataTable dtDiscount = dsDiscount.Tables[0];

            foreach (DataRow drDiscount in dtDiscount.Rows)
            {
                cmb_Discount.Items.Add(drDiscount["TypeOfDiscount"]);
            }

        }

        //BUTTON CONFIRM
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txtbx_Companion1.ReadOnly == true && txtbx_Companion2.ReadOnly == true)
            {
                if ((txtbx_Name.Text == string.Empty || txtbx_Name.Text == "Name") || (txtbx_Address.Text == string.Empty || txtbx_Address.Text == "Location/Address") || (txtbx_ContactNum.Text == string.Empty || txtbx_ContactNum.Text == "Contact Number"))
                {
                    MessageBox.Show("Please fill the details");
                    return;
                }
            }
            else if (txtbx_Companion1.ReadOnly == false && txtbx_Companion2.ReadOnly == true)
            {
                if ((txtbx_Name.Text == string.Empty || txtbx_Name.Text == "Name") || (txtbx_Address.Text == string.Empty || txtbx_Address.Text == "Location/Address") || (txtbx_ContactNum.Text == string.Empty || txtbx_ContactNum.Text == "Contact Number") || txtbx_Companion1.Text == "Name of Companion (1)")
                {
                    MessageBox.Show("Please fill the details");
                    return;
                }
            }
            else if (txtbx_Companion1.ReadOnly == false && txtbx_Companion2.ReadOnly == false)
            {
                if ((txtbx_Name.Text == string.Empty || txtbx_Name.Text == "Name") || (txtbx_Address.Text == string.Empty || txtbx_Address.Text == "Location/Address") || (txtbx_ContactNum.Text == string.Empty || txtbx_ContactNum.Text == "Contact Number") || txtbx_Companion1.Text == "Name of Companion (1)" || txtbx_Companion2.Text == "Name of Companion (2)")
                {
                    MessageBox.Show("Please fill the details");
                    return;
                }
            }

            
            
            cmbdiscount();
            //MessageBox.Show(FpersonDis.ToString() + com1Dis.ToString() + com2Dis.ToString());

            string currentcode = "0";
            string infocurrentcode = "0";
            string infonewcode = "0";

            newconnection.OpenConnection();
            OleDbCommand maxcode = new OleDbCommand("SELECT MAX(PickupCode) AS pickupcode FROM Tbl_PickupSeat", newconnection.connection);
            OleDbDataReader maxread = maxcode.ExecuteReader();
            if (maxread != null)
            {
                if (maxread.HasRows)
                {
                    maxread.Read();
                    currentcode = object.ReferenceEquals(maxread["pickupcode"], DBNull.Value) ? "0" : maxread["pickupcode"].ToString();
                }
            }

            //newconnection.connection.Close();
            //newconnection.OpenConnection();

            //for (int i = 1; i <= gv.CountOfTicket; i++)
            //{
            OleDbCommand cmdinfo = new OleDbCommand("SELECT MAX(InfoID) AS infoid FROM Tbl_Information", newconnection.connection);
            OleDbDataReader readinfo = cmdinfo.ExecuteReader();
            if (readinfo != null)
            {
                if (readinfo.HasRows)
                {
                    readinfo.Read();
                    infocurrentcode = object.ReferenceEquals(readinfo["infoid"], DBNull.Value) ? "0" : readinfo["infoid"].ToString();
                }
            }
            int infocode = 0;
            infocode = Convert.ToInt16(infocurrentcode) + 1;
            infonewcode = infocode.ToString("0");

            OleDbCommand infocommand = new OleDbCommand("INSERT INTO Tbl_Information (InfoID,Pickupcode,Name,ContactNumber,Address,Companion1,Companion2,Discount) VALUES ('" + infonewcode + "','" + currentcode + "', '" + txtbx_Name.Text + "','" + txtbx_ContactNum.Text + "','" + txtbx_Address.Text + "','" + txtbx_Companion1.Text + "','" + txtbx_Companion2.Text + "','" + discount + "')", newconnection.connection);
            infocommand.ExecuteNonQuery();
            //}
            newconnection.connection.Close();

            User_Payment payment = new User_Payment();
            payment.Show();
            this.Hide();

        }

        //DISCOUNT COMBOBOX
        private void cmbdiscount()
        {
            if (cmb_Discount.SelectedIndex == -1)
            {
                discount = "01";
            }
            else if (cmb_Discount.SelectedIndex == 0)
            {
                discount = "01";
            }
            else if (cmb_Discount.SelectedIndex == 1)
            {
                discount = "02";
            }
            else if (cmb_Discount.SelectedIndex == 2)
            {
                discount = "03";
            }
            else
            {
                discount = "04";
            }
        }

        //LINK FOR COVID INFO
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CovidInfo info = new CovidInfo();
            info.Show();
            this.Hide();
        }

        //KEYPRESS VALIDATION
        private void txtbx_ContactNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtbx_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar);
        }
        private void txtbx_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void txtbx_Companion1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar);
        }
        private void txtbx_Companion2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar);
        }

    }
}
