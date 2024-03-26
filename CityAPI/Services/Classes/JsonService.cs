using CityAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CityAPI.Services.Classes
{
    public class JsonService : IJsonService
    {
        
        public async Task<T> Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json) ?? throw new NullReferenceException("null");
        }
    }
}
