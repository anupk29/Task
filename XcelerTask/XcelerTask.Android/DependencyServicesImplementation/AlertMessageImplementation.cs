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
using Android.Support.Design.Widget;
using XcelerTask.DependencyServices;
using XcelerTask.Models;
using Plugin.CurrentActivity;
using XcelerTask.Droid.DependencyServicesImplementation;

[assembly: Xamarin.Forms.Dependency(typeof(AlertMessageImplementation))]
namespace XcelerTask.Droid.DependencyServicesImplementation
{
    public class AlertMessageImplementation : IAlertMessages
    {
        private Snackbar snackbar;
        public void ShowAlert(string _message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View activityRootView = activity.FindViewById(Android.Resource.Id.Content);
            snackbar = Snackbar.Make(activityRootView, _message, Snackbar.LengthLong);
            snackbar.Show();
            
        }
    }
}