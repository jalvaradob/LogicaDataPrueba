using PruebaTecnica.Models;
using PruebaTecnica.Services;
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
            UpdateCommand = new Command(async () => await this.Update(), () => !this.IsLoading);
            DeleteCommand = new Command(async () => await this.Delete(), () => !this.IsLoading);
            GetCommand = new Command(async () => await this.Get(), () => !this.IsLoading);
            ClearCommand = new Command(this.Clear, () => !this.IsLoading);
        }

        /// <summary>
        /// Save form command
        /// </summary>
        public Command SaveCommand { get; set; }

        /// <summary>
        /// Update form command
        /// </summary>
        public Command UpdateCommand { get; set; }

        /// <summary>
        /// Delete form command
        /// </summary>
        public Command DeleteCommand { get; set; }

        /// <summary>
        /// Clear form command
        /// </summary>
        public Command ClearCommand { get; set; }
        public Command GetCommand { get; set; }

        private async Task Get()
        {
            this.IsLoading = true;

            var dd = dataService.GetLastData().Result;
            this.IsLoading = false;
        }

        private async Task Save()
        {
            this.IsLoading = true;

            dataModel = new DataModel()
            {
                Data1 = this.Data1,
                Data2 = this.Data2
            };

            dataService.SaveData(dataModel);

            await Task.Delay(2000);

            await Application.Current.MainPage.DisplayAlert("Sucess", "Data saved", "OK");
            Clear();

            this.IsLoading = false;

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async Task Update()
        {
            this.IsLoading = true;

            dataModel = new DataModel()
            {
                Data1 = this.Data1,
                Data2 = this.Data2,
                Id = this.Id
            };

            dataService.Update(dataModel);
            this.IsLoading = false;
        }

        private async Task Delete()
        {
            this.IsLoading = true;
            dataService.Delete(this);
            this.IsLoading = false;
        }

        private void Clear()
        {
            this.Data1 = "";
            this.Data2 = "";
            this.Id = 0;
        }

        private void ShowMessage(string message)
        {
            
        }
    }
}
