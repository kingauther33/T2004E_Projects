using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_FastFood.Models
{
    class MenuItem
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public string MenuPage { get; set; }

        public MenuItem(string icon, string name, string menuPage)
        {
            Icon = icon;
            Name = name;
            MenuPage = menuPage;
        }
    }
}
