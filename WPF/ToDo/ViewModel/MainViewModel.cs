using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Interfaces;
using ToDo.Messages;

namespace ToDo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        private ViewModelBase currentView;

        public ViewModelBase CurrentView
        {
            get => currentView;
            set => Set(ref currentView, value);
        }

        public MainViewModel(INavigationService navigationService, IMessenger messenger)
        {
            CurrentView = App.Container.GetInstance<ToDoViewModel>();
            _navigationService = navigationService;
            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelBase;
            });
        }
    }
}
