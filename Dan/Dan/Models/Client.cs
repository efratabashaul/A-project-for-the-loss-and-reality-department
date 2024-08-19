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
    public class Client
    {
        public bool Status { get; set; }
        public DataRow Dr { get; set; }
        private string id;
        private string pel;
        private string lName;
        private string fName;
        private string tel;
        private string adress;
        private string pincode;
        public Client(DataRow dr)
        {
            this.Dr = dr;
            this.id = dr["id"].ToString();
            this.pel = dr["pel"].ToString();
            this.Status = Convert.ToBoolean(dr["Status"]);
            this.lName = dr["lName"].ToString();
            this.fName = dr["fName"].ToString();
            this.tel = dr["tel"].ToString();
            this.adress = dr["adress"].ToString();
            this.pincode = dr["pincode"].ToString();
        }
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (ValidateUtil.LegalId(value))
                    this.id = value;
                else
                    throw new Exception("מס' הזהות אינו תקין!");
            }

        }
        public string Pel
        {
            get
            {
                return this.pel;
            }
            set
            {
                if (ValidateUtil.IsCellPhone(value))
                    this.pel = value;
                else
                    throw new Exception("מספר הפלאפון אינו תקין!");
            }

        }
        public string LName
        {
            get
            {
                return this.lName;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.lName = value;
                else
                    throw new Exception("השם אינו תקין!");

            }

        }
        public string FName
        {
            get
            {
                return this.fName;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.fName = value;
                else
                    throw new Exception("השם אינו תקין!");

            }

        }
        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                if (ValidateUtil.IsTelPhone(value))
                    this.tel = value;
                else
                    throw new Exception("מספר הטלפון אינו תקין!");
            }

        }
        public string Adress
        {
            get
            {
                return this.adress;
            }
            set
            {
                if (ValidateUtil.Isalfa(value))
                    this.adress = value;
                else
                    throw new Exception("הכתובת אינה תקינה!");
            }
        }
        public string Pincode
        {
            get
            {
                return this.pincode;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("נא להקיש סיסמה!");
                else
                {
                    if (value.Length < 4)
                        throw new Exception("הסיסמה אינה תקינה!");
                    else
                         this.pincode = value;
                }
                
            }

        }
        public Client()
        {
        }
        public void PutInto()
        {
            Dr["id"] = this.id;
            Dr["pel"] = this.pel;
            Dr["Status"] = this.Status;
            Dr["lName"] = this.lName;
            Dr["fName"] = this.fName;
            Dr["tel"] = this.tel;
            Dr["adress"] = this.adress;
            Dr["pincode"] = this.pincode;
        }
        public override string ToString()
        {
            return id;
        }




    }
    
    
}
