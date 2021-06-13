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
using Project_FastFood.Models;
using System.Collections.ObjectModel;
using Project_FastFood.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_FastFood.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestXam
    {
        private ObservableCollection<Test> List;

        public TestXam()
        {
            this.InitializeComponent();
            List = new ObservableCollection<Test>();
            List.Add(new Test("An", "Dinh"));
            List.Add(new Test("Dung", "Dinh"));
            List.Add(new Test("Tran", "Dinh"));
            myListView.ItemsSource = List;

        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    //var item = (sender as FrameworkElement).Tag as Test;
        //    //var list = (DataContext as TestItemViewDataContext).List;
        //    //myListView.SelectedItem = item;
        //    Test itemTest = myListView.SelectedItem as Test;
        //    DogShit.Text = itemTest.Fname;
        //}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).Tag as Test;
            //var list = (DataContext as TestItemViewDataContext).List;
            myListView.SelectedItem = item;
            Test itemTest = myListView.SelectedItem as Test;
            DogShit.Text = itemTest.Fname;
        }
    }
}
