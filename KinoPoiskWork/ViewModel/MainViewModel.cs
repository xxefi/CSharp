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

namespace KinoPoiskWork.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDownloadService _downloadService;
        private readonly MovieDbContext _context;
        private string _searchText;
        private ObservableCollection<MovieModel.Info> _movie;
        
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

        public MainViewModel(IDownloadService downloadService, MovieDbContext context)
        {
            _downloadService = downloadService;
            _context = context;
            
        }

       

        public RelayCommand SearchCommand => new(async () =>
        {
            try
            {
                Movie = new ObservableCollection<MovieModel.Info>
                {
                    await _downloadService.DownloadMovie(SearchText)
                };
                
                MessageBoxResult result = MessageBox.Show("Сохранить результат?", "Уведомление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var movieInfo = await _downloadService.DownloadMovie(SearchText);
                    var movieModel = new MovieModel
                    {
                        info = movieInfo
                    };
                    _context.Movies.Add(movieModel);
                    await _context.SaveChangesAsync();
                    MessageBox.Show("Успешно сохранено");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ViewModel: {ex.Message}");
            }
           
        });

    }
}
