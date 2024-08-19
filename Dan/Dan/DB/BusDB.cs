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
    public class BusDB : GeneralDB
    {

        protected List<Bus> list = new List<Bus>();
        public BusDB() : base("Bus")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Bus(dr));
            }
        }
        public List<Bus> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Bus Find(int code)
        {
            return this.GetList().Find(x => x.KodB == code);
        }
        public void DeleteRow(int code)
        {
            Bus bus = this.Find(code);
            if (bus != null)
            {
                bus.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(int code)
        {
            Bus bus = this.Find(code);
            if (bus != null)
            {
                bus.Status = false;
                this.UpdateRow(bus);
            }
        }
        public void UpdateRow(Bus b)
        {
            b.PutInto();
            this.Update();
        }
        public void AddNew(Bus b)
        {
            b.Dr = table.NewRow();
            b.PutInto();
            this.Add(b.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodB) + 1;
        }
    }
}
