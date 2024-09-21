import { MainPage } from "../../classes/MainPage";

Mocha.describe('Automation Practice Site', function () {
    let mainPage: MainPage;

    Mocha.beforeEach(() => {
        mainPage = new MainPage();
        mainPage.visitPage();
    });

    Mocha.it('realize a validação do texto do título “Automation Practice”', () => {
        mainPage.assertTitle();
    });

    Mocha.it('realize a validação do texto “Use your skills to learn how to automate different scenarios”', () => {
        mainPage.assertHeaders();
    });
});
