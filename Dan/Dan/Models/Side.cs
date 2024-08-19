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
    public class Side
    {
        public bool Status { get; set; }
        public DataRow Dr { get; set; }
        private int kodSi;
        private string nameSi;
        
        public Side()
        {
        }
        public Side(DataRow dr)
        {
            this.Dr = dr;
            this.kodSi = Convert.ToInt32(dr["kodSi"]);
            this.nameSi = dr["nameSi"].ToString();
            this.Status = Convert.ToBoolean(dr["Status"]);
        }
        public int KodSi
        {
            get
            {
                return this.kodSi;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.kodSi = value;
                else
                    throw new Exception("הקוד אינו תקין!");
            }
        }
        public string NameSi
        {
            get
            {
                return this.nameSi;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("נא להקיש שם צד!");
                if (ValidateUtil.IsHebrew(value))
                    this.nameSi = value;
                else
                    throw new Exception("שם הצד אינו תקין!");
            }
        }
        public void PutInto()
        {
            Dr["kodSi"] = this.kodSi;
            Dr["nameSi"] = this.nameSi;
            Dr["Status"] = this.Status;
        }
        public override string ToString()
        {
            return nameSi.ToString();
        }


    }
}
