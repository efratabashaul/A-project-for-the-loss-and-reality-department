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
    public class Lost
    {
        public DataRow Dr { get; set; }
        public bool Status { get; set; }
        private int kodL;
        private int kodK;
        private int kodB;
        private string picture;
        public DateTime dateT;
        public DateTime hourT;
        public bool moveD { get; set;}
        public bool banked { get; set;}
        private string id;
        private string information;
        public Lost()
        {
        }
        public Lost(DataRow dr)
        {
            this.Dr = dr;
            this.kodL = Convert.ToInt32(dr["kodL"]);
            this.kodK= Convert.ToInt32(dr["kodK"]);
            this.kodB = Convert.ToInt32(dr["kodB"]);
            this.dateT = Convert.ToDateTime(dr["dateT"]);
            this.hourT = Convert.ToDateTime(dr["hourT"]);
            this.id = dr["id"].ToString();
            this.information= dr["information"].ToString();
            this.picture = dr["picture"].ToString()
;            if (dr["moveD"].Equals(true))
                this.moveD = true;
            else
                this.moveD = false;
            if (dr["banked"].Equals(true))
                this.banked = true;
            else
                this.banked = false;
            if (dr["status"].Equals(true))
                this.Status = true;
            else
                this.Status = false;
        }
        public int KodL
        {
            get
            {
                return this.kodL ;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.kodL = value;
                else
                    throw new Exception("הקוד אינו תקין!");
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
        public int KodB
        {
            get
            {
                return this.kodB;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.kodB = value;
                else
                    throw new Exception("הקוד אינו תקין!");
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
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("נא להקיש ת.ז!");
                if (ValidateUtil.LegalId(value))
                    this.id = value;
                else
                    throw new Exception("הת.ז. אינו תקין!");
            }
        }
        public string Information
        {
            get
            {
                return this.information;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("נא להקיש מידע!");
                }
                else
                {
                    this.information = value;
                }
            }
        }
        public string Picture
        {
            get
            {
                return this.picture;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.picture = "";

                }
                this.picture = value;
            }
        }
        public void PutInto()
        {
            Dr["kodL"] = this.kodL;
            Dr["kodK"] = this.kodK;
            Dr["kodB"] = this.kodB;
            Dr["id"] = this.id;
            Dr["information"] = this.information;
            Dr["dateT"] = this.dateT;
            Dr["hourT"] = this.hourT;
            Dr["moveD"] = this.moveD;
            Dr["banked"] = this.banked;
            Dr["status"] = this.Status;
            Dr["picture"] = this.picture;
        }
        public override string ToString()
        {
            return KodL.ToString();
        }
        public KindL ThisKindL()
        {
            KindLDB tblK = new KindLDB();
            return tblK.Find(this.kodK);
        }
        public Traveling ThisTraveling()
        {
            TravelingDB tblT = new TravelingDB();
            return tblT.Find(this.kodB,this.dateT,this.hourT);
        }
        public Client ThisClient()
        {
            ClientDB tblC = new ClientDB();
            return tblC.Find(this.Id);
        }
    }
}
