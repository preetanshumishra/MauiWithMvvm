using MauiWithMvvm.ViewModels;

namespace MauiWithMvvm
{
    public partial class MainPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}