using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoworkerPage : ContentPage
	{
		public CoworkerPage ()
		{
			InitializeComponent ();
            Image image = this.FindByName<Image>("PhotoImage");
            TapGestureRecognizer imageTap = new TapGestureRecognizer();
            imageTap.Tapped += ToPhoto;
            image.GestureRecognizers.Add(imageTap);
        }

        private async void ToPhoto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PhotoFullscreen(BindingContext));
        }

        private void Call(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall(this.FindByName<Entry>("PhoneNumber").Text);
            //await DependencyService.Get<IPhone>()?.Call(this.FindByName<Entry>("PhoneNumber").Text);
        }
        private void SendSMS(object sender, EventArgs e)
        {
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms(this.FindByName<Entry>("PhoneNumber").Text, "");
        }
        private void SendEmail(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail(this.FindByName<Entry>("Email").Text, "", "");
            }
        }


        private void SaveCoworker(object sender, EventArgs e)
        {
            var coworker = (Coworker)BindingContext;
            if (!String.IsNullOrEmpty(coworker.FirstName) && !String.IsNullOrEmpty(coworker.LastName))
            {
                App.Database.SaveItem(coworker);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteCoworker(object sender, EventArgs e)
        {
            var coworker = (Coworker)BindingContext;
            App.Database.DeleteItem(coworker.Id);
            this.Navigation.PopAsync();
        }
    }
}