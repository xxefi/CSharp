using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Service.Command;

namespace ToDo
{
    public partial class ToDoListViewModel
    {
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public ICommand AddTaskCommand
        {
            get
            {
                return _addTaskCommand ?? (_addTaskCommand = new RelayCommand(param => AddTask()));
            }
            set
            {
                _addTaskCommand = value;
                OnPropertyChanged(nameof(AddTaskCommand));
            }
        }

        public ICommand AddToDo
        {
            get
            {
                return _addToDo ?? (_addToDo = new RelayCommand(param => AddToDoList()));
            }
            set
            {
                _addToDo = value;
                OnPropertyChanged(nameof(AddToDo));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
