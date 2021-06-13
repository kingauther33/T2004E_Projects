using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Project_FastFood.Adapters;
using Project_FastFood.Models;
using SQLitePCL;
using Project_FastFood.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_FastFood.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Cart : Page
    {
        public Cart()
        {
            this.InitializeComponent();
            GetCartDatabase();
            SubTotalCalculation();
        }

        public void GetCartDatabase()
        {
            CartModel cartModel = new CartModel();
            CartListView.ItemsSource = cartModel.GetCart();
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Layout._mainFrame.Navigate(typeof(Pages.Collection));
        }

        private void DeleteOrderItem(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).Tag as CartItem;
            CartListView.SelectedItem = item;
            CartItem cartSelected = CartListView.SelectedItem as CartItem;
            CartModel cartModel = new CartModel();
            bool result = cartModel.RemoveItem(cartSelected);
            CartFrame.Navigate(this.GetType());

            //TestButtonSubmit.Text = cartModel.AddToCart(cartItem).ToString();
        }

        private void TextBox_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.ToString().Equals("Back"))
            {
                e.Handled = false;
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                if (e.Key.ToString() == string.Format("Number{0}", i))
                {
                    e.Handled = false;
                    return;
                }
            }
            e.Handled = true;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //TestLostFocus.Text = "Dog Shit Lost Focus";
            var item = (sender as FrameworkElement).Tag as CartItem;
            CartListView.SelectedItem = item;
            CartItem cartSelected = CartListView.SelectedItem as CartItem;
            CartModel cartModel = new CartModel();
            bool result = cartModel.UpdateCart(cartSelected, cartSelected.qty);

            // Subtotal Value
            SubTotalCalculation();
        }

        public void SubTotalCalculation()
        {
            int tempSubtotal = 0;
            if (CartListView.Items.FirstOrDefault() != null)
            {
                foreach (CartItem item in CartListView.Items)
                {
                    tempSubtotal += item.qty * item.price;
                }
            }
            SubTotalMoney.Text = tempSubtotal.ToString() + " VND";
        }

        private async void CheckOutButton(object sender, RoutedEventArgs e)
        {
            OrderService orderService = new OrderService();
            CartModel cartModel = new CartModel();
            CreateOrder createOrder = await orderService.CreateOrder(cartModel.GetCart());
            // Sau cau lenh nay la Order da duoc chuyen len Server cung voi data cua trang Cart, createOrder luu tru data cua Order bao gom id va data 
            if (cartModel.GetCart().Count > 0)
            {
                cartModel.ClearCart();
                SuccessCOBlock.Text = "Order Successfully. Your Order ID is " + createOrder.data.order_id.ToString();
                RedirectBlock.Text = "Refreshing ...";

                await System.Threading.Tasks.Task.Delay(6000);

                CartFrame.Navigate(this.GetType());
            }
            
            // Server hong, em chi lay duoc ra id cua item duoc Order
        }
    }
}
