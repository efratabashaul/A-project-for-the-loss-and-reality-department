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
    public class SideDB:GeneralDB
    {
        protected List<Side> list = new List<Side>();
        public SideDB() : base("Side")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Side(dr));
            }
        }
        public List<Side> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Side Find(int code)
        {
            return this.GetList().Find(x => x.KodSi == code);
        }
        public Side Find(string name)
        {
            return this.GetList().Where(x => x.NameSi == name).FirstOrDefault();
        }
        public void DeleteRow(int code)
        {
            Side side = this.Find(code);
            if (side != null)
            {
                side.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(int code)
        {
            Side s = this.Find(code);
            if (s != null)
            {
                s.Status = false;
                this.UpdateRow(s);
            }
        }
        public void UpdateRow(Side s)
        {
            s.PutInto();
            this.Update();
        }
        public void AddNew(Side s)
        {
            s.Dr = table.NewRow();
            s.PutInto();
            this.Add(s.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodSi) + 1;
        }
    }
}
