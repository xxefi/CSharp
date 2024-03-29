using CityAPI.Models;
using CityAPI.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CityAPI.ViewModels;

public class MainViewModel : ViewModelBase
{

    private readonly IDownloadService _downloadService;

    private string _searchBox;

    private ObservableCollection<CountryInfo.Rootobject> _countryInfo;
    private ObservableCollection<ExchangeRateInfo.Rootobject> _exchangeRateInfo;
    private ObservableCollection<WeatherInfo.Rootobject> _weatherInfo;

    public ObservableCollection<CountryInfo.Rootobject> CountryInfo
    {
        get => _countryInfo;
        set => Set(ref _countryInfo, value);
    }

    public ObservableCollection<ExchangeRateInfo.Rootobject> ExChangeRateInfo
    {
        get => _exchangeRateInfo;
        set => Set(ref _exchangeRateInfo, value);
    }

    public ObservableCollection<WeatherInfo.Rootobject> WeatherInfo
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

            WeatherInfo = new ObservableCollection<WeatherInfo.Rootobject>
            {
                await _downloadService.DownloadWeather(SearchBox)
            };

            CountryInfo = new ObservableCollection<CountryInfo.Rootobject>
            {
                await _downloadService.DownloadCountry(SearchBox)
            };

            /*ExChangeRateInfo = new ObservableCollection<ExchangeRateInfo.Rootobject>
            {
                await _downloadService.DownloadExchange(SearchBox)
            };*/

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    });
    
}