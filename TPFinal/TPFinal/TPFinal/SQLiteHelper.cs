using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Models;

namespace TPFinal
{
    public class SQLiteHelper
    {
        private SQLiteAsyncConnection db;
        public SQLiteHelper(String dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Produto>().Wait();
        }

        //Read All Items  
        public Task<List<Produto>> GetItemsAsync()
        {
            return db.Table<Produto>().ToListAsync();
        }

        //Insert and Update new record  
        public Task<int> SaveItemAsync(Produto produto)
        {
            if (produto.Id != 0)
            {
                return db.UpdateAsync(produto);
            }
            else
            {
                return db.InsertAsync(produto);
            }
        }

        //Read Item  
        public Task<Produto> GetItemAsync(int id)
        {
            return db.Table<Produto>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        //Delete  
        public Task<int> DeleteItemAsync(Produto produto)
        {
            return db.DeleteAsync(produto);
        }
    }
}
