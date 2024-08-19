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
    public partial class FrmLine : Form
    {
        private LineDB tblLine;
        private Line thisLine;
        private bool flagAdd;
        private bool flagUpdate;
        private string ch;
        public FrmLine()
        {
            InitializeComponent();
            tblLine = new LineDB();
            notPossible();
            flagAdd = false;
            flagUpdate = false;
            dg.DataSource = tblLine.GetList().Where(X => X.Status).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
        }
        private void Possible()
        {
            panel2.Visible = true;
            panel1.Visible = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
        }
        private void notPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            panel2.Visible = false;
            panel1.Visible = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblLine.GetList().Where(X => X.KodL.ToString().StartsWith(textBox1.Text) && X.Status).Select(x => new {קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblLine.GetList().Where(X => X.Price.ToString().StartsWith(textBox1.Text) && X.Status).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblLine.GetList().Where(X => X.Dunation.ToString().StartsWith(textBox1.Text) && X.Status).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
        }

        private bool CreateFields(Line l)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                 l.KodL =Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
                ok = false;
            }
            try
            {
                  if (Convert.ToDouble(textBox2.Text) <= 0)
                    {
                        ok = false;
                        errorProvider1.SetError(textBox2, "!הקש מחיר גדול מ-0");
                    }
                    else
                        l.Price = Convert.ToDouble(textBox2.Text);
               
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox2, ex.Message);
                ok = false;
            }
            try
            {
                 l.Dunation = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox3, ex.Message);
                ok = false;
            }
            l.Status = true;
            return ok;
        }

        private void Fill(Line line)
        {
            if (tblLine.Size() > 0)
            {
                textBox1.Text = line.KodL.ToString();
                ch = textBox1.Text;
                textBox2.Text = line.Price.ToString();
                textBox3.Text = line.Dunation.ToString();
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
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            dg.DataSource = tblLine.GetList().Where(x=>x.Status).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation,פעיל=x.Status }).ToList();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                thisLine = tblLine.Find(Convert.ToInt32(st));
                Fill(thisLine);
                flagUpdate = true;
                flagAdd = false;
                Possible();
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            flagAdd = true;
            textBox2.Text = "";
            textBox3.Text = "";
            Possible();
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק קו זה?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                    tblLine.DeleteStatus(Convert.ToInt32(st));
                    dg.DataSource = tblLine.GetList().Where(x => x.Status).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
                }
            }
            else
            {
                MessageBox.Show("בחר קו למחיקה!");
            }
        }

        private void btnClient_Click_1(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                thisLine = tblLine.Find(Convert.ToInt32(st));
                Fill(thisLine);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
                if (flagUpdate)
                {
                if (textBox2.Text == "")
                    errorProvider1.SetError(textBox2, "הקש מחיר");
                if (textBox3.Text == "")
                    errorProvider1.SetError(textBox3, "הקש משך זמן");
                if (textBox1.Text != "")
                {
                    if (this.tblLine.Find(Convert.ToInt32(textBox1.Text)) == null || textBox1.Text == ch)
                    {
                        if (CreateFields(thisLine))
                        {
                            DialogResult r = MessageBox.Show("האם לעדכן קו זה?", "אישור עידכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.Yes)
                            {
                                tblLine.UpdateRow(thisLine);
                                notPossible();
                                dg.DataSource = tblLine.GetList().Where(x => x.Status).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("קיים קו זהה!!");
                    }
                }
                 else
                    errorProvider1.SetError(textBox1, "הקש קו");
            }

            else
            {
                if (flagAdd)
                {
                 
                    if (textBox2.Text == "")
                        errorProvider1.SetError(textBox2, "הקש מחיר");
                    if (textBox3.Text == "")
                        errorProvider1.SetError(textBox3, "הקש משך זמן");
                    Line l = new Line();
                    if (textBox1.Text != "")
                    {
                        if (this.tblLine.Find(Convert.ToInt32(textBox1.Text)) == null)
                        {
                            if (CreateFields(l))
                            {
                                DialogResult r = MessageBox.Show("האם להוסיף קו זה?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                if (r == DialogResult.Yes)
                                {
                                    tblLine.AddNew(l);
                                    notPossible();
                                    dg.DataSource = tblLine.GetList().Where(x => x.Status).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("קיים קו זהה!!");
                        }
                    }
                    else
                        errorProvider1.SetError(textBox1, "הקש קו");
                }
            }    
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            notPossible();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            errorProvider1.Clear();
        }

        private void FrmLine_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEnter f = new FrmEnter("director","");
            f.Show();
            this.Hide();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblLine.GetList().Where(x => x.Status && x.Price.ToString() == textBox2.Text).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblLine.GetList().Where(x => x.Status&&x.KodL.ToString()==textBox1.Text).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblLine.GetList().Where(x => x.Status && x.Dunation.ToString() == textBox3.Text).Select(x => new { קוד_קו = x.KodL, מחיר = x.Price, משך_זמן = x.Dunation, פעיל = x.Status }).ToList();
        }
    }
}
