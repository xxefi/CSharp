using MovieSearch.Context;
using MovieSearch.Services.Classes;
using MovieSearch.Services.Interfaces;
using MovieSearch.ViewModel;
using MovieSearch.Views;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MovieSearch
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
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<MovieDbContext>();
            Container.RegisterSingleton<IDownloadService, DownloadService>();
            Container.RegisterSingleton<ISerializeService, SerializeService>();

            Container.Verify();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            var window = new MainWindow();
            window.DataContext = Container.GetInstance<MainViewModel>();
            window.Show();
        }
    }

}
