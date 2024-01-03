using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDo.Service.Command
{
    public class Command : ICommand
    {
        public static Func<object, bool> defaultCanExecuteMetod = (obj) => true;
        private Func<object, bool> _canExecuteMetod;
        public Action<object> executeMetod;
        private Func<object, bool> defaultCanExecuteMetod1;
        public event EventHandler CanExecuteChanged;

        public Command(Action<object> executeMetod) : this(executeMetod, defaultCanExecuteMetod)
        {

        }

        public Command(Action<object> executeMetod, Func<object, bool> defaultCanExecuteMetod1)
        {
            this.executeMetod = executeMetod;
            this.defaultCanExecuteMetod1 = defaultCanExecuteMetod1;
        }

        public bool CanExecute(object parameter)
        {
            return defaultCanExecuteMetod(parameter);
        }

        public void Execute(object parameter)
        {
            this.executeMetod(parameter);
        }

        public void Check()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
