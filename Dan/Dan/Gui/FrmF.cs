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
    public partial class FrmF : Form
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
        private LineDDB tblLineD;
        private bool flagAdd;
        private bool flagUpdate;
        private bool flagOk = false;
        private string s1;
        private string s5;
        public FrmF(string s,string s7)
        {
            InitializeComponent();
            s5 = s7;
            tblKindL = new KindLDB();
            tblClient = new ClientDB();
            tblTraveling = new TravelingDB();
            tblDepartment = new DepartmentDB();
            tblLost = new LostDB();
            tblBus = new BusDB();
            tblLine = new LineDB();
            tblSide = new SideDB();
            tblLineD = new LineDDB();
            comboBox2.DataSource = tblDepartment.GetList();
            comboBox4.DataSource = tblBus.GetList();
            comboBox1.DataSource = tblLine.GetList();
            comboBox3.DataSource = tblLineD.GetList();
            ClearControl();
            flagAdd = false;
            flagUpdate = false;
            lstSug.DataSource = tblKindL.GetList();
            dgT.DataSource=tblTraveling.GetList().Where(x=>x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            s1 = s;
            dgL.DataSource = tblLost.GetList().Where(x =>x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(),קו=x.ThisTraveling().KodL }).ToList();
            if (s == "client")
            {
                btnNew.Visible = false;
                btnUpdate.Visible = false;
                btnDelOrder.Visible = false;
                button3.Visible = false;
                button1.Visible = false;
                btnCancel.Visible = false;
                btnOk.Visible = false;
                button7.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLost.GetList().Where(x => x.KodL.ToString().StartsWith(textBox1.Text) && x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT .ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectDG(dgL))
            {
                string st = dgL.SelectedRows[0].Cells[0].Value.ToString();
                thisLost = tblLost.Find(Convert.ToInt32(st));
                if (thisLost.moveD)
                {
                    errorProvider1.SetError(dgL, "מציאה זו הועברה ליעדה!");
                }
                else
                    {
                        errorProvider1.Clear();
                        checkBox2.Visible = true;
                        Fill(thisLost);
                        textBox1.ReadOnly = true;
                        flagUpdate = true;
                        flagAdd = false;
                    }
            }
        }
        private void Fill(Lost lost)
        {
            if (tblLost.Size() > 0)
            {
                textBox1.Text = lost.KodL.ToString();
                dt1.Value = lost.dateT;
                dt2.Value = lost.hourT;
                Traveling t = tblTraveling.GetList().Find(x => x.KodB == lost.KodB && x.HourT.Hour == lost.hourT.Hour && x.DateT.Date == lost.DateT.Date&&x.status&& x.KodL == lost.ThisTraveling().KodL && x.KodSi == lost.ThisTraveling().KodSi);
                comboBox4.Text = lost.KodB.ToString();
                dgT.DataSource = tblTraveling.GetList().Where(x => x.KodB == t.KodB && x.DateT.Date == t.DateT.Date && x.HourT.Hour == t.HourT.Hour && x.status && x.KodSi == t.KodSi && x.KodL == t.KodL).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
                KindL k = tblKindL.GetList().Find(x => x.KodK == lost.KodK);
                comboBox2.Text = k.ThisDepartment().NameD;
                int index = lstSug.FindString(k.NameK);
                lstSug.SetSelected(index,true);
                richTextBox1.Text = lost.Information;
                checkBox2.Checked = lost.moveD.Equals(true);
                checkBox1.Checked = lost.banked.Equals(true);
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
                dt1.Value = DateTime.Today;
                dt2.Value = DateTime.Now;
                richTextBox1.Text = "";
                comboBox4.Text = "";
                comboBox2.Text = "";
                lstSug.Text = "";
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
        }
        private bool SelectDG(DataGridView dg)
        {
            return dg.SelectedRows.Count>= 1;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbT.Visible = true;
            if(s5=="")
                dgT.DataSource = tblTraveling.GetList().Where(x => x.KodB == ((Bus)comboBox4.SelectedItem).KodB && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            else
            dgT.DataSource = tblTraveling.GetList().Where(x => x.KodB == ((Bus)comboBox4.SelectedItem).KodB&&x.status && x.ThisDriver().Pincode == s5).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLost.GetList().Where(x => x.moveD==checkBox2.Checked && x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }
        private void lstSug_SelectedIndexChanged(object sender, EventArgs e)
        {
             dgL.DataSource = tblLost.GetList().Where(x => x.ThisKindL().ToString()==lstSug.SelectedItem.ToString()&&  x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            checkBox2.Visible = false;
            textBox1.Text = tblLost.GetNextKey().ToString();
            ClearControl();
            panel1.Visible = false;
            gbL.Visible = false;
            flagAdd = true;
            dt1.Value = DateTime.Today;
            dt2.Value = DateTime.Now;
            textBox1.ReadOnly = true;
            thisLost = null;
            button3.Visible = true;
        }
        public void ClearControl()
        {
            richTextBox1.Text = "";
            comboBox4.Text = "";
            dt1.Text = "";
            dt2.Text = "";
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            dgT.DataSource = null;
            textBox1.ReadOnly = false;
            dgL.DataSource = null;
        }

        private void dgL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectDG(dgL))
            {
                string st = dgL.SelectedRows[0].Cells[0].Value.ToString();
                string s = dgL.SelectedRows[0].Cells[1].Value.ToString();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearControl();
            textBox1.Text = "";
            dgL.DataSource = tblLost.GetList().Where(x=>x.Id=="111111118"&&x.Status). Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked,הועבר_ליעדו=x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            if (dgL.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק מציאה זו?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string st = dgL.SelectedRows[0].Cells[0].Value.ToString();
                    tblLost.DeleteStatus(Convert.ToInt32(st));
                    MessageBox.Show("המציאה נמחקה!");
                    dgL.DataSource = tblLost.GetList().Where(x => x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
                }
            }
            else
            {
                MessageBox.Show("בחר מציאה למחיקה!");
            }
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = tblDepartment.GetList();
            Department depart = ((Department)comboBox2.SelectedItem);
            if(depart!=null)
            lstSug.DataSource = tblKindL.GetList().Where(x => x.KodD == depart.KodD&&x.Status).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flagAdd)
            {
                Lost thisLost = new Lost();
                if (this.tblLost.Find(Convert.ToInt32( textBox1.Text)) == null)
                {
                    DialogResult r = MessageBox.Show("האם להוסיף מציאה זו?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        if (CreateFields(thisLost))
                        {
                            thisLost.moveD = false;
                            tblLost.AddNew(thisLost);
                            gbL.Visible = false;
                            MessageBox.Show(" תודה רבה על פנייתך !המציאה נוספה!");
                            checkBox2.Visible = true;
                            dgL.DataSource = tblLost.GetList().Where(x => x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("קימת מציאה זו!");
                    checkBox2.Visible = true;
                }
            }
                    
            else
                if (flagUpdate)
                {
                if (CreateFields(thisLost))
                {
                    DialogResult r = MessageBox.Show("האם לעדכן מציאה זו?", "אישור עידכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
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
                        tblLost.UpdateRow(thisLost);
                        MessageBox.Show("המציאה התעדכנה!");
                        dgL.DataSource = tblLost.GetList().Where(x => x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
                    }
                }
            }
                
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
                l.Information = richTextBox1.Text.ToString();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(richTextBox1, ex.Message);
                ok = false;
            }
            try
            {
                l.Id = "111111118";
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(richTextBox1, ex.Message);
                ok = false;
            }
            try
            {
                l.Picture = textBox2.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox2, ex.Message);
                ok = false;
            }
            KindL k = tblKindL.GetList().Find(x => x.NameK == lstSug.SelectedItem.ToString());
            l.KodK = k.KodK;
            try
            {
                l.banked = checkBox1.Checked;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(checkBox1, ex.Message);
            }
            l.Status =  true;
            try
            {
                if (flagOk)
                {
                    DateTime d = new DateTime();
                    d = thisTraveling.DateT.Date;
                    l.DateT = d.Date;
                    DateTime h = new DateTime();
                    h= thisTraveling.HourT;
                    l.hourT= h;
                    l.KodB = thisTraveling.KodB;
                }
                else
                {
                        if (flagAdd)
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
            return ok;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            checkBox2.Visible = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            panel1.Visible = true;
            ClearControl();
            textBox1.Text = "";
            errorProvider1.Clear();
            flagAdd = true;
            flagUpdate = false;
            gbL.Visible = true;
    }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEnter f = new FrmEnter(s1,s5);
            f.Show();
            this.Hide();
        }

        private void FrmF_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLost.GetList().Where(x => x.Information.ToString().StartsWith(richTextBox1.Text) && x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT,שעת_נסיעה=x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void btnDelParit_Click(object sender, EventArgs e)
        {

        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            if (s5 == "")
                dgT.DataSource = tblTraveling.GetList().Where(x => x.HourT.Hour.Equals(dt2.Value.Hour) && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            else
            dgT.DataSource = tblTraveling.GetList().Where(x => x.HourT.Hour.Equals(dt2.Value.Hour)&&x.status && x.ThisDriver().Pincode == s5).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            dgL.DataSource = tblLost.GetList().Where(x => x.HourT.Hour == dt2.Value.Hour && x.Status&&x.Id=="111111118").Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void dt2_ValueChanged(object sender, EventArgs e)
        {
            if (s5 == "")
                dgT.DataSource = tblTraveling.GetList().Where(x => x.DateT == dt1.Value.Date && x.status ).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
           else
            dgT.DataSource = tblTraveling.GetList().Where(x => x.DateT == dt1.Value.Date && x.status&&x.ThisDriver().Pincode==s5).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            dgL.DataSource=tblLost.GetList().Where(x=>x.DateT==dt1.Value.Date&&x.Status&&x.Id=="111111118").Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        
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
                dgL.DataSource = tblLost.GetList().Where(x => x.KodB == t.KodB && x.HourT == t.HourT && x.DateT.Date == t.DateT.Date && x.Status && x.Id == "111111118").Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
            }
            catch { }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(s5=="")
                dgT.DataSource = tblTraveling.GetList().Where(x => x.KodL == ((Line)comboBox1.SelectedItem).KodL && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            else
            dgT.DataSource = tblTraveling.GetList().Where(x => x.KodL== ((Line)comboBox1.SelectedItem).KodL && x.status && x.ThisDriver().Pincode == s5).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD()}).ToList();
            dgL.DataSource = tblLost.GetList().Where(x => x.ThisTraveling().KodL ==((Line) comboBox1.SelectedItem).KodL && x.Status&&x.Id=="11111118").Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(s5=="")
                dgT.DataSource = tblTraveling.GetList().Where(x => x.KodSi == ((LineD)comboBox3.SelectedItem).KodSi && x.KodL == ((LineD)comboBox3.SelectedItem).KodL && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            else
            dgT.DataSource = tblTraveling.GetList().Where(x => x.KodSi == ((LineD)comboBox3.SelectedItem).KodSi && x.KodL == ((LineD)comboBox3.SelectedItem).KodL && x.status && x.ThisDriver().Pincode == s5).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
        }
        private void gbK_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                textBox2.Text = mikum;
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmKindL f = new FrmKindL("no");
            f.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dgL.DataSource = tblLost.GetList().Where(x => x.banked == checkBox1.Checked && x.Id == "111111118" && x.Status).Select(x => new { קוד_מציאה = x.KodL, מחלקה = x.ThisKindL().ThisDepartment().NameD, סוג_אבידה = x.ThisKindL().NameK, תיאור = x.Information, קיים_במאגר = x.banked, הועבר_ליעדו = x.moveD, תאריך_נסיעה = x.DateT, שעת_נסיעה = x.hourT.ToLongTimeString(), קו = x.ThisTraveling().KodL }).ToList();
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
