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
    public partial class FrmLost : Form
    {
        private Bus thisBus;
        private BusDB tblBus;
        private KindL thisKindL;
        private KindLDB tblKindL;
        private Traveling thisTraveling;
        private TravelingDB tblTraveling;
        private Client thisClient;
        private ClientDB tblClient;
        private Department thisDepartment;
        private DepartmentDB tblDepartment;
        private Lost thisLost;
        private LostDB tblLost;
        private LineDB tblLine;
        private SideDB tblSide;
        private DriverDB tblDriver;
        private LineDDB tblLineD;
        private bool flagAdd;
        private bool flagUpdate;
        private bool flagOk = false;
        private string s1;
        private string s33;
        public FrmLost(string s,string s11)
        {
            InitializeComponent();
            s33 = s11;
            tblKindL = new KindLDB();
            tblClient = new ClientDB();
            tblTraveling = new TravelingDB();
            tblDepartment = new DepartmentDB();
            tblLost = new LostDB();
            tblBus = new BusDB();
            tblLost = new LostDB();
            tblSide = new SideDB();
            tblLine = new LineDB();
            tblDriver = new DriverDB();
            tblLineD = new LineDDB();
            comboBox2.DataSource = tblDepartment.GetList();
            thisLost = new Lost();
            comboBox1.DataSource = tblLine.GetList();
            comboBox3.DataSource = tblLineD.GetList();
            ClearControl();
            flagAdd = false;
            flagUpdate = false;
            lstSug.DataSource = tblKindL.GetList();
            dgT.DataSource = tblTraveling.GetList().Where(x=>x.status) .Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            s1 = s;
            dgL.DataSource = tblLost.GetList().Where(x =>x.Id != "111111118"&& x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(),קו=x.ThisTraveling().KodL }).ToList();
            if (s == "driver")
            {
                btnNew.Visible = false;
                btnDelOrder.Visible = false;
                btnUpdate.Visible = false;
                button3.Visible = false;
                btnOk.Visible = false;
                button1.Visible = false;
                btnCancel.Visible = false;
                button7.Visible = false;
            }
        }

        private void FrmLost_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEnter f = new FrmEnter(s1,s33);
            f.Show();
            this.Hide();
        }

        private void gbC_Enter(object sender, EventArgs e)
        {

        }

        private void gbO_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dgC.DataSource = null;
            dgL.DataSource = tblLost.GetList().Where(x => x.banked ==checkBox1.Checked&& x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dgC.DataSource = null;
            dgL.DataSource = tblLost.GetList().Where(x => x.moveD == checkBox2.Checked&& x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            dgC.DataSource = tblClient.GetList().Where(X => X.Id.StartsWith(textBox2.Text) && X.Status).Select(x => new { תז = x.Id, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress }).ToList();
            dgL.DataSource = tblLost.GetList().Where(x => x.Id.ToString().StartsWith(textBox2.Text) && x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLost.GetList().Where(x => x.KodL.ToString().StartsWith(textBox1.Text) && x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnDelParit_Click(object sender, EventArgs e)
        {

        }

        private void DateT_ValueChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLost.GetList().Where(x => x.DateT.ToString().StartsWith(DateT.ToString()) && x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void TimeT_ValueChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLost.GetList().Where(x => x.HourT.ToString().StartsWith(TimeT.ToString()) && x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }


        private void gbD_Enter(object sender, EventArgs e)
        {

        }


        private void ClearControl()
        {
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            richTextBox1.Text = "";
            textBox2.Text = "";
            DateT.Text = "";
            TimeT.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            dgC.DataSource = null;
            pnlC.Visible = false;
            textBox1.ReadOnly =false;
            dgL.DataSource = null;
            pnlC.Visible = false;
            errorProvider1.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            panel1.Visible = true;
            richTextBox1.Text = "";
            ClearControl();
            errorProvider1.Clear();
            flagAdd = false;
            gbL.Visible = true;
            checkBox2.Visible = true;
            checkBox1.Visible = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private bool SelectDG(DataGridView dg)
        {
            return (dg.SelectedRows.Count >= 1);
        }
        



        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = tblLost.GetNextKey().ToString();
            checkBox2.Visible = false;
            checkBox1.Visible = false;
            ClearControl();
            panel1.Visible = false;
            gbL.Visible = false;
            flagAdd = true;
            DateT.Value = System.DateTime.Today;
            TimeT.Value = System.DateTime.Now;
            textBox1.ReadOnly = true;
            thisLost = null;
            button3.Visible = true;
            comboBox2.DataSource = tblDepartment.GetList();
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            if (dgL.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק אבידה זו?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string st = dgL.SelectedRows[0].Cells[0].Value.ToString();
                    tblLost.DeleteStatus(Convert.ToInt32(st));
                    MessageBox.Show("האבידה נמחקה!");
                    dgL.DataSource = tblLost.GetList().Where(x => x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
                }
            }
            else
            {
                MessageBox.Show("בחר אבידה למחיקה!");
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ClearControl();
            dgL.DataSource = tblLost.GetList().Where(x => x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
            pictureBox1 .Image= null;
        }

        private void Fill(Lost lost)
        {
            if (tblLost.Size() > 0)
            {
                textBox1.Text = lost.KodL.ToString();
                DateT.Value = lost.dateT;
                TimeT.Value = lost.hourT;
                Traveling t = tblTraveling.GetList().Find(x => x.KodB == lost.KodB && x.HourT .Hour== lost.hourT.Hour && x.DateT.Date == lost.DateT.Date&&x.status&&x.KodL==lost.ThisTraveling().KodL&&x.KodSi==lost.ThisTraveling().KodSi);
                comboBox1.Text = t.KodL.ToString();
                comboBox3.Text = t.ThisLineD().ThisSide().NameSi.ToString();
                dgT.DataSource = tblTraveling.GetList().Where(x => x.KodB == t.KodB && x.DateT.Date == t.DateT.Date && x.HourT.Hour == t.HourT.Hour&&x.status&&x.KodSi==t.KodSi&&x.KodL==t.KodL).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
                KindL k = tblKindL.GetList().Find(x => x.KodK == lost.KodK);
                comboBox2.Text = k.ThisDepartment().NameD;
                int index = lstSug.FindString(k.NameK);
                lstSug.SetSelected(index, true);
                textBox2.Text = lost.Id;
                richTextBox1.Text = lost.Information;
                checkBox1.Checked = lost.banked.Equals(true);
                checkBox2.Checked = lost.moveD.Equals(true);
                try
                {
                    string path = System.IO.Directory.GetCurrentDirectory();
                    int x = path.IndexOf("\\bin");
                    path = path.Substring(0, x) + lost.Picture;
                    pictureBox1.Image = Image.FromFile(path);
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                }
                catch { }
            }
            else
            {
                textBox1.Text = "";
                DateT.Value = DateTime.Today;
                TimeT.Value = DateTime.Now;
                comboBox3.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                lstSug.Text = "";
                textBox2.Text = "";
                richTextBox1.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectDG(dgL))
            {
                string st = dgL.SelectedRows[0].Cells[0].Value.ToString();
                thisLost = tblLost.Find(Convert.ToInt32(st));
                if (thisLost.moveD)
                {
                    errorProvider1.SetError(dgL, "אבידה זו הועברה ליעדה!");
                }
                else
                {
                        errorProvider1.Clear();
                        checkBox1.Visible = true;
                        checkBox2.Visible = true;
                        Fill(thisLost);
                        flagUpdate = true;
                        flagAdd = false;
                        textBox1.ReadOnly = true;
                }
            }
        }



        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                flagOk = true;
                if (SelectDG(dgT))
                {

                    DateTime d = new DateTime();
                    d = Convert.ToDateTime(dgT.SelectedRows[0].Cells[1].Value);
                    DateTime h = new DateTime();
                    h = Convert.ToDateTime(dgT.SelectedRows[0].Cells[2].Value);
                    int st = Convert.ToInt32(dgT.SelectedRows[0].Cells[0].Value);
                    List<Traveling> lst = tblTraveling.GetList().Where(x => x.KodB == st).ToList();
                    foreach (Traveling item in lst)
                    {
                        if (item.DateT.Date == d.Date)
                        {
                            if (item.HourT.Hour == h.Hour)
                            {
                                if (item.HourT.Minute == h.Minute)
                                {
                                    if (item.HourT.Second == h.Second)
                                    {
                                        thisTraveling = item;
                                    }
                                }
                            }
                        }
                    }

                    errorProvider1.Clear();
                }
                else
                    errorProvider1.SetError(dgT, "לא נבחרה נסיעה!");
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = tblDepartment.GetList();
            Department depart = ((Department)comboBox2.SelectedItem);
            if (depart != null)
                lstSug.DataSource = tblKindL.GetList().Where(x => x.KodD == depart.KodD&&x.Status).ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            thisClient = tblClient.GetList().Find(x => x.Id == textBox2.Text&&x.Status);
            if (thisClient != null)
            {
                string st = textBox2.Text;
                if (flagAdd)
                {
                    Lost thisLost = new Lost();
                    if (this.tblLost.Find(Convert.ToInt32(textBox1.Text)) == null)
                    {
                        if (CreateFields(thisLost))
                        {
                            DialogResult r = MessageBox.Show("האם להוסיף אבידה זו?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.Yes)
                            {
                                thisLost.moveD = false;
                                thisLost.banked = false;
                                tblLost.AddNew(thisLost);
                                gbL.Visible = false;
                                MessageBox.Show("האבידה נוספה,במידה ונמצא את אבידתך נציגנו יצור איתך קשר!");
                                checkBox2.Visible = true;
                                checkBox1.Visible = true;
                                dgL.DataSource = tblLost.GetList().Where(x => x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("קימת אבידה זו!");
                    }
                }
                if (flagUpdate)
                {
                    if (CreateFields(thisLost))
                    {
                        DialogResult r = MessageBox.Show("האם לעדכן אבידה זו?", "אישור עידכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            try
                            {
                                thisLost.moveD = checkBox2.Checked;
                            }
                            catch (Exception ex)
                            {
                                errorProvider1.SetError(checkBox2, ex.Message); 
                            }
                            try
                            {
                                thisLost.banked = checkBox1.Checked;
                            }
                            catch (Exception ex)
                            {
                                errorProvider1.SetError(checkBox1, ex.Message);
                            }
                            tblLost.UpdateRow(thisLost);
                            MessageBox.Show("האבידה עודכנה!");
                            dgL.DataSource = tblLost.GetList().Where(x => x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
                        }
                    }
                }
            }
            else
                pnlC.Visible = true;
        }
    
            private bool CreateFields(Lost l)
            {
                bool ok = true;
                errorProvider1.Clear();
                try
                {
                    l.KodL = Convert.ToInt32(textBox1.Text);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(textBox1, ex.Message);
                    ok = false;
                }
                try
                {
                    if(textBox2.Text!="111111118")    
                        l.Id = textBox2.Text;
                    else
                        {
                            ok = false;
                            errorProvider1.SetError(textBox2, "רשום ת.ז. תקינה!");
                        }        
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(textBox2, ex.Message);
                    ok = false;
                }
                try
                {
                    l.Information = richTextBox1.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(richTextBox1, ex.Message);
                    ok = false;
                }
               
                try
                {
                    l.Status = true;
                }
                catch (Exception ex)
                {   
                    errorProvider1.SetError(checkBox2, ex.Message);
                    ok = false;
                }
                try
                {
                    l.Picture = textBox3.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(textBox3, ex.Message);
                    ok = false;
                }
            try
                {
                    if (flagOk)
                    {
                        l.DateT = thisTraveling.DateT;
                        l.HourT = thisTraveling.HourT;
                        l.KodB = thisTraveling.KodB;
                    }
                    else
                    {
                        if(flagAdd)
                        {
                            errorProvider1.SetError(dgT,"בחר נסיעה!");
                            ok = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(dgT, ex.Message);
                    ok = false;
                }
                KindL k = tblKindL.GetList().Find(x => x.NameK == lstSug.SelectedItem.ToString());
                l.KodK = k.KodK;
                return ok;
            }

            private void dgL_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            if (SelectDG(dgL))
            {
                string st = dgL.SelectedRows[0].Cells[0].Value.ToString();
                string s= dgL.SelectedRows[0].Cells[1].Value.ToString();
                dgC.DataSource = tblClient.GetList().Where(x => x.Id == s && x.Status).Select(x => new { תז = x.Id, משפחה = x.LName, פרטי = x.FName, טלפון = x.Tel, פלאפון = x.Pel, פעיל = x.Status, כתובת = x.Adress }).ToList();
                gbL.Visible = true;
                try
                {
                    pictureBox1.Image = null;
                    thisLost = tblLost.Find(Convert.ToInt32(st));
                    string path = System.IO.Directory.GetCurrentDirectory();
                    int x = path.IndexOf("\\bin");
                    path = path.Substring(0, x) + thisLost.Picture;
                    pictureBox1.Image = Image.FromFile(path);
                    pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                }
                catch
                {
                   
                }
            }
        }


            private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                dgL.DataSource = tblLost.GetList().Where(x => x.Information.ToString().StartsWith(richTextBox1.Text) && x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
            }

            private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
            {
             
            }

            private void button5_Click(object sender, EventArgs e)
            {
                FrmClient f = new FrmClient(s1,"");
                f.Show();
            }

            private void dgC_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            try
            {
                textBox2.Text = dgC.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch { }
            }

            private void dgT_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            try
            {
                Traveling t = new Traveling();
                DateTime d = new DateTime();
                d = Convert.ToDateTime(dgT.SelectedRows[0].Cells[1].Value);
                DateTime h = new DateTime();
                h = Convert.ToDateTime(dgT.SelectedRows[0].Cells[2].Value);
                int st = Convert.ToInt32(dgT.SelectedRows[0].Cells[0].Value);
                List<Traveling> lst = tblTraveling.GetList().Where(x => x.KodB == st && x.status).ToList();
                foreach (Traveling item in lst)
                {
                    if (item.DateT.Date == d.Date)
                    {
                        if (item.HourT.Hour == h.Hour)
                        {
                            if (item.HourT.Minute == h.Minute)
                            {
                                if (item.HourT.Second == h.Second)
                                {
                                    t = item;
                                }
                            }
                        }
                    }
                }
                dgL.DataSource = tblLost.GetList().Where(x => x.KodB == t.KodB && x.HourT == t.HourT&& x.DateT.Date == t.DateT.Date && x.Id != "111111118" && x.Status).Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
            }
            catch { }
            }

            private void DateT_ValueChanged_1(object sender, EventArgs e)
            {
                dgT.DataSource = tblTraveling.GetList().Where(x => x.DateT == DateT.Value.Date && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            }

            private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
            {
                dgT.DataSource = tblTraveling.GetList().Where(x => x.KodL == ((Line)comboBox1.SelectedItem).KodL && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            }

            private void TimeT_ValueChanged_1(object sender, EventArgs e)
            {
                dgT.DataSource = tblTraveling.GetList().Where(x => x.HourT.Hour.Equals( TimeT.Value.Hour) && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            }

            private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
            {
                dgT.DataSource = tblTraveling.GetList().Where(x => x.KodSi == ((LineD)comboBox3.SelectedItem).KodSi && x.KodL == ((LineD)comboBox3.SelectedItem).KodL && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files|*.jpg";
                openFileDialog1.ShowDialog();
                string r = openFileDialog1.FileName;
                string mikum;
                int x = r.IndexOf("\\pictures");
                int y = r.Length - x;
                mikum = r.Substring(x, y);
                pictureBox1.Image = Image.FromFile(r);
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                textBox3.Text = mikum;
            }
            catch
            {
                MessageBox.Show(" !pictures לא ניתן לפתוח קובץ זה, עליך לבחור תמונה מתיקיה ");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            button4.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDepartment f = new FrmDepartment("no");
            f.Show();
            comboBox2.DataSource = tblDepartment.GetList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmKindL f = new FrmKindL("no");
            f.Show();
        }

        private void lstSug_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLost.GetList().Where(x => x.ThisKindL().NameK == lstSug.SelectedItem.ToString() && x.Status&&x.Id!="111111118").Select(x => new { קוד_אבידה = x.KodL, תז_לקוח = x.Id, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.HourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dgT_CellContentClick(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            tblDepartment = new DepartmentDB();
            comboBox2.DataSource = tblDepartment.GetList();
        }

        private void lstSug_Click(object sender, EventArgs e)
        {

        }
    }
    }