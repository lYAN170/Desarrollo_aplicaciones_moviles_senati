using SQLite;
using CarritoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Data
{
    public class BaseDatos
    {
        private readonly string _databasePath;
        private SQLiteConnection _connection;

        public BaseDatos(string databasePath)
        {
            _databasePath = databasePath;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _connection = new SQLiteConnection(_databasePath);
            _connection.CreateTable<Usuario>(); 
            Console.WriteLine($"Base de datos inicializada en: {_databasePath}");
        }

        public SQLiteConnection Connection => _connection;

        public Task<Usuario> ObtenerUsuarioAsync(string nombreUsuario, string contrasena)
        {
            return Task.FromResult(_connection.Table<Usuario>()
                        .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena));
        }

        public Task<int> GuardarUsuarioAsync(Usuario usuario)
        {
            return Task.FromResult(_connection.Insert(usuario));
        }

        public Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return Task.FromResult(_connection.Table<Usuario>().ToList());
        }

    }
}



