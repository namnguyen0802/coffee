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
    public class DBNhapHang
    {
        DAL db = null;

        public DBNhapHang()
        {
            db = new DAL();
        }
        public DataSet LayThongTinNhapHang()
        {
            return db.ExecuteQueryDataSet("select * from NHAPHANG", CommandType.Text, null);
        }
        public DataSet LayThongTinChiTietNhapHang()
        {
            return db.ExecuteQueryDataSet("select * from CHIETIETDONHANG", CommandType.Text, null);
        }
        public bool ThemNhapHang(ref string err,
            DateTime NgayNhap, int IDNhanVien)
        {
            return db.MyExecuteNonQuery("SpThemNhapHang",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@NgayNhap", NgayNhap),
                new SqlParameter("@ID_NhanVien", IDNhanVien));
        }
        public bool XoaNhanVien(ref string err, int IDPhieuNhap)
        {
            return db.MyExecuteNonQuery("spXoaNhapHang",
                CommandType.StoredProcedure, ref err, new SqlParameter("@IDPhieuNhap", IDPhieuNhap));
        }
        public bool CapNhatNhapHang(ref string err,
            int IDPhieuNhap, DateTime NgayNhap, int IDNhanVien)
        {
            return db.MyExecuteNonQuery("SpCapNhatNhanVien",
                CommandType.StoredProcedure, ref err,
                 new SqlParameter("@IDPhieuNhap ", IDPhieuNhap),
                new SqlParameter("@NgayNhap", NgayNhap),
                new SqlParameter("@IDNhanVien", IDNhanVien));
        }
        public DataSet ThongTinNhapHang()
        {
            return db.ExecuteQueryDataSet("select * from fNhapHang()", CommandType.Text, null);
        }
        public int GetMaxIDNhapHang()
        {
            try
            {
                return (int)db.ExecuteScalar("select max(IDPhieuNhap) from NHAPHANG");
            }
            catch
            {
                return 1;
            }
        }
    }
}

