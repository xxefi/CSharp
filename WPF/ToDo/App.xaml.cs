using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using ToDo.Interfaces;
using ToDo.Services;
using ToDo.ViewModel;
using ToDo.Views;

namespace ToDo
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
            Container.RegisterSingleton<Interfaces.INavigationService, NavigationService>();
            Container.RegisterSingleton<ToDoDbContext>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<AddToDoViewModel>(); 


            Container.Register<ToDoViewModel>();
            Container.Register<RemoveToDoViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            var window = new MainView();
            window.DataContext = Container.GetInstance<MainViewModel>();
            window.Show();
        }
    }

}
