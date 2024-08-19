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
    public class LostDB:GeneralDB
    {
            protected List<Lost> list = new List<Lost>();
            public LostDB() : base("Lost")
            {
            }
            private void DataTableToList()
            {
                foreach (DataRow dr in table.Rows)
                {
                    list.Add(new Lost(dr));
                }
            }
            public List<Lost> GetList()
            {
                list.Clear();
                DataTableToList();
                return list;
            }
            public Lost Find(int code)
            {
                return this.GetList().Find(x => x.KodL == code);
            }
            public void DeleteRow(int code,DateTime d,DateTime h)
            {
                Lost lost = this.Find(code);
                if (lost != null)
                {
                    lost.Dr.Delete();
                    this.Update();
                }
            }
        public void DeleteStatus(int code)
        {
            Lost lost = this.Find(code);
            if (lost != null)
            {
                lost.Status = false;
                this.UpdateRow(lost);
            }
        }
        public void UpdateRow(Lost l)
            {
                l.PutInto();
                this.Update();
            }
            public void AddNew(Lost l)
            {
                l.Dr = table.NewRow();
                l.PutInto();
                this.Add(l.Dr);
            }
            public int GetNextKey()
            {
                if (this.Size() == 0)
                    return 1;
                return this.GetList().Max(x => x.KodL) + 1;
            }
        }
}
