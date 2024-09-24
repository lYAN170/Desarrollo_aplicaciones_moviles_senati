using CarritoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<Departamento> GetDepartamentoAsync(int id);
        Task<IEnumerable<Departamento>> GetAllDepartamentosAsync();
        Task<int> AddDepartamentoAsync(Departamento departamento);
        Task<int> UpdateDepartamentoAsync(Departamento departamento);
        Task<bool> DeleteDepartamentoAsync(int id);
    }
}