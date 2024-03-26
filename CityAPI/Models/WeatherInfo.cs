using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityAPI.Models
{
    public class WeatherInfo
    {
        [JsonProperty("description")]
        public string Description {  get; set; }
        [JsonProperty("temperature")]
        public double Temperature {  get; set; }
        [JsonProperty("humidity")]
        public double Humidity {  get; set; }
    }
}
