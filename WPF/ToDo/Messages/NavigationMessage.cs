using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SimpleInjector;

namespace ToDo.Messages
{
    public class NavigationMessage
    {
        public ViewModelBase ViewModelBase {  get; set; }
    }
}
