using PruebaTecnica.Models;
using PruebaTecnica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaTecnica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PushNotificationPage : ContentPage
    {
        PushNotificationViewModel context = new PushNotificationViewModel();
        public PushNotificationPage()
        {
            InitializeComponent();
            BindingContext = this.context;
            //System.Diagnostics.Debug.WriteLine($"******** TOKEN: ${Preferences.Get("token", "")}");
        }
    }
}