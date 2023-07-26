using CarShopMaui.Context;
using CarShopMaui.Models;

namespace CarShopMaui.Views;

public partial class AddCar : ContentPage
{
	public AddCar()
	{
		InitializeComponent();
	}

    private async void btnAceptar_Clicked(object sender, EventArgs e)
    {

		Car car = new()
		{
			Brand = entryMarca.Text,
			Description = entryDescripcion.Text,
			Model = entryModelo.Text,
			Year = int.Parse(entryAnio.Text),
			PhotoUrl = "https://img.freepik.com/vector-premium/icono-aislado-vector-coche-rojo-emoji-ilustracion-emoticono-vector-vehiculo_603823-666.jpg",
			Price = decimal.Parse(entryPrecio.Text)
		};

		await new RestService().SetCar(car);

		await Navigation.PopAsync();
    }
}