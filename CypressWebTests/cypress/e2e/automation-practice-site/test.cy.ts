import { InteractionPage } from "../../classes/InteractionPage";
import { LoginPage } from "../../classes/LoginPage";
import { MainPage } from "../../classes/MainPage";

describe('Automation Practice Site', function () {
    let mainPage: MainPage;
    let loginPage: LoginPage;
    let interactionPage: InteractionPage;

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

        describe('Interagir com elementos', () => {
            beforeEach(() => {
                interactionPage = new InteractionPage();
                interactionPage.visitPage(InteractionPage.URL);
            });

            it('selecionar e validar radio button', () => {
                interactionPage.checkRadioButton('male')
                .then(radio => interactionPage.assertRadioButtonIsChecked(radio));
            });

            it('selecionar e validar checkbox', () => {
                interactionPage.toggleCheckbox('Bike')
                .then(checkbox => interactionPage.assertCheckboxIsChecked(checkbox));
            });

            it('selecionar e validar dropdown', () => {
                interactionPage.selectDropdownOption('audi')
                .then(dropdown => interactionPage.assertDropdownOptionIsSelected(dropdown, 'audi'));
            });

        });
    });
});
