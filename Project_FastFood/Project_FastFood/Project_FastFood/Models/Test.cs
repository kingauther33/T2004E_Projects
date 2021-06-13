using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Project_FastFood.Models
{
    public class Test : INotifyPropertyChanged
    {
        //private string name;

        //public string Name
        //{
        //    get { return name; }
        //    set 
        //    { 
        //        name = value;
        //        OnPropertyChanged("Name");
        //        OnPropertyChanged("FullName");
        //    }
        //}

        //private string lastName;

        //public string LastName
        //{
        //    get { return lastName; }
        //    set 
        //    { 
        //        lastName = value;
        //        OnPropertyChanged("LastName");
        //        OnPropertyChanged("FullName");
        //    }
        //}

        //private string fullName;

        //public string FullName
        //{
        //    get { return name + " " + lastName; }
        //    set 
        //    {
        //        fullName = value;
        //        OnPropertyChanged("FullName");
        //    }
        //}



        //public event PropertyChangedEventHandler PropertyChanged;

        //public Test()
        //{
        //    if(DesignMode.DesignModeEnabled)
        //    {
        //        this.Name = "An";
        //        this.LastName = "Dinh";
        //    }
        //}

        //private void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private string fnameVal;
        public string Fname
        {
            get { return "$" + fnameVal; }
            set { fnameVal = value; RaisePropertyChanged("Fname"); }
        }

        private string lnameVal;
        public string Lname
        {
            get { return lnameVal; }
            set { lnameVal = value; RaisePropertyChanged("Lname"); }
        }

        protected void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public Test(string fname, string lname)
        {
            Fname = fname;
            Lname = lname;
        }
    }

    public class TestItemViewDataContext
    {
        public ObservableCollection<Test> List { get; set; }
        public TestItemViewDataContext()
        {
            List = new ObservableCollection<Test>();
        }
    }
}
