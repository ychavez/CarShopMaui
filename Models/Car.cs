namespace CarShopMaui.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string PhotoURL { get; set; }

        public double? Lat  { get; set; }
        public double? Lon { get; set; }
    }
}
