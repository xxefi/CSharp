using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ToDo.Interfaces;

namespace ToDo.ViewModel
{
    public class ToDoViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ToDoViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AddToDoViewModel>();
                });
        }

        public RelayCommand Remove
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<RemoveToDoViewModel>();
                });
        }
    }
}
