using CityAPI.Models;
using CityAPI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CityAPI.Services.Classes
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _client;

        public CurrencyService()
        {
            _client = new HttpClient();
        }

        public async Task<ExchangeRateInfo.Rootobject> GetExchangeRateAsync(string baseCurrency)
        {
            string api = "LTWM0oFjdr337Got65jTMXZanKdV33Za";
            string url = $"https://openexchangerates.org/api/latest.json?app_id={api}&base={baseCurrency}";
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                ExchangeRateInfo.Rootobject info = JsonConvert.DeserializeObject<ExchangeRateInfo.Rootobject>(json);

                return info;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Ошибка: {ex.Message}");
            }
            catch (Newtonsoft.Json.JsonException ex)
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
