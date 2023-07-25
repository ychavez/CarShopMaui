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
            _url = new Uri("URL_BASE");
            _httpClient = new();
            _httpClient.BaseAddress = _url;
        }

        public async Task<List<Car>> GetCars()
        {
            var response = await _httpClient.GetAsync("URL_GET");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Car>>(content);
            }

            throw new Exception("Error al tratar de obtener la informacion");
        }

        public async Task SetCar(Car car)
        {
            var json = JsonSerializer.Serialize(car);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("URL_Post", data);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al tratar de enviar la informacion");

        }
    }
}
