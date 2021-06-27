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
            BindingContext = this.context;

            this.lblId.Text = this.context.data != null ? this.context.data.Id.ToString() : "-";
            this.lblData1.Text = this.context.data != null ? this.context.data.Data1 : "-";
            this.lblData2.Text = this.context.data != null ? this.context.data.Data2 : "-";
        }

        
    }
}