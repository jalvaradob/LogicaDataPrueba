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
            Title = string.Empty;
            Message = string.Empty;
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
            firebaseNotifyRequest.Priority = Constants.priorityPushNotification;
            firebaseNotifyRequest.To = Preferences.Get(Constants.tokenText, "");

            bool response = await pushNotificationService.SendMessage(firebaseNotifyRequest);

            if (response)
            {
                await Application.Current.MainPage.DisplayAlert(Constants.generalSuccessTitle, Constants.notificationSuccess, Constants.generalOK);
                Clear();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(Constants.generalError, Constants.notificationError, Constants.generalOK);
            }

            IsLoading = false;
        }
    }
}
