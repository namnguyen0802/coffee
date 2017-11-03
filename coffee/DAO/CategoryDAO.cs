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
    public class CategoryDAO
    {
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            // string query = "select * from FoodCategory";
            DBCategory db = new DBCategory();
            //  DataTable data = DataProvider.Instance.ExecuteQuery(query);
            DataTable data = db.LayCategory().Tables[0];
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }
    }
}
