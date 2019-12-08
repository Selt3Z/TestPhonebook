using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Foundation;
using UIKit;
using System.Threading.Tasks;

[assembly: Dependency(typeof(App3.iOS.IOSPhone))]
namespace App3.iOS
{
    public class IOSPhone : IPhone
    {
        public Task Call(string phoneNumber)
        {
            var nsurl = new NSUrl(new Uri($"tel:{phoneNumber}").AbsoluteUri);
            if (!string.IsNullOrWhiteSpace(phoneNumber) &&
                    UIApplication.SharedApplication.CanOpenUrl(nsurl))
            {
                UIApplication.SharedApplication.OpenUrl(nsurl);
            }
            return Task.FromResult(true);
        }
    }
}