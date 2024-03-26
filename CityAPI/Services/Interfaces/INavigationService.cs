using GalaSoft.MvvmLight;

namespace CityAPI.Services.Interfaces;

public interface INavigationService
{
    public void NavigateTo<T>() where T : ViewModelBase;
}