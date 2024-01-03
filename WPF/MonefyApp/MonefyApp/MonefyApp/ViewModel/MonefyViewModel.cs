using MonefyApp.Model;
using MonefyApp.Service.Command;
using MonefyApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Series;

namespace MonefyApp.ViewModel
{
    public partial class MonefyViewModel : INotifyPropertyChanged
    {
        public MonefyViewModel(IFileService _fileService)
        {
            try
            {
                Categories = new ObservableCollection<Data>();
                PieChart = new ObservableCollection<Canvas>() { new Canvas() };
                DataFilter = new ObservableCollection<Data>();
                ExpenseDataSeries = new SeriesCollection();
                listVisible = "Hidden";
                dateTimeUser = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                fileName = "Data.json";
                fileService = _fileService;
                data = fileService.Open(fileName);

                showCalculate = new Command(obj =>
                {
                    if (obj is Button)
                    {
                        if ((obj as Button).Name.StartsWith("plus"))
                        {
                            plusShow = true;
                        }
                        else
                        {
                            plusShow = false;
                        }
                    }
                    calculate = new Calculate(this);
                    calculate.ShowDialog();
                    labelValue = "0";
                    dotPressed = false;
                    plusCategoriesView = "Hidden";
                    NoteVisibility = "Visible";
                });

                showCalculateExpense = new Command(obj =>
                {
                    if (obj is Button)
                    {
                        if ((obj as Button).Name.StartsWith("minus"))
                        {
                            minusShow = true;
                        }
                        else
                        {
                            minusShow = false;
                        }
                    }
                    calculateExpense = new CalculateExpense(this);
                    calculateExpense.ShowDialog();
                    labelValue = "0";
                    dotPressed = false;
                    minusCategoriesView = "Hidden";
                    NoteVisibility = "Visible";
                });

                showCalculateIcon = new Command(obj =>
                {
                    if (obj is Button)
                    {
                        if ((obj as Button).Name.StartsWith(""))
                        {
                            iconShow = true;
                        }
                        else
                        {
                            iconShow = false;
                        }
                    }
                    calculateIcon = new CalculateIcon(this);
                    calculateIcon.ShowDialog();
                    labelValue = "0";
                    dotPressed = false;
                });


                filter = new Command(obj =>
                {
                    if (obj is MenuItem)
                    {
                        filterName = (obj as MenuItem).Header.ToString();
                        UpdateFilter();
                    }
                    filter.Check();
                }, obj =>
                {
                    if (obj is MenuItem)
                    {
                        return filterName != (obj as MenuItem).Header.ToString();
                    }
                    return false;
                });
                changeListVisible = new Command(obj =>
                {
                    if (ListVisible == "Hidden")
                    {
                        ListVisible = "Visible";
                    }
                    else { ListVisible = "Hidden"; }
                });
                changeUserDateTime = new Command(obj =>
                {
                    if (obj is Button)
                    {
                        int year = dateTimeUser.Year;
                        int month = dateTimeUser.Month;
                        int day = dateTimeUser.Day;
                        switch ((obj as Button).Content)
                        {
                            case "<":
                                day--;
                                break;
                            case "<<":
                                month--;
                                break;
                            case "<<<":
                                year--;
                                break;
                            case ">":
                                DateTimeUser = dateTimeUser.AddDays(1);
                                UpdateFilter();
                                return;
                            case ">>":
                                DateTimeUser = dateTimeUser.AddMonths(1);
                                UpdateFilter();
                                return;
                            case ">>>":
                                DateTimeUser = dateTimeUser.AddMonths(12);
                                UpdateFilter();
                                return;
                        }
                        if (day <= 0)
                        {
                            month--;
                            day = DateTime.DaysInMonth(year, month);
                        }
                        if (month <= 0)
                        {
                            year--;
                            month = 12;
                        }
                        if (day > DateTime.DaysInMonth(year, month))
                        {
                            day = DateTime.DaysInMonth(year, month);
                        }
                        DateTimeUser = new DateTime(year, month, day);
                        UpdateFilter();

                    }
                });

                UpdateFilter();


                LabelValue = "0";
                NoteVisibility = "Visible";
                PlusCategoriesView = "Hidden";
                MinusCategoriesView = "Hidden";

                addDigit = new Command(obj => //Execute
                {
                    if (obj is Button)
                    {
                        if ((obj as Button).Content.ToString() == ",")
                        {
                            dotPressed = true;
                        }
                        else if (LabelValue == "0")
                        {
                            labelValue = String.Empty;
                        }
                        LabelValue += (obj as Button).Content.ToString();
                    }
                }, obj => //CanExecute
                {
                    if (calculate.IsActive)
                    {
                        if (dotPressed)
                        {
                            if (obj is Button)
                            {
                                if (labelValue.Split(',')[1].Length == 2)
                                {
                                    return false;
                                }
                                return (obj as Button).Content.ToString() != ",";
                            }
                        }
                        else if (LabelValue == "0")
                        {
                            if (obj is Button)
                            {
                                return (obj as Button).Content.ToString() != "0";
                            }
                        }
                    }
                    return true;
                });

                removeDigit = new Command(obj =>
                {
                    if (labelValue.Length > 1)
                    {
                        if (labelValue[labelValue.Length - 1] == ',')
                        {
                            dotPressed = false;
                        }
                        LabelValue = labelValue.Remove(labelValue.Length - 1);
                    }
                    else
                    {
                        LabelValue = "0";
                    }
                });

                enterCategorie = new Command(obj =>
                {
                    if (obj is Button button)
                    {
                        if (button.Content.ToString().StartsWith("ВЫБОР"))
                        {
                            (obj as Button).Content = "Открыто";
                            incomeCategoryShow = true;
                            calculate.Hide();
                        }
                        
                        else
                        {
                            calculate.Show();
                        }
                        incomeCategory = new IncomeCategory(this);
                        incomeCategory.ShowDialog();
                        labelValue = "0";
                        dotPressed = true;
                        plusCategoriesView = "Hidden";
                        NoteVisibility = "Visible";

                    }
                    (obj as Button).Content = "ВЫБОР КАТЕГОРИИ";
                });

                enterExpenseCategorie = new Command(obj =>
                {
                    if (obj is Button button)
                    {
                        if (button.Content.ToString().StartsWith("ВЫБОР"))
                        {
                            (obj as Button).Content = "Открыто";
                            expenseCategoryShow = true;
                            calculateExpense.Hide();
                        }
                        expenseCategory = new ExpenseCategory(this);
                        expenseCategory.ShowDialog();
                        labelValue = "0";
                        dotPressed = false;
                        minusCategoriesView = "Hidden";
                        NoteVisibility = "Visible";
                    }
                    (obj as Button).Content = "ВЫБОР КАТЕГОРИИ";
                });

                enterIconCategorie = new Command(obj =>
                {
                    if (obj is Button button)
                    {
                        if (button.Content.ToString().StartsWith("ВЫБОР"))
                        {
                            (obj as Button).Content = "Открыто";
                            iconShow = true;
                        }
                    }
                    calculateIcon = new CalculateIcon(this);
                    calculateIcon.ShowDialog();
                    labelValue = "0";
                    dotPressed = false;

                    (obj as Button).Content = "ДОБАВИТЬ";

                });
                {

                }
                addCategorie = new Command(obj =>
                {
                    if (obj is Button)
                    {
                        data.Add(new Data()
                        {
                            Color = (obj as Button).Foreground.ToString(),
                            Categorie = (obj as Button).Content.ToString(),
                            Note = noteValue,
                            TimeCreate = dateTimeUser,
                            Money = Double.Parse(labelValue),
                        });
                        DataFilter.Add(data[data.Count - 1]);


                        if (!data[data.Count - 1].Income)
                        {
                            if (emptyExpensData)
                            {
                                Categories.Clear();
                                emptyExpensData = false;
                            }
                            if (Categories.Count(x => x.Categorie == data[data.Count - 1].Categorie) == 0)
                            {
                                Categories.Add(new Data() { Categorie = data[data.Count - 1].Categorie, Color = data[data.Count - 1].Color, Money = data[data.Count - 1].Money, Income = data[data.Count - 1].Income, TimeCreate = data[data.Count - 1].TimeCreate });
                            }
                            else
                            {
                                Categories.Where(x => x.Categorie == data[data.Count - 1].Categorie).ToList().ElementAt(0).Money += data[data.Count - 1].Money;
                            }
                            Expens = (expens - data[data.Count - 1].Money).ToString();
                            UpdateExpenseDataSeries();
                            int max = Categories.Count;
                            for (int i = 0; i < max; i++)
                            {
                                Categories.Add(Categories[0]);
                                Categories.RemoveAt(0);
                            }
                        }
                        else
                        {
                            Profit = (profit + data[data.Count - 1].Money).ToString();
                        }
                        calculate.Close();
                    }
                    incomeCategory.Close();
                    fileService.Save(fileName, data);



                }, obj =>
                {
                    if (obj is Button)
                    {
                        if (Double.Parse(labelValue) > 0)
                        {
                            (obj as Button).Opacity = 1;
                            return true;
                        }
                        else
                        {
                            (obj as Button).Opacity = 0.3;
                            return false;
                        }
                    }
                    return Double.Parse(labelValue) > 0;
                });


                addCategorieExpense = new Command(obj =>
                {
                    if (obj is Button)
                    {
                        data.Add(new Data()
                        {
                            Color = (obj as Button).Foreground.ToString(),
                            Categorie = (obj as Button).Content.ToString(),
                            Note = noteValue,
                            TimeCreate = dateTimeUser,
                            Money = Double.Parse(labelValue)
                        });
                        DataFilter.Add(data[data.Count - 1]);
                        if (!data[data.Count - 1].Expensed)
                        {
                            if (emptyExpensData)
                            {
                                Categories.Clear();
                                emptyExpensData = false;
                            }
                            if (Categories.Count(x => x.Categorie == data[data.Count - 1].Categorie) == 0)
                            {
                                Categories.Add(new Data() { Categorie = data[data.Count - 1].Categorie, Color = data[data.Count - 1].Color, Money = data[data.Count - 1].Money, Expensed = data[data.Count - 1].Expensed, TimeCreate = data[data.Count - 1].TimeCreate });
                            }
                            else
                            {
                                Categories.Where(x => x.Categorie == data[data.Count - 1].Categorie).ToList().ElementAt(0).Money += data[data.Count - 1].Money;
                            }
                            Expens = (expens + data[data.Count - 1].Money).ToString();
                            UpdateExpenseDataSeries();
                            int max = Categories.Count;
                            for (int i = 0; i < max; i++)
                            {
                                Categories.Add(Categories[0]);
                                Categories.RemoveAt(0);
                            }
                        }
                        else
                        {
                            Profit = (profit + data[data.Count - 1].Money).ToString();
                        }
                        calculateExpense.Close();
                    }
                    expenseCategory.Close();
                    fileService.Save(fileName, data);

                }, obj =>
                {
                    if (obj is Button)
                    {
                        if (Double.Parse(labelValue) > 0)
                        {
                            (obj as Button).Opacity = 1;
                            return true;
                        }
                        else
                        {
                            (obj as Button).Opacity = 0.3;
                            return false;
                        }
                    }
                    return Double.Parse(labelValue) > 0;
                });
                

                addCategorieIcon = new Command(obj =>
                {
                    if (obj is Button)
                    {
                        data.Add(new Data()
                        {
                            Color = (obj as Button).Foreground.ToString(),
                            Categorie = (obj as Button).Name.ToString(),
                            Note = noteValue,
                            Income = plusShow,
                            TimeCreate = DateTime.Now,
                            Money = Double.Parse(labelValue)
                        });
                        DataFilter.Add(data[data.Count - 1]);
                        if (!data[data.Count - 1].Income)
                        {
                            if (emptyExpensData)
                            {
                                Categories.Clear();
                                emptyExpensData = false;
                            }
                            if (Categories.Count(x => x.Categorie == data[data.Count - 1].Categorie) == 0)
                            {
                                Categories.Add(new Data() { Categorie = data[data.Count - 1].Categorie, Color = data[data.Count - 1].Color, Money = data[data.Count - 1].Money, Income = data[data.Count - 1].Income, TimeCreate = data[data.Count - 1].TimeCreate });
                            }
                            else
                            {
                                Categories.Where(x => x.Categorie == data[data.Count - 1].Categorie).ToList().ElementAt(0).Money += data[data.Count - 1].Money;
                            }
                            Expens = (expens + data[data.Count - 1].Money).ToString();
                            UpdateExpenseDataSeries();
                            int max = Categories.Count;
                            for (int i = 0; i < max; i++)
                            {
                                Categories.Add(Categories[0]);
                                Categories.RemoveAt(0);
                            }
                        }
                        else
                        {
                            Profit = (profit - data[data.Count - 1].Money).ToString();
                        }
                        calculateIcon.Close();
                        fileService.Save(fileName, data);
                    }


                }, obj =>
                {
                    if (obj is Button)
                    {
                        if (Double.Parse(labelValue) > 0)
                        {
                            (obj as Button).Opacity = 1;
                            return true;
                        }
                        else
                        {
                            (obj as Button).Opacity = 0.3;
                            return false;
                        }
                    }
                    return Double.Parse(labelValue) > 0;
                });



                PropertyChanged += (sender, e) =>
                {
                    if (calculate != null)
                    {
                        if (calculate.IsActive && e.PropertyName == nameof(LabelValue))
                        {
                            (addCategorie as Command).Check();
                        }
                    }
                };
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException(nameof(labelValue));
            }

        }
    }
}
