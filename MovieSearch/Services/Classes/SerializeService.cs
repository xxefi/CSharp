using MovieSearch.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace MovieSearch.Services.Classes
{
    public class SerializeService : ISerializeService
    {
        public async Task<T> DeserializeAsync<T>(string json)
        {
            try
            {
                return await JsonConvert.DeserializeObjectAsync<T>(json);
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                MessageBox.Show($"JSON Deserialize Error: {ex.Message}");
                throw;
            }
        }
        public async Task<string> SerializeAsync<T>(object? obj)
        {
            if (obj != null)
            {
                return await JsonConvert.SerializeObjectAsync(obj);
            }
            throw new NullReferenceException("Object is null");
        }
    }
}
