using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XcelerTask.DependencyServices;
using XcelerTask.Models;
using XcelerTask.Droid.DependencyServicesImplementation;
using System.IO;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(JsonDataImplementation))]
namespace XcelerTask.Droid.DependencyServicesImplementation
{
    public class JsonDataImplementation : IJsonData
    {
        public UserProfileList ReadDataFromJson()
        {
            var stream = Android.App.Application.Context.Assets.Open("JsonFormatFile.txt");
            StreamReader sr = new StreamReader(stream);
            string text = sr.ReadToEnd();
            var result = JsonConvert.DeserializeObject<UserProfileList>(text);
            return result;

        }

        //public bool WriteDatatoJson()
        //{
        //    var stream = Android.App.Application.Context.Assets.Open("JsonFormatFile.txt",FileMode.Create,FileAccess.Write);
        //    StreamReader sr = new StreamReader(stream);
        //    string text = sr.ReadToEnd();
        //    var result = JsonConvert.DeserializeObject<UserProfileList>(text);
        //    return true;
        //}
    }
}