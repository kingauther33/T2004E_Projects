using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_FastFood.Services;
using SQLitePCL;
using Project_FastFood.Models;
using Project_FastFood.Adapters;

namespace Project_FastFood.Models
{
    class CartModel : CartService
    {
        public List<CartItem> GetCart()
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "select * from Cart";
            var statement = sQLiteConnection.Prepare(sql_txt);
            List<CartItem> list = new List<CartItem>();
            while (SQLiteResult.ROW == statement.Step())
            {
                int id = Convert.ToInt32(statement[0]);
                string name = (string)statement[1];
                string image = (string)statement[2];
                int price = Convert.ToInt32(statement[3]);
                int qty = Convert.ToInt32(statement[4]);
                CartItem c = new CartItem(id, name, image, price, qty);
                list.Add(c);
            }
            return list;
        }

        public bool AddToCart(CartItem item)
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_checkId = "select * from Cart where id = " + item.id;
            var statementCheckId = sQLiteConnection.Prepare(sql_checkId);
            int i = item.qty;
            if (SQLiteResult.ROW == statementCheckId.Step())
            {
                // Update  qty + 1 
                string sql_updateCartChecked = "update Cart set qty = ? where id = ?";
                var statementUpdateChecked = sQLiteConnection.Prepare(sql_updateCartChecked); // them so luong
                statementUpdateChecked.Bind(1, i + 1);
                statementUpdateChecked.Bind(2, item.id);
                var resultUpdate = statementUpdateChecked.Step();
                return resultUpdate == SQLiteResult.DONE;
            } else
            {
                string sql_txt = "insert into Cart (id,name,image,price,qty) values(?,?,?,?,?)";
                var statement = sQLiteConnection.Prepare(sql_txt);
                statement.Bind(1, item.id);
                statement.Bind(2, item.name);
                statement.Bind(3, item.image);
                statement.Bind(4, item.price);
                statement.Bind(5, 1);
                var rs = statement.Step();
                return rs == SQLiteResult.DONE;
            }
        }

        public bool RemoveItem(CartItem item)
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "delete from Cart where id = ?";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Bind(1, item.id);
            var rs = statement.Step();
            return rs == SQLiteResult.DONE;
        }

        public bool UpdateCart(CartItem item, int qty)
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "update Cart set qty = ? where id = ?";
            var statement = sQLiteConnection.Prepare(sql_txt); // them so luong
            statement.Bind(1, qty); 
            statement.Bind(2, item.id);
            var rs = statement.Step();
            return rs == SQLiteResult.DONE;
        }

        public bool ClearCart()
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "delete from Cart";
            var statement = sQLiteConnection.Prepare(sql_txt);
            var rs = statement.Step();
            return rs == SQLiteResult.DONE;
        }
    }
}