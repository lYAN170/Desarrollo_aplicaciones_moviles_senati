using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarritoApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarritoApp.Repositories
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly SQLiteConnection _connection;

        public ProvinciaRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Provincia>(); 
        }

        public async Task<Provincia> GetProvinciaAsync(int id)
        {
            return await Task.Run(() => _connection.Table<Provincia>().FirstOrDefault(p => p.Id == id));
        }

        public async Task<IEnumerable<Provincia>> GetAllProvinciasAsync()
        {
            return await Task.Run(() => _connection.Table<Provincia>().ToList());
        }

        public async Task<int> AddProvinciaAsync(Provincia provincia)
        {
            return await Task.Run(() => _connection.Insert(provincia));
        }

        public async Task<int> UpdateProvinciaAsync(Provincia provincia)
        {
            return await Task.Run(() => _connection.Update(provincia));
        }

        public async Task<bool> DeleteProvinciaAsync(int id)
        {
            var provincia = await GetProvinciaAsync(id);
            if (provincia != null)
            {
                await Task.Run(() => _connection.Delete(provincia));
                return true;
            }
            return false;
        }
    }
}
