
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace CarShopMaui.Views
{
    public class MainTabbedPage : Microsoft.Maui.Controls.TabbedPage
    {
        public MainTabbedPage()
        {
            Children.Add(new CarsForSale());
            Children.Add(new FavoriteCars());
            Children.Add(new MapCars());

            On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
    }
}
