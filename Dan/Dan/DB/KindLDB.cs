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
    public class KindLDB:GeneralDB
    {
        protected List<KindL> list = new List<KindL>();
        public KindLDB() : base("KindL")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new KindL(dr));
            }
        }
        public List<KindL> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public KindL Find(int code)
        {
            return this.GetList().Find(x => x.KodK == code);
        }
        public void DeleteRow(int code)
        {
            KindL kindL = this.Find(code);
            if (kindL != null)
            {
                kindL.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(int code)
        {
            KindL kindL = this.Find(code);
            if (kindL != null)
            {
               kindL.Status = false;
                this.UpdateRow(kindL);
            }
        }
        public void UpdateRow(KindL k)
        {
            k.PutInto();
            this.Update();
        }
        public void AddNew(KindL k)
        {
            k.Dr = table.NewRow();
            k.PutInto();
            this.Add(k.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodK) + 1;
        }
    }
}
