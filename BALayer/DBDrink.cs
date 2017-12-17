using BDLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer
{
    public class DBDrink
    {
        DAL db = null;

        public DBDrink()
        {
            db = new DAL();
        }
        public DataSet LayDrink(int id)
        {
            return db.ExecuteQueryDataSet("select * from DOUONG where IDDanhMuc = " + id, CommandType.Text, null);
        }
    }
}

