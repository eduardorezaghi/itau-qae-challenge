using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;

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