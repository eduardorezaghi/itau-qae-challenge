import { BasePage } from "./BasePage";

export class MainPage extends BasePage {
    private readonly PAGE_TITLE = 'Automation Practice - Ultimate QA';
    private readonly PRACTICE_HEADER_TITLE = "Automation Practice";
    private readonly SUBHEADER_TITLE = "Use your skills to learn how to automate different scenarios";

    private readonly HEADER_DIV = "div[class='et_pb_text_inner']:eq(0)";
    private readonly AUTOMATION_PRACTICE_TITLE = "span[id='Automation_Practice']";
    private COMPLICATED_PAGE_LINK = "a[href='../complicated-page']";
    private FAKE_LANDING_PAGE_LINK = "a[href='../fake-landing-page']";
    private FAKE_PRICING_PAGE_LINK = "a[href='../fake-pricing-page']";

    constructor() {
        super();
    }

    public visitPage(): void {
        cy.visit('/');
    }

    public assertTitle(): void {
        cy.title().should('eq', this.PAGE_TITLE);
    }

    public assertHeaders(): void {
        this.getElement(this.HEADER_DIV)
            .within(() => {
                this.getElement(this.AUTOMATION_PRACTICE_TITLE).should('have.text', this.PRACTICE_HEADER_TITLE);
                this.getElement("strong").invoke('text').should('match', new RegExp(this.SUBHEADER_TITLE));
            });
    }
}