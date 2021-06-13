﻿using System;
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
using System.Collections;
using Project_FastFood.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Project_FastFood.Services;
using SQLitePCL;
using Project_FastFood.Adapters;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_FastFood.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Collection : Page
    {
        public Collection()
        {
            this.InitializeComponent();
            //ObservableCollection<Food> dataList = new ObservableCollection<Food>();
            GetCategoryMenu();
        }

        private void BurgerFood_Click(object sender, RoutedEventArgs e)
        {
            App.getCategoryID.id = 1;
            Frame.Navigate(this.GetType());
        }

        private void ChickenFood_Click(object sender, RoutedEventArgs e)
        {
            App.getCategoryID.id = 2;
            Frame.Navigate(this.GetType());
        }

        private void RiceFood_Click(object sender, RoutedEventArgs e)
        {
            App.getCategoryID.id = 3;
            Frame.Navigate(this.GetType());
        }

        private void DrinksFood_Click(object sender, RoutedEventArgs e)
        {
            App.getCategoryID.id = 4;
            Frame.Navigate(this.GetType());
        }

        private void DesertFood_Click(object sender, RoutedEventArgs e)
        {
            App.getCategoryID.id = 5;
            Frame.Navigate(this.GetType());
        }

        public async void GetCategoryMenu()
        {
            CategoryMenuService categoryService = new CategoryMenuService();
            CategoryDetail categoryDetail = await categoryService.GetCategoryMenu();
            if (categoryDetail != null)
            {
                CategoryMenuList.ItemsSource = categoryDetail.data.foods;
            }
        }


        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    string msg = e.Parameter as string;
        //    collectionTextTest.Text = msg;
        //    base.OnNavigatedTo(e);
        //}        

        private void onGridViewSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var columns = Math.Ceiling(ActualWidth / 1000);
            ((ItemsWrapGrid)CategoryMenuList.ItemsPanelRoot).ItemWidth = e.NewSize.Width / columns;
        }

        private void OrderToDatabase(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).Tag as Food;
            CategoryMenuList.SelectedItem = item;
            Food foodSelected = CategoryMenuList.SelectedItem as Food;
            CartModel cartModel = new CartModel();
            // Day Food vao trong Cart Item va mac dinh qty = 1
            CartItem cartItem = new CartItem(foodSelected.id, foodSelected.name, foodSelected.image, foodSelected.price, 1);
            TestButtonSubmit.Text = cartModel.AddToCart(cartItem).ToString();
        }
    }
}
