using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee.DTO
{
    public class BillInfo
    {
        public BillInfo(int idchitiet, int idHoadon, int idDouong, int soLuong)
        {
            this.IDChiTiet = idchitiet;
            this.IDHoaDon = idHoadon;
            this.IDDoUong = idDouong;
            this.SoLuong = soLuong;
        }

        public BillInfo(DataRow row)
        {
            this.IDChiTiet = (int)row["IDChiTiet"];
            this.IDHoaDon = (int)row["IDHoaDon"];
            this.IDDoUong = (int)row["IDDoUong"];
            this.SoLuong = (int)row["SoLuong"];
        }
        private int iDChiTiet;

        public int IDChiTiet
        {
            get
            {
                return iDChiTiet;
            }

            set
            {
                iDChiTiet = value;
            }
        }

        public int IDHoaDon
        {
            get
            {
                return iDHoaDon;
            }

            set
            {
                iDHoaDon = value;
            }
        }

        public int IDDoUong
        {
            get
            {
                return iDDoUong;
            }

            set
            {
                iDDoUong = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        private int iDHoaDon;
        private int iDDoUong;
        private int soLuong;
    }
}
