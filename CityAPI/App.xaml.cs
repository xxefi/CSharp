using System.Configuration;
using System.Data;
using System.Windows;
using CityAPI.Messages;
using CityAPI.Services.Classes;
using CityAPI.Services.Interfaces;
using CityAPI.ViewModels;
using CityAPI.Views;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;

namespace CityAPI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }

        void Register()
        {
            Container = new Container();
            
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IDownloadService, DownloadService>();
            Container.RegisterSingleton<IJsonService, JsonService>();
            Container.RegisterSingleton<ICountryService, CountryService>();
            Container.RegisterSingleton<ICurrencyService, CurrencyService>();
            Container.RegisterSingleton<IWeatherService, WeatherService>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<MainWindowViewModel>();

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            var window = new MainWindow();
            window.DataContext = Container.GetInstance<MainWindowViewModel>();
            window.Show();
        }
    }

}
