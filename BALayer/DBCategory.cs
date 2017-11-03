using BDLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer
{
    public class DBCategory
    {
        DAL db = null;

        public DBCategory()
        {
            db = new DAL();
        }
        public DataSet LayCategory()
        {
            return db.ExecuteQueryDataSet("select * from DANHMUCDOUONG", CommandType.Text, null);
        }
    }
}
