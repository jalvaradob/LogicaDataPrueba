using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace PruebaTecnica.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        AndroidNotificationManager androidNotificationManager = new AndroidNotificationManager();
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);
            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
            androidNotificationManager.CrearNotificacionLocal(message.GetNotification().Title, message.GetNotification().Body);
        }

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
            Preferences.Set("token", token);
            System.Diagnostics.Debug.WriteLine($"******** TOKEN: ${Preferences.Get("token", "")}");
            sedRegisterToken(token);
        }

        public void sedRegisterToken(string token)
        {

        }
    }
}