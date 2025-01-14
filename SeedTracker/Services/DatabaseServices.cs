using SQLite;
using SeedTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedTracker.Services
{
    internal class DatabaseServices
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseServices()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SeedTracker.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Seed>().Wait();
        }

        public Task<List<Seed>> GetSeedsAsync()
        {
            return _database.Table<Seed>().ToListAsync();
        }

        public Task<int> SaveSeedAsync(Seed seed)
        {
            if (seed.Id != 0)
            {
                return _database.UpdateAsync(seed);
            }
            else
            {
                return _database.InsertAsync(seed);
            }
        }

        public Task<int> DeleteSeedAsync(Seed seed)
        {
            return _database.DeleteAsync(seed);
        }
    }
}
