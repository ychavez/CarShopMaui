using CarShopMaui.Context;
using CarShopMaui.Messages;
using CarShopMaui.Models;
using CarShopMaui.ViewModels.Base;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace CarShopMaui.ViewModels
{
    public class AddCarViewModel : BaseViewModel
    {
        public Car CarModel { get; set; }
        public ICommand AddCarCommand { get; set; }
        public ICommand TakePhotoCommand { get; set; }

        public AddCarViewModel(INavigation navigation) : base(navigation)
        {
            CarModel = new Car();
            AddCarCommand = new Command(async x => await AddCar());
            TakePhotoCommand = new Command(async x => await TakePhoto());
        }

        private async Task TakePhoto()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            CarModel.PhotoUrl = photo.FullPath;

            var photoStream = await photo.OpenReadAsync();
        }

        private async Task AddCar()
        {
            var location = await Geolocation.Default.GetLocationAsync();
            CarModel.Lon = location.Longitude;
            CarModel.Lat = location.Latitude;

            await new RestService().SetCar(CarModel);
            await Navigation.PopAsync();

            WeakReferenceMessenger.Default.Send(new RefreshCarsMessage());

        }
    }
}
