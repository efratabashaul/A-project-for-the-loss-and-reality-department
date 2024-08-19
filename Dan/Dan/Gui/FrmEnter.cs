using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dan.Gui
{
    public partial class FrmEnter : Form
    {
        private string s2;
        private string s3;
        public FrmEnter(string s ,string s1)
        {
            InitializeComponent();
            s2 = s;
            s3 = s1;
            if (s == "director")
            {
                menuStrip2.Visible = false;
                menuStrip3.Visible = false;
            }
            else
            {
                if (s == "driver")
                {
                    menuStrip3.Visible = false;
                    menuStrip1.Visible = false;
                }
                else
                {
                    if (s == "client")
                    {
                        menuStrip1.Visible = false;
                        menuStrip2.Visible = false;
                    }
                    else
                    {
                        Form1 f = new Form1();
                        f.Show();
                        this.Hide();
                    }
                    
                }
            }
        }

        private void אבידותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLost f = new FrmLost("director","");
            f.Show();
            this.Hide();
        }

        private void נהגיםToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           FrmDriver f = new FrmDriver("director","");
            f.Show();
            this.Hide();
        }

        private void לקוחותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClient f = new FrmClient("director","");
            f.Show();
            this.Hide();
        }

        private void נסיעותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTraveling f = new FrmTraveling();
            f.Show();
            this.Hide();
        }

        private void אוטובוסיםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBus f = new FrmBus();
            f.Show();
            this.Hide();
        }

        private void קויםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLine f = new FrmLine();
            f.Show();
            this.Hide();
        }

        private void קויםעפיעדToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineD f = new FrmLineD();
            f.Show();
            this.Hide();
        }

        private void צדדיםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSide f = new FrmSide();
            f.Show();
            this.Hide();
        }

        private void סוגיאבידותToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmKindL f = new FrmKindL("director");
            f.Show();
            this.Hide();
        }

        private void מחלקותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepartment f = new FrmDepartment("dures");
            f.Show();
            this.Hide();
        }

        private void סוגיאבידותToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void אחרToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void נהגיםToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmDriver f = new FrmDriver("driver", s3);
            f.Show();
            this.Hide();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmEnter_Load(object sender, EventArgs e)
        {

        }

        private void אבידותToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmLost f = new FrmLost("client", s3);
            f.Show();
            this.Hide();
        }

        private void מציאותToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmF f = new FrmF("client", s3);
            f.Show();
            this.Hide();
        }

        private void לקוחותToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmClient f = new FrmClient("client",s3);
            f.Show();
            this.Hide();
        }

        private void אבידותToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmLost f = new FrmLost("driver", s3);
            f.Show();
            this.Hide();
        }

        private void מציאותToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmF f = new FrmF("driver", s3);
            f.Show();
            this.Hide();
        }

        private void מציאותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmF f = new FrmF("director","");
            f.Show();
            this.Hide();
        }

        private void נהגיםToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
