using BDLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer
{
    public class DBMenu
    {

        DAL db = null;

        public DBMenu()
        {
            db = new DAL();
        }
        public DataSet LayMenu(int id)
        {
            return db.ExecuteQueryDataSet("select GiaBan,DOUONG.Ten as Ten, SoLuong*GiaBan as totalPrice,SoLuong, SoLuong*GiaBan as thanhtien,NgayLapHoaDon from HOADON, CHITIETHOADON, BAN, DOUONG where BAN.IDBan = HOADON.IDBan and HOADON.IDHoaDon = CHITIETHOADON.IDHoaDon and HOADON.IDBan = " + id+ " and  CHITIETHOADON.IDDoUong = DOUONG.IDDoUong and TrangThai = 'Chua Thanh Toan'", CommandType.Text, null);
        }
    }
}

