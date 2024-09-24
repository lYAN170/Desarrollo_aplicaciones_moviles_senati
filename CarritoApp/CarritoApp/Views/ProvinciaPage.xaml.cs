using CarritoApp.Models;
using CarritoApp.Repositories;
using CarritoApp.Services;
using Microsoft.Maui.Controls;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarritoApp.Views
{
    public partial class ProvinciaPage : ContentPage
    {
        private readonly DepartamentoService _departamentoService;
        private readonly ProvinciaService _provinciaService;

        public ProvinciaPage()
        {
            InitializeComponent();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "provincias.db3");
            _departamentoService = new DepartamentoService(new DepartamentoRepository(new SQLiteConnection(dbPath)));
            _provinciaService = new ProvinciaService(new ProvinciaRepository(new SQLiteConnection(dbPath)));
            LoadDepartamentos();
            LoadProvincias();
        }

        private async void LoadDepartamentos()
        {
            var departamentos = await _departamentoService.GetAllDepartamentosAsync();
            DepartamentoPicker.ItemsSource = departamentos.ToList(); 
            DepartamentoPicker.ItemDisplayBinding = new Binding("NombreDepartamento");
        }

        private async void LoadProvincias()
        {
            var provincias = await _provinciaService.GetAllProvinciasAsync();
            ProvinciasListView.ItemsSource = provincias;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var nombre = NombreProvinciaEntry.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                await DisplayAlert("Error", "Por favor, ingrese el nombre de la provincia.", "OK");
                return;
            }

            var selectedDepartamentoId = GetSelectedDepartamentoId();
            if (selectedDepartamentoId == 0)
            {
                await DisplayAlert("Error", "Por favor, seleccione un departamento.", "OK");
                return;
            }

            var provincia = new Provincia
            {
                NombreProvincia = nombre,
                DepartamentoId = selectedDepartamentoId
            };

            await _provinciaService.AddProvinciaAsync(provincia);
            NombreProvinciaEntry.Text = string.Empty; 
            LoadProvincias(); 
        }

        private int GetSelectedDepartamentoId()
        {
            var selectedDepartamento = (Departamento)DepartamentoPicker.SelectedItem;
            return selectedDepartamento?.Id ?? 0;
        }

        private async void OnProvinceTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var selectedProvincia = (Provincia)e.Item;
                NombreProvinciaEntry.Text = selectedProvincia.NombreProvincia;
            }
        }
    }
}
