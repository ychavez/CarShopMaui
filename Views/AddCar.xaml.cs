using CarShopMaui.ViewModels;

namespace CarShopMaui.Views;

public partial class AddCar : ContentPage
{
    public AddCar()
    {
        InitializeComponent();

        BindingContext = new AddCarViewModel(Navigation);
    }
}