using CarShopMaui.ViewModels.Base;
using SQLite;

namespace CarShopMaui.Models
{
    public class Car : ObservableObject
    {
        int _id;
        [PrimaryKey, AutoIncrement]
        public int Id { get => _id; set => SetProperty(ref _id, value); }

        string _brand;
        public string Brand { get => _brand; set => SetProperty(ref _brand, value); }

        string _model;
        public string Model { get => _model; set => SetProperty(ref _model, value); }

        string _description;
        public string Description { get => _description; set => SetProperty(ref _description,value); }

        decimal _price;
        public decimal Price { get=> _price; set=> SetProperty(ref _price,value); }

        int _year;
        public int Year { get => _year; set=> SetProperty(ref _year, value); }

        string _photoUrl;
        public string PhotoUrl { get => _photoUrl; set=> SetProperty(ref _photoUrl,value); }

        double? _lat;
        public double? Lat { get => _lat; set => SetProperty(ref _lat, value); }

        double? _lon;
        public double? Lon { get=> _lon; set => SetProperty(ref _lon, value); }
    }
}
