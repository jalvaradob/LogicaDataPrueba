using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaTecnica.ViewModel
{
    public class PushNotificationViewModel : PushNotificationModel
    {
        public PushNotificationModel pushNotification { get; set; }
        PushNotificationModel pushNotificationModel;
        
        public PushNotificationViewModel()
        {
            SendMessageCommand = new Command(async () => await SendMessage(), () => !IsLoading);
        }

        public Command SendMessageCommand { get; set; }

        /// <summary>
        /// Send push notification
        /// </summary>
        /// <returns></returns>
        private async Task SendMessage()
        {
            IsLoading = true;

            IsLoading = false;
        }
    }
}
