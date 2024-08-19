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
    public class LineD
    {
        public DataRow Dr { get; set; }
        private int kodL;
        private int kodSi;
        private string origin;
        private string destination;
        public bool Status { get; set; }

        public LineD()
        {
        }
        public LineD(DataRow dr)
        {
            this.Dr = dr;
            this.kodL = Convert.ToInt32(dr["kodL"]);
            this.kodSi = Convert.ToInt32(dr["kodSi"]);
            this.origin = dr["origin"].ToString();
            this.destination = dr["destination"].ToString();
            this.Status = Convert.ToBoolean(dr["Status"]);
        }
        public int KodL
        {
            get
            {
                return this.kodL;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.kodL = value;
                else
                    throw new Exception("הקוד אינו תקין!");
            }
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
        public string Origin
        {
            get
            {
                return this.origin;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("נא להקיש מוצא!");
                if (ValidateUtil.IsHebrew(value))
                    this.origin = value;
                else
                    throw new Exception("המוצא אינו תקין!");
            }
        }
        public string Destination
        {
            get
            {
                return this.destination;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("נא להקיש יעד!");
                if (ValidateUtil.IsHebrew(value))
                    this.destination = value;
                else
                    throw new Exception("היעד אינו תקין!");
            }
        }
        public void PutInto()
        {
            Dr["kodL"] = this.kodL;
            Dr["kodSi"] = this.kodSi;
            Dr["origin"] = this.origin;
            Dr["destination"] = this.destination;
            Dr["Status"] = this.Status;
        }
        public override string ToString()
        {
            return origin+"-"+destination.ToString();
        }
        public Line ThisLine()
        {
            LineDB tblL = new LineDB();
            return tblL.Find(this.kodL);
        }
        public Side ThisSide()
        {
            SideDB tblS = new SideDB();
            return tblS.Find(this.kodSi);
        }
    }
}
