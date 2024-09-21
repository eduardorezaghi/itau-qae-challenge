using BoDi;
using IonAppSpecFlow.Drivers;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace IonAppSpecFlow.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = AppiumDriverFactory.InitializeDriver();
            _objectContainer.RegisterInstanceAs<AndroidDriver>(driver);
        }

        [AfterScenario]
        // Return to the splash screen
        public void AfterScenario() {
            AppiumDriverFactory.BackToHomeScreen();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            AppiumDriverFactory.QuitDriver();
        }
    }
}