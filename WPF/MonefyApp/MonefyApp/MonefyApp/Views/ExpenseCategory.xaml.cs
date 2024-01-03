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
using MonefyApp.Views;
using MonefyApp.ViewModel;
using MonefyApp.Service.Command;

namespace MonefyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ExpenseCategory.xaml
    /// </summary>
    public partial class ExpenseCategory : Window
    {
        public ExpenseCategory()
        {
            InitializeComponent();
            DataContext = new MonefyViewModel(new JsonFileService());
        }
        public ExpenseCategory(MonefyViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
