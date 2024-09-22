import { LoginPage } from "../../classes/LoginPage";
import { MainPage } from "../../classes/MainPage";

describe('Automation Practice Site', function () {
    let mainPage: MainPage;
    let loginPage: LoginPage;

    context('Dado que esteja na página principal do site', () => {
        beforeEach(() => {
            mainPage = new MainPage();
            mainPage.visitPage(MainPage.URL);
        });

        describe('Validar título e subtítulo', () => {
            it('validar título “Automation Practice”', () => {
                mainPage.assertTitle();
            });

            it('validar subtítulo “Use your skills to learn how to automate different scenarios”', () => {
                mainPage.assertHeaders();
            });
        });

        describe('Realizar login', () => {
            before(() => {
                loginPage = new LoginPage();
            });

            it('realizar o login com email válido e senha inválida', () => {
                mainPage.clickLoginAutomation();
                loginPage.login('eduardo.rezaghi@gmail.com', 'invalidpassword');
                loginPage.assertErrorMessage();
            });
        });
        });
    });
});
