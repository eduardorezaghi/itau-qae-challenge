using BoDi;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace IonAppSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class SplashScreenStepDefinitions
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;
        private readonly AndroidDriver _driver;
        private SplashPage _splashPage;
        private LoginPage _loginPage;
        private CreateAccountPage _createAccountPage;

        public SplashScreenStepDefinitions(IObjectContainer objectContainer)
        {
            _container = objectContainer;
            _driver = _container.Resolve<AndroidDriver>();
            _splashPage = new SplashPage(_driver);
            _loginPage = new LoginPage(_driver);
            _createAccountPage = new CreateAccountPage(_driver);
        }


        [Given("que esteja na tela principal do App")]
        public void GivenUserIsInSplashScreen()
        {
            Assert.IsTrue(_splashPage.IsSplashScreenDisplayed());
        }

        [When("clicar em (.*)")]
        public void WhenUserClicks(string button)
        {
            switch(button.ToLower()) {
                case "entrar":
                    _splashPage.clickLoginButton();
                    break;
                case "abrir conta":
                    _splashPage.clickCreateAccountButton();
                    break;
                default:
                    throw new ArgumentException(
                        $"Button '{button}' is not recognized"
                    );
            }
        }

        [Then("o usuário é redirecionado para (.*)")]
        public void ThenScreenIsShown(string screen)
        {
            switch(screen.ToLower()) {
                case "tela de login":
                    Assert.IsTrue(_loginPage.IsScreenDisplayed());
                    break;
                case "tela de abertura de conta":
                    Assert.IsTrue(_createAccountPage.IsScreenDisplayed());
                    break;
                default:
                    throw new ArgumentException(
                        $"Screen '{screen}' is not recognized"
                    );
            }
        }
    }
}
