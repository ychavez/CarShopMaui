using CarShopMaui.Context;

namespace CarShopMaui.Views;

public partial class FavoriteCars : ContentPage
{
	public FavoriteCars()
	{
		InitializeComponent();
	}
	
	private async Task LoadData() 
	{
	  CarList.ItemsSource = await new DataContext().GetFavorites();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await LoadData();
    }

}