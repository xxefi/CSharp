using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDo;

public partial class ToDoListViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;
    public event NotifyCollectionChangedEventHandler? CollectionChanged;
    private ObservableCollection<Task> _tasks;
    private ICommand _addTaskCommand;
    private ICommand _addToDo;
}
