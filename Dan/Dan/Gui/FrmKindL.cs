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
namespace Dan.Gui
{
    public partial class FrmKindL : Form
    {
        private KindL thisKindL;
        private KindLDB tblKindL;
        private Department thisDepartment;
        private DepartmentDB tblDepartment;
        private bool flagAdd;
        private bool flagUpdate;
        public FrmKindL(string s)
        {
            InitializeComponent();
            tblDepartment = new DepartmentDB();
            tblKindL = new KindLDB();
            dg.DataSource = tblKindL.GetList();
            dg.DataSource = tblKindL.GetList().Where(x=>x.Status).Select(x => new {קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.KodD,סטטוס=x.Status}).ToList();
            flagAdd = false;
            flagUpdate = false;
            notPossible();
            comboBox1.DataSource = tblDepartment.GetList();
            if (s == "no")
            {
                btnDel.Visible = false;
                button1.Visible = false;
                txtKod.Text = tblKindL.GetNextKey().ToString();
                flagAdd = true;
                txtSug.Text = "";
                Possible();
                txtKod.ReadOnly = true;
                btnKindL.Visible = false;
                btnUpdate.Visible = false;
            }
        }
        private void Possible()
        {
            panel1.Visible = false;
            panel2.Visible = true;
            comboBox1.Enabled = true;
            
        }
        private void notPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            panel2.Visible = false;
            panel1.Visible = true;
        }
        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEnter f = new FrmEnter("director","");
            f.Show();
            this.Hide();
        }

        private void FrmKindL_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblKindL.GetList().Where(x => x.KodD == ((Department)comboBox1.SelectedItem).KodD &&x.Status).Select(x => new { קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.ThisDepartment(). NameD,סטטוס=x.Status }).ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dg.DataSource = tblKindL.GetList().Where(x=>x.Status).Select(x => new { קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.ThisDepartment().NameD ,סטטוס=x.Status}).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtKod.Text = tblKindL.GetNextKey().ToString();
            flagAdd = true;
            txtSug.Text = "";
            Possible();
            txtKod.ReadOnly = true;
        }

        private void txtSug_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblKindL.GetList().Where(x => x.NameK.StartsWith(txtSug.Text) && x.Status).Select(x => new { קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.ThisDepartment().NameD,סטטוס=x.Status }).ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                txtKod.ReadOnly = true;
                string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                thisKindL = tblKindL.Find(Convert.ToInt32(st));
                Fill(thisKindL);
                flagUpdate = true;
                flagAdd = false;
                Possible();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var lst = tblDepartment.GetList();
            if (flagUpdate)
                if (CreateFields(thisKindL))
                {
                    DialogResult r = MessageBox.Show("האם לעדכן סוג זה?", "אישור עידכון", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        tblKindL.UpdateRow(thisKindL);
                        notPossible();
                        dg.DataSource = tblKindL.GetList().Where(x => x.Status).Select(x => new { קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.KodD, סטטוס = x.Status }).ToList();
                    }
                }
            if (flagAdd)
            {
                KindL k = new KindL();
                if (!tblKindL.GetList().Exists(x =>x.Status&& x.NameK ==txtSug.Text &&x.ThisDepartment().KodD.ToString()== comboBox1.SelectedItem.ToString()))
                {
                    if (CreateFields(k))
                    {
                        DialogResult r = MessageBox.Show("האם להוסיף סוג זה?", "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            tblKindL.AddNew(k);
                            notPossible();
                            dg.DataSource = tblKindL.GetList().Where(x => x.Status).Select(x => new { קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.KodD, סטטוס = x.Status }).ToList();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("קיים סוג זה במחלקה זו!");
                }
            }
        }
        private bool CreateFields(KindL k)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                k.KodK = Convert.ToInt32(txtKod.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtKod, ex.Message);
                ok = false;
            }
            try
            {
                if(comboBox1.SelectedItem!=null)
                k.KodD = ((Department)comboBox1.SelectedItem).KodD;
                else
                {
                    errorProvider1.SetError(comboBox1,"בחר מחלקה");
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
                k.NameK = txtSug.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtSug, ex.Message);
                ok = false;
            }
            k.Status = true;
            return ok;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtKod.ReadOnly = false;
            txtKod.Text = "";
            txtSug.Text = "";
            notPossible();
            errorProvider1.Clear();
        }

        private void btnKindL_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                thisKindL = tblKindL.Find(Convert.ToInt32(st));
                Fill(thisKindL);
            }
        }
        private void Fill(KindL kindL)
        {
            if (tblKindL.Size() > 0)
            {
                txtKod.Text = kindL.KodK.ToString();
                comboBox1.Text = kindL.ThisDepartment().NameD.ToString();
                txtSug.Text = kindL.NameK.ToString();
            }
            else
            {
                txtKod.Text = "";
                comboBox1.Text = "";
                txtSug.Text = "";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק סוג זה?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string st = dg.SelectedRows[0].Cells[0].Value.ToString();
                    tblKindL.DeleteStatus(Convert.ToInt32(st));
                    dg.DataSource = tblKindL.GetList().Where(x => x.Status).Select(x => new { קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.KodD, סטטוס = x.Status }).ToList();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblKindL.GetList().Where(x => x.KodD.ToString().StartsWith(comboBox1.SelectedItem.ToString())&&x.Status).Select(x => new { קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.ThisDepartment().NameD, סטטוס = x.Status }).ToList();
        }

        private void txtKod_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblKindL.GetList().Where(x =>x.KodK.ToString()==txtKod.Text && x.Status).Select(x => new { קוד_סוג_פריט = x.KodK, שם_סוג_פריט = x.NameK, קוד_מחלקה = x.ThisDepartment().NameD, סטטוס = x.Status }).ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
