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
    public partial class FrmLineD : Form
    {
        private LineDDB tblLineD;
        private LineDB tblLine;
        private SideDB tblSide;
        private bool flagAdd;
        private bool flagUpdate;
        private LineD thisLineD;
        private int kodL;
        private int kodSi;
        public FrmLineD()
        {
            InitializeComponent();
            tblLineD = new LineDDB();
            tblLine = new LineDB();
            tblSide = new SideDB();
            comboBox1.DataSource = tblLine.GetList();
            comboBox2.DataSource = tblSide.GetList();
            panel2.Visible = false;
            dgL.DataSource = tblLineD.GetList().Where(x => x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLineD.GetList().Where(x => x.KodL.ToString().StartsWith(comboBox1.Text)&&x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
            errorProvider1.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLineD.GetList().Where(x => x.KodSi.ToString().StartsWith(comboBox2.Text) && x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
            errorProvider1.Clear();
        }

        private void FrmLineD_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLineD.GetList().Where(x => x.Origin.ToString().StartsWith(textBox3.Text) && x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
            errorProvider1.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLineD.GetList().Where(x => x.Destination.ToString().StartsWith(textBox4. Text) && x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
            errorProvider1.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgL.DataSource = tblLineD.GetList().Where(x=> x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
            errorProvider1.Clear();
            dgL.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dgL.Visible = false;
            flagAdd = true;
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
            dgL.DataSource = null;  
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void btnLineD_Click(object sender, EventArgs e)
        {
            if (dgL.SelectedRows.Count > 0)
            {
                int kodL = Convert.ToInt32(dgL.SelectedRows[0].Cells[0].Value);
                string nameSi =dgL.SelectedRows[0].Cells[1].Value.ToString();
                thisLineD = tblLineD.Find(kodL,nameSi);
                Fill(thisLineD);
            }
            
        }
        private void Fill(LineD lineD)
        {
            if (tblLineD.Size() > 0)
            {
                comboBox1.Text = lineD.KodL.ToString();
                kodL =lineD.KodL;
                textBox4.Text = lineD.Destination.ToString();
                comboBox2.Text = lineD.ThisSide().NameSi;
                kodSi = lineD.KodSi;
                textBox3.Text = lineD.Origin;
            }
            else
            {
                comboBox1.Text = "";
                textBox3.Text = "";
                comboBox2.Text = "";
                textBox4.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgL.SelectedRows.Count > 0)
            {
                    int kodL = Convert.ToInt32(dgL.SelectedRows[0].Cells[0].Value);
                    string s = dgL.SelectedRows[0].Cells[1].Value.ToString();
                    Side st= tblSide.GetList().Find(x => x.NameSi == s);
                    int kodSi = st.KodSi;
                    thisLineD = tblLineD.Find(kodL, kodSi);
                    Fill(thisLineD);
                    flagUpdate = true;
                    flagAdd = false;
                    panel1.Visible = false;
                    panel2.Visible = true;
            }   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox1.SelectedItem != null)
            {
                if (flagUpdate)
                {
                    if (tblLineD.GetList().Exists(x => x.KodL == ((Line)comboBox1.SelectedItem).KodL && x.KodSi == ((Side)comboBox2.SelectedItem).KodSi) == false || (((Side)comboBox2.SelectedItem).KodSi == kodSi && ((Line)comboBox1.SelectedItem).KodL == kodL))
                    {
                        if (CreateFields(thisLineD))
                        {
                            DialogResult r = MessageBox.Show("האם לעדכן קו על פי יעד זה?", "אישור עידכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.Yes)
                            {
                                tblLineD.UpdateRow(thisLineD);
                                MessageBox.Show("קו על פי יעד עודכן!");
                                panel2.Visible = false;
                                panel1.Visible = true;
                                dgL.DataSource = tblLineD.GetList().Where(x => x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
                            }
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(comboBox1, "קיים קו זה בצד זה!");
                        errorProvider1.SetError(comboBox2, "קיים קו זה בצד זה!");
                    }
                }
                if (flagAdd)
                {

                    if (tblLineD.GetList().Exists(x => x.KodL == ((Line)comboBox1.SelectedItem).KodL && x.KodSi == ((Side)comboBox2.SelectedItem).KodSi))
                    {
                        errorProvider1.SetError(comboBox1, "קיים קו זה בצד זה!");
                        errorProvider1.SetError(comboBox2, "קיים קו זה בצד זה!");
                    }
                    else
                    {
                        DialogResult r = MessageBox.Show("האם להוסיף קו זה?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            thisLineD = new LineD();
                            if (CreateFields(thisLineD))
                            {
                                tblLineD.AddNew(thisLineD);
                                MessageBox.Show("הקו נשמר!");
                                panel2.Visible = false;
                                panel1.Visible = true;
                                dgL.DataSource = tblLineD.GetList().Where(x => x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
                            }
                        }
                    }
                }
            }
            else
            {
                if (comboBox1.SelectedItem == null)
                    errorProvider1.SetError(comboBox1, "בחר קו");
                if (comboBox2.SelectedItem == null)
                    errorProvider1.SetError(comboBox2, "בחר צד");
            }
        }

        private bool CreateFields(LineD l)
        {
            
            bool ok = true;
            errorProvider1.Clear();
            
                try
                {
                if(comboBox1.SelectedItem!=null)    
                l.KodL = ((Line)comboBox1.SelectedItem).KodL;
                else
                {
                    errorProvider1.SetError(comboBox1, "בחר קו");
                    ok = false;
                }
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(comboBox1, ex.Message);
                    ok = false;
                }
                try
                {
                if(comboBox2.SelectedItem!=null)    
                l.KodSi = ((Side)comboBox2.SelectedItem).KodSi;
                else
                {
                    errorProvider1.SetError(comboBox2, "בחר צד");
                    ok = false;
                }
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(comboBox2, ex.Message);
                    ok = false;
                }
                try
                {
                    l.Origin = textBox3.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(textBox3, ex.Message);
                    ok = false;
                }
                try
                {
                    l.Destination= textBox4.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(textBox4, ex.Message);
                    ok = false;
                }
            l.Status = true;
            return ok;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            panel2.Visible = false;
            panel1.Visible = true;
            errorProvider1.Clear();
            flagAdd = false;
            flagUpdate = false;
            dgL.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmEnter f = new FrmEnter("director","");
            f.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (dgL.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק קו על פי יעד זה?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    int kodl = Convert.ToInt32(dgL.SelectedRows[0].Cells[0].Value);
                    string s =dgL.SelectedRows[0].Cells[1].Value.ToString();
                    LineD l= tblLineD.GetList().Find(x => x.KodL==kodl&&x.ThisSide().NameSi==s);
                    tblLineD.DeleteStatus(l.KodL, l.KodSi);
                    MessageBox.Show("קו על פי יעד נמחק!");
                    dgL.DataSource = tblLineD.GetList().Where(x => x.Status).Select(x => new { קו = x.KodL, צד = x.ThisSide().NameSi, מוצא = x.Origin, יעד = x.Destination }).ToList();
                }
            }
            else
            {
                MessageBox.Show("בחר קו על פי יעד למחיקה!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }
