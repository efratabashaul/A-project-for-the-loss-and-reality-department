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
    public class DepartmentDB:GeneralDB
    {
        protected List<Department> list = new List<Department>();
        public DepartmentDB() : base("Department")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Department(dr));
            }
        }
        public List<Department> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Department Find(int code)
        {
            return this.GetList().Find(x => x.KodD == code);
        }
        public void DeleteRow(int code)
        {
            Department department = this.Find(code);
            if (department != null)
            {
                department.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(int code)
        {
           Department department = this.Find(code);
            if (department != null)
            {
                department.Status = false;
                this.UpdateRow(department);
            }
        }
        public void UpdateRow(Department d)
        {
            d.PutInto();
            this.Update();
        }
        public void AddNew(Department d)
        {
            d.Dr = table.NewRow();
            d.PutInto();
            this.Add(d.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
           return this.GetList().Max(x => x.KodD) + 1;
        }
    }
}
