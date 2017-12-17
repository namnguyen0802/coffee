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
    public class DBBill
    {
        DAL db = null;

        public DBBill()
        {
            db = new DAL();
        }
        public DataSet LayBill(int id)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM HOADON WHERE IDBan = " + id + " AND TrangThai = 'Chua Thanh Toan'", CommandType.Text, null);
        }

        public bool InsertBill(ref string err, int id,int idNhanVien,DateTime NgayLapHoaDon)
        {
           return db.MyExecuteNonQuery("SpThemHoaDon",
              CommandType.StoredProcedure, ref err,
              new SqlParameter("@IDBan ", id),
              new SqlParameter("@IDNhanVien", idNhanVien),
              new SqlParameter("@NgayLapHoaDon", NgayLapHoaDon.Date)
              );
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)db.ExecuteScalar("SELECT MAX(IDHoaDon) FROM HOADON");
            }
            catch
            {
                return 1;
            }
        }
        public bool updateBill(ref string err, int id/*, float totalPrice*/)
        {
            return db.MyExecuteNonQuery("SpCapNhatHoaDon",
              CommandType.StoredProcedure, ref err,
              new SqlParameter("@ID", id)            
              );
        }
        public DataSet ThongKeDU(String date)
        {
            //db = new DAL();
            return db.ExecuteQueryDataSet("select Ten,SoLuong from dbo.Top5DoUong('" + date + "')"
                , CommandType.Text, null);
        }


    }
}
