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
    public class DBDoUong
    {

        DAL db = null;

        public DBDoUong()
        {
            db = new DAL();
        }
        public DataSet LayDoUong(int IDDanhMuc)
        {
            return db.ExecuteQueryDataSet("select * from DOUONG where IDDanhMuc=" + IDDanhMuc, CommandType.Text, null);
        }

        public bool ThemDoUong(ref string err,
            int ID_DanhMuc,
            float GiaBan, String Ten)
        {
            return db.MyExecuteNonQuery("SpThemDoUong", CommandType.StoredProcedure, ref err,
                new SqlParameter("@ID_DanhMuc", ID_DanhMuc),
                new SqlParameter("@GiaBan", GiaBan),
                new SqlParameter("@Ten", Ten));
        }
        public bool XoaDoUong(ref string err, int ID_DoUong)
        {
            return db.MyExecuteNonQuery("spXoaDoUong",
                CommandType.StoredProcedure, ref err, new SqlParameter("@ID_DoUong", ID_DoUong));
        }
        public bool CapNhatDoUong(ref string err,
            int ID_DoUong,/*int ID_DanhMuc,*/float GiaBan, string Ten)
        {

            return db.MyExecuteNonQuery("SpCapNhatDoUong",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@IDDoUong", ID_DoUong),
                //new SqlParameter("@IDDanhMuc", ID_DanhMuc),
                new SqlParameter("@GiaBan", GiaBan),
                new SqlParameter("@Ten", Ten)
                );
        }
    }

}
