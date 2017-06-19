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
using XcelerTask.Droid.DependencyServicesImplementation;

[assembly: Xamarin.Forms.Dependency(typeof(CloseMethodImplementation))]
namespace XcelerTask.Droid.DependencyServicesImplementation
{
    public class CloseMethodImplementation:ICloseMethod
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}