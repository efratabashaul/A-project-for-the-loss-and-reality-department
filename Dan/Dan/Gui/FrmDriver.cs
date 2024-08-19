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
    public partial class FrmDriver : Form
    {
        private DriverDB tblDriver;
        private Driver thisDriver;
        private bool flagAdd;
        private bool flagUpdate;
        private string s1;
        private string s2;
        private string ch;
        private string ch2;
        public FrmDriver(string s, string s11)
        {
            InitializeComponent();
            tblDriver = new DriverDB();
            notPossible();
            flagAdd = false;
            flagUpdate = false;
            s1 = s;
            s2 = s11;
            if (s == "no")
            {
                dg.Visible = false;
                btnUpdate.Visible = false;
                btnRefresh.Visible = false;
                btnDel.Visible = false;
                btnClient.Visible = false;
                flagAdd = true;
                textBox1.ReadOnly = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                btnNew.Visible = true;
            }
            else
            {
                if (s == "driver")
                {
                    thisDriver = tblDriver.GetList().Find(x => x.Pincode == s2);
                    Fill(thisDriver);
                    flagUpdate = true;
                    flagAdd = false;
                    Possible();
                    dg.Visible = false;
                    btnRefresh.Visible = false;
                    btnNew.Visible = false;
                    btnClient.Visible = false;
                    btnDel.Visible = false;
                    btnCancel.Visible = false;
                }
            }
            dg.DataSource = tblDriver.GetList().Where(X => X.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {

        }
        private void Possible()
        {
            panel2.Visible = true;
            panel1.Visible = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
        }
        private void notPossible()
        {
            if (s1 != "driver")
            {
                flagUpdate = false;
                if (s1 != "no")
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    flagAdd = false;
                }
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(X => X.IdD.StartsWith(textBox1.Text)&& X.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(X => X.FName.StartsWith(textBox2.Text) && X.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(X => X.LName.StartsWith(textBox3.Text) && X.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(X => X.Tel.StartsWith(textBox4.Text) && X.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(X => X.Pel.StartsWith(textBox5.Text) && X.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x => x.Adress.StartsWith(textBox6.Text) && x.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private bool CreateFields(Driver d)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                d.IdD = textBox1.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
                ok = false;
            }
            try
            {
                d.LName = textBox2.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox2, ex.Message);
                ok = false;
            }
            try
            {
                d.FName = textBox3.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox3, ex.Message);
                ok = false;
            }
            try
            {
                d.Tel = textBox4.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox4, ex.Message);
                ok = false;
            }
            try
            {
                d.Pel = textBox5.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox5, ex.Message);
                ok = false;
            }
            try
            {
                d.Adress = textBox6.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox6, ex.Message);
                ok = false;
            }
            try
            {
                d.Pincode = textBox7.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox7, ex.Message);
                ok = false;
            }
            d.Status =  true;
            return ok;
        }

        private void Fill(Driver driver)
        {
            if (tblDriver.Size() > 0)
            {
                ch= driver.IdD.ToString();
                textBox1.Text = driver.IdD.ToString();
                textBox2.Text = driver.LName.ToString();
                textBox3.Text = driver.FName.ToString();
                textBox4.Text = driver.Tel.ToString();
                textBox5.Text = driver.Pel.ToString();
                textBox6.Text = driver.Adress.ToString();
                textBox7.Text = driver.Pincode.ToString();
                ch2 = textBox7.Text;
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
        }
        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagUpdate)
                if (this.tblDriver.Find(textBox1.Text.ToString()) == null||textBox1.Text==ch) 
                {
                    if(!tblDriver.GetList().Exists(x => x.Pincode == textBox7.Text)||textBox7.Text==ch2)
                    {
                        if (CreateFields(thisDriver))
                        {
                            DialogResult r = MessageBox.Show("האם לעדכן נהג זה?", "אישור עידכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.Yes)
                            {
                                tblDriver.UpdateRow(thisDriver);
                                notPossible();
                                dg.DataSource = tblDriver.GetList().Where(x => x.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("קיים נהג עם סיסמה זהה!!");
                    }
                }
                else
                {
                    MessageBox.Show("קיים נהג עם ת.ז. זהה!!");
                }

            if (flagAdd)
            {
                Driver d = new Driver();
                if (this.tblDriver.Find(textBox1.Text.ToString()) == null )
                {
                    if(!tblDriver.GetList().Exists(x => x.Pincode == textBox7.Text))
                    {
                        if (CreateFields(d))
                        {
                            DialogResult r = MessageBox.Show("האם להוסיף נהג זה?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.Yes)
                            {
                                tblDriver.AddNew(d);
                                notPossible();
                                dg.DataSource = tblDriver.GetList().Where(x => x.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("קיים נהג עם סיסמה זהה!!");

                    }

                }
                else
                {
                    MessageBox.Show("קיים נהג עם ת.ז. זהה!!");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x=>x.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            flagAdd = true;
            textBox1.ReadOnly = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            Possible();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק נהג זה?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                    tblDriver.DeleteStatus(st);
                    dg.DataSource = tblDriver.GetList().Where(x => x.Status).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
                }
            }
            else
            {
                MessageBox.Show("בחר נהג למחיקה!");
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                thisDriver = tblDriver.Find(st);
                Fill(thisDriver);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                thisDriver = tblDriver.Find(st);
                Fill(thisDriver);
                flagUpdate = true;
                flagAdd = false;
                Possible();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            notPossible();
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (s1 == "no")
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else
            {
                FrmEnter f;
                if (s1 == "driver")
                {
                    f = new FrmEnter(s1, ch2);

                }
                else
                {
                    f = new FrmEnter(s1, "");
                }
                f.Show();
                this.Hide();
            }

            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x => x.Status && x.Pincode == textBox7.Text).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x => x.Status && x.Adress == textBox6.Text).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x => x.Status && x.FName == textBox3.Text).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void FrmDriver_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x => x.Status&&x.IdD==textBox1.Text).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x => x.Status && x.LName == textBox2.Text).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x => x.Status && x.Tel == textBox4.Text).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblDriver.GetList().Where(x => x.Status && x.Pel == textBox5.Text).Select(x => new { תז = x.IdD, משפחה = x.LName, פרטי = x.FName, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress, סיסמה = x.Pincode }).ToList();
        }
    }
}
