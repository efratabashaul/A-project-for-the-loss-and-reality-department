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
        public class Line
        {
            public DataRow Dr { get; set; }

            private int kodL;
            private double price;
            private int dunation;
            public bool Status;
        public Line()
        {
        }
        public Line(DataRow dr)
        {
            this.Dr = dr;
            this.kodL = Convert.ToInt32(dr["kodL"]);
            this.dunation = Convert.ToInt32(dr["dunation"]);
            this.price = Convert.ToDouble(dr["price"]);
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
                if (string.IsNullOrEmpty( value.ToString()))
                    throw new Exception("נא להקיש קו!");
                    if (ValidateUtil.IsNum(value.ToString()))
                        this.kodL = value;
                    else
                        throw new Exception("הקוד אינו תקין!");
                    
            }
        }
        public int Dunation
        {
            get
            {
                return this.dunation;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("נא להקיש משך זמן!");
                
                    if (value < 1)
                    {
                        throw new Exception("משך הזמן אינו תקין!");
                    }
                    else
                    {
                        if (ValidateUtil.IsNum(value.ToString()))
                            this.dunation = value;
                        else
                            throw new Exception("משך הזמן אינו תקין!");
                    }
                 
            }
        }
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("נא להקיש מחיר!");
                if (ValidateUtil.IsNum(value.ToString()))
                        this.price = value;
            }
        }
        public void PutInto()
        {
            Dr["kodL"] = this.kodL;
            Dr["dunation"] = this.dunation;
            Dr["price"] = this.price;
            Dr["Status"] = this.Status;
        }
        public override string ToString()
        {
            return KodL.ToString();
        }
    }
}
