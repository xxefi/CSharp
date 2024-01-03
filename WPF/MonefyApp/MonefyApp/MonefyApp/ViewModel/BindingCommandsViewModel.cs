using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MonefyApp.Model;
using MonefyApp.Service.Command;

namespace MonefyApp.ViewModel
{
    public partial class MonefyViewModel
    {
        public string UserDateTimeLabel
        {
            get => $"{dateTimeUser.Day} {GetMonthName(dateTimeUser.Month)} {dateTimeUser.Year}";
        }
        public string ListVisible
        {
            get => listVisible;
            set
            {
                if (!Equals(listVisible, value))
                {
                    listVisible = value;
                    OnPropertyChanged(nameof(ListVisible));
                }
            }
        }
        public string BRBackground
        {
            get => buttonResultBackground;
            set
            {
                if (!Equals(buttonResultBackground, value))
                {
                    buttonResultBackground = value;
                    OnPropertyChanged(nameof(BRBackground));
                }
            }
        }
        public string BRBorderBrush
        {
            get => buttonResultBorderBrush;
            set
            {
                if (!Equals(buttonResultBorderBrush, value))
                {
                    buttonResultBorderBrush = value;
                    OnPropertyChanged(nameof(BRBorderBrush));
                }
            }
        }

        public bool IsCalculatorVisible
        {
            get { return _isCalculatorVisible; }
            set
            {
                if (_isCalculatorVisible != value)
                {
                    _isCalculatorVisible = value;
                    OnPropertyChanged(nameof(IsCalculatorVisible));
                }
            }
        }

        public string SearchQuery
        {
            get { return searchQuery; }
            set
            {
                if (searchQuery != value)
                {
                    searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    UpdateFilter();
                }
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(param => ExecuteSearch());
            }
        }

        public RelayCommand SearchTextChangedCommand
        {
            get
            {
                return _searchTextChangedCommand;
            }
        }

        private void SearchTextChanged()
        {
            if (_searchTextChangedCommand != null)
            {
                DataFilter = new ObservableCollection<Data>(Data.Where(item => item.Name.Contains(SearchQuery)));
            }
        }

        private void ExecuteSearch()
        {
            UpdateFilter();
        }

        public bool IsTransactionListVisible
        {
            get { return _isTransactionListVisible; }
            set
            {
                _isTransactionListVisible = value;
                OnPropertyChanged(nameof(IsTransactionListVisible));
            }
        }
        public string Expens
        {
            get
            {
                int num = Convert.ToInt32(expens * 100);
                return (num / 100).ToString() + ',' + ((num % 100).ToString().Length == 2 ? (num % 100).ToString() : '0' + (num % 100).ToString());
            }
            set
            {
                if (!Equals(expens.ToString(), value))
                {
                    expens = Double.Parse(value);
                    Result = (profit - expens).ToString();
                    OnPropertyChanged(nameof(Expens));
                }
            }
        }
        public string Result
        {
            get 
            {
                int num = Convert.ToInt32(result * 100);
                return "Баланс: " + (num / 100).ToString() + ',' + (Math.Abs(num % 100).ToString().Length == 2 ? Math.Abs(num % 100).ToString() : '0' + Math.Abs(num % 100).ToString()) + " ₼";
            }
            set
            {
                if (!Equals(result.ToString(), value))
                {
                    result = Double.Parse(value);
                    if (result == 0)
                    {
                        BRBackground = "#7ac795";
                        BRBorderBrush = "#5aa377";
                    }
                    if (result >= 0)
                    {
                        BRBackground = "#7ac795";
                        BRBorderBrush = "#5aa377";
                    }
                    else
                    {
                        BRBackground = "#fc8181";
                        BRBorderBrush = "#a24445";
                    }
                    OnPropertyChanged(nameof(result));
                }
            }
        }

        public string Profit
        {
            get
            {
                int num = Convert.ToInt32(profit * 100);
                return (num / 100).ToString() + ',' + ((num % 100).ToString().Length == 2 ? (num % 100).ToString() : '0' + (num % 100).ToString());
            }
            set
            {
                if (!Equals(profit.ToString(), value))
                {
                    profit = int.Parse(value);
                    Result = (profit - expens).ToString();
                    OnPropertyChanged(nameof(Profit));
                }
            }
        }



        public string NoteVisibility
        {
            get => noteVisibility;
            set
            {
                if (!Equals(noteVisibility, value))
                {
                    noteVisibility = value;
                    OnPropertyChanged(nameof(NoteVisibility));
                }
            }
        }

        public string MinusCategoriesView
        {
            get => minusCategoriesView;
            set
            {
                if (!Equals(minusCategoriesView, value))
                {
                    minusCategoriesView = value;
                    OnPropertyChanged(nameof(MinusCategoriesView));
                }
            }
        }
        public string PlusCategoriesView
        {
            get => plusCategoriesView;
            set
            {
                if (!Equals(plusCategoriesView, value))
                {
                    plusCategoriesView = value;
                    OnPropertyChanged(nameof(PlusCategoriesView));
                }
            }
        }
        public string LabelValue
        {
            get { return labelValue; }
            set
            {
                if (!Equals(labelValue, value))
                {
                    labelValue = value;
                    OnPropertyChanged(nameof(LabelValue));
                }
            }
        }
        public string NoteValue
        {
            get { return noteValue; }
            set
            {
                if (!Equals(noteValue, value))
                {
                    noteValue = value;
                    OnPropertyChanged(nameof(NoteValue));
                }
            }
        }
    }
}
