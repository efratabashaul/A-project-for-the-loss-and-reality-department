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
    public class Traveling
    {
        public DataRow Dr { get; set; }
        public bool status { get; set; }
        private int kodB;
        private DateTime dateT;
        private DateTime hourT;
        private string idD;
        private int kodL;
        private int kodSi;
        private BusDB tblBus;
        public Traveling()
        {
            tblBus = new BusDB();
        }
        public Traveling(DataRow dr)
        {
            this.Dr = dr;
            this.kodB = Convert.ToInt32(dr["kodB"]);
            this.kodL = Convert.ToInt32(dr["kodL"]);
            this.kodSi = Convert.ToInt32(dr["kodSi"]);
            this.dateT = Convert.ToDateTime(dr["dateT"]);
            this.hourT = Convert.ToDateTime(dr["hourT"]);
            this.idD = dr["idD"].ToString();
            this.status = Convert.ToBoolean(dr["status"]);
        }
        public int KodB
        {
            get
            {
                return this.kodB;
            }
            set
            {
                if (string. IsNullOrEmpty(value.ToString()))
                    throw new Exception("נא להקיש קוד אוטובוס!");
                if (ValidateUtil.IsNum(value.ToString()))
                        this.kodB = value;  
                else
                    throw new Exception("הקוד אינו תקין!");
            }
        }
        public int KodL
        {
            get
            {
                return this.kodL;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("נא להקיש קו!");
                if (ValidateUtil.IsNum(value.ToString()))
                    this.kodL = value;
                else
                    throw new Exception("הקו אינו תקין!");
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
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("נא להקיש מוצא ויעד!");
                if (ValidateUtil.IsNum(value.ToString()))
                    this.kodSi = value;
                else
                    throw new Exception("מוצא והיעד אינם תקינים!");
            }
        }
        public DateTime DateT
        {
            get
            {
                return this.dateT;
            }
            set
            {
                this.dateT = value;
            }
        }
        public DateTime HourT
        {
            get
            {
                return this.hourT;
            }
            set
            {
                this.hourT = value;
            }
        }
        public string IdD
        {
            get
            {
                return this.idD;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("נא להקיש ת.ז!");
                if (ValidateUtil.LegalId(value))
                    this.idD= value;
                else
                    throw new Exception("הת.ז. אינה תקינה!");
            }
        }
        public void PutInto()
        {
            Dr["kodB"] = this.kodB;
            Dr["kodL"] = this.kodL;
            Dr["kodSi"] = this.kodSi;
            Dr["idD"] = this.idD;
            Dr["dateT"] = this.dateT.ToLongDateString();
            Dr["hourT"] = this.hourT.ToLongTimeString();
            Dr["Status"] = this.status;
        }
        public override string ToString()
        {
            return KodB.ToString();
        }
        public LineD ThisLineD()
        {
            LineDDB tblLD = new LineDDB();
            return tblLD.Find(this.kodL,this.kodSi);
        }
        public Driver ThisDriver()
        {
            DriverDB tblD = new DriverDB();
            return tblD.Find(this.IdD);
        }
        public Bus ThisBus()
        {
            BusDB tblB = new BusDB();
            return tblB.Find(this.kodB);
        }
    }
}
