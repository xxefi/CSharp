using System.Net.Http;
using System.Windows;
using KinoPoiskWork.Models;
using KinoPoiskWork.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace KinoPoiskWork.Services.Classes;

public class MovieService : IMovieService
{
    private readonly HttpClient _httpClient;

    public MovieService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<MovieModel.Info> GetMovieAsync(string movie)
    {
        string api = "9b78fa7a";
        string url = $"http://www.omdbapi.com/?apikey={api}&t={movie}";

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            MovieModel.Info info = JsonConvert.DeserializeObject<MovieModel.Info>(json);
            return info;
        }
        catch (HttpRequestException http)
        {
            MessageBox.Show($"HTTP: {http.Message}");
        }
        catch (SqlException sql)
        {
            MessageBox.Show($"SQL: {sql.Message}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        return null;
    }
}