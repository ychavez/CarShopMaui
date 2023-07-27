using CarShopMaui.Context;
using Microsoft.Maui.Maps;

namespace CarShopMaui.Views
{
    public class MapCars : ContentPage
    {
        Microsoft.Maui.Controls.Maps.Map map;
        public MapCars()
        {
            Title = "Mapa de vehiculos";
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var location = await Geolocation.Default.GetLocationAsync();
            map = new(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5)));

            map.IsShowingUser = true;

            var carsForSale = await new RestService().GetCars();

            foreach (var car in carsForSale)
            {
                if (car.Lat is null || car.Lon is null)
                    continue;

                map.Pins.Add(
                    new()
                    {
                        Label = car.Description,
                        Location = new Location(car.Lat.Value, car.Lon.Value)
                    });

            }



            Content = map;

        }


    }
}
