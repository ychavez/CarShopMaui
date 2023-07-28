using CarShopMaui.ViewModels;

namespace CarShopMaui.Views;

public partial class CarsForSale : ContentPage
{
	public CarsForSale()
	{
		InitializeComponent();

		BindingContext = new CarListViewModel(Navigation);
	}
}