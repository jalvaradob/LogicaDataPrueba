using PruebaTecnica.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Data
{
    public class SQLiteManager
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteManager(string dbPath)
        {
            this.db = new SQLiteAsyncConnection(dbPath);
            //this.db.CreateTableAsync<DataModel>().Wait();
        }

        public async Task<DataModel> GetLastData()
        {
            return this.db.Table<DataModel>().OrderByDescending(x => x.Id).FirstOrDefaultAsync().Result;
        }

        public Task<int> InsertData(DataModel request)
        {
            if (request != null)
            {
                return this.db.InsertAsync(request);
            }
            else
            {
                return null;
            }
        }
    }
}
