using BoDi;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace IonAppSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class LoginPageStepDefinitions
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;
        private readonly AndroidDriver _driver;
        private SplashPage _splashPage;
        private LoginPage _loginPage;
        private CreateAccountPage _createAccountPage;
        private string _button;

        public LoginPageStepDefinitions(IObjectContainer objectContainer)
        {
            _container = objectContainer;
            _driver = _container.Resolve<AndroidDriver>();
            _splashPage = new SplashPage(_driver);
            _loginPage = new LoginPage(_driver);
            _createAccountPage = new CreateAccountPage(_driver);
        }


        [Given("que esteja na tela de login")]
        public void GivenUserIsInLoginScreen()
        {
            _splashPage.clickLoginButton();
            Assert.IsTrue(_loginPage.IsScreenDisplayed());
        }

        [Given("desejo validar se os componentes estão na tela")]
        public void WhenUserWantsToValidate()
        {
            Assert.IsTrue(_loginPage.IsScreenDisplayed());
        }

        [Given("desejo validar o botão (.*)")]
        public void WhenUserWantsToValidate(string button)
        {
            _button = button;
            Assert.IsInstanceOf<string>(_button);
        }

        [When("iniciar a validação")]
        public void WhenUserClicks()
        {   
            Assert.IsTrue(_loginPage.IsScreenDisplayed());
        }

        [When("clicar no botão (.*)")]
        public void WhenUserClicks(string _)
        {
            switch(_button.ToLower()) {
                case "voltar":
                    _loginPage.ClickBackButton();
                    break;
                default:
                    throw new ArgumentException(
                        $"Button '{_button}' is not recognized"
                    );
            }
        }

        [Then("o botão voltar deve estar presente na tela")]
        public void ThenBackButtonIsDisplayed()
        {
            Assert.IsTrue(_loginPage.AssertBackButtonIsDisplayed());
        }


        [Then("a label (.*) deve estar presente na tela")]
        public void ThenLabelIsDisplayed(string label)
        {
            Assert.IsTrue(_loginPage.AssertLabelIsDisplayed(label));
        }


        [Then("os campos de agência, conta e senha devem estar presentes na tela")]
        public void ThenFieldsAreDisplayed()
        {
            Assert.IsTrue(_loginPage.AssertFieldsAreDisplayed());
        }


        [Then("o botão esqueci minha senha deve estar presente na tela, porém inibido")]
        public void ThenForgotPasswordButtonIsDisplayed()
        {
            Assert.IsTrue(_loginPage.AssertForgotPasswordButtonIsDisplayedAndDisabled());
        }

    }
}
