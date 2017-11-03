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
   public class DrinkDAO
    {
        public List<Drink> GetFoodByCategoryID(int id)
        {
            DBDrink db = new DBDrink();
            List<Drink> list = new List<Drink>();

            //string query = "select * from Food where idCategory = " + id;
            DataTable data = db.LayDrink(id).Tables[0];
            //DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Drink food = new Drink(item);
                list.Add(food);
            }

            return list;
        }
    }
}
