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
    public class DBTable
    {
        DAL db = null;

        public DBTable()
        {
            db = new DAL();
        }
        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet("select * from BAN", CommandType.Text, null);
        }
        public void CapNhatSauThanhToan (int id)
        {
             db.ExecuteQueryDataSet("EXEC dbo.SpCapNhatBan "+id
                 , CommandType.Text, null);
        }
        public void CapNhatTruocThanhToan(int id)
        {
            db.ExecuteQueryDataSet("EXEC dbo.SpCapNhatBanTruocTT " + id
                , CommandType.Text, null);
        }
        public DataSet BanLS(int id)
        {
            return db.ExecuteQueryDataSet(" select* from dbo.LSBan(" + id + ")", CommandType.Text, null);

        }
        //public bool ThemNhanVien(ref string err,
        //    string Ten, string DiaChi, string GioiTinh, int SDT, DateTime Ngay, float TienThuong,
        //     string CaLam, float Luong, int NgayNghi, byte[] Hinh, string ChucVu, int Tuoi)
        //{
        //    return db.MyExecuteNonQuery("SpThemNhanVien",
        //        CommandType.StoredProcedure, ref err,

        //        new SqlParameter("@Ten ", Ten),
        //        new SqlParameter("@GioiTinh", GioiTinh),
        //        new SqlParameter("@DiaChi", DiaChi),
        //        new SqlParameter("@Ngay ", Ngay),
        //        new SqlParameter("@SDT", SDT),
        //         new SqlParameter("@TienThuong", TienThuong),
        //         new SqlParameter("@CaLam ", CaLam),
        //         new SqlParameter("@Luong ", Luong),
        //         new SqlParameter("@NgayNghi ", NgayNghi),
        //         new SqlParameter("@ChucVu ", ChucVu),
        //         new SqlParameter("@Tuoi ", Tuoi),
        //         new SqlParameter("@Hinh", Hinh));
        //}
        //public bool XoaNhanVien(ref string err, int ID_NhanVien)
        //{
        //    return db.MyExecuteNonQuery("spXoaNhanVien",
        //        CommandType.StoredProcedure, ref err, new SqlParameter("@ID_NhanVien", ID_NhanVien));
        //}
        //public bool CapNhatNhanVien(ref string err, int ID_NhanVien, string Ten, string DiaChi, string GioiTinh, int SDT, DateTime Ngay, float TienThuong,
        //     string CaLam, float Luong, int NgayNghi, byte[] Hinh, string ChucVu, int Tuoi)
        //{
        //    return db.MyExecuteNonQuery("SpCapNhatNhanVien",
        //        CommandType.StoredProcedure, ref err,
        //        new SqlParameter("@ID_NhanVien", ID_NhanVien),
        //        new SqlParameter("@DiaChi", DiaChi),
        //        new SqlParameter("@Ten", Ten),
        //        new SqlParameter("@GioiTinh", GioiTinh),
        //        new SqlParameter("@Ngay", Ngay),
        //        new SqlParameter("@SDT", SDT),
        //         new SqlParameter("@TienThuong", TienThuong),
        //         new SqlParameter("@CaLam ", CaLam),
        //         new SqlParameter("@Luong ", Luong),
        //         new SqlParameter("@NgayNghi ", NgayNghi),
        //         new SqlParameter("@ChucVu ", ChucVu),
        //         new SqlParameter("@Tuoi ", Tuoi),
        //         new SqlParameter("@Hinh", Hinh));
        //}
    }

}

