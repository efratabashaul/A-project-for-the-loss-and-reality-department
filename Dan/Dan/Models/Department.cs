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
    public class Department
    {
        public DataRow Dr { get; set; }
        private int kodD;
        private string nameD;
        public bool Status { get; set; }
        public Department()
        {
        }
        public Department(DataRow dr)
        {
            this.Dr = dr;
            this.kodD = Convert.ToInt32(dr["kodD"]);
            this.nameD = dr["nameD"].ToString();
            this.Status = Convert.ToBoolean(dr["Status"]);
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
        public string NameD
        {
            get
            {
                return this.nameD;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("נא להקיש שם מחלקה!");
                if (ValidateUtil.IsHebrew(value))
                    this.nameD = value;
                else
                    throw new Exception("שם המחלקה אינו תקין!");
            }
        }
        public void PutInto()
        {
            Dr["kodD"] = this.kodD;
            Dr["nameD"] = this.nameD;
            Dr["Status"] = this.Status;
        }
        public override string ToString()
        {
            return nameD.ToString();
        }
    }
}
