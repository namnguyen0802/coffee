using BALayer;
using coffee.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee.DAO
{
    public class BillInfoDAO
    {
        
        public List<BillInfo> GetListBillInfo(int id)
        {
            DBBillInfo db = new DBBillInfo();
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = db.LayBillInfo(id).Tables[0];
           // DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
    }
}
