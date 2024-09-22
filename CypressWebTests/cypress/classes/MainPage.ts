import { BasePage } from "./BasePage";
import { LoginPage } from "./LoginPage";

export class MainPage extends BasePage {
    public static readonly URL = "/";

    private readonly PAGE_TITLE = 'Automation Practice - Ultimate QA';
    private readonly PRACTICE_HEADER_TITLE = "Automation Practice";
    private readonly SUBHEADER_TITLE = "Use your skills to learn how to automate different scenarios";

    private readonly HEADER_DIV = "div[class='et_pb_text_inner']:eq(0)";
    private readonly AUTOMATION_PRACTICE_TITLE = "span[id='Automation_Practice']";
    private LOGIN_AUTOMATION_LINK = "a[href*='courses.ultimateqa.com/users/sign_in']";

    private subHeaderRegex = new RegExp(this.SUBHEADER_TITLE);
    
    constructor() {
        super();
    }

    public assertTitle(): void {
        cy.title().should('eq', this.PAGE_TITLE);
    }

    public assertHeaders(): void {
        this.getElement(this.HEADER_DIV)
            .within(() => {
                this.getElement(this.AUTOMATION_PRACTICE_TITLE).should('have.text', this.PRACTICE_HEADER_TITLE);
                this.getElement("strong").invoke('text').should('to.match', this.subHeaderRegex);
            });
    }

    public clickLoginAutomation(): void {
        // We must use invoke instead of click because the button has a click tracker
        // that fires many other requests and we don't want to deal with them
        this.getElement(this.LOGIN_AUTOMATION_LINK).invoke('attr', 'href').then((href) => {
            cy.visit(href!);
            return cy.url();
        })
        .should(url => assert.isTrue(url.includes(LoginPage.URL)));
    }
}