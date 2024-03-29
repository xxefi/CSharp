using KinoPoiskWork.Models;

namespace KinoPoiskWork.Services.Interfaces;

public interface IDownloadService
{
    Task<MovieModel.Info> DownloadMovie(string title);
}