# MauiWithMvvm

A .NET MAUI sample demonstrating the modern MVVM pattern using constructor-based dependency injection with the Community Toolkit MVVM library.

## Overview

This project showcases best practices for implementing MVVM in .NET MAUI applications using:
- **Community Toolkit MVVM** - Modern, lightweight MVVM framework with source generators
- **Constructor Injection** - Recommended modern DI pattern with `Microsoft.Extensions.DependencyInjection`
- **Type Safety** - Strong typing with platform-specific abstractions

## Tech Stack

- .NET 10.0
- .NET MAUI 10.0.10
- Community Toolkit MVVM 8.4.0
- Microsoft.Extensions.DependencyInjection 10.0.0

## Quick Start

```bash
# Build the project
dotnet build

# Run on iOS
dotnet run -f net10.0-ios

# Run on Android
dotnet run -f net10.0-android
```

## Key Features

- Clean MVVM architecture with view models and converters
- Dependency injection setup in `MauiProgram.cs`
- Platform-specific code in `Platforms/` directory
- XAML-based UI with data binding
- Cross-platform support (iOS and Android)

## License

MIT License - See LICENSE file for details.
