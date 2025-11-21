# MauiWithMvvm

A .NET MAUI mobile application demonstrating MVVM (Model-View-ViewModel) architecture using the Community Toolkit MVVM framework with Constructor Injection.

## Overview

This project showcases best practices for building cross-platform mobile applications with .NET MAUI. It demonstrates:

- **MVVM Pattern Implementation**: Clean separation between UI (View), presentation logic (ViewModel), and data (Model)
- **Constructor Injection Pattern**: ViewModels are injected through constructors, providing better testability and loose coupling
- **Source Generators**: Leverages Community Toolkit's source generators for reduced boilerplate code
- **Counter Application**: Interactive demo showing state management and command binding

This is one of three demonstration projects comparing different MVVM frameworks:
- **MauiWithMvvm** (this project) - Community Toolkit MVVM with constructor injection
- **MauiWithPrism** - Service locator pattern with static ServiceProvider
- **MauiWithMvvmCross** - MvvmCross enterprise framework integration

## Features

- **MVVM Architecture**: Clean separation of concerns using the Community Toolkit MVVM library
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection for managing application dependencies
- **Constructor Injection**: ViewModels are injected through constructors for better testability
- **Observable Properties**: Automatic UI updates using the MVVM Toolkit's `[ObservableProperty]` attribute
- **Relay Commands**: Type-safe command implementation with `[RelayCommand]` attribute
- **Multi-Platform Support**: Runs on Android and iOS

## Project Structure

```
MauiWithMvvm/
├── ViewModels/
│   ├── BaseViewModel.cs          # Abstract base class for all ViewModels
│   └── MainViewModel.cs          # ViewModel for MainPage
├── MainPage.xaml                 # Main UI page
├── MainPage.xaml.cs              # Code-behind with constructor injection
├── App.xaml                      # Application resources
├── App.xaml.cs                   # App startup logic
├── AppShell.xaml                 # Navigation shell
├── MauiProgram.cs                # DI configuration and app startup
└── README.md                     # This file
```

## Getting Started

### Prerequisites

- .NET 10 SDK or later
- Visual Studio 2022, Visual Studio Code, or JetBrains Rider
- Android SDK (for Android builds)
- Xcode (for iOS builds on macOS)

### Building the Project

```bash
# Restore dependencies
dotnet restore

# Build for all platforms
dotnet build

# Build for specific platform
dotnet build -f net10.0-android
dotnet build -f net10.0-ios
```

### Running the Application

```bash
# Run on Android emulator
dotnet run -f net10.0-android

# Run on iOS simulator
dotnet run -f net10.0-ios
```

## MVVM Implementation

### BaseViewModel

The `BaseViewModel` class serves as the foundation for all ViewModels in the application:

```csharp
[ObservableProperty]
private bool isBusy;

[ObservableProperty]
private string title = string.Empty;
```

### MainViewModel

The `MainViewModel` demonstrates:

- Observable properties for data binding
- Relay commands for user interactions
- Counter functionality with dynamic message updates

```csharp
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
```

## Dependency Injection

Services are registered in `MauiProgram.cs`:

```csharp
builder.Services.AddSingleton<AppShell>();
builder.Services.AddSingleton<MainViewModel>();
builder.Services.AddSingleton<MainPage>();
```

The `MainPage` receives its ViewModel through constructor injection:

```csharp
public MainPage(MainViewModel viewModel)
{
    InitializeComponent();
    BindingContext = viewModel;
}
```

## Technologies Used

- **.NET MAUI**: Cross-platform mobile framework
- **Community Toolkit MVVM**: MVVM implementation with source generators
- **Microsoft.Extensions.DependencyInjection**: Dependency injection container
- **C# 13**: Latest language features

## Supported Platforms

- Android 21.0+
- iOS 14.2+

## License

MIT License - See LICENSE file for details

## Author

Preetanshu Mishra
