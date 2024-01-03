using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonefyApp.Model;

namespace MonefyApp.ViewModel
{
    public partial class MonefyViewModel
    {
        public SeriesCollection ExpenseDataSeries
        {
            get { return _expenseDataSeries; }
            set
            {
                if (_expenseDataSeries != value)
                {
                    _expenseDataSeries = value;
                    OnPropertyChanged(nameof(ExpenseDataSeries));
                    UpdateExpenseDataSeries();
                }
            }
        }
        private void UpdateExpenseDataSeries()
        {
            ExpenseDataSeries.Clear();
            double totalExpense = Categories.Sum(category => category.Money);

            foreach (var category in Categories)
            {
                double percentAge = totalExpense > 0 ? (category.Money / totalExpense) * 100 : 0;
                var pieSeries = new PieSeries
                {
                    Title = category.Categorie,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(category.Money) },
                };

                string label = $"({category.Money} ₼)";
                pieSeries.LabelPoint = point => label;
                ExpenseDataSeries.Add(pieSeries);
            }
        }

        public double CurrentExpenseValue
        {
            get { return _currentExpenseValue; }
            set
            {
                if (_currentExpenseValue != value)
                {
                    _currentExpenseValue = value;
                    OnPropertyChanged(nameof(CurrentExpenseValue));
                    UpdateExpenseDataSeries();
                }
            }
        }

    }
}
