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
    public partial class FrmDepartment : Form
    {
        private Department thisDepartment;
        private DepartmentDB tblDepartment;
        public FrmDepartment(string s)
        {
            InitializeComponent();
            tblDepartment = new DepartmentDB();
            dg.DataSource = tblDepartment.GetList().Where(x=>x.Status==true).Select(x => new { קוד= x.KodD, שם_מחלקה = x.NameD,פעיל=x.Status}).ToList();
            panel1.Visible = false;
            if (s == "no")
            {
                button2.Visible = false;
                button1.Visible = false;
                txtKod.Text = tblDepartment.GetNextKey().ToString();
                txtD.Text = "";
                Possible();
            }
        }
        private void Possible()
        {
            panel1.Visible = true;
            btnNew.Visible = false;
            txtD.ReadOnly = false;
        }
        private void notPossible()
        {
            btnNew.Visible = true;
            panel1.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Department d = new Department();
            if (tblDepartment.GetList().Exists(x => x.NameD == this.txtD.Text))
            {
                MessageBox.Show("שגיאת הוספה", "שם זה כבר קיים", MessageBoxButtons.OK);
                txtD.Text = "";
            }
            else
                if (CreateFields(d))
            {
                DialogResult r = MessageBox.Show("האם להוסיף שם זה?", "אישור הוספה" , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    tblDepartment.AddNew(d);
                    dg.DataSource = tblDepartment.GetList().Where(x => x.Status).Select(x => new { קוד = x.KodD, שם_מחלקה = x.NameD }).ToList();
                    notPossible();
                }
            }
        }
        private bool CreateFields(Department d)
        {
            bool ok = true;
            errorProvider1.Clear();
            d.KodD = Convert.ToInt32(txtKod.Text);
            try
            {
                d.NameD = txtD.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtD, ex.Message);
                ok = false;
            }
            d.Status = true;
            return ok;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtKod_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmEnter f = new FrmEnter("director","");
            f.Show();
            this.Hide();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtKod.Text = tblDepartment.GetNextKey().ToString();
            txtD.Text = "";
            Possible();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            notPossible();
            errorProvider1.Clear();
            txtD.Text = "";
            txtKod.Text = "";
            dg.DataSource = tblDepartment.GetList().Where(x => x.Status).Select(x => new { קוד = x.KodD, שם_מחלקה = x.NameD }).ToList();
        }

        private void FrmDepartment_Load(object sender, EventArgs e)
        {

        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtKod_TextChanged_1(object sender, EventArgs e)
        {
            dg.DataSource = tblDepartment.GetList().Where(x => x.Status&&x.KodD.ToString()==txtKod.Text).Select(x => new { קוד = x.KodD, שם_מחלקה = x.NameD }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dg.SelectedRows.Count > 0)
            {
                DialogResult r = MessageBox.Show("האם למחוק מחלקה זו?", "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    int kod =Convert.ToInt32( dg.SelectedRows[0].Cells[0].Value);
                    tblDepartment.DeleteStatus(kod);
                    MessageBox.Show(" המחלקה נמחקה!");
                }
            }
            else
            {
                MessageBox.Show("בחר מחלקה למחיקה!");
            }
            dg.DataSource = tblDepartment.GetList().Where(x=>x.Status).Select(x => new { קוד = x.KodD, שם_מחלקה = x.NameD }).ToList();
        }

        private void txtD_TextChanged(object sender, EventArgs e)
        {
            dg.DataSource = tblDepartment.GetList().Where(x => x.Status&&x.NameD==txtD.Text).Select(x => new { קוד = x.KodD, שם_מחלקה = x.NameD }).ToList();
        }
    }

    }

