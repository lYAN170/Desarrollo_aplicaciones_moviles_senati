using CarritoApp.Models;
using CarritoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Services
{
    public class DepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<Departamento> GetDepartamentoAsync(int id) =>
            await _departamentoRepository.GetDepartamentoAsync(id);

        public async Task<IEnumerable<Departamento>> GetAllDepartamentosAsync() =>
            await _departamentoRepository.GetAllDepartamentosAsync();

        public async Task<bool> AddDepartamentoAsync(Departamento departamento) =>
            await _departamentoRepository.AddDepartamentoAsync(departamento) > 0;

        public async Task<bool> UpdateDepartamentoAsync(Departamento departamento) =>
            await _departamentoRepository.UpdateDepartamentoAsync(departamento) > 0;

        public async Task<bool> DeleteDepartamentoAsync(int id) =>
            await _departamentoRepository.DeleteDepartamentoAsync(id);
    }
}