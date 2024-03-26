using CityAPI.Models;
using CityAPI.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;

namespace CityAPI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IDownloadService _downloadService;

    private string _searchBox;

    private ObservableCollection<CountryInfo> _countryInfo;
    private ObservableCollection<ExchangeRateInfo> _exchangeRateInfo;
    private ObservableCollection<WeatherInfo> _weatherInfo;

    public ObservableCollection<CountryInfo> CountryInfo
    {
        get => _countryInfo;
        set => Set(ref _countryInfo, value);
    }

    public ObservableCollection<ExchangeRateInfo> ExChangeRateInfo
    {
        get => _exchangeRateInfo;
        set => Set(ref _exchangeRateInfo, value);
    }

    public ObservableCollection<WeatherInfo> WeatherInfo
    {
        get => _weatherInfo;
        set => Set(ref _weatherInfo, value);
    }
    
    public string SearchBox
    {
        get => _searchBox;
        set => Set(ref _searchBox, value);
    }

    public MainViewModel(IDownloadService downloadService)
    {
        _downloadService = downloadService;
    }

    public RelayCommand Search => new(async () =>
    {
        try
        {
            WeatherInfo = new ObservableCollection<WeatherInfo>
            {
                await _downloadService.DownloadWeather(SearchBox)
            };

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    });
    
}