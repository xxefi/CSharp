using MonefyApp.Model;
using MonefyApp.Service.Command;
using MonefyApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonefyApp.ViewModel;
using System.Data;

namespace MonefyApp.ViewModel
{
    public partial class MonefyViewModel
    {
        Calculate calculate;
        CalculateExpense calculateExpense;
        CalculateIcon calculateIcon;
        ExpenseCategory expenseCategory;
        IncomeCategory incomeCategory;
        private Dictionary<string, MonefyViewModel> userDictionary = new Dictionary<string, MonefyViewModel>();
        private List<Data> data;
        private IFileService fileService;
        private RelayCommand _searchTextChangedCommand;
        DateTime dateTimeUser;
        DateTime DateTimeUser { get => dateTimeUser; set { dateTimeUser = value; OnPropertyChanged(nameof(UserDateTimeLabel)); } }
        string filterName;
        private double expens;
        private double result;
        private double profit;
        string fileName;
        bool emptyExpensData;
        private double pieChartSize;
        private int currentUserID;
        private readonly double center;
        private readonly double radius;
        bool plusShow;
        bool minusShow;
        bool expenseCategoryShow;
        bool incomeCategoryShow;
        bool iconShow;
        string buttonResultBackground;
        private string searchQuery;
        string buttonResultBorderBrush;
        string listVisible;
        private bool _isTransactionListVisible;
        private bool _isCalculatorVisible;
        private double _currentExpenseValue;
        private string noteVisibility;
        private string minusCategoriesView;
        private string plusCategoriesView;
        private string labelValue;
        private string noteValue;
        private bool isMinusClicked = false;
        private bool dotPressed;

    }
}
