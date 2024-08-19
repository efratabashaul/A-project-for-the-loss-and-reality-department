using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Dan.Data;
using Dan.DB;
using Dan.Properties;
using Dan.Utilities;
using Dan.Gui;
using Dan.Models;
using System.Windows.Forms;

namespace Dan
{
    public partial class Form1 : Form
    {
        private DriverDB tblDriver;
        private ClientDB tblClient;
        public Form1()
        {
            InitializeComponent();
            tblDriver = new DriverDB();
            tblClient = new ClientDB();    
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FrmTraveling f = new FrmTraveling();
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmLineD f = new FrmLineD();
            f.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmLine f = new FrmLine();
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lblD.Visible = true;
            txtD.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmBus f = new FrmBus();
            f.Show();
            this.Hide();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button5.Visible = true;
            button6.Visible = true;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if ((tblClient.GetList().Find(x => x.Pincode == txtC.Text)) != null)
            {
                FrmEnter f = new FrmEnter("client" ,txtC.Text);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("הסיסמה שגויה!");
                txtC.Text = "";
            }
        }

        private void txtD_TextChanged(object sender, EventArgs e)
        {
            btnD.Visible = true;
        }

        private void txtDr_TextChanged(object sender, EventArgs e)
        {
            btnDr.Visible = true;
        }

        private void txtC_TextChanged(object sender, EventArgs e)
        {
            btnC.Visible = true;
                
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (txtD.Text == "6548")
            {
                FrmEnter f = new FrmEnter("director","");
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("הסיסמה שגויה!");
                txtD.Text = "";
            }
        }

        private void btnDr_Click(object sender, EventArgs e)
        {
            if ((tblDriver.GetList().Find(x => x.Pincode .StartsWith( txtDr.Text))) != null)
            {
                FrmEnter f = new FrmEnter("driver" ,txtDr.Text);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("הסיסמה שגויה!");
                txtDr.Text = "";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            lblDr.Visible = true;
            txtDr.Visible = true;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            lblC.Visible = true;
            txtC.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FrmDriver f = new FrmDriver("no","");
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmClient f = new FrmClient("no","");
            f.Show();
            this.Hide();
        }

        private void lblDr_Click(object sender, EventArgs e)
        {

        }

        private void lblD_Click(object sender, EventArgs e)
        {

        }

        private void lblC_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            FrmDan f = new FrmDan();
            f.Show();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            FrmCall f = new FrmCall();
            f.Show();
            this.Hide();
        }
    }
}
