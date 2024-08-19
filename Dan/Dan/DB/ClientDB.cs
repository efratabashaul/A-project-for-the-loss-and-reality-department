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
    public class ClientDB:GeneralDB
    {
        protected List<Client> list = new List<Client>();
        public ClientDB() : base("Client")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Client(dr));
            }
        }
        public List<Client> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Client Find(string code)
        {
            return this.GetList().Find(x => x.Id == code);
        }
        public void DeleteRow(string code)
        {
            Client client = this.Find(code);
            if (client != null)
            {
                client.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(string code)
        {
            Client client = this.Find(code);
            if (client != null)
            {
                client.Status = false;
                this.UpdateRow(client);
            }
        }
        public void UpdateRow(Client c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Client c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        //public int GetNextKey()
        //{
        //    if (this.Size() == 0)
        //        return 1;
        //    return this.GetList().Max(x => x.Id) + 1;
        //}
    }
}
