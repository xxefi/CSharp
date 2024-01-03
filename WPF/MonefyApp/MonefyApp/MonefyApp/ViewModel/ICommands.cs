using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonefyApp.ViewModel
{
    public partial class MonefyViewModel
    {
        public ICommand ExpenseCategoryCommand { get; set; }
        public ICommand IncomeCategoryCommand { get; set; }
        public ICommand ShowCalculate => showCalculate;
        public ICommand ShowCalculateExpense => showCalculateExpense;
        public ICommand ShowCalculateIcon => showCalculateIcon;
        public ICommand ExpenseCategory => showExpenseCategory;
        public ICommand IncomeCategory => showIncomeCategory;
        public ICommand Filter => filter;
        public ICommand ChangeListVisible => changeListVisible;
        public ICommand ChangeUserDateTime => changeUserDateTime;
        public ICommand ChangeTheme => changeTheme;
        public ICommand AddDigit => addDigit;
        public ICommand RemoveDigit => removeDigit;
        public ICommand EnterCategorie => enterCategorie;
        public ICommand EnterExpenseCategorie => enterExpenseCategorie;
        public ICommand AddCategorie => addCategorie;
        public ICommand AddCategorieExpense => addCategorieExpense;
        public ICommand AddCategorieIcon => addCategorieIcon;

    }
}
