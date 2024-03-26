using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityAPI.Models
{
    public class ExchangeRateInfo
    {
        [JsonPropertyName("base")]
        public string Base {  get; set; }
        [JsonPropertyName("date")]
        public DateTime Date {  get; set; }
        [JsonPropertyName("rates")]
        public double[] Rates {  get; set; }

    }
}
