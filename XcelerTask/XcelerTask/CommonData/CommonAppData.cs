using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelerTask.Models;

namespace XcelerTask.CommonData
{
    public static class CommonAppData
    {
        public static List<UserProfile> _listUserProfile = new List<UserProfile>();
        public static UserProfile Commonuserprofile;

        public static string CustomError = "Something went wrong. Please try after sometime.";
        public static List<Country> CountryList = new List<Country>() {
            new Country() { Id = 0,Name="Select" },
            new Country() { Id = 1,Name="India" },
            new Country() { Id = 2,Name="Russia" },
            new Country() { Id = 3,Name="USA" },
            new Country() { Id = 4,Name="UK" }
        };
        public static List<MaritalStatus> MaritalStatusList = new List<MaritalStatus>() {
            new MaritalStatus() { Id = 0,Name="Select" },
            new MaritalStatus() { Id = 1,Name="Married" },
            new MaritalStatus() { Id = 2,Name="Single" }
        };
    }
}
