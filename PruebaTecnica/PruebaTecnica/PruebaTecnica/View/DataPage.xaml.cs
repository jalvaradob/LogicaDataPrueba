using PruebaTecnica.Services;
using PruebaTecnica.ViewModel;
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
    public partial class DataPage : ContentPage
    {
        DataViewModel context = new DataViewModel();
        DataService dataService = new DataService();
        public DataPage()
        {
            InitializeComponent();
            BindingContext = context;

            lblId.Text = context.data != null ? context.data.Id.ToString() : "-";
            lblData1.Text = context.data != null ? context.data.Data1 : "-";
            lblData2.Text = context.data != null ? context.data.Data2 : "-";
        }

        
    }
}