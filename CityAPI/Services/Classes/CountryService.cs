using CityAPI.Models;
using CityAPI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace CityAPI.Services.Classes
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _client;

        public CountryService()
        {
            _client = new HttpClient();
        }

        public async Task<CountryInfo> GetCountryAsync(string country)
        {
            string url = $"https://restcountries.com/v3.1/capital/{country}";
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                CountryInfo[] info = JsonConvert.DeserializeObject<CountryInfo[]>(json);

                return info[0];
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
