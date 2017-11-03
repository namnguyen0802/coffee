using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee.DTO
{
    public class Bill
    {
        public Bill(int idhoadon,int idban,int idnhanvien, string trangthai ){
            this.IDHoaDon = idhoadon;
            this.IDBan = idban;
            this.IDNhanVien = idnhanvien;
            this.IDTrangThai = trangthai;
        }
        public Bill(DataRow row)
        {
            this.IDBan = (int)row["IDBan"];
            //this.DateCheckIn = (DateTime?)row["dateCheckin"];

            //var dateCheckOutTemp = row["dateCheckOut"];
            //if (dateCheckOutTemp.ToString() != "")
            //    this.DateCheckOut = (DateTime?)dateCheckOutTemp;

            this.IDHoaDon = (int)row["IDHoaDon"];
            this.IDNhanVien= (int)row["IDNhanVien"];
            this.IDTrangThai = row["TrangThai"].ToString();

        }
        private int iDBan;

        private int iDHoaDon;

        public int IDBan
        {
            get
            {
                return iDBan;
            }

            set
            {
                iDBan = value;
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

    
        public string IDTrangThai
        {
            get
            {
                return iDTrangThai;
            }

            set
            {
                iDTrangThai = value;
            }
        }

        public int IDNhanVien
        {
            get
            {
                return iDNhanVien;
            }

            set
            {
                iDNhanVien = value;
            }
        }

        private int iDNhanVien;
        private string iDTrangThai;
    }
}
