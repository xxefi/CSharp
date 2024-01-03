using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TextDocument.Views;
using System.IO;

namespace TextDocument.Views;

public partial class NoteViewModel : INotifyPropertyChanged
{
    public string Note
    {
        get { return _note; }
        set
        {
            if (_note != value)
            {
                _note = value;
                OnPropertyChanged(nameof(Note));
            }
        }
    }


    public ICommand SaveCommand
    {
        get
        {
            return _saveCommand ?? (_saveCommand = new RelayCommand(param => Save()));
        }
        set
        {
            if (_saveCommand != value)
            {
                _saveCommand = value;
                OnPropertyChanged(nameof(SaveCommand));
            }
        }
    }

    public ICommand SaveToCommand
    {
        get
        {
            return _saveToCommand ?? (_saveToCommand = new RelayCommand(param => SaveTo()));
        }
        set
        {
            if (_saveToCommand != value)
            {
                _saveToCommand = value;
                OnPropertyChanged(nameof(SaveToCommand));
            }
        }
    }

    public ICommand OpenCommand
    {
        get
        {
            return _openCommand ?? (_openCommand = new RelayCommand(param => Open()));
        }
        set
        {
            if (_openCommand != value)
            {
                _openCommand = value;
                OnPropertyChanged(nameof(OpenCommand));
            }
        }
    }

    public ICommand CutCommand
    {
        get
        {
            return _cutCommand ?? (_cutCommand = new RelayCommand(param => Cut()));
        }
        set
        {
            if (_cutCommand != value)
            {
                _cutCommand = value;
                OnPropertyChanged(nameof(CutCommand));
            }
        }
    }

    public ICommand CopyCommand
    {
        get
        {
            return _copyCommand ?? (_copyCommand = new RelayCommand(param => Copy()));
        }
        set
        {
            if (_copyCommand != value)
            {
                _copyCommand = value;
                OnPropertyChanged(nameof(CopyCommand));
            }
        }
    }

    public ICommand PasteCommand
    {
        get
        {
            return _pasteCommand ?? (_pasteCommand = new RelayCommand(param => Paste()));
        }
        set
        {
            if (_pasteCommand != value)
            {
                _pasteCommand = value;
                OnPropertyChanged(nameof(PasteCommand));
            }
        }
    }

    public ICommand DeleteCommand
    {
        get
        {
            return _deleteCommand ?? (_deleteCommand = new RelayCommand(param => Delete()));
        }
        set
        {
            if (_deleteCommand  != value)
            {
                _deleteCommand = value;
                OnPropertyChanged(nameof(DeleteCommand));
            }
        }
    }

    public ICommand ExitCommand
    {
        get
        {
            return _exitCommand ?? (_exitCommand = new RelayCommand(param => Exit()));
        }
        set
        {
            if (_exitCommand != value)
            {
                _exitCommand = value;
                OnPropertyChanged(nameof(ExitCommand));
            }
        }
    }




    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
