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
   
    public class BillDAO
    {
        DBBill dbBill = new DBBill();
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = dbBill.LayBill(id).Tables[0];

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.IDHoaDon;
            }

            return -1;
        }

    }
}
