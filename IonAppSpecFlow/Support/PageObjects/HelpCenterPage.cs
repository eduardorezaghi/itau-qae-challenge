using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Text.RegularExpressions;

namespace IonAppSpecFlow.StepDefinitions
{
    public partial class HelpCenterPage : BasePage
    {
        private readonly By pageSubtitle = MobileBy.Id("com.itau.investimentos:id/subtitle");
        private readonly By pageScrollHelpSections = MobileBy.Id("com.itau.investimentos:id/nested_scroll");
        private readonly By feedbackButton = MobileBy.Id("com.itau.investimentos:id/btn_feedback");

        // Regexes
        [GeneratedRegex("central de ajuda", RegexOptions.IgnoreCase, "pt-BR")]
        private static partial Regex HelpCenterRegex();

        public HelpCenterPage(AndroidDriver driver) : base(driver) { }

        public bool IsScreenDisplayed()
        {
            var isDisplayed = IsElementDisplayed(pageSubtitle);
            var isCorrectText = AssertText(pageSubtitle, HelpCenterRegex());
            var isScrollDisplayed = IsElementDisplayed(pageScrollHelpSections);
            var isFeedbackButtonDisplayed = IsElementDisplayed(feedbackButton);

            var pageScrollHelpSectionsEl = WaitForElement(pageScrollHelpSections);
            var childElements = pageScrollHelpSectionsEl.FindElements(By.XPath(".//*"));
            bool allVisible = childElements.All(element => element.Displayed);

            return isDisplayed && isCorrectText && isScrollDisplayed && isFeedbackButtonDisplayed && allVisible;
        }
    }
}