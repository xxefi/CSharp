using MonefyApp.Service.Command;
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
        Command showCalculate;
        Command showCalculateExpense;
        Command showCalculateIcon;
        Command showExpenseCategory;
        Command showIncomeCategory;
        Command changeListVisible;
        Command changeUserDateTime;
        Command filter;
        Command changeTheme;
        Command addDigit;
        Command removeDigit;
        Command enterCategorie;
        Command enterExpenseCategorie;
        Command enterIconCategorie;
        Command addCategorie;
        Command addCategorieExpense;
        Command addCategorieIcon;
    }
}
