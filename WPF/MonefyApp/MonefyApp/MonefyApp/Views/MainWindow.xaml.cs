
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MonefyApp.Views;
using MonefyApp.ViewModel;
using MonefyApp.Service.Command;

namespace MonefyApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MonefyViewModel viewModel = new MonefyViewModel(new JsonFileService());
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;

        }

        


        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(Object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result  = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            { 
                App.Current.Shutdown();

            }

        }

        

        private bool isDraging = false;
        private Point lastPosition;

        private void WindowTitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDraging = true;
            lastPosition = e.GetPosition(this);
        }

        private void WindowTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraging)
            {
                Point newPosition = e.GetPosition(this);
                Left += newPosition.X - lastPosition.X;
                Top += newPosition.Y - lastPosition.Y;

            }
        }

        private void WindowTitleBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDraging = false; 
        }

        
    }
}
