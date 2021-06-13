using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_FastFood.Models
{
    class CartItem : INotifyPropertyChanged
    {
        public CartItem(int id, string name, string image, int price, int qty)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.price = price;
            this.qty = qty;
        }

        public CartItem(int id, string name, string image, int price)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.price = price;
        }

        private int Id;
        public int id { get 
            {
                return Id;
            } set 
            {
                Id = value;
                OnPropertyChanged("id");
            } 
        } // property -> tham chiếu id product
        public string name { get; set; }
        public string image { get; set; }
        public int price { get; set; }
        private int Qty;
        public int qty
        {
            get
            {
                return Qty;
            }
            set
            {
                Qty = value;
                OnPropertyChanged("id");
            }
        }
        //public int qty { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

