using System;
using CarritoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarioAsync(string nombreUsuario);
        Task<bool> RegistrarUsuarioAsync(string nombreUsuario, string contrasena);
        Task<bool> AutenticarUsuarioAsync(string nombreUsuario, string contrasena);
    }
}