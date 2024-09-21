import { MainPage } from "../../classes/MainPage";

describe('Automation Practice Site', function () {
    let mainPage: MainPage;

    context('Dado que esteja na página principal do site', () => {
        beforeEach(() => {
            mainPage = new MainPage();
            mainPage.visitPage();
        });

        it('Então realize a validação do texto do título “Automation Practice”', () => {
            mainPage.assertTitle();
        });

        it('E realize a validação do texto “Use your skills to learn how to automate different scenarios”', () => {
            mainPage.assertHeaders();
        });
    });
});
