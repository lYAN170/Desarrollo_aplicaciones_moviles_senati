using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarritoApp.Models;
using CarritoApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarritoApp.Services
{
    public class ProvinciaService
    {
        private readonly IProvinciaRepository _provinciaRepository;

        public ProvinciaService(IProvinciaRepository provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
        }

        public async Task<Provincia> GetProvinciaAsync(int id) =>
            await _provinciaRepository.GetProvinciaAsync(id);

        public async Task<IEnumerable<Provincia>> GetAllProvinciasAsync() =>
            await _provinciaRepository.GetAllProvinciasAsync();

        public async Task<bool> AddProvinciaAsync(Provincia provincia) =>
            await _provinciaRepository.AddProvinciaAsync(provincia) > 0;

        public async Task<bool> UpdateProvinciaAsync(Provincia provincia) =>
            await _provinciaRepository.UpdateProvinciaAsync(provincia) > 0;

        public async Task<bool> DeleteProvinciaAsync(int id) =>
            await _provinciaRepository.DeleteProvinciaAsync(id);
    }
}


