using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;
        private readonly string _dbPath;

        public DatabaseService()
        {
            // Use the full database path
            _dbPath = @"D:\Support\MarchSupport\703516\products.db";

            // Check if file exists before connecting
            if (!File.Exists(_dbPath))
            {
                throw new FileNotFoundException($"Database file not found at {_dbPath}");
            }

            _database = new SQLiteAsyncConnection(_dbPath);
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            return await _database.Table<Products>().ToListAsync();
        }
    }
}
