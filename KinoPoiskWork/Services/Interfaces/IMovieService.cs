using KinoPoiskWork.Migrations;
using KinoPoiskWork.Models;

namespace KinoPoiskWork.Services.Interfaces;

public interface IMovieService
{ 
    Task<MovieModel.Info> GetMovieAsync(string movie);
}