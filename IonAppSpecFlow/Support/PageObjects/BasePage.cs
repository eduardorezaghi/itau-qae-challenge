using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace IonAppSpecFlow.StepDefinitions
{
    public class BasePage
    {
        protected readonly AndroidDriver driver;
        protected readonly WebDriverWait driverWait;

        public BasePage(AndroidDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this.driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected void ClickElement(By by)
        {
            driver.FindElement(by).Click();
        }

        protected string WriteText(By by, string text)
        {
            WebElement element = driver.FindElement(by);
            var oldText = element.Text;
            element.Clear();
            element.SendKeys(text);
            
            Assert.AreNotEqual(oldText, text);           
            return text;
        }

        protected bool AssertText(By by, string expectedText)
        {
            string actualText = driver.FindElement(by).Text;
            Assert.AreEqual(expectedText, actualText);
            return true;
        }

        protected bool AssertText(By by, Regex expectedText)
        {
            string actualText = driver.FindElement(by).Text;
            Assert.IsTrue(expectedText.IsMatch(actualText));
            return true;
        }

        protected bool IsElementDisplayed(By by)
        {
            try
            {
                return driverWait.Until(driver => driver.FindElement(by).Displayed);
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
    }
}