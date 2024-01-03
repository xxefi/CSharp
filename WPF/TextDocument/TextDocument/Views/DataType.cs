using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TextDocument.Views;

public partial class NoteViewModel : INotifyPropertyChanged
{
    private string _note;
    private string _cutBuffer;
    private string _copyBuffer;
    private ICommand _saveCommand;
    private ICommand _saveToCommand;
    private ICommand _openCommand;
    private ICommand _exitCommand;
    private ICommand _cutCommand;
    private ICommand _copyCommand;
    private ICommand _pasteCommand;
    private ICommand _deleteCommand;

}
