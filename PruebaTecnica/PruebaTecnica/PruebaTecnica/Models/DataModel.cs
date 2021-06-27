using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models
{
    public class DataModel : INotifyPropertyChanged
    {
        //Handle property change
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int id;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string data1;

        public string Data1
        {
            get { return data1; }
            set { data1 = value; OnPropertyChanged(); }
        }

        private string data2;

        public string Data2
        {
            get { return data2; }
            set { data2 = value; OnPropertyChanged(); }
        }

        private bool isLoading = false;

        public bool IsLoading
        {
            get { return isLoading = false; }
            set { isLoading = value; OnPropertyChanged(); }
        }

        public DataModel() {}

        public DataModel(int id, string data1, string data2)
        {
            this.id = id;
            this.data1 = data1;
            this.data2 = data2;
        }

        public static implicit operator Task<object>(DataModel v)
        {
            throw new NotImplementedException();
        }
    }
}
