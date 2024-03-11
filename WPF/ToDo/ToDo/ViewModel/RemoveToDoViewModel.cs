using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDo.Interfaces;
using ToDo.Models;

namespace ToDo.ViewModel
{
    public class RemoveToDoViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ToDoDbContext _context;

        private ObservableCollection<ToDoModel> _todo;
        private ToDoModel _selectedTodo;

        public ObservableCollection<ToDoModel> Todo
        {
            get => _todo;
            set => Set(ref _todo, value);
        }

        public ToDoModel SelectedTodo
        {
            get => _selectedTodo;
            set => Set(ref _selectedTodo, value);
        }

        public RemoveToDoViewModel(INavigationService navigationService, ToDoDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            Todo = new ObservableCollection<ToDoModel>(_context.ToDo);   
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<ToDoViewModel>();
                });
        }

        public RelayCommand Remove
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (SelectedTodo == null)
                        {
                            MessageBox.Show("Выберите дело");
                            return;
                        }
                        else
                        {
                            var todo = _context.ToDo.FirstOrDefault(t => t.Name == _selectedTodo.Name);
                            if (todo != null)
                            {
                                _context.ToDo.Remove(todo);
                                _context.SaveChanges();
                                Todo.Remove(todo);
                                MessageBox.Show("Дело удалено");
                                _navigationService.NavigateTo<ToDoViewModel>();
                            }
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
