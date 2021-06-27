using PruebaTecnica.Data;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services
{
    public class DataService
    {
        public ObservableCollection<DataModel> data { get; set; }
        
        private static SQLiteManager db;
        public static SQLiteManager DB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "assessment.db3"));
                }

                return db;
            }
        }

        public DataService()
        {
            //Singleton object
            if (data == null)
            {
                data = new ObservableCollection<DataModel>();
            }
        }

        public async Task<DataModel> GetLastData()
        {
            return await DB.GetLastData();
        }

        public void SaveData(DataModel request)
        {
            int id = DB.InsertData(request).Result;
        }

        public void Update(DataModel request)
        {
            foreach (var item in this.data)
            {
                if (item.Id == request.Id)
                {
                    item.Data1 = request.Data1;
                    item.Data2 = request.Data2;
                }
            }
        }

        public void Delete(DataModel request)
        {
            this.data.Remove(request);
        }
    }
}
