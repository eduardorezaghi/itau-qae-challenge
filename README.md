# itau-qae-challenge

This repo will hold all examples for Itaú SDET Challenge.
The following tools will be used for the challenge:
- [Makefile](https://www.gnu.org/software/make/manual/make.html) for automation of tasks
- [Python](https://www.python.org/) for minor automation (alongside with Makefile)
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) as the main language for the challenge
- [NUnit](https://nunit.org/) for general testing framework
- [Appium](http://appium.io/) for mobile automation
- [Cypress](https://www.cypress.io/) for web automation
- [RestSharp](https://restsharp.dev/) for API automation



## Table of Contents
- [itau-qae-challenge](#itau-qae-challenge)
  - [Table of Contents](#table-of-contents)
  - [Appium C# with Specflow](#appium-c-with-specflow)
    - [Requirements](#requirements)
    - [Mapping the application elements](#mapping-the-application-elements)
    - [Running the tests](#running-the-tests)


## Appium C# with Specflow
### Requirements
I used the following tools for the Appium C# IonAppSpecFlow project:
- [Appium](http://appium.io/)
- [Android Studio](https://developer.android.com/studio)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/) or [Visual Studio Code](https://code.visualstudio.com/) with C# extension

To run the tests, first I started the Appium server with the following command:
```bash
appium --allow-cors
```

Then, I started the Android Emulator with the following command:
```bash
emulator -avd "Pixel_8_Pro_API_34"
```
Note, though. You must have an emulator created in Android Studio to run the tests.
To list the available emulators, you can use the following command:
```bash
emulator -list-avds
```

### Mapping the application elements
To map the elements of the application, I used the [Appium Inspector Web](https://inspector.appiumpro.com/) tool.
It allows you to inspect the elements of the application and get the locator of each one of them, given that it is connected to the local Appium server.

Here's the JSON used to connect locally.
```json
{
  "appium:automationName": "UiAutomator2",
  "appium:platformName": "Android",
  "appium:platformVersion": "14",
  "appium:deviceName": "emulator-5554",
  "appium:appPackage": "com.itau.investimentos",
  "appium:appActivity": "com.itau.investimentos.launcher.LauncherActivity"
}
```


### Running the tests
First, install the dependencies with the following command:
```bash
make dotnet_restore
```
The following packages are defined in the [IonAppSpecFlow.csproj](IonAppSpecFlow/IonAppSpecFlow.csproj) file:
```
   Top-level Package                    Requested    Resolved
   > Appium.WebDriver                   5.2.0        5.2.0
   > FluentAssertions                   6.2.0        6.2.0
   > Microsoft.NET.Test.Sdk             17.0.0       17.0.0
   > nunit                              3.13.2       3.13.2
   > NUnit3TestAdapter                  4.1.0        4.1.0
   > Selenium.WebDriver                 4.25.0       4.25.0
   > SeleniumExtras.WaitHelpers         1.0.2        1.0.2
   > SpecFlow.NUnit                     3.9.40       3.9.40
   > SpecFlow.Plus.LivingDocPlugin      3.9.57       3.9.57
```


Then, run the tests with the following command:
```bash
make test_appium
# or dotnet test --property:WarningLevel=0
```
This will run the tests in the emulator.

