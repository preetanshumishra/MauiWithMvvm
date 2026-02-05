# MauiWithMvvm

A .NET MAUI production-ready sample demonstrating modern MVVM pattern with constructor-based dependency injection and the Community Toolkit MVVM library. This project serves as a best-practice reference for .NET MAUI application architecture.

## Overview

MauiWithMvvm showcases **industry best practices** for building scalable, maintainable .NET MAUI applications:
- **Community Toolkit MVVM** - Modern, lightweight MVVM framework with source generators
- **Constructor Injection** - Recommended modern DI pattern with `Microsoft.Extensions.DependencyInjection`
- **Type Safety** - Strong typing and compile-time safety across the application
- **Platform-Agnostic** - Single codebase for iOS and Android with platform-specific customizations

## Project Structure

```
MauiWithMvvm/
├── MauiProgram.cs                    # Dependency injection & app startup
├── App.xaml / App.xaml.cs           # Global resources & styling
├── AppShell.xaml / AppShell.xaml.cs  # Shell-based navigation
├── MainPage.xaml / MainPage.xaml.cs  # Main UI page with bindings
│
├── ViewModels/
│   ├── BaseViewModel.cs              # Base class with IsBusy, Title
│   └── MainViewModel.cs              # Counter demo & command handling
│
├── Converters/
│   └── InverseBooleanConverter.cs    # XAML value converter
│
├── Resources/
│   ├── Styles/
│   │   ├── Colors.xaml               # Color palette (light/dark theme)
│   │   └── Styles.xaml               # 20+ control styles
│   ├── Images/
│   │   └── dotnet_bot.svg
│   ├── Fonts/
│   │   ├── OpenSans-Regular.ttf
│   │   └── OpenSans-Semibold.ttf
│   ├── AppIcon/                      # App icons & splash screen
│   └── Splash/
│
└── Platforms/
    ├── iOS/
    │   ├── AppDelegate.cs            # iOS lifecycle
    │   └── Program.cs                # iOS entry point
    └── Android/
        ├── MainActivity.cs           # Android main activity
        └── MainApplication.cs        # Android app lifecycle
```

## Tech Stack

| Component | Version | Purpose |
|-----------|---------|---------|
| **.NET** | 10.0 | Runtime framework |
| **.NET MAUI** | 10.0.10 | Cross-platform UI framework |
| **Community Toolkit MVVM** | 8.4.0 | MVVM source generators & attributes |
| **Microsoft.Extensions.DependencyInjection** | 10.0.0 | Constructor-based dependency injection |
| **Target Platforms** | iOS 14.2+, Android 21+ | Supported platforms |

## Architecture

### MVVM Pattern Implementation

**View Layer** (`*.xaml` files):
- XAML-based UI with data binding
- Binds to ViewModel properties and commands
- No business logic in code-behind

**ViewModel Layer** (`ViewModels/`):
- Inherits from `ObservableObject` (Community Toolkit)
- Uses `[ObservableProperty]` for automatic property notifications
- Uses `[RelayCommand]` for automatic command generation
- Base class provides common properties (Title, IsBusy)

**Model Layer**:
- Plain C# data objects
- Serializable for API communication

**Binding Context**:
```csharp
// In MainPage.xaml.cs (constructor injection pattern)
public MainPage(MainViewModel viewModel)
{
    InitializeComponent();
    BindingContext = viewModel;  // Set via constructor
}
```

### Dependency Injection Pattern

The **constructor-based DI pattern** is the modern, recommended approach:

**Setup in MauiProgram.cs**:
```csharp
builder.Services.AddSingleton<AppShell>();
builder.Services.AddSingleton<MainPage>();
builder.Services.AddSingleton<MainViewModel>();
```

**Advantages**:
- ✅ Explicit dependencies (no hidden service locators)
- ✅ Testable (easy to mock dependencies)
- ✅ Type-safe (compile-time verification)
- ✅ Better for Swift 6 strict concurrency
- ✅ Industry best practice

## Key Features

- **Clean MVVM Architecture** - Clear separation of concerns
- **Constructor Injection** - Type-safe dependency resolution
- **Automatic Property Notifications** - Via `[ObservableProperty]` attributes
- **Automatic Command Generation** - Via `[RelayCommand]` attributes
- **Theme Support** - Light/dark theme with `AppThemeBinding`
- **Custom Converters** - XAML value converters for data transformation
- **Responsive Design** - Mobile-first responsive layouts
- **Accessibility** - Semantic properties on all controls
- **Cross-Platform** - Single codebase for iOS and Android

## Quick Start

### Prerequisites
- .NET 10.0 SDK
- Xcode 15+ (for iOS)
- Android SDK 21+ (for Android)
- Visual Studio 2022 or Visual Studio Code

### Build & Run

```bash
# Install dependencies
dotnet restore

# Build the project
dotnet build

# Run on iOS Simulator
dotnet run -f net10.0-ios

# Run on Android Emulator
dotnet run -f net10.0-android

# Build for device deployment
dotnet publish -f net10.0-ios -c Release
dotnet publish -f net10.0-android -c Release
```

## MVVM Patterns Used

### Observable Properties
```csharp
public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private int counter = 0;

    [ObservableProperty]
    private string welcomeText = "Click the button";
}
```

### Relay Commands
```csharp
[RelayCommand]
private void IncrementCounter()
{
    Counter++;
    WelcomeText = $"You clicked {Counter} times";
}
```

### XAML Data Binding
```xml
<Label Text="{Binding WelcomeText}" />
<Button Command="{Binding IncrementCounterCommand}" />
```

## Styling System

The application includes comprehensive styling with theme support:

**Color Palette** (`Resources/Styles/Colors.xaml`):
- **Primary**: #512BD4 (Purple)
- **Secondary**: #DFD8F7 (Light Purple)
- **Tertiary**: #2B0B98 (Dark Purple)
- **Grayscale**: Gray100-Gray950 for light/dark modes

**Theme Binding**:
```xml
<Color x:Key="PageBackground">
    <AppThemeBinding Light="White" Dark="#1F1F1F" />
</Color>
```

## Extending the Project

### Adding a New ViewModel

1. Create class inheriting from `BaseViewModel`
2. Use `[ObservableProperty]` for properties
3. Use `[RelayCommand]` for commands
4. Register in `MauiProgram.cs`
5. Create corresponding XAML page

### Adding a New Page

1. Create `NewPage.xaml` in Screens folder
2. Create `NewPageViewModel.cs` in ViewModels folder
3. Set binding context in `NewPage.xaml.cs` via constructor injection
4. Add route in `AppShell.xaml`

## Testing

The architecture supports unit testing:

```csharp
[TestClass]
public class MainViewModelTests
{
    [TestMethod]
    public void IncrementCounter_ShouldUpdateCounter()
    {
        var viewModel = new MainViewModel();
        viewModel.IncrementCounterCommand.Execute(null);
        Assert.AreEqual(1, viewModel.Counter);
    }
}
```

## Platform-Specific Code

Platform-specific implementations are located in `Platforms/` folder:

- **iOS**: UIKit customizations in `Platforms/iOS/`
- **Android**: Android Framework customizations in `Platforms/Android/`

Access platform features via Xamarin.Essentials or direct platform calls.

## Performance Considerations

- Use `[ObservableProperty]` instead of manual `INotifyPropertyChanged`
- Leverage source generators for compile-time optimization
- Minimize bindings to frequently-updating properties
- Use `WeakReference` for event handlers in long-lived objects

## Best Practices Demonstrated

1. ✅ Constructor-based dependency injection (not service locators)
2. ✅ Separation of concerns (View, ViewModel, Model)
3. ✅ Type-safe property and command generation
4. ✅ Immutable default values
5. ✅ Theme-aware styling
6. ✅ Responsive layouts
7. ✅ Clear project organization
8. ✅ Accessibility support

## Resources

- [Community Toolkit MVVM Docs](https://learn.microsoft.com/en-us/windows/communitytoolkit/mvvm/)
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Dependency Injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

## License

MIT License - See LICENSE file for details.
