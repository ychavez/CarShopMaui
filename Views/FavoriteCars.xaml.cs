using CarShopMaui.Context;
using CarShopMaui.Models;

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

    private async void SwipeItem_Invoked(object sender, EventArgs e)
    {
        var car = (Car)((SwipeItem)sender).BindingContext;

        var result = new DataContext().RemoveFavorite(car.Id);

        await LoadData();
    }

}