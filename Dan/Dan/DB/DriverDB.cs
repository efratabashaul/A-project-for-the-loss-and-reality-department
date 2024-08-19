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
using Dan.Models;


namespace Dan.DB
{
    public class DriverDB:GeneralDB
    {
        protected List<Driver> list = new List<Driver>();
        public DriverDB() : base("Driver")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Driver(dr));
            }
        }
        public List<Driver> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Driver Find(string code)
        {
            return this.GetList().Find(x => x.IdD == code);
        }
        public void DeleteRow(string code)
        {
            Driver driver = this.Find(code);
            if (driver != null)
            {
                driver.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(string code)
       {
            Driver driver = this.Find(code);
            if (driver != null)
           {
                driver.Status = false;
                this.UpdateRow(driver);
            }
        }
        public void UpdateRow(Driver d)
        {
            d.PutInto();
            this.Update();
        }
        public void AddNew(Driver d)
        {
            d.Dr = table.NewRow();
            d.PutInto();
            this.Add(d.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return Convert.ToInt32( this.GetList().Max(x => x.IdD) + 1);
        }
    }
}
