using CarShopMaui.Context;
using CarShopMaui.Models;

namespace CarShopMaui.Views;

public partial class CarsForSale : ContentPage
{
	public CarsForSale()
	{
		InitializeComponent();
		
	}

    private async Task LoadList()
    {
        CarList.ItemsSource = await new RestService().GetCars();
    }

    protected override async void OnAppearing()
    {
        await LoadList();
        base.OnAppearing();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCar());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var favoriteResult = await 
            new DataContext().SetFavorite((Car)(((Button)sender).BindingContext));

        await DisplayAlert("Auto favorito", favoriteResult ?
            "Auto agregado correctamente" : "El auto ya se encuentra en favoritos", "Ok");

    }
}