using System;
using CarritoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Services
{
    public class ProductoService
    {
        private Database _database;

        public ProductoService(string dbPath)
        {
            _database = new Database(dbPath);
        }

        public Task<List<Producto>> GetAll() => _database.GetAllProductosAsync();
        public Task Add(Producto producto) => _database.SaveProductoAsync(producto);
        public Task Update(Producto producto) => _database.SaveProductoAsync(producto);
        public Task Delete(int id) => _database.DeleteProductoAsync(id);
    }
}



