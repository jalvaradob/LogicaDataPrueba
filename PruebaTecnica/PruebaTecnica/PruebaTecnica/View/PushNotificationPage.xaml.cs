using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaTecnica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PushNotificationPage : ContentPage
    {
        PushNotificationModel context = new PushNotificationModel();
        public PushNotificationPage()
        {
            InitializeComponent();
            BindingContext = this.context;
        }
    }
}