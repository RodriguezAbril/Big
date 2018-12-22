using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using BIG.Mobile.Views;


namespace BIG.Mobile.Views
{
    public class ProductDatabase
    {
       








        //parte de SQLite 

        readonly SQLiteAsyncConnection database;

        public ProductDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Product_Catalog>().Wait();
        }
   

        public Task<List<Product_Catalog>> GetProductAsync()
        {
            return database.Table<Product_Catalog>().ToListAsync();
            
        }

        public Task<Product_Catalog> GetProductAsync(string id)
        {
            return database.Table<Product_Catalog>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

    }
}
