using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XcelerTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutAppPage : ContentPage
    {
        public AboutAppPage()
        {
            InitializeComponent();
        }

        protected  override bool OnBackButtonPressed()
        {
            if(Device.OS==TargetPlatform.Android)
            {
                Navigation.PushAsync(new UsersListView(), false);
                return true;

            }
            return true;
        }
    }
}