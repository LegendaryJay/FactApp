
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace FactApp
{
    public class FactDbContext
    {
        readonly SQLiteAsyncConnection database;

        public FactDbContext(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<FactData>().Wait();
        }

        public Task<List<FactData>> GetItemsAsync()
        {
            return database.Table<FactData>().ToListAsync();
        }

        public Task<int> SaveItemAsync(FactData item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(FactData item)
        {
            return database.DeleteAsync(item);
        }
    }
}