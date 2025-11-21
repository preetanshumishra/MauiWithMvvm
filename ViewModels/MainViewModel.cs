using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiWithMvvm.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Title = "Home";
        }
        
        [ObservableProperty]
        private string _welcomeText = "Hello from MVVM!";
        
        [ObservableProperty]
        private int _counter;
        
        [RelayCommand]
        private void IncrementCounter()
        {
            Counter++;
            WelcomeText = Counter == 1
                ? "Clicked 1 time"
                : $"Clicked {Counter} times";
        }
    }
}