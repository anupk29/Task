using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XcelerTask.DependencyServices;

namespace XcelerTask.Models
{
    public static class AlertMessages
    {
        public static void ShowAlert(string message)
        {
            DependencyService.Get<IAlertMessages>().ShowAlert(message);

        }
    }
}
