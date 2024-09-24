using CarritoApp.Models;
using CarritoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Controller
{
    public class LoginController
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<bool> Autenticar(string nombreUsuario, string contrasena)
        {
            return await _usuarioService.AutenticarUsuarioAsync(nombreUsuario, contrasena);
        }

        public async Task<bool> Registrar(string nombreUsuario, string contrasena)
        {
            return await _usuarioService.RegistrarUsuarioAsync(nombreUsuario, contrasena);
        }
    }
}