using KinoPoiskWork.Models;
using KinoPoiskWork.Services.Interfaces;

namespace KinoPoiskWork.Services.Classes;

public class DownloadService : IDownloadService
{
    private readonly IMovieService _movieService;

    public DownloadService(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<MovieModel.Info> DownloadMovie(string title)
    {
        return await _movieService.GetMovieAsync(title);
    }
}