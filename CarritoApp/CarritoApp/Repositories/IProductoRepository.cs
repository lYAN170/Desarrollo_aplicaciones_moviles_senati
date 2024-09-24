using CarritoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarritoApp.Repositories
{
    public interface IProductoRepository
    {
        Task<Producto> GetProductoAsync(int id);
        Task<IEnumerable<Producto>> GetAllProductosAsync();
        Task<int> AddProductoAsync(Producto producto);
        Task<int> UpdateProductoAsync(Producto producto);
        Task<bool> DeleteProductoAsync(int id);
    }
}
