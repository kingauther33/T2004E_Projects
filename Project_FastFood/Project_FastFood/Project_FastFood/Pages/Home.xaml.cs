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
using Project_FastFood.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Project_FastFood.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_FastFood.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            GetHomeMenu();
            
        }

        public async void GetHomeMenu()
        {
            HomeMenuService service = new HomeMenuService();
            HomeMenuData menu = await service.GetHomeMenu();
            if (menu != null)
            {
                homeMenuItems.ItemsSource = menu.data;
            }
            
        }
    }
}
