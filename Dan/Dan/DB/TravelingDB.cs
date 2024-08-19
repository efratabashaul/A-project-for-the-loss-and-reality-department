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
    public class TravelingDB:GeneralDB
    {

        protected List<Traveling> list = new List<Traveling>();
        public TravelingDB() : base("Traveling")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Traveling(dr));
            }
        }
        public List<Traveling> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Traveling Find(int code,DateTime d,DateTime h)
        {
            return this.GetList().Find(x => x.KodB ==code&&x.DateT==d&&x.HourT==h);
        }
        public void DeleteRow(int code,DateTime d,DateTime h)
        {
            Traveling traveling = this.Find(code,d,h);
            if (traveling != null)
            {
                traveling.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(int code,DateTime d,DateTime h)
        {
            Traveling t = this.Find(code,d,h);
            if (t != null)
            {
                t.status = false;
                this.UpdateRow(t);
            }
        }
        public void UpdateRow(Traveling t)
        {
            t.PutInto();
            this.Update();
        }
        public void AddNew(Traveling t)
        {
            t.Dr = table.NewRow();
            t.PutInto();
            this.Add(t.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodB) + 1;
        }
    }
}
