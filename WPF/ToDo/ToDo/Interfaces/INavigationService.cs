using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Interfaces
{
    public interface INavigationService
    {
        public void NavigateTo<T>() where T : ViewModelBase;
    }
}
