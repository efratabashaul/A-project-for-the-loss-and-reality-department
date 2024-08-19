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
    public class LineDB:GeneralDB
    {

        protected List<Line> list = new List<Line>();
        public LineDB() : base("Line")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Line(dr));
            }
        }
        public List<Line> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Line Find(int code)
        {
            return this.GetList().Find(x => x.KodL == code);
        }
        public void DeleteRow(int code)
        {
            Line line = this.Find(code);
            if (line != null)
            {
                line.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(int code)
        {
            Line line = this.Find(code);
            if (line != null)
            {
                line.Status = false;
                this.UpdateRow(line);
            }
        }
        public void UpdateRow(Line l)
        {
            l.PutInto();
            this.Update();
        }
        public void AddNew(Line l)
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
