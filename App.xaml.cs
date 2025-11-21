namespace MauiWithMvvm
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }
        
        protected override Window CreateWindow(IActivationState activationState)
        {
            var appShell = Handler?.MauiContext?.Services.GetService<AppShell>();
            return new Window(appShell ?? new AppShell());
        }
    }
}