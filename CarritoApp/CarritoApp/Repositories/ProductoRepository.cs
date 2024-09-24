using CarritoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarritoApp.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly SQLiteConnection _connection;

        public ProductoRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Producto>();
        }

        public async Task<Producto> GetProductoAsync(int id)
        {
            return await Task.Run(() => _connection.Table<Producto>().FirstOrDefault(p => p.Id == id));
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await Task.Run(() => _connection.Table<Producto>().ToList());
        }

        public async Task<int> AddProductoAsync(Producto producto)
        {
            return await Task.Run(() => _connection.Insert(producto));
        }

        public async Task<int> UpdateProductoAsync(Producto producto)
        {
            return await Task.Run(() => _connection.Update(producto));
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            var producto = await GetProductoAsync(id);
            if (producto != null)
            {
                await Task.Run(() => _connection.Delete(producto));
                return true;
            }
            return false;
        }
    }
}
