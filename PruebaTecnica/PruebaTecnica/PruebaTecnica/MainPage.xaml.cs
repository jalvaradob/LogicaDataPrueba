using PruebaTecnica.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaTecnica
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void BtnPage1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new DataPage()));
        }
        private async void BtnPage2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new DataPage()));
        }
    }
}
