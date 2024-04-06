using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch.Services.Interfaces
{
    public interface ISerializeService
    {
        Task <string> SerializeAsync<T> (object? obj);
        Task<T> DeserializeAsync<T> (string json);    
    }
}
