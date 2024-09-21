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
        private readonly int DEFAULT_TIMEOUT = 15;
        private readonly int POLLING_INTERVAL = 250;

        public BasePage(AndroidDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DEFAULT_TIMEOUT);
            this.driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(DEFAULT_TIMEOUT));
        }

        protected void ClickElement(By by)
        {
            WaitForElement(by).Click();
        }

        protected IWebElement WaitForElement(By by)
        {
            var fluentWait = new DefaultWait<AndroidDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(DEFAULT_TIMEOUT),
                PollingInterval = TimeSpan.FromMilliseconds(POLLING_INTERVAL)
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement element = fluentWait.Until(driver => driver.FindElement(by));

            return element;
        }

        protected string WriteText(By by, string text)
        {
            WebElement element = (WebElement)WaitForElement(by);
            var oldText = element.Text;
            element.Clear();
            element.SendKeys(text);
            
            Assert.AreNotEqual(oldText, text);           
            return text;
        }

        protected bool AssertText(By by, string expectedText)
        {
            string actualText = WaitForElement(by).Text;
            Assert.AreEqual(expectedText, actualText);
            return true;
        }

        protected bool AssertText(By by, Regex expectedText)
        {
            string actualText = WaitForElement(by).Text;
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