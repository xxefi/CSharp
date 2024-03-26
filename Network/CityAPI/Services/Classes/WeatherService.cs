using CityAPI.Models;
using CityAPI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.WebRequestMethods;

namespace CityAPI.Services.Classes
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;

        public WeatherService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherInfo> GetWeatherAsync(string city)
        {
            string api = "5caac4f47cdc971f168d07e78c3f8c54";
            string apiurl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={api}&units=metric";

            try
            {
                HttpResponseMessage response = await _client.GetAsync(apiurl);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                WeatherInfo info = JsonConvert.DeserializeObject<WeatherInfo>(json);

                return info;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Ошибка: {ex.Message}");
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JSON Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
       }
    }
}
