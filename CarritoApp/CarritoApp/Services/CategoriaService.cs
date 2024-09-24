using CarritoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Services
{
    public class CategoriaService
    {
        private readonly SQLiteAsyncConnection _database;

        public CategoriaService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Categoria>().Wait();
        }

        public Task<List<Categoria>> GetAll()
        {
            return _database.Table<Categoria>().ToListAsync();
        }

        public Task<Categoria> GetById(int id)
        {
            return _database.Table<Categoria>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<int> Add(Categoria categoria)
        {
            return _database.InsertAsync(categoria);
        }

        public Task<int> Update(Categoria categoria)
        {
            return _database.UpdateAsync(categoria);
        }

        public Task<int> Delete(int id)
        {
            return _database.DeleteAsync<Categoria>(id);
        }
    }
}
