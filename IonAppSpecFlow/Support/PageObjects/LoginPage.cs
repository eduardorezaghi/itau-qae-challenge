using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Android.UiAutomator;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Appium.Interfaces;
using NUnit.Framework;
using System.Text.RegularExpressions;
using NUnit.Framework.Constraints;

namespace IonAppSpecFlow.StepDefinitions
{
    public class LoginPage : BasePage
    {
        private readonly By pageTitle = MobileBy.Id("com.itau.investimentos:id/titleTextView");
        private readonly By backButton = MobileBy.Id("com.itau.investimentos:id/backButton");
        private readonly By agencyField = MobileBy.Id("com.itau.investimentos:id/agencyEditText");
        private readonly By accountField = MobileBy.Id("com.itau.investimentos:id/accountEditText");
        private readonly By accountPasswordField = MobileBy.Id("com.itau.investimentos:id/passwordEditText");
        private readonly By forgotPasswordButton = MobileBy.Id("com.itau.investimentos:id/forgotPasswordButton");

        public LoginPage(AndroidDriver driver) : base(driver) { }

        public void ClickBackButton()
        {
            ClickElement(backButton);
        }

        public bool IsScreenDisplayed()
        {
            var isDisplayed = IsElementDisplayed(pageTitle);
            var isCorrectText = AssertText(pageTitle, new Regex("acesso à conta", RegexOptions.IgnoreCase));
            return isDisplayed && isCorrectText;
        }

        public bool AssertBackButtonIsDisplayed()
        {
            return IsElementDisplayed(backButton);
        }

        public bool? AssertFieldsAreDisplayed()
        {
            foreach (By field in new[] { agencyField, accountField, accountPasswordField })
            {
                if (!IsElementDisplayed(field))
                {
                    return false;
                }
            }
            return true;
        }

        public bool? AssertForgotPasswordButtonIsDisplayedAndDisabled()
        {
            if (!IsElementDisplayed(forgotPasswordButton))
            {
                return false;
            }
            return !driver.FindElement(forgotPasswordButton).Enabled;
        }

        public bool? AssertLabelIsDisplayed(string label)
        {
            switch (label)
            {
                case "acesso à conta":
                    return AssertText(pageTitle, new Regex("acesso à conta", RegexOptions.IgnoreCase));
                default:
                    throw new ArgumentException($"Label '{label}' is not recognized");
            }
        }
    }
}