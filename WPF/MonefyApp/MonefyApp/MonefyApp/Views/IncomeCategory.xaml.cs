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
using MonefyApp.ViewModel;

namespace MonefyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для IncomeCategory.xaml
    /// </summary>
    public partial class IncomeCategory : Window
    {
        public IncomeCategory()
        {
            InitializeComponent();
            DataContext = new MonefyViewModel(new JsonFileService());
        }
        public IncomeCategory(MonefyViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

        }

        
    }
}
