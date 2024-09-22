# itau-qae-challenge

This repo will hold all examples for Itaú SDET Challenge.
The following tools will be used for the challenge:
- [Makefile](https://www.gnu.org/software/make/manual/make.html) for automation of tasks
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) language for the Appium/REST API tests
- [TypeScript](https://www.typescriptlang.org/) language for the Cypress tests
- [Gherkin](https://cucumber.io/docs/gherkin/) for BDD writing
- [SpecFlow](https://specflow.org/) for BDD automation
- [NUnit](https://nunit.org/) for general testing framework
- [Appium](http://appium.io/) for mobile automation
- [Cypress](https://www.cypress.io/) for web automation
- [HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-8.0) for REST API tests, using C# with NUnit and an Adapter for HttpClient



## Table of Contents
- [itau-qae-challenge](#itau-qae-challenge)
  - [Table of Contents](#table-of-contents)
  - [Appium C# with Specflow](#appium-c-with-specflow)
    - [Requirements](#requirements)
    - [Mapping the application elements](#mapping-the-application-elements)
    - [Running the tests](#running-the-tests)
  - [Cypress (Web Automation) - TypeScript](#cypress-web-automation---typescript)
    - [Requirements](#requirements-1)
    - [Running the tests](#running-the-tests-1)
  - [REST API tests (NUnit)](#rest-api-tests-nunit)
    - [Requirements](#requirements-2)


## Appium C# with Specflow
### Requirements
I used the following tools for the Appium C# IonAppSpecFlow project:
- [Dotnet 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
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


## Cypress (Web Automation) - TypeScript
### Requirements
- [Node.js](https://nodejs.org/en/)
- [pnpm](https://pnpm.io/)

To run the tests, first install the dependencies with the following command:
```bash
make cypress_install
```
The following packages are defined in the [package.json](CypressWebTests/package.json) file:
```
CypressWebTests@1.0.0 itau-qae-challenge/CypressWebTests

dependencies:
cypress 13.14.2

devDependencies:
@eslint/js 9.11.0
@types/eslint__js 8.42.3
eslint 9.11.0
eslint-plugin-cypress 3.5.0
rimraf 6.0.1
typescript 5.6.2
typescript-eslint 8.6.0
```


### Running the tests
To run the tests, use the following command:
```bash
make test_cypress
# Or pnpm run test
```


## REST API tests (NUnit)
### Requirements
I used the following tools for the REST API tests:
- [Dotnet 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)

With the dependencies bellow:
```
   > coverlet.collector          6.0.0        6.0.0
   > FluentAssertions            6.12.1       6.12.1
   > Microsoft.NET.Test.Sdk      17.8.0       17.8.0
   > Newtonsoft.Json             13.0.3       13.0.3
   > NUnit                       3.14.0       3.14.0
   > NUnit.Analyzers             3.9.0        3.9.0
   > NUnit3TestAdapter           4.5.0        4.5.0
```

Install the dependencies with the following command:
```bash
make dotnet_restore
```

Then, run the tests with the following command:
```bash
make test_nunit
```
This will run the tests in the terminal.