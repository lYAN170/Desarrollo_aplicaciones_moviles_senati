using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarritoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarritoApp.Repositories
{
    public interface IProvinciaRepository
    {
        Task<Provincia> GetProvinciaAsync(int id);
        Task<IEnumerable<Provincia>> GetAllProvinciasAsync();
        Task<int> AddProvinciaAsync(Provincia provincia);
        Task<int> UpdateProvinciaAsync(Provincia provincia);
        Task<bool> DeleteProvinciaAsync(int id);
    }
}
