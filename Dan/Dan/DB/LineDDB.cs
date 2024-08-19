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
    public class LineDDB:GeneralDB
    {
        protected List<LineD> list = new List<LineD>();
        public LineDDB() : base("LineD")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new LineD(dr));
            }
        }
        public List<LineD> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public LineD Find(int kodl,int kodside)
        {
            return this.GetList().Find(x => x.KodL == kodl&&x.KodSi==kodside);
        }
        public LineD Find(int kodl, string nameSi)
        {
            Side ss=new Side();
            SideDB s=new SideDB();
            ss=s.Find(nameSi);
            return this.GetList().Find(x => x.KodL == kodl && x.KodSi == ss.KodSi);
        }
        public void DeleteRow(int kodl, int kodside)
        {
            LineD lineD = this.Find(kodl,kodside);
            if (lineD != null)
            {
                lineD.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(int kodl, int kodside)
        {
            LineD lineD = this.Find(kodl,kodside);
            if (lineD != null)
            {
                lineD.Status = false;
                this.UpdateRow(lineD);
            }
        }
        public void UpdateRow(LineD l)
        {
            l.PutInto();
            this.Update();
        }
        public void AddNew(LineD l)
        {
            l.Dr = table.NewRow();
            l.PutInto();
            this.Add(l.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodL)+1;
        }
    }
}
