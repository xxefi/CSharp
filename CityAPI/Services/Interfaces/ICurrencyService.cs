using CityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAPI.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<ExchangeRateInfo.Rootobject> GetExchangeRateAsync(string baseCurrency);
    }
}
