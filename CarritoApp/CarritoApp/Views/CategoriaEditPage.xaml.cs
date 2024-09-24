using CarritoApp.Models;
using CarritoApp.Controller;

namespace CarritoApp.View;

public partial class CategoriaEditPage : ContentPage
{
    private CategoriaController _categoriaController;
    private Categoria _categoria;

    public CategoriaEditPage(Categoria categoria = null)
    {
        InitializeComponent();
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
        _categoriaController = new CategoriaController(dbPath);
        _categoria = categoria ?? new Categoria();
        if (_categoria.Id != 0)
        {
            NombreEntry.Text = _categoria.Nombre;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _categoria.Nombre = NombreEntry.Text;

        if (_categoria.Id == 0)
        {
            await _categoriaController.AddCategoria(_categoria);
        }
        else
        {
            await _categoriaController.UpdateCategoria(_categoria);
        }

        await Navigation.PopAsync();
    }
}

