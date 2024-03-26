using CityAPI.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace CityAPI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IMessenger _messenger;
    private ViewModelBase currentView;

    public ViewModelBase CurrentView
    {
        get => currentView;
        set => Set(ref currentView, value);
    }

    public MainWindowViewModel(IMessenger messenger)
    {
        CurrentView = App.Container.GetInstance<MainViewModel>();
        _messenger = messenger;
        
        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = message.ViewModelType;
        });
    }
}