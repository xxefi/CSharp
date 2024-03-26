using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAPI.Services.Interfaces
{
    public interface IJsonService
    {
        public Task<T> Deserialize<T>(string json);
    }
}
