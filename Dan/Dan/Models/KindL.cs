using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using Dan.Data;
using Dan.DB;
using Dan.Properties;
using Dan.Utilities;
using Dan.Gui;
namespace Dan.Models
{
    public class KindL
    {
        public bool Status { get; set; }
        public DataRow Dr { get; set; }
        private int kodK;
        private string nameK;
        private int kodD;
        public KindL()
        {
        }
        public KindL(DataRow dr)
        {
            this.Dr = dr;
            this.kodK = Convert.ToInt32(dr["kodK"]);
            this.kodD = Convert.ToInt32(dr["kodD"]);
            this.nameK = dr["nameK"].ToString();
            this.Status = Convert.ToBoolean(dr["Status"]);
        }
        public string NameK
        {
            get
            {
                return this.nameK;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("נא לבחור סוג אבידה!");
                }
                else
                    this.nameK = value;
            }

        }
        public int KodK
        {
            get
            {
                return this.kodK;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.kodK = value;
                else
                    throw new Exception("הקוד אינו תקין!");
            }
        }
        public int KodD
        {
            get
            {
                return this.kodD;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.kodD = value;
                else
                    throw new Exception("הקוד אינו תקין!");
            }
        }
        public void PutInto()
        {
            Dr["kodK"] = this.kodK;
            Dr["kodD"] = this.kodD;
            Dr["nameK"] = this.nameK;
            Dr["Status"] = this.Status;
        }
        public Department ThisDepartment()
        {
              DepartmentDB tblD = new DepartmentDB();
              return tblD.Find(this.kodD);
        }
        public override string ToString()
        {
            return NameK.ToString();
        }
    }
}
