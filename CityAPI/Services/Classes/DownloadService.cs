using CityAPI.Models;
using CityAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CityAPI.Services.Classes
{
    public class DownloadService : IDownloadService
    {
        private readonly IWeatherService _weatherService;
        private readonly ICountryService _countryService;
        private readonly ICurrencyService _currencyService;

        public DownloadService(IWeatherService weatherService, ICountryService countryService, ICurrencyService currencyService)
        {
            _weatherService = weatherService;
            _countryService = countryService;
            _currencyService = currencyService;
        }

        public async Task<WeatherInfo.Rootobject> DownloadWeather(string city)
        {
            return await _weatherService.GetWeatherAsync(city);
        }

        public async Task<ExchangeRateInfo.Rootobject> DownloadExchange(string baseCurrency)
        {
            return await _currencyService.GetExchangeRateAsync(baseCurrency);
        }

        public async Task<CountryInfo.Rootobject> DownloadCountry(string country)
        {
            return await _countryService.GetCountryAsync(country);
        }
    }
}
