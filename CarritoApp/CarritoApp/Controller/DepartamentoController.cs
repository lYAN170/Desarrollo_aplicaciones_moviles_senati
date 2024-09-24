using CarritoApp.Models;
using CarritoApp.Repositories;
using CarritoApp.Services;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace CarritoApp.Controllers
{
    public class DepartamentoController
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoService = new DepartamentoService(departamentoRepository);
        }

        public async Task<List<Departamento>> GetAllDepartamentos()
        {
            var departamentos = await _departamentoService.GetAllDepartamentosAsync();
            return departamentos.ToList();
        }

        public Task<bool> AddDepartamento(Departamento departamento) => _departamentoService.AddDepartamentoAsync(departamento);
        public Task<bool> UpdateDepartamento(Departamento departamento) => _departamentoService.UpdateDepartamentoAsync(departamento);
        public Task<bool> DeleteDepartamento(int id) => _departamentoService.DeleteDepartamentoAsync(id);
    }
}

