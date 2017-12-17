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
    public class DBChiTietDonHang
    {
        DAL db = null;

        public DBChiTietDonHang()
        {
            db = new DAL();
        }
        public bool ThemChiTietDonHang(ref string err, int IDPhieuNhap,int IDNguyenLieu )
        {
            return db.MyExecuteNonQuery("SpThemChiTietNhapHang",
               CommandType.StoredProcedure, ref err,
               new SqlParameter("@IDPhieuNhap ", IDPhieuNhap),
               new SqlParameter("@IDNguyenLieu", IDNguyenLieu)
               );
        }

    }
}
