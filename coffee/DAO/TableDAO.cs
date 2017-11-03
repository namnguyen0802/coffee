using BALayer;
using coffee.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee.DAO
{
    public class TableDAO
    {
        DBTable dbTable = new DBTable();

        public static int TableWidth = 100;
        public static int TableHeight = 100;
        public List<Table> LoadTableList()
        { 
            
            List<Table> tableList = new List<Table>();

            DataTable data = dbTable.LayNhanVien().Tables[0];

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
    }
}
