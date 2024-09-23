using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Android.UiAutomator;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Appium.Interfaces;



namespace IonAppSpecFlow.StepDefinitions
{
    public class SplashPage : BasePage
    {
        private readonly By pageLogo = MobileBy.Id("com.itau.investimentos:id/investLogo");
        private readonly By loginButton = MobileBy.Id("com.itau.investimentos:id/btLogin");
        private readonly By createAccountButton = MobileBy.Id("com.itau.investimentos:id/btSignup");

        public SplashPage(AndroidDriver driver) : base(driver) { }

        public void clickLoginButton() {
            ClickElement(loginButton);
        }

        public void clickCreateAccountButton() {
            ClickElement(createAccountButton);
        }

        public bool IsScreenDisplayed()
        {
            return IsElementDisplayed(pageLogo);
        }
    }
}