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
using MonefyApp.Service.Command;
using MonefyApp.Model;
using MonefyApp.ViewModel;

namespace MonefyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CalculateExpense.xaml
    /// </summary>
    public partial class CalculateExpense : Window
    {
        public CalculateExpense()
        {
            InitializeComponent();
            DataContext = new MonefyViewModel(new JsonFileService());
        }

        public CalculateExpense(MonefyViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
