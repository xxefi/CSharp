using CityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAPI.Services.Interfaces
{
    public interface IDownloadService
    {
        Task<WeatherInfo> DownloadWeather(string city);
        Task<CountryInfo> DownloadCountry(string country);
        Task<ExchangeRateInfo> DownloadExchange(string baseCurrency, string targetCurrency);
    }
}
