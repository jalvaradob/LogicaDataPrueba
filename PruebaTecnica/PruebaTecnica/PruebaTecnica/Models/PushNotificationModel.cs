using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Models
{
    public class PushNotificationModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsLoading { get; set; }

        public PushNotificationModel() {}

        public PushNotificationModel(string title, string message, bool isLoading = false)
        {
            Title = title;
            Message = message;
            IsLoading = isLoading;
        }
    }
}
