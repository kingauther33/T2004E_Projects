using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_FastFood.Models
{
    public class CategoryMenu
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class Food
    {
        public int id { get; set; }

        public string name { get; set; }

        public string image { get; set; }

        public string description { get; set; }

        public int price { get; set; }
    }

    public class CategoryData
    {
        public CategoryMenu category { get; set; }

        public List<Food> foods { get; set; }
    }

    public class CategoryDetail
    {
        public string message { get; set; }

        public CategoryData data { get; set; }
    }

    public class FoodDetail
    {
        public string message { get; set; }

        public Food foodData { get; set; }
    }
}
