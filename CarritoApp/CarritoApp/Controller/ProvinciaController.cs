using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarritoApp.Models;
using CarritoApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarritoApp.Repositories;

namespace CarritoApp.Controllers
{
    public class ProvinciaController
    {
        private readonly ProvinciaService _provinciaService;

        public ProvinciaController(IProvinciaRepository provinciaRepository)
        {
            _provinciaService = new ProvinciaService(provinciaRepository);
        }

        public async Task<List<Provincia>> GetAllProvincias()
        {
            var provincias = await _provinciaService.GetAllProvinciasAsync();
            return provincias.ToList();
        }

        public Task<bool> AddProvincia(Provincia provincia) => _provinciaService.AddProvinciaAsync(provincia);
        public Task<bool> UpdateProvincia(Provincia provincia) => _provinciaService.UpdateProvinciaAsync(provincia);
        public Task<bool> DeleteProvincia(int id) => _provinciaService.DeleteProvinciaAsync(id);
    }
}
