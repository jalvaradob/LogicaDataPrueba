using PruebaTecnica.Models;
using PruebaTecnica.Services;
using PruebaTecnica.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PruebaTecnica.ViewModel
{
    public class PushNotificationViewModel : PushNotificationModel
    {
        public PushNotificationModel pushNotification { get; set; }
        PushNotificationService pushNotificationService;
        
        public PushNotificationViewModel()
        {
            SendMessageCommand = new Command(async () => await SendMessage(), () => !IsLoading);
            ClearCommand = new Command(this.Clear, () => !this.IsLoading);
        }

        public Command SendMessageCommand { get; set; }

        /// <summary>
        /// Clear form command
        /// </summary>
        public Command ClearCommand { get; set; }

        private void Clear()
        {
            Title = "";
            Message = "";
        }

        /// <summary>
        /// Send push notification
        /// </summary>
        /// <returns></returns>
        private async Task SendMessage()
        {
            IsLoading = true;

            pushNotificationService = new PushNotificationService();

            FirebaseNotifyRequest firebaseNotifyRequest = new FirebaseNotifyRequest();
            Notification notification = new Notification();
            notification.Title = Title;
            notification.Body = Message;
            firebaseNotifyRequest.Notification = notification;
            firebaseNotifyRequest.Priority = "high";
            firebaseNotifyRequest.To = Preferences.Get(Constants.tokenLabel, "");

            bool response = await pushNotificationService.SendMessage(firebaseNotifyRequest);

            if (response)
            {
                await Application.Current.MainPage.DisplayAlert("Sucess", "The notification was sent", "OK");
                Clear();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The notification could not be sent", "OK");
            }

            IsLoading = false;
        }
    }
}
