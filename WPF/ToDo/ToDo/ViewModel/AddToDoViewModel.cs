using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDo.Interfaces;
using ToDo.Models;

namespace ToDo.ViewModel
{
    public class AddToDoViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ToDoDbContext _context;

        private string _name;
        private string _toDo;
        private string _description;
        private DateTime _time = DateTime.Now;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Todo
        {
            get => _toDo;
            set => Set(ref _toDo, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public DateTime Time
        {
            get => _time;
            set => Set(ref _time, value);
        }

        public AddToDoViewModel(INavigationService navigationService, ToDoDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<ToDoViewModel>();
                });
        }

        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Todo)
                           || string.IsNullOrWhiteSpace(Description))
                        {
                            MessageBox.Show("Поля не могут быть пустыми");
                            return;
                        }
                        else
                        {
                            ToDoModel ToDo = new()
                            {
                                Name = Name,
                                Type = Todo,
                                Description = Description,
                                Time = Time,
                            };
                            _context.ToDo.Add(ToDo);
                            _context.SaveChanges();
                            MessageBox.Show("Успешно добавлено");
                            Name = "";
                            Todo = "";
                            Description = "";
                            _navigationService.NavigateTo<ToDoViewModel>();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }

    }
}
