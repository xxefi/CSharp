using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using KinoPoiskWork.Models;
using KinoPoiskWork.Services.Interfaces;
using KinoPoiskWork.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Data.SqlClient;

namespace KinoPoiskWork.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDownloadService _downloadService;
        private readonly MovieDbContext _context;
        private string _searchText;
        private ObservableCollection<MovieModel.Info> _movie;
        private MovieModel.Info _selectedMovie;
        
        public string SearchText
        {
            get => _searchText;
            set => Set(ref _searchText, value);
        }

        public ObservableCollection<MovieModel.Info> Movie
        {
            get => _movie;
            set => Set(ref _movie, value);
        }

        public MovieModel.Info SelectedMovie
        {
            get => _selectedMovie;
            set => Set(ref _selectedMovie, value);
        }

        public MainViewModel(IDownloadService downloadService, MovieDbContext context)
        {
            _downloadService = downloadService;
            _context = context;
            Movie = new ObservableCollection<MovieModel.Info>();
        }

       

        public RelayCommand SearchCommand => new(async () =>
        {
            try
            {
                Movie = new ObservableCollection<MovieModel.Info>
                {
                    await _downloadService.DownloadMovie(SearchText)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ViewModel: {ex.Message}");
            }
           
        });

        public RelayCommand SaveMovie
        {
            get => new(
                async () =>
                {
                    try
                    {
                        var existingMovie = _context.Movies.FirstOrDefault(m => m.info.title == _selectedMovie.title);
                        if (existingMovie != null)
                        {
                            MessageBox.Show("Вы уже сохраняли этот фильм");
                            return;
                        }
                        if (_selectedMovie == null)
                        {
                            MessageBox.Show("Выберите фильм");
                            return;
                        }
                        var movie = await _downloadService.DownloadMovie(SearchText);
                        var model = new MovieModel
                        {
                            info = movie
                        };
                        _context.Movies.Add(model);
                        await _context.SaveChangesAsync();
                        MessageBox.Show("Фильм сохранён");
                        _selectedMovie = null;
                    }
                    catch (SqlException sql)
                    {
                        MessageBox.Show($"SQL: {sql.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }
    }
}
