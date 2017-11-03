using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee.DTO
{
    public class Table
    {
        public Table(int id, string name, string status,string khuvuc)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.KhuVuc = khuVuc;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["IDBan"];
            this.Name = row["Ten"].ToString();
            this.KhuVuc = row["KhuVuc"].ToString();
            this.Status = row["status"].ToString();
        }           
        private string khuVuc;
        public string KhuVuc
        {
            get { return khuVuc; }
            set { khuVuc = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}

