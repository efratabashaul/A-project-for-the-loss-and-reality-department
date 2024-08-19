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



namespace Dan.DB
{
    public abstract class GeneralDB
    {
        protected DataTable table;
        public GeneralDB(string tableName)
        {
           Dal.GetInstance().AddTable(tableName);
           table = Dal.GetInstance().GetTable(tableName);

        }
        public int Size()
        {
            return table.Rows.Count;
        }
        public bool IsEmpty()
        {
            return table.Rows.Count == 0;
        }
        public virtual void Save()
        {
            Dal.GetInstance().Update(table.TableName);
        }
        public void Add(DataRow dr)
        {
            table.Rows.Add(dr);
            this.Save();
        }
        public DataTable GetTable()
        {
            return this.table;
        }
        public void Update()
        {
            Dal.GetInstance().Update(table.TableName);
        }
    }
}
