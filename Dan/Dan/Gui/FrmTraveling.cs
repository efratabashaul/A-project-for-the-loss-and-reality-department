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

    public partial class FrmTraveling : Form
    {
        private Bus thisBus;
        private BusDB tblBus;
        private Traveling thisTraveling;
        private TravelingDB tblTraveling;
        private Lost thisLost;
        private LostDB tblLost;
        private Driver thisDriver;
        private DriverDB tblDriver;
        private LineD thisLineD;
        private LineDDB tblLineD;
        private LineDB tblLine;
        private Side thisSide;
        private SideDB tblSide;
        private bool flagAdd;
        private bool flagUpdate;
        private Client thisClient;
        private DateTime d = new DateTime();
        private DateTime h = new DateTime();
        private int kodB;

        public FrmTraveling()
        {
            InitializeComponent();
            tblLine = new LineDB();
            tblSide = new SideDB();
            tblBus = new BusDB();
            tblTraveling = new TravelingDB();
            tblLineD = new LineDDB();
            tblDriver = new DriverDB();
            comboBox1.DataSource = tblBus.GetList();
            comboBox2.DataSource = tblLine.GetList();
            comboBox3.DataSource = tblLineD.GetList();
            dgT.DataSource = tblTraveling.GetList().Where(x => x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
        }

        private void FrmTraveling_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEnter f = new FrmEnter("director","");
            f.Show();
            this.Hide();
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgT.DataSource = tblTraveling.GetList().Where(x => x.KodB.ToString().StartsWith(comboBox1.Text)&&x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            dgT.Visible = true;
            errorProvider1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dgT.DataSource = tblTraveling.GetList().Where(x => x.IdD.ToString().StartsWith(textBox2.Text)&&x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            dgT.Visible = true;
            errorProvider1.Clear();
        }



        private void dateT_ValueChanged(object sender, EventArgs e)
        {
            dgT.DataSource = tblTraveling.GetList().Where(x => x.DateT == DateT.Value.Date && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            dgT.Visible = true;
            errorProvider1.Clear();
        }

        private void hourT_ValueChanged(object sender, EventArgs e)
        {
            dgT.DataSource = tblTraveling.GetList().Where(x => x.HourT.Hour.Equals(hourT.Value.Hour) &&x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            dgT.Visible = true;
            errorProvider1.Clear();
        }

        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgT.DataSource = tblTraveling.GetList().Where(x => x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            panel1.Visible = false;
            dgT.Visible = false;
            flagAdd = true;
            flagUpdate = false;
            DateT.Value = DateTime.Today;
            hourT.Value = DateTime.Now;
            thisLost = null;
            panel2.Visible = true;
        }
        private void ClearControl()
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            DateT.Text = "";
            hourT.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dgT.DataSource = null;
            panel1.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgT.Visible = true;
            errorProvider1.Clear();
            comboBox3.DataSource = tblLineD.GetList().Where(x => x.KodL==((Line)comboBox2.SelectedItem).KodL&&x.Status).ToList();
            dgT.DataSource = tblTraveling.GetList().Where(x => x.KodL == ((Line)comboBox2.SelectedItem).KodL && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgT.DataSource = tblTraveling.GetList().Where(x => x.KodSi == ((LineD)comboBox3.SelectedItem).KodSi && x.KodL == ((LineD)comboBox3.SelectedItem).KodL && x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            dgT.Visible = true;
            errorProvider1.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgT.DataSource = tblTraveling.GetList().Where(x => x.KodB==((Bus)comboBox1.SelectedItem).KodB&&x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
            dgT.Visible = true;
            errorProvider1.Clear();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            
            if (dgT.SelectedRows.Count > 0)
            {
                DateTime d = new DateTime();
                d = Convert.ToDateTime(dgT.SelectedRows[0].Cells[1].Value);
                DateTime h = new DateTime();
                h = Convert.ToDateTime(dgT.SelectedRows[0].Cells[2].Value);
                int st = Convert.ToInt32(dgT.SelectedRows[0].Cells[0].Value);
                List<Traveling> lst = tblTraveling.GetList().Where(x => x.KodB == st&&x.status).ToList();
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
            }
            Fill(thisTraveling);
        }


            private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgT.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק נסיעה זו?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    DateTime d = new DateTime();
                    d =Convert.ToDateTime(dgT.SelectedRows[0].Cells[1].Value);
                    DateTime h = new DateTime();
                    h = Convert.ToDateTime(dgT.SelectedRows[0].Cells[2].Value);
                    int st =Convert.ToInt32( dgT.SelectedRows[0].Cells[0].Value);
                    List<Traveling> lst = tblTraveling.GetList().Where(x => x.KodB == st&&x.status).ToList();
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
                    tblTraveling.DeleteStatus(thisTraveling.KodB, thisTraveling.DateT, thisTraveling.HourT);
                    MessageBox.Show("הנסיעה נמחקה!");
                    dgT.DataSource = tblTraveling.GetList().Where(x => x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
                }
            }
            else
            {
                MessageBox.Show("!בחר נסיעה למחיקה");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgT.SelectedRows.Count > 0)
            {
                DateTime d = new DateTime();
                d = Convert.ToDateTime(dgT.SelectedRows[0].Cells[1].Value);
                DateTime h = new DateTime();
                h = Convert.ToDateTime(dgT.SelectedRows[0].Cells[2].Value);
                int st =Convert.ToInt32( dgT.SelectedRows[0].Cells[0].Value);
                List<Traveling> lst = tblTraveling.GetList().Where(x => x.KodB == st&&x.status).ToList();
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
                Fill(thisTraveling);
                d = thisTraveling.DateT.Date;
                h = thisTraveling.HourT;
                kodB = thisTraveling.KodB;
                flagUpdate = true;
                flagAdd = false;
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }

        private void Fill(Traveling t)
        {
            if (tblTraveling.Size() > 0)
            {
                LineD l = tblLineD.Find(t.KodL, t.KodSi);
                comboBox1.Text = t.KodB.ToString();
                textBox2.Text = t.IdD.ToString();
                comboBox2.Text = t.KodL.ToString();
                comboBox3.Text = l.ToString();
                DateT.Text = t.DateT.ToString();
                hourT.Text = t.HourT.ToString();
            }
            else
            {
                comboBox1.Text = "";
                textBox2.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                DateT.Value= DateTime.Today;
                hourT.Value = DateTime.Today;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox1.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                if (flagUpdate)
                {
                    d = thisTraveling.DateT.Date;
                    h = thisTraveling.HourT;
                    kodB = thisTraveling.KodB;
                    if ((tblTraveling.Find(((Bus)comboBox1.SelectedItem).KodB, DateT.Value.Date, hourT.Value) != null && (((Bus)comboBox1.SelectedItem).KodB != kodB || DateT.Value.Date != d.Date || hourT.Value != h)) ||
                        (tblTraveling.GetList().Exists(x => ((x.KodB == ((Bus)comboBox1.SelectedItem).KodB && x.HourT < hourT.Value && x.HourT.AddMinutes(x.ThisLineD().ThisLine().Dunation) >= hourT.Value && x.DateT.Date == DateT.Value.Date)
                        || (x.KodB == ((Bus)comboBox1.SelectedItem).KodB && x.HourT > hourT.Value && hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)) >= x.HourT && x.DateT.Date == DateT.Value.Date)
                        || ((hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Hour < hourT.Value.Hour) && DateT.Value.AddDays(1) == x.DateT.Date && ((hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Hour > x.HourT.Hour) || (hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Hour == x.HourT.Hour && hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Minute > x.HourT.Minute) || (hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Hour == x.HourT.Hour && hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Minute == x.HourT.Minute && hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Second >= x.HourT.Second)) && x.KodB == ((Bus)comboBox1.SelectedItem).KodB)
                        || (DateT.Value.AddDays(-1) == x.DateT.Date && (x.HourT.AddMinutes(x.ThisLineD().ThisLine().Dunation).Hour < x.HourT.Hour) && (x.HourT.AddMinutes(x.ThisLineD().ThisLine().Dunation) >= hourT.Value) && (x.KodB == ((Bus)comboBox1.SelectedItem).KodB))) && (x.DateT.Date != d.Date || x.HourT != h || x.KodB != kodB))))
                    {
                        MessageBox.Show("קימת נסיעה באוטובוס הנוכחי במשך זמן זה!");
                    }
                    else
                    {
                        if (CreateFields(thisTraveling))
                        {
                            DialogResult r = MessageBox.Show("האם לעדכן נסיעה זו?", "אישור עידכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.Yes)
                            {
                                tblTraveling.UpdateRow(thisTraveling);
                                MessageBox.Show("הנסיעה עודכנה!");
                                panel2.Visible = false;
                                panel1.Visible = true;
                                dgT.DataSource = tblTraveling.GetList().Where(x => x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
                            }
                        }
                    }

                }
                if (flagAdd)
                {
                    if ((tblTraveling.GetList().Exists(x=>x.KodB== ((Bus)comboBox1.SelectedItem).KodB&&x.DateT == DateT.Value.Date&&x.HourT==hourT.Value&&x.status)) ||
                        tblTraveling.GetList().Exists(x => (x.KodB == ((Bus)comboBox1.SelectedItem).KodB && x.HourT < hourT.Value && x.HourT.AddMinutes(x.ThisLineD().ThisLine().Dunation) >= hourT.Value && x.DateT.Date == DateT.Value.Date&&x.status)
                        || (x.KodB == ((Bus)comboBox1.SelectedItem).KodB && x.HourT > hourT.Value && hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)) >= x.HourT && x.DateT.Date == DateT.Value.Date&&x.status)
                        || ((hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Hour < hourT.Value.Hour) && DateT.Value.AddDays(1) == x.DateT.Date && ((hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Hour > x.HourT.Hour&&x.status) 
                        ||(hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Hour == x.HourT.Hour && hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Minute > x.HourT.Minute&&x.status) 
                        || (hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Hour == x.HourT.Hour && hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Minute == x.HourT.Minute && hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation)).Second >= x.HourT.Second)) && x.KodB == ((Bus)comboBox1.SelectedItem).KodB&&x.status)
                        || (DateT.Value.AddDays(-1) == x.DateT.Date && (x.HourT.AddMinutes(x.ThisLineD().ThisLine().Dunation).Hour < x.HourT.Hour) && (x.HourT.AddMinutes(x.ThisLineD().ThisLine().Dunation) >= hourT.Value)&&x.status && (x.KodB == ((Bus)comboBox1.SelectedItem).KodB))))
                    {
                        MessageBox.Show("קימת נסיעה באוטובוס הנוכחי במשך זמן זה!");
                    }
                    else
                    {
                        Traveling t = new Traveling();
                        if (CreateFields(t))
                        {
                            DialogResult r = MessageBox.Show("האם להוסיף נסיעה זו?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.Yes)
                            {
                                tblTraveling.AddNew(t);
                                MessageBox.Show("הנסיעה נשמרה!");
                                panel2.Visible = false;
                                panel1.Visible = true;
                                dgT.DataSource = tblTraveling.GetList().Where(x => x.status).Select(x => new { קוד_אוטובוס = x.KodB, תאריך = x.DateT, שעה = x.HourT.ToLongTimeString(), תז_נהג = x.IdD, קו = x.KodL, מוצא_יעד = x.ThisLineD() }).ToList();
                            }
                        }

                    }
                }
            }
            else
            {
                if (comboBox3.SelectedItem == null)
                    errorProvider1.SetError(comboBox3, "בחר מוצא ויעד");
                if (comboBox2.SelectedItem == null)
                    errorProvider1.SetError(comboBox2, "בחר קו");
                if (comboBox1.SelectedItem == null)
                    errorProvider1.SetError(comboBox1, "בחר קוד אוטובוס");
            }   
        }
        private bool CreateFields(Traveling t)
        {
            bool ok = true;
            errorProvider1.Clear();
                try
                {
                if (tblBus.GetList().Exists(x => x.KodB == ((Bus)comboBox1.SelectedItem).KodB))
                    t.KodB = ((Bus)comboBox1.SelectedItem).KodB;
                else
                {
                    errorProvider1.SetError(comboBox1, "הקוד אינו תקין");
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
                    if(tblDriver.GetList().Exists(x=>x.IdD==textBox2.Text))
                       t.IdD = textBox2.Text;
                    else
                    {
                        errorProvider1.SetError(textBox2, "לא קיים נהג זה");
                        ok = false;
                    }
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(textBox2, ex.Message);
                    ok = false;
                }
                try
                {
                    t.KodL = ((Line)comboBox2.SelectedItem).KodL;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(comboBox2, ex.Message);
                    ok = false;
                }
                try
                {
                    t.KodSi = ((LineD)comboBox3.SelectedItem).KodSi;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(comboBox3, ex.Message);
                    ok = false;
                }
                try
                {
                    if (DateT.Value.Date < DateTime.Today.Date)
                    {
                        t.DateT = DateT.Value;
                        t.HourT = hourT.Value;
                    }
                else
                {
                    if ((DateT.Value.Date == DateTime.Now.Date && hourT.Value.Hour < DateTime.Now.Hour)
                       || (DateT.Value.Date == DateTime.Today.Date && hourT.Value.Hour == DateTime.Now.Hour && hourT.Value.Minute < DateTime.Now.Minute)
                       || (DateT.Value.Date == DateTime.Today.Date && hourT.Value.Hour == DateTime.Now.Hour
                       && hourT.Value.Minute == DateTime.Now.Minute && hourT.Value.Second < DateTime.Now.Second))
                    {

                        var afterAdd = hourT.Value.AddMinutes(Convert.ToDouble(((Line)comboBox2.SelectedItem).Dunation));
                        if ((afterAdd.Hour < DateTime.Now.Hour && DateTime.Today.Date == DateT.Value.Date)
                                || (DateTime.Today.Date == DateT.Value.Date && afterAdd.Hour == DateTime.Now.Hour && afterAdd.Minute < DateTime.Now.Minute)
                                || (DateTime.Today.Date == DateT.Value.Date && DateTime.Now.Hour == afterAdd.Hour && DateTime.Now.Minute == afterAdd.Minute && DateTime.Now.Second > afterAdd.Second)
                                || ((afterAdd.Hour < hourT.Value.Hour) && DateT.Value.AddDays(1) == DateTime.Today.Date && afterAdd.Hour < DateTime.Now.Hour)
                                || (afterAdd.Hour < hourT.Value.Hour && DateT.Value.AddDays(1) == DateTime.Today.Date && afterAdd.Hour == DateTime.Now.Hour && afterAdd.Minute < DateTime.Now.Minute)
                                || ((afterAdd.Hour < hourT.Value.Hour) && DateT.Value.AddDays(1) == DateTime.Today.Date && afterAdd.Hour == DateTime.Now.Hour && afterAdd.Minute == DateTime.Now.Minute && DateTime.Now.Second > afterAdd.Second))
                        {
                            t.DateT = DateT.Value;
                            t.HourT = hourT.Value;
                        }
                        else
                        {
                            errorProvider1.SetError(DateT, "רשום נסיעה בעבר!");
                            ok = false;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(DateT, "רשום נסיעה בעבר!");
                        ok = false;
                    }

                }
                       
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(DateT, ex.Message);
                    ok = false;
                }
                t.status =  true;
                return ok;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            panel2.Visible = false;
            panel1.Visible = true;
            errorProvider1.Clear();
            flagAdd = false;
            flagUpdate = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
