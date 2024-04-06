using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Data.SqlClient;
using MovieSearch.Context;
using MovieSearch.Model;
using MovieSearch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MovieSearch.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _searchText;
        private Search _selectedMovie;
        private ObservableCollection<Search> _movie = new();
        private readonly IDownloadService _downloadService;
        private readonly ISerializeService _serializeService;
        private readonly MovieDbContext _context;
        
        public string SearchText
        {
            get => _searchText;
            set => Set(ref _searchText, value);
        }

        public ObservableCollection<Search> Movie
        {
            get => _movie;
            set => Set(ref _movie, value);
        }

        public Search SelectedMovie
        {
            get => _selectedMovie;
            set => Set(ref _selectedMovie, value);
        }
        
        public MainViewModel(IDownloadService downloadService, ISerializeService serializeService, MovieDbContext context)
        {
            _downloadService = downloadService;
            _serializeService = serializeService;
            _context = context;
        }

        public RelayCommand SearchCommand => new(async () =>
        {
            Movie.Clear();
            if (SearchText != null)
            {
                try
                {
                    var json = await _downloadService.DownloadJsonAsync(UriModel.SearchByMovie(SearchText));
                    var searchResult = await _serializeService.DeserializeAsync<Movie>(json);

                    foreach (var item in searchResult.Search)
                    {
                        Movie.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        });
        public RelayCommand SaveMovie => new(async () =>
        {
            try
            {
                var movie = _context.Movies.FirstOrDefault(m => m.imdbID == SelectedMovie.imdbID);
                if (SelectedMovie == null)
                {
                    MessageBox.Show("Вы не выбрали фильм");
                    return;
                }
                if (movie != null)
                {
                    MessageBox.Show("Вы уже сохраняли этот фильм");
                    return;
                }
                var json = await _downloadService.DownloadJsonAsync(UriModel.SearchByMovie(SearchText));
                var searchResult = await _serializeService.SerializeAsync<Movie>(json);
                var model = new Search
                {
                    imdbID = SelectedMovie.imdbID,
                    Poster = SelectedMovie.Poster,
                    Title = SelectedMovie.Title,
                    Year = SelectedMovie.Year,
                    Type = SelectedMovie.Type,
                };
                _context.Movies.Add(model);
                _context.SaveChanges();
                MessageBox.Show("Фильм сохранён");
            }
            catch (SqlException sql)
            {
                MessageBox.Show($"Не удалось сохранить. Ошибка: {sql.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
    }
}
