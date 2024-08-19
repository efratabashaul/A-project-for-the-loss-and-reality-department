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
    public class Bus
    {
        public bool Status { get; set; }
        public DataRow Dr { get; set; }
        private int kodB;
        private string nameB;
        private int numS;
        public Bus(DataRow dr)
        {
            this.Dr = dr;
            this.kodB =Convert.ToInt32( dr["kodB"]);
            this.nameB = dr["nameB"].ToString();
            if (dr["Status"].Equals(true))
                this.Status = true;
            else
                this.Status = false;
            this.numS = Convert.ToInt32(dr["numS"]);
        }
        public Bus()
        {

        }
        public string NameB
        {
            get
            {
                return this.nameB;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.nameB = value;
                else
                    throw new Exception("השם אינו תקין!");

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
        public int NumS
        {
            get
            {
                return this.numS;
            }
            set
            {
                if (value < 1)
                    throw new Exception("המספר אינו תקין!");
                else
                {
                    if (ValidateUtil.IsNum(value.ToString()))
                        this.numS = value;
                    else
                        throw new Exception("המספר אינו תקין!");
                }
            }
        }
        public void PutInto()
        {
            Dr["kodB"] = this.kodB;
            Dr["numS"] = this.numS;
            Dr["nameB"] = this.nameB;
            Dr["Status"] = this.Status;

        }
        public override string ToString()
        {
            return KodB.ToString();
        }
    }
}
