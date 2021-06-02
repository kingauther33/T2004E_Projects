using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_FastFood.Models
{
    public class HomeMenuData
    {
        public string message { get; set; }
        public List<HomeMenuItem> data { get; set; }
    }
    public class HomeMenuItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }
}
