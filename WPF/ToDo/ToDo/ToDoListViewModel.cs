using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ToDo;

public partial class ToDoListViewModel : INotifyPropertyChanged
{
    public void AddTask()
    {
        AddToDo toDo = new AddToDo();
        toDo.ShowDialog();


    }
    public void AddToDoList()
    {
        App.Current.Shutdown();
    }
}
