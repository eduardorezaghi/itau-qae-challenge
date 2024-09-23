
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Android.UiAutomator;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Appium.Interfaces;
using NUnit.Framework;
using System.Text.RegularExpressions;



namespace IonAppSpecFlow.StepDefinitions
{
    public partial class CreateAccountPage : BasePage
    {
        private readonly By pageTitle = MobileBy.Id("com.itau.investimentos:id/title_details");
        private readonly By optionsCarousel = MobileBy.Id("com.itau.investimentos:id/carousel_view");
        private readonly By continueButton = MobileBy.Id("com.itau.investimentos:id/button_continue");
        [GeneratedRegex("comece sua jornada de investimentos com o íon", RegexOptions.IgnoreCase, "pt-BR")]
        private static partial Regex IonInvestmentRegex();

        public CreateAccountPage(AndroidDriver driver) : base(driver) { }

        public bool IsScreenDisplayed()
        {
            IsElementDisplayed(pageTitle);
            IsElementDisplayed(optionsCarousel);
            IsElementDisplayed(continueButton);

            string titleText = WaitForElement(pageTitle).Text;
            Assert.IsTrue(IonInvestmentRegex().IsMatch(titleText));

            return true;
        }
    }
}