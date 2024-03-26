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

        public async Task<ExchangeRateInfo> GetExchangeRateAsync(string baseCurrency, string exChangeRate)
        {
            string api = "WpqzFwMdCM0qwn6y";
            string url = $"https://api.exchangeratesapi.io/latest?access_key={api}&base={baseCurrency}&symbols={exChangeRate}";
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                ExchangeRateInfo info = JsonConvert.DeserializeObject<ExchangeRateInfo>(json);

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
