using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_FastFood.Models;

namespace Project_FastFood.Services
{
    interface CartService
    {
        List<CartItem> GetCart();
        bool AddToCart(CartItem item);
        bool RemoveItem(CartItem item);
        bool UpdateCart(CartItem item, int qty);
        bool ClearCart();
    }
}