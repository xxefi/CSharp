using MovieSearch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieSearch.Services.Classes
{
    public class DownloadService : IDownloadService
    {
        public async Task<string> DownloadJsonAsync(string url)
        {
            HttpClient client = new();
            try
            {
                var res = await client.GetStringAsync(url);
                return res;
            }
            catch (HttpRequestException http)
            {
                MessageBox.Show($"HTTP Requset Error: {http.Message}");
                throw;
            }
        }
    }
}
