using PruebaTecnica.Models;
using PruebaTecnica.Services;
using PruebaTecnica.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaTecnica.ViewModel
{
    public class DataViewModel : DataModel
    {
        public DataModel data { get; set; }
        DataModel dataModel;
        private DataService dataService = new DataService();

        public DataViewModel()
        {
            data = dataService.GetLastData().Result;
            SaveCommand = new Command(async() => await this.Save(), () => !this.IsLoading);
            ClearCommand = new Command(this.Clear, () => !this.IsLoading);
        }

        /// <summary>
        /// Save form command
        /// </summary>
        public Command SaveCommand { get; set; }

        /// <summary>
        /// Clear form command
        /// </summary>
        public Command ClearCommand { get; set; }

        private async Task Save()
        {
            this.IsLoading = true;

            dataModel = new DataModel()
            {
                Data1 = this.Data1,
                Data2 = this.Data2
            };

            dataService.SaveData(dataModel);

            await Application.Current.MainPage.DisplayAlert(Constants.generalSuccessTitle, Constants.generalSavedData, Constants.generalOK);
            Clear();

            this.IsLoading = false;

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void Clear()
        {
            Data1 = string.Empty;
            Data2 = string.Empty;
            Id = 0;
        }
    }
}
