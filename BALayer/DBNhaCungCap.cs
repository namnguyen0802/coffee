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
    public class DBNhaCungCap
    {
        DAL db = null;

        public DBNhaCungCap()
        {
            db = new DAL();
        }
        public DataSet LayNhaCugnCap()
        {
            return db.ExecuteQueryDataSet("spLayInfoNhaCungCap", CommandType.Text, null);
        }

        public bool ThemNhaCungCap(ref string err,
         string Ten, string DiaChi, int IDNguyenLieu)
        {
            return db.MyExecuteNonQuery("SpThemNhaCungCap",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Ten ", Ten),
                 new SqlParameter("@DiaChi", DiaChi),
                 new SqlParameter("@IDNguyenLieu", IDNguyenLieu)
               
               );
        }
        public bool CapNhatNhaCungCap(ref string err,int IDNhaCungCap,
        string TenNCC, int IDNguyenLieu, string DiaChi)
        {
            return db.MyExecuteNonQuery("SpCapNhatNCC",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@IDNhaCungCap", IDNhaCungCap),
                new SqlParameter("@TenNCC", TenNCC),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@IDNguyenLieu", IDNguyenLieu));
             
        }
        public bool XoaNhaCungCap(ref string err, int IDNhaCungCap)
        {
            return db.MyExecuteNonQuery("spXoaNhaCungCap",
                CommandType.StoredProcedure, ref err, new SqlParameter("@IDNhaCungCap", IDNhaCungCap));
        }
    }
}
