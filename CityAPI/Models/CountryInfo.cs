using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityAPI.Models
{
    public class CountryInfo
    {
        [JsonPropertyName("name")]
        public string Name {  get; set; }
        [JsonPropertyName("capital")]
        public string Capital {  get; set; }
        [JsonPropertyName("currencies")]
        public string[] Currencies {  get; set; }
    }
}
