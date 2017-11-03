using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee.DTO
{
    public class Drink
    {
        public Drink(int id, int categoryID, float price, string name  )
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }

        public Drink(System.Data.DataRow row)
        {
            this.ID = (int)row["IDDoUong"];
            this.Name = row["Ten"].ToString();
            this.CategoryID = (int)row["IDDanhMuc"];
            this.Price = (float)Convert.ToDouble(row["GiaBan"].ToString());
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}

