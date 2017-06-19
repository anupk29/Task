using FloatingButtonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XcelerTask.DependencyServices;
using XcelerTask.Models;
using XcelerTask.Repository;

namespace XcelerTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersListView : ContentPage
    {
        
        public UsersListView()
        {
            InitializeComponent();
            

            LoadData();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UserProfileListview.SelectedItem = null;
            //LoadData();
            UserProfileListview.ItemTapped += UserProfileListview_ItemTapped;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            UserProfileListview.ItemTapped -= UserProfileListview_ItemTapped;
        }
        private void LoadData()
        {
            var listUserProfile = new UserProfileRepository().GetAllusers();
            if (listUserProfile.Count == 0)
            {
                //_listUserProfile = new List<UserProfile>{
                //new UserProfile { Id=1,Name="Abc",Gender=false,image="people_1.jpg",Email="Abc@gmail.com",phone="1234567890",IsActive=true},
                //new UserProfile { Id=2,Name="def",Gender=true,image="people_2.jpg",Email="def@gmail.com",phone="1234567890",IsActive=true},
                //new UserProfile { Id=3,Name="ghi",Gender=false,image="people_3.jpg",Email="ghi@gmail.com",phone="1234567890",IsActive=true},
                //new UserProfile { Id=4,Name="jkl",Gender=true,image="people_4.jpg",Email="jkl@gmail.com",phone="1234567890",IsActive=true},
                //new UserProfile { Id=5,Name="mno",Gender=false,image="people_5.jpg",Email="mno@gmail.com",phone="1234567890",IsActive=true},

                //};
                var LocalUserProfilelist = DependencyService.Get<IJsonData>().ReadDataFromJson();
                foreach (var item in LocalUserProfilelist.userprofilelist)
                {
                    new UserProfileRepository().AddItem(item);
                }


            }

            var LocallistUserProfile = new UserProfileRepository().GetAllusers();
            //var LocallistUserProfile = DependencyService.Get<IJsonData>().ReadDataFromJson();
            //foreach(var item in LocallistUserProfile.userprofilelist)
            //{
            //    CommonData.CommonAppData._listUserProfile.Add(item);
            //} 
            CommonData.CommonAppData._listUserProfile = LocallistUserProfile;
            UserProfileListview.ItemsSource = CommonData.CommonAppData._listUserProfile;
            
        }

        private void UserProfileListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selecteditem = e.Item as UserProfile;
            Navigation.PushAsync(new UserDetailView(Selecteditem));

        }
        protected override bool OnBackButtonPressed()
        {
            if (Device.OS != TargetPlatform.WinPhone)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Warning", "Sure to close the app?", "Yes", "No");
                    if (result)
                        //IAndroidMethods is used to close the app, Nameing is not correct as android it must be somthing generic IAppClose instead of IAndroidMethods
                        DependencyService.Get<ICloseMethod>().CloseApp();
                });
                return true;
            }
            else
            {
                return false;
            }
        }
        private async void Handle_FabClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewUser(), false);

        }
    }
}