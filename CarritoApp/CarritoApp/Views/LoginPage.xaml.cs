
using CarritoApp.Controller;
using System;
using Microsoft.Maui.Controls;
namespace CarritoApp.View;




public partial class LoginPage : ContentPage
{
    private readonly LoginController _loginController;

    public LoginPage(LoginController loginController)
    {
        InitializeComponent();
        _loginController = loginController;
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        var nombreUsuario = NombreUsuarioEntry.Text;
        var contrasena = ContrasenaEntry.Text;

        if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
        {
            MensajeLabel.Text = "Por favor, complete todos los campos.";
            MensajeLabel.IsVisible = true;
            return;
        }

        if (await _loginController.Autenticar(nombreUsuario, contrasena))
        {
            await DisplayAlert("Éxito", "¡Inicio de sesión exitoso!", "OK");

            await Navigation.PushAsync(new MainPage()); 
        }
        else
        {
            MensajeLabel.Text = "Nombre de usuario o contraseña incorrectos.";
            MensajeLabel.IsVisible = true;
        }
    }
    private async void OnCreateAccountButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage(_loginController));
    }
}
