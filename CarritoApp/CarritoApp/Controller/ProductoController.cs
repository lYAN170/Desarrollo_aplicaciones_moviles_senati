using CarritoApp.Models;
using CarritoApp.Services;
using CarritoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Controller
{
    public class ProductoController
    {
        private readonly ProductoService _productoService;

        public ProductoController(string dbPath)
        {
            _productoService = new ProductoService(dbPath);
        }

        public Task<List<Producto>> GetAllProductos() => _productoService.GetAll();
        public Task AddProducto(Producto producto) => _productoService.Add(producto);
        public Task UpdateProducto(Producto producto) => _productoService.Update(producto);
        public Task DeleteProducto(int id) => _productoService.Delete(id);
    }
} 