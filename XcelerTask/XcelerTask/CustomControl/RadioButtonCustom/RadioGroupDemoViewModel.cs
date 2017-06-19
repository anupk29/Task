using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelerTask.CustomControl.RadioButtonCustom
{
    public class RadioGroupDemoViewModel : INotifyPropertyChanged
    {

        public RadioGroupDemoViewModel()
        {
            myList = new Dictionary<int, string>();
            selectedIndex = -1;
            LoadData();
        }


        private void LoadData()
        {

            //for (int i = 0; i < 2; i++)
            //{
            //    MyList.Add(i, "Male " + i);
            //}
            MyList.Add(0, "Male");
            MyList.Add(1, "Female");


        }


        private Dictionary<int, string> myList;
        public Dictionary<int, string> MyList
        {
            get { return myList; }
            set
            {
                myList = value;
                NotifyPropertyChanged("MyList");
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value == -1)
                {
                    selectedIndex = 0;
                    NotifyPropertyChanged("SelectedIndex");
                }
                else
                {
                    selectedIndex = value;
                    NotifyPropertyChanged("SelectedIndex");
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
