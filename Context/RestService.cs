using System.Text;
using CarShopMaui.Models;
using System.Text.Json;

namespace CarShopMaui.Context
{
    public class RestService
    {
        HttpClient _httpClient;
        Uri _url;

        public RestService()
        {
            _url = new Uri("https://carshopweb20230725151115.azurewebsites.net/api/");
            _httpClient = new();
            _httpClient.BaseAddress = _url;
        }

        public async Task<List<Car>> GetCars()
        {
            var response = await _httpClient.GetAsync("CarsForSalesApi");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Car>>(content,
                    new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase} );
            }

            throw new Exception("Error al tratar de obtener la informacion");
        }

        public async Task SetCar(Car car)
        {
            var json = JsonSerializer.Serialize(car);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("CarsForSalesApi", data);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al tratar de enviar la informacion");

        }
    }
}
