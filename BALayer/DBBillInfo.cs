using BDLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer
{
    public class DBBillInfo
    {
        DAL db = null;

        public DBBillInfo()
        {
            db = new DAL();
        }
        public DataSet LayBillInfo(int id)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM CHITIETHOADON WHERE IDHoaDon = " + id, CommandType.Text, null);
        }
        public bool thembliiInfo(ref string err, int idBill, int idFood, int count)
        {
            return db.MyExecuteNonQuery("SpThemChiTietHoaDon",
              CommandType.StoredProcedure, ref err,
              new SqlParameter("@idBill ", idBill),
              new SqlParameter("@idFood", idFood),
               new SqlParameter("@count", count)
              );
        }
    }
}
