using CarritoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly SQLiteConnection _connection;

        public DepartamentoRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Departamento>(); 
        }

        public async Task<Departamento> GetDepartamentoAsync(int id)
        {
            return await Task.Run(() => _connection.Table<Departamento>().FirstOrDefault(d => d.Id == id));
        }

        public async Task<IEnumerable<Departamento>> GetAllDepartamentosAsync()
        {
            return await Task.Run(() => _connection.Table<Departamento>().ToList());
        }

        public async Task<int> AddDepartamentoAsync(Departamento departamento)
        {
            return await Task.Run(() => _connection.Insert(departamento));
        }

        public async Task<int> UpdateDepartamentoAsync(Departamento departamento)
        {
            return await Task.Run(() => _connection.Update(departamento));
        }

        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            var departamento = await GetDepartamentoAsync(id);
            if (departamento != null)
            {
                await Task.Run(() => _connection.Delete(departamento));
                return true;
            }
            return false;
        }
    }
}


