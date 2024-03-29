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
        Task<WeatherInfo.Rootobject> DownloadWeather(string city);
        Task<CountryInfo.Rootobject> DownloadCountry(string country);
        Task<ExchangeRateInfo.Rootobject> DownloadExchange(string baseCurrency);
    }
}
