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
    public partial class FrmSide : Form
    {

        private Side thisSide;
        private SideDB tblSide;
        public FrmSide()
        {
            InitializeComponent();
            tblSide = new SideDB();
            dg.DataSource = tblSide.GetList().Where(x => x.Status).Select(x => new { קוד_צד = x.KodSi, צד = x.NameSi }).ToList();
            panel1.Visible = false;
        }
        private void Possible()
        {
            panel1.Visible = true;
            btnNew.Visible = false;
            txtS.ReadOnly = false;
        }
        private void notPossible()
        {
            btnNew.Visible = true;
            panel1.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Side s= new Side();
            if (tblSide.GetList().Exists(x => x.NameSi == this.txtS.Text))
            {
                MessageBox.Show("שגיאת הוספה", "צד זה כבר קיים", MessageBoxButtons.OK);
                txtS.Text = "";
            }
            else
                if (CreateFields(s))
            {
                DialogResult r = MessageBox.Show("האם להוסיף צד זה?" , "אישור הוספה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    tblSide.AddNew(s);
                    dg.DataSource = tblSide.GetList().Where(x=>x.Status).Select(x => new { קוד_צד = x.KodSi, צד = x.NameSi }).ToList();
                    notPossible();
                }
            }
        }
        private bool CreateFields(Side s)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                s.KodSi = Convert.ToInt32(txtKod.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtKod, ex.Message);
                ok = false;
            }
            try
            {
                s.NameSi = txtS.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtS, ex.Message);
                ok = false;
            }
            return ok;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtKod_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtKod.Text = tblSide.GetNextKey().ToString();
            txtS.Text = "";
            Possible();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            notPossible();
            txtKod.Text = "";
            txtS.Text = "";
            errorProvider1.Clear();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmSide_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק צד זה?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    int code =Convert.ToInt32(dg.SelectedRows[0].Cells[0].Value);
                    tblSide.DeleteStatus(code);
                    dg.DataSource = tblSide.GetList().Where(x => x.Status).Select(x => new { קוד_צד = x.KodSi, צד = x.NameSi }).ToList();
                }
            }
            else
            {
                MessageBox.Show("בחר לקוח למחיקה!");
            }
        }

        private void txtKod_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblSide.GetList().Where(x => x.Status&&x.KodSi.ToString()==txtKod.Text).Select(x => new { קוד_צד = x.KodSi, צד = x.NameSi }).ToList();
        }

        private void txtS_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblSide.GetList().Where(x => x.Status && x.NameSi==txtS.Text).Select(x => new { קוד_צד = x.KodSi, צד = x.NameSi }).ToList();
        }
    }
}







