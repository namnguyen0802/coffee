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
    public class DBNguyenLieu
    {
        DAL db = null;

        public DBNguyenLieu()
        {
            db = new DAL();
        }
        public DataSet LayNguyenLieu()
        {
            return db.ExecuteQueryDataSet("spLayInfoNguyenLieu", CommandType.Text, null);
        }
        public DataSet LayThongTinNguyenLieu()
        {
            return db.ExecuteQueryDataSet("spLayNguyenLieu", CommandType.Text, null);
        }
        public bool ThemNguyenLieu(ref string err,
         string Ten, float SoLuong,string DonVi,float Gia )
        {
            return db.MyExecuteNonQuery("SpThemNguyenLieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Ten ", Ten),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonVi", DonVi),
                new SqlParameter("@Gia ", Gia));         
        }
        public bool CapNhatNguyenLieu(ref string err,
         int IDNguyenLieu,string Ten, float SoLuong, string DonVi, float Gia)
        {
            return db.MyExecuteNonQuery("SpCapNhatNguyenLieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@IDNguyenLieu", IDNguyenLieu),
                new SqlParameter("@Ten", Ten),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonVi", DonVi),
                new SqlParameter("@Gia", Gia));
        }
        public bool XoaNguyenLieu(ref string err,int IDNguyenLieu)
        {
            return db.MyExecuteNonQuery("spXoaNguyenLieu",
                CommandType.StoredProcedure, ref err, new SqlParameter("@IDNguyenLieu", IDNguyenLieu));
        }
    }
}
