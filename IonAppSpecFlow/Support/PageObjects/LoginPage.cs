using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Text.RegularExpressions;

namespace IonAppSpecFlow.StepDefinitions
{
    public partial class LoginPage : BasePage
    {
        private readonly By pageTitle = MobileBy.Id("com.itau.investimentos:id/titleTextView");
        private readonly By backButton = MobileBy.Id("com.itau.investimentos:id/backButton");
        private readonly By agencyField = MobileBy.Id("com.itau.investimentos:id/agencyEditText");
        private readonly By accountField = MobileBy.Id("com.itau.investimentos:id/accountEditText");
        private readonly By accountPasswordField = MobileBy.Id("com.itau.investimentos:id/passwordEditText");
        private readonly By forgotPasswordButton = MobileBy.Id("com.itau.investimentos:id/forgotPasswordButton");
        private readonly By helpIcon = MobileBy.Id("com.itau.investimentos:id/helpButton");

        // Error elements
        private readonly By errorSnackbar = MobileBy.Id("com.itau.investimentos:id/errorView");
        private readonly By errorTextView = MobileBy.Id("com.itau.investimentos:id/errorMessageTextView");

        // Regexes
        [GeneratedRegex("acesso à conta", RegexOptions.IgnoreCase, "pt-BR")]
        private static partial Regex AccountAccessRegex();
        [GeneratedRegex("agência ou conta incorreta", RegexOptions.IgnoreCase, "pt-BR")]
        private static partial Regex IncorrectLoginDataRegex();

        public LoginPage(AndroidDriver driver) : base(driver) { }

        public void ClickBackButton()
        {
            ClickElement(backButton);
        }

        public void ClickForgotPasswordButton()
        {
            ClickElement(forgotPasswordButton);
        }

        public void ClickHelpIcon()
        {
            ClickElement(helpIcon);
        }

        public void EnterAgency(string text)
        {
            WriteText(agencyField, text);
        }

        public void EnterAccount(string text)
        {
            WriteText(accountField, text);
        }

        public bool IsScreenDisplayed()
        {
            var isDisplayed = IsElementDisplayed(pageTitle);
            var isCorrectText = AssertText(pageTitle, AccountAccessRegex());
            return isDisplayed && isCorrectText;
        }

        public bool AssertBackButtonIsDisplayed()
        {
            return IsElementDisplayed(backButton);
        }

        public bool? AssertFieldsAreDisplayed()
        {
            var fields = new[] { agencyField, accountField, accountPasswordField };
            var displayedFields = fields.Select(IsElementDisplayed).ToList();

            try
            {
                CollectionAssert.AllItemsAreNotNull(displayedFields);
                CollectionAssert.DoesNotContain(displayedFields, false);
                return true;
            }
            catch (AssertionException)
            {
                return false;
            }
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
                    return AssertText(pageTitle, AccountAccessRegex());
                default:
                    throw new ArgumentException($"Label '{label}' is not recognized");
            }
        }

        public bool? AssertErrorMessageIsDisplayed()
        {
            return IsElementDisplayed(errorSnackbar);
        }

        public bool? AssertInvalidLoginData()
        {
            var isError = IsElementDisplayed(errorSnackbar);
            var isValidErrorMessage = AssertText(errorTextView, IncorrectLoginDataRegex());

            return isError && isValidErrorMessage;

        }
    }
}