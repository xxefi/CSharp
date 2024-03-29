using KinoPoiskWork.Context;
using KinoPoiskWork.Services.Classes;
using KinoPoiskWork.Services.Interfaces;
using KinoPoiskWork.ViewModel;
using KinoPoiskWork.Views;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;

namespace KinoPoiskWork
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container;

        void Register()
        {
            Container = new Container();
            Container.RegisterSingleton<IDownloadService, DownloadService>();
            Container.RegisterSingleton<IMovieService, MovieService>();
            Container.RegisterSingleton<MovieDbContext>();
            Container.RegisterSingleton<MainViewModel>();

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
