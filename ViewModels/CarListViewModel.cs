using CarShopMaui.Context;
using CarShopMaui.Messages;
using CarShopMaui.Models;
using CarShopMaui.ViewModels.Base;
using CarShopMaui.Views;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CarShopMaui.ViewModels
{
    public class CarListViewModel : BaseViewModel
    {
        public ICommand RefreshCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SetFavoriteCommand { get; set; }

        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        ObservableCollection<Car> _carList;
        public ObservableCollection<Car> CarsList
        {
            get => _carList;
            set => SetProperty(ref _carList, value);
        }

        public CarListViewModel(INavigation navigation) : base(navigation)
        {
            if (!WeakReferenceMessenger.Default.IsRegistered<RefreshCarsMessage>(""))
                WeakReferenceMessenger.Default.Register<RefreshCarsMessage>("", async (o, s) =>
                {
                    await LoadCars();
                });

            RefreshCommand = new Command(async x => await LoadCars());

            SetFavoriteCommand = new Command(SetFavorite);

            AddCommand = new Command(async () => await Navigation.PushAsync(new AddCar()));

            _ = LoadCars();

            IsBusy = false;
        }

        private async void SetFavorite(object obj)
        {

            if (obj is Button carButton)
                if (carButton.BindingContext is Car car)
                {
                    await new DataContext().SetFavorite(car);
                    await Application.Current.MainPage.DisplayAlert("Test", "Test", "Ok");
                }
        }

        private async Task LoadCars()
        {
            //  if (IsBusy) return;

            IsBusy = true;
            CarsList = new ObservableCollection<Car>(await new RestService().GetCars());

            IsBusy = false;
        }
    }
}
