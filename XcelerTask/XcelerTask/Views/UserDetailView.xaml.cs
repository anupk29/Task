using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XcelerTask.CommonData;
using XcelerTask.CustomControl.RadioButtonCustom;
using XcelerTask.Models;
using XcelerTask.Repository;

namespace XcelerTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailView : ContentPage
    {
        public int GenderId;
        private async void EditMethod(UserProfile item)
        {

            await Navigation.PushAsync(new AddNewUser(item), false);
            //Navigation.InsertPageBefore(new AddNewUser(item), this);
        }

        private async void DeleteMethod()
        {

            var result = await this.DisplayAlert("Warning", "Sure to Delete the User ?", "Yes", "No");
            if (result)
            {
                CommonAppData.Commonuserprofile.IsActive = false;
                var result1 = new UserProfileRepository().AddItem(CommonAppData.Commonuserprofile);
            }
            
        }

        public UserDetailView(UserProfile item)
        {

            InitializeComponent();
            
            txtname.Text = item.Name;
            txtemail.Text = item.Email;
            txtphone.Text = item.phone;
            TbDob.Date = Convert.ToDateTime(item.DOB);
            
            MaritialStatusList.ItemsSource = null;
            NationalityList.ItemsSource = null;
            foreach (var itemms in CommonAppData.MaritalStatusList)
            {
                MaritialStatusList.Items.Add(itemms.Name);

            }
            MaritialStatusList.SelectedIndex = 0;
            foreach (var itemc in CommonAppData.CountryList)
            {
                NationalityList.Items.Add(itemc.Name);

            }
            NationalityList.SelectedIndex = 0;
            MaritialStatusList.SelectedIndex = item.MartialStatusId;
            NationalityList.SelectedIndex = item.NationalityId;
            this.BindingContext = new RadioGroupDemoViewModel();
            if (item.Gender == true)
            {
                GenderId = 0;
            }
            else
            {
                GenderId = 1;
            }
            MyRadiouGroup.SelectedIndex = GenderId;
            
            ToolbarItem page = new ToolbarItem("Delete", "delete.png", () =>
            {
                DeleteMethod();

            });
            ToolbarItem page1 = new ToolbarItem("Edit", "edit.png", () =>
            {
                EditMethod(item);

            });
            ToolbarItems.Add(page);
            ToolbarItems.Add(page1);
        }
    }
}