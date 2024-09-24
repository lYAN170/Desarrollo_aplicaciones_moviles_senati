using System;
using Microsoft.Maui.Controls;
using CarritoApp.View;
using CarritoApp.Views;

namespace CarritoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnProductosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductoListPage());
        }

        private async void OnCategoriasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriaListPage());
        }
        private async void OnDepartamentosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DepartamentoPage());
        }

        private async void OnProvinciasClicked(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new ProvinciaPage());
        }


    }
}