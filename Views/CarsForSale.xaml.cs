using CarShopMaui.Context;

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
}