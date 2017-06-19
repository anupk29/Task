using Newtonsoft.Json;
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
    public partial class AddNewUser : ContentPage
    {
        public int GenderId;
        public int ItemId;
        public static int SelectedGenderId;
        public static int SelectedMaritalStatusId;
        public static int SelectedNationalityId;
        public static string profileimg;
        UserProfile _userprofile = new UserProfile();

        public AddNewUser()
        {
            InitializeComponent();

            ToolbarItem page = new ToolbarItem("Cancel", "cancel.png", () =>
            {
                CancelMethod();

            });
            ToolbarItem page1 = new ToolbarItem("Save", "save.png", () =>
            {
                SaveMethod();

            });


            ToolbarItems.Add(page);
            ToolbarItems.Add(page1);
            MaritialStatusList.ItemsSource = null;
            NationalityList.ItemsSource = null;

            foreach (var item in CommonAppData.MaritalStatusList)
            {
                MaritialStatusList.Items.Add(item.Name);

            }
            MaritialStatusList.SelectedIndex = 0;
            foreach (var item in CommonAppData.CountryList)
            {
                NationalityList.Items.Add(item.Name);

            }
            NationalityList.SelectedIndex = 0;
            this.BindingContext = new RadioGroupDemoViewModel();
            MyRadiouGroup.SelectedIndex = 0;
            ItemId = 0;
            profileimg =null;
            //if (CommonAppData.Commonuserprofile != null)
            //{
            //    txtname.Text = CommonAppData.Commonuserprofile.Name;

            //    txtemail.Text = CommonAppData.Commonuserprofile.Email;
            //    txtphone.Text = CommonAppData.Commonuserprofile.phone;
            //    if(CommonAppData.Commonuserprofile.Gender==true)
            //    {
            //        GenderId = 0;
            //    }
            //    else
            //    {
            //        GenderId = 1;
            //    }
            //    MyRadiouGroup.SelectedIndex = GenderId;
            //}
        }

        public AddNewUser(UserProfile item)
        {
            InitializeComponent();

            ToolbarItem page = new ToolbarItem("Cancel", "cancel.png", () =>
            {
                CancelMethod();

            });
            ToolbarItem page1 = new ToolbarItem("Save", "save.png", () =>
            {
                SaveMethod();

            });


            ToolbarItems.Add(page);
            ToolbarItems.Add(page1);

            this.BindingContext = new RadioGroupDemoViewModel();
            MyRadiouGroup.SelectedIndex = 0;
            if (item != null)
            {
                ItemId = item.Id;
                txtname.Text = item.Name;
                TbDob.Date=Convert.ToDateTime(item.DOB);
                txtemail.Text = item.Email;
                txtphone.Text = item.phone;
                SelectedGenderId=Convert.ToInt32(item.Gender);
                SelectedMaritalStatusId=item.MartialStatusId;
                SelectedNationalityId=item.NationalityId;
                profileimg = item.image;
                if (item.Gender == true)
                {
                    GenderId = 0;
                }
                else
                {
                    GenderId = 1;
                }
                MaritialStatusList.ItemsSource = null;
                NationalityList.ItemsSource = null;
                foreach (var itemms in CommonAppData.MaritalStatusList)
                {
                    MaritialStatusList.Items.Add(itemms.Name);

                }
                foreach (var itemc in CommonAppData.CountryList)
                {
                    NationalityList.Items.Add(itemc.Name);

                }
                MyRadiouGroup.SelectedIndex = GenderId;
                MaritialStatusList.SelectedIndex = item.MartialStatusId;
                NationalityList.SelectedIndex = item.NationalityId;
            }
            
        }
        protected override void OnDisappearing()
        {
            MaritialStatusList.SelectedIndexChanged -= MaritialStatusList_SelectedIndexChanged;
            NationalityList.SelectedIndexChanged -= NationalityList_SelectedIndexChanged;
            MyRadiouGroup.CheckedChanged -= MyRadiouGroup_CheckedChanged;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MaritialStatusList.SelectedIndexChanged += MaritialStatusList_SelectedIndexChanged;
            NationalityList.SelectedIndexChanged += NationalityList_SelectedIndexChanged;
            MyRadiouGroup.CheckedChanged += MyRadiouGroup_CheckedChanged;
        }

        private void NationalityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NationalityList.SelectedIndex == 1)
            {
                SelectedNationalityId = 1;
            }
            else if (NationalityList.SelectedIndex == 2)
            {
                SelectedNationalityId = 2;
            }
            else if (NationalityList.SelectedIndex == 3)
            {
                SelectedNationalityId = 3;
            }
            else if (NationalityList.SelectedIndex == 4)
            {
                SelectedNationalityId = 4;
            }
            else 
            {
                SelectedNationalityId = 0;
            }

        }

        private void MaritialStatusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(MaritialStatusList.SelectedIndex==1)
            {
                SelectedMaritalStatusId = 1;
            }
            else if (MaritialStatusList.SelectedIndex == 2)
            {
                SelectedMaritalStatusId = 2;
            }
            else
            {
                SelectedMaritalStatusId = 0;
            }

        }

        private async void SaveMethod()
        {
            //var result = await this.DisplayAlert("Warning", "Sure to save the User ?", "Yes", "No");
            //if (result)
            //{
                //Add Data to local storage;

                _userprofile.Name = txtname.Text;
                _userprofile.DOB = TbDob.Date.ToString();
                
                _userprofile.Email = txtemail.Text;
                _userprofile.phone = txtphone.Text;
                _userprofile.MartialStatusId = SelectedMaritalStatusId;
                _userprofile.NationalityId = SelectedNationalityId;
                if (string.IsNullOrEmpty(_userprofile.Name) || string.IsNullOrEmpty(_userprofile.Name))
                {
                    AlertMessages.ShowAlert("please Enter Name");
                    return;
                }
                if (_userprofile.DOB == null)
                {
                    AlertMessages.ShowAlert("please Enter Date of Birth");
                    return;
                }
                if (string.IsNullOrEmpty(_userprofile.Email) || string.IsNullOrEmpty(_userprofile.Email))
                {
                    AlertMessages.ShowAlert("please Enter Email");
                    return;
                }
                if (string.IsNullOrEmpty(_userprofile.phone) || string.IsNullOrEmpty(_userprofile.phone))
                {
                    AlertMessages.ShowAlert("please Enter phone");
                    return;
                }
                if (_userprofile.MartialStatusId == 0 || _userprofile.MartialStatusId == null)
                {
                    AlertMessages.ShowAlert("please Select Martial Status");
                    return;
                }
                if (_userprofile.NationalityId == 0 || _userprofile.NationalityId == null)
                {
                    AlertMessages.ShowAlert("please Select Nationality");
                    return;
                }

            //CommonData.CommonAppData._listUserProfile.RemoveAt()

            if(ItemId==0)
            {
                var listUserProfile = new UserProfileRepository().GetAllusers();
                var lastvalue = listUserProfile.Last<UserProfile>();
                var NewId = lastvalue.Id + 1;
                _userprofile.Id = NewId;
            }
            else
            {
                _userprofile.Id = ItemId;
            }
                
                _userprofile.IsActive = true;
            if(profileimg==null)
            {
                _userprofile.image = "defaultavatar.png";
            }
            else
            {
                _userprofile.image = profileimg;
            }
                
                var result=JsonConvert.SerializeObject(_userprofile);
                var result1 = new UserProfileRepository().AddItem(_userprofile);
            await  Navigation.PushModalAsync(new MasterDetail());
            //new NavigationPage(new UsersListView());
            //}


        }

        private async void CancelMethod()
        {
            await Navigation.PushAsync(new UsersListView(), false);
        }

        async void MyRadiouGroup_CheckedChanged(object sender, int e)
        {
            var radio = sender as CustomRadioButton;
            GenderId = radio.Id;
            if (GenderId == 0)
            {
                //Male
                SelectedGenderId = 0;
            }
            else
            {
                //Female
                SelectedGenderId = 1;
            }
        }
        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    //Add Data to local data base
           
        //    _userprofile.Name= txtname.Text;
        //    _userprofile.Age = int.Parse(txtage.Text);
        //    _userprofile.Email = txtemail.Text;
        //    _userprofile.phone = txtphone.Text;
        //    _userprofile.image = "defaultavatar.png";


        //}
    }
}