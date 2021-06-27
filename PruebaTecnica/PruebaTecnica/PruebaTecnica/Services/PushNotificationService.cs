using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PruebaTecnica.Services
{
    public class PushNotificationService
    {
        public ObservableCollection<PushNotificationModel> pushNotification { get; set; }

        public PushNotificationService()
        {
            if (pushNotification == null)
            {
                pushNotification = new ObservableCollection<PushNotificationModel>();
            }
        }

        public void SendMessage(PushNotificationModel request)
        {

        }
    }
}
