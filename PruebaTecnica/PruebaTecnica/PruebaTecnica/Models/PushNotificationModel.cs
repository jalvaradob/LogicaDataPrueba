using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PruebaTecnica.Models
{
    public class PushNotificationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChange(); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChange(); }
        }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChange(); }
        }


        public PushNotificationModel() {}

        public PushNotificationModel(string title, string message, bool isLoading = false)
        {
            Title = title;
            Message = message;
            IsLoading = isLoading;
        }
    }
}
