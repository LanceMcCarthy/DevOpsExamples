# MauiDemo - VS Code Info for XPlat Dev

This repository contains a comprehensive VS Code setup for .NET MAUI development on macOS, supporting all major platforms.

## Prerequisites

### Required Software
1. **Visual Studio Code** - Latest version
2. **.NET SDK** - Version 8.0 or later with MAUI workload
3. **Xcode** - Latest version (for iOS/macOS development)
4. **Android Studio** or **Android SDK** (for Android development)
5. **JDK 17** (for Android development)

### Install MAUI Workload
```bash
sudo dotnet workload install maui
```

### Verify Installation
```bash
dotnet workload list
```

## VS Code Configuration Overview

This project includes a complete VS Code setup with the following files:

### `.vscode/launch.json`
Comprehensive debugging and launch configurations for all platforms:

- **Debug Configurations**: Interactive debugging with breakpoints
  - `Debug Android` - Debug on Android emulator/device
  - `Debug iOS Simulator` - Debug on iOS simulator 
  - `Debug Mac Catalyst` - Debug Mac Catalyst app

- **Build Configurations**: Build-only configurations
  - `Build Android (Debug/Release)` - Build Android APK
  - `Build iOS (Debug/Release)` - Build iOS app
  - `Build Mac Catalyst (Debug/Release)` - Build Mac app

- **Compound Configurations**: Run multiple platforms simultaneously
  - `Debug All Platforms` - Debug all platforms at once
  - `Build All Platforms (Debug)` - Build all debug configurations
  - `Build All Platforms (Release)` - Build all release configurations

### `.vscode/tasks.json`
Pre-configured build tasks for all platforms:

#### Build Tasks
- `build-android-debug` / `build-android-release`
- `build-ios-debug` / `build-ios-release` 
- `build-maccatalyst-debug` / `build-maccatalyst-release`

#### Run Tasks
- `run-android-debug` - Build and run Android
- `run-ios-debug` - Build and run iOS Simulator
- `run-maccatalyst-debug` - Build and run Mac Catalyst

#### Utility Tasks
- `clean` - Clean build artifacts
- `restore` - Restore NuGet packages
- `deploy-android` / `deploy-ios` / `deploy-maccatalyst` - Deploy release builds

### `.vscode/settings.json`
Optimized VS Code settings for MAUI development:

- **Performance Optimizations**: Excludes bin/obj from file watching
- **XAML Support**: File associations and formatting
- **IntelliSense**: Enhanced code completion and hints
- **Hot Reload**: Optimized settings for fast development
- **.NET Configuration**: Solution and runtime settings

### `.vscode/extensions.json`
Recommended extensions for the best MAUI development experience:

- **ms-dotnettools.csharp** - C# language support
- **ms-dotnettools.csdevkit** - .NET development kit
- **ms-dotnettools.vscode-dotnet-runtime** - .NET runtime management
- And many more productivity extensions

## How to Use

### 1. Quick Start - Debug a Platform
1. Open the project in VS Code
2. Press `F5` or go to **Run and Debug** panel
3. Select your target platform:
   - `Debug Android` - Launches Android emulator and debugs
   - `Debug iOS Simulator` - Launches iOS simulator and debugs  
   - `Debug Mac Catalyst` - Launches Mac app and debugs

### 2. Build Only (No Debugging)
1. Go to **Run and Debug** panel
2. Select a build configuration:
   - `Build Android (Debug)`
   - `Build iOS (Release)`
   - etc.

### 3. Run Tasks Manually
1. Press `Cmd+Shift+P`
2. Type "Tasks: Run Task"
3. Select from available tasks:
   - `run-android-debug`
   - `build-ios-release`
   - `clean`
   - etc.

### 4. Debug All Platforms Simultaneously
1. Select `Debug All Platforms` configuration
2. Press `F5`
3. All three platforms will build and launch for debugging

## Platform-Specific Notes

### Android
- Requires Android emulator or connected device
- Uses `net10.0-android` target framework
- APK files generated in `bin/Debug/net10.0-android/`

### iOS
- Requires macOS and Xcode
- Only iOS Simulator supported (device requires Apple Developer account)
- Uses `net10.0-ios` target framework
- App generated in `bin/Debug/net10.0-ios/iossimulator-arm64/`

### Mac Catalyst
- Runs natively on macOS
- Uses `net10.0-maccatalyst` target framework  
- App generated in `bin/Debug/net10.0-maccatalyst/maccatalyst-arm64/`

## Troubleshooting

### Common Issues

1. **"No Android devices found"**
   - Start Android emulator first
   - Check `adb devices` to verify connection

2. **"iOS Simulator not found"**
   - Install Xcode and iOS Simulator
   - Run `xcrun simctl list devices` to verify available simulators

3. **"Build failed - MAUI workload not found"**
   - Install MAUI workload: `sudo dotnet workload install maui`
   - Restart VS Code

4. **"Hot Reload not working"**
   - Ensure `DOTNET_MODIFIABLE_ASSEMBLIES=debug` is set in environment
   - Check that you're running in Debug mode

### Performance Tips

1. **Exclude build folders**: The configuration already excludes `bin/` and `obj/` folders from file watching
2. **Use compound configurations**: Debug multiple platforms simultaneously for comprehensive testing
3. **Leverage tasks**: Use the pre-built tasks instead of manual terminal commands

## Project Structure

```
MauiDemo/
├── .vscode/                    # VS Code configuration
│   ├── launch.json            # Debug configurations
│   ├── tasks.json             # Build tasks
│   ├── settings.json          # VS Code settings
│   ├── extensions.json        # Recommended extensions
│   └── c_cpp_properties.json  # C++ IntelliSense
├── Platforms/                 # Platform-specific code
│   ├── Android/
│   ├── iOS/
│   ├── MacCatalyst/
│   ├── Tizen/
│   └── Windows/
├── Resources/                 # App resources
├── Views/                     # XAML views
├── ViewModels/               # View models
└── MauiProgram.cs            # App configuration
```

## Development Workflow

1. **Setup**: Install prerequisites and open project in VS Code
2. **Code**: Write your MAUI application code
3. **Debug**: Use F5 with platform-specific configurations
4. **Test**: Use compound configurations to test all platforms
5. **Build**: Use release tasks for production builds
6. **Deploy**: Use deploy tasks for final deployment

This setup provides a complete development environment for .NET MAUI applications with support for all major platforms from a single VS Code workspace.