using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace IonAppSpecFlow.Drivers
{
    public class AppiumDriverFactory
    {
        private static AndroidDriver? _driver;

        public static AndroidDriver InitializeDriver()
        {
            if (_driver == null)
            {
                var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");
                var driverOptions = new AppiumOptions()
                {
                    AutomationName = AutomationName.AndroidUIAutomator2,
                    PlatformName = "Android",
                    DeviceName = "Pixel 8 Pro",
                };
                driverOptions.AddAdditionalAppiumOption("appPackage", "com.itau.investimentos");
                driverOptions.AddAdditionalAppiumOption("appActivity", "com.itau.investimentos.launcher.LauncherActivity");
                driverOptions.AddAdditionalAppiumOption("noReset", true);

                _driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return _driver;
        }

        public static void BackToHomeScreen()
        {
            if (_driver != null)
            {
                _driver.Navigate().Back();
            }
        }
        public static void QuitDriver()
        {
            if (_driver == null) return;
            _driver.TerminateApp("com.itau.investimentos");
            _driver.Dispose();
        }
    }
}