using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dan.Models;
using Dan.DB;


namespace Dan.Gui
{
    public partial class FrmBus : Form
    {
        private BusDB tblBus;
        private Bus thisBus;
        private bool flagAdd;
        private bool flagUpdate;
        private string ch;
        public FrmBus()
        {
            InitializeComponent();
            tblBus = new BusDB();
            notPossible();
            flagAdd = false;
            flagUpdate = false;
            dg.DataSource = tblBus.GetList().Where(X =>X.Status).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
        }
        private void Possible()
        {
            panel2.Visible = true;
            panel1.Visible = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
        }
        private void notPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            panel2.Visible = false;
            panel1.Visible = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblBus.GetList().Where(X => X.KodB.ToString().StartsWith(textBox1.Text)&&X.Status).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblBus.GetList().Where(X => X.NameB.ToString().StartsWith(textBox1.Text) && X.Status).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblBus.GetList().Where(X => X.NumS.ToString().StartsWith(textBox1.Text) && X.Status).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
        }
        private bool CreateFields(Bus b)
        {
            bool ok = true;
            errorProvider1.Clear();
            b.KodB = Convert.ToInt32(textBox1.Text);
            try
            {
                b.NameB = textBox2.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox2, ex.Message);
                ok = false;
            }
            try
            {
                b.NumS = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox3, ex.Message);
                ok = false;
            }
           
            b.Status =  true;
            return ok;
        }

        private void Fill(Bus bus)
        {
            if (tblBus.Size() > 0)
            {
                textBox1.Text = bus.KodB.ToString();
                ch = textBox1.Text;
                textBox2.Text = bus.NameB.ToString();
                textBox3.Text = bus.NumS.ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FrmBus_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagUpdate)
            {
                if (this.tblBus.Find(Convert.ToInt32(textBox1.Text)) == null || textBox1.Text == ch)
                {
                    if (CreateFields(thisBus))
                    {
                        DialogResult r = MessageBox.Show("האם לעדכן אוטובוס זה?", "אישור עידכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            tblBus.UpdateRow(thisBus);
                            notPossible();
                            dg.DataSource = tblBus.GetList().Where(x => x.Status).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("קיים אוטובוס זהה!!");
                }
            }
                
            if (flagAdd)
            {
                    Bus b = new Bus();
                    if (this.tblBus.Find(Convert.ToInt32(textBox1.Text)) == null)
                    {
                        if (CreateFields(b))
                        {
                            DialogResult r = MessageBox.Show("האם להוסיף אוטובוס זה?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.Yes)
                            {
                                dg.DataSource = tblBus.GetList().Where(x => x.Status).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
                                tblBus.AddNew(b);
                                notPossible();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("קיים אוטובוס זהה!!");
                    }
      
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dg.DataSource = tblBus.GetList().Where(x=> x.Status).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            flagAdd = true;
            textBox1.Text =tblBus.GetNextKey().ToString();
            textBox1.ReadOnly = true;
            textBox2.Text = "";
            textBox3.Text = "";
            Possible();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק אוטובוס זה?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                    tblBus.DeleteStatus(Convert.ToInt32(st));
                    dg.DataSource = tblBus.GetList().Where(x => x.Status).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
                }
            }
            else
            {
                MessageBox.Show("בחר אוטובוס למחיקה!");
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                thisBus = tblBus.Find(Convert.ToInt32(st));
                Fill(thisBus);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                thisBus = tblBus.Find(Convert.ToInt32(st));
                Fill(thisBus);
                textBox1.ReadOnly = true;
                flagUpdate = true;
                flagAdd = false;
                Possible();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            notPossible();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            errorProvider1.Clear();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblBus.GetList().Where(x => x.KodB.ToString() == textBox1.Text).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEnter f = new FrmEnter("director","");
            f.Show();
            this.Hide();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblBus.GetList().Where(x => x.NameB.ToString() == textBox2.Text).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblBus.GetList().Where(x => x.NumS.ToString() == textBox3.Text).Select(x => new { קוד_אוטובוס = x.KodB, שם_אוטובוס = x.NameB, מספר_מקומות_ישיבה = x.NumS, פעיל = x.Status }).ToList();
        }
    }
}
