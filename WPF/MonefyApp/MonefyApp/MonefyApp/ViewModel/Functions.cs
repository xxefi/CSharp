using MonefyApp.Model;
using MonefyApp.Service.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonefyApp.ViewModel
{
    public partial class MonefyViewModel
    {
        public void Save()
        {
            fileService.Save(fileName, data);
        }

        private void UpdateFilter()
        {
            DataFilter.Clear();
            Categories.Clear();
            Expens = "0";
            Profit = "0";
            emptyExpensData = true;
            List<Data> userdata = fileService.Open(fileName);
            if (userdata != null)
            {
                userdata.Add(userdata.FirstOrDefault());
            }
            if (data.Count != 0)
            {

                bool today = false, month = false, year = false;
                switch (filterName)
                {
                    default:
                    case "Day":
                        today = true;
                        month = true;
                        year = true;
                        break;
                    case "Month":
                        year = true;
                        month = true;
                        break;
                    case "Year":
                        year = true;
                        break;
                }
                foreach (Data item in data)
                {
                    if (year)
                    {
                        if (dateTimeUser.Year == item.TimeCreate.Year)
                        {
                            if (month)
                            {
                                if (dateTimeUser.Month == item.TimeCreate.Month)
                                {
                                    if (today)
                                    {
                                        if (dateTimeUser.Day != item.TimeCreate.Day) { continue; }
                                    }
                                }
                                else { continue; }
                            }
                        }
                        else { continue; }
                    }
                    DataFilter.Add(item);
                    if (!item.Income)
                    {
                        emptyExpensData = false;
                        if (Categories.Count(x => x.Categorie == item.Categorie) == 0)
                        {
                            Categories.Add(new Data() { Categorie = item.Categorie, Color = item.Color, Money = item.Money });
                        }
                        else
                        {
                            Categories.Where(x => x.Categorie == item.Categorie).ToList().ElementAt(0).Money += item.Money;
                        }
                        Expens = (expens - item.Money).ToString();
                    }
                    else
                    {
                        Profit = (profit += item.Money).ToString();
                    }
                }
                OnPropertyChanged(nameof(Expens));
                OnPropertyChanged(nameof(Profit));
            }
            if (emptyExpensData)
            {
                Categories.Add(new Data() { Categorie = "Empty", Color = "Gray", Percentage = 100 });
            }
            UpdateExpenseDataSeries();
        }

        private string GetMonthName(int numOfMonth)
        {
            switch (numOfMonth)
            {
                case 1:
                    return "Январь";
                case 2:
                    return "Февраль";
                case 3:
                    return "Март";
                case 4:
                    return "Апрель";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Август";
                case 9:
                    return "Сентябрь";
                case 10:
                    return "Октрябрь";
                case 11:
                    return "Ноябрь";
                case 12:
                    return "Декабрь";
                default:
                    return "";

            }
        }

        private void SearchTransactionsByName(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                UpdateFilter();
            }
            else
            {
                DataFilter.Clear();
                foreach(var transaction in data.Where(t => t.Categorie.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)))
                {
                    DataFilter.Add(transaction);
                }
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
