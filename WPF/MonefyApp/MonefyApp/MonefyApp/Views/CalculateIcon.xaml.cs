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
using System.Windows.Shapes;
using MonefyApp.ViewModel;
using MonefyApp.Views;
using MonefyApp.Service.Command;
namespace MonefyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CalculateIcon.xaml
    /// </summary>
    public partial class CalculateIcon : Window
    {
        public CalculateIcon()
        {
            InitializeComponent();
            DataContext = new MonefyViewModel(new JsonFileService());
        }
        public CalculateIcon(MonefyViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
