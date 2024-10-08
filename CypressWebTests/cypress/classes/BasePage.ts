export class BasePage {
    protected static URL?: string;

    public visitPage(url: string): void {
        cy.visit(url);
    }

    protected getElement(selector: string): Cypress.Chainable<JQuery<HTMLElement>> {
        return cy.get(selector);
    }

    protected clickElement(element: Cypress.Chainable<JQuery<HTMLElement>>): Cypress.Chainable<JQuery<HTMLElement>> {
        return element
            .click()
            .then(() => element);
    }

    protected typeText(element: Cypress.Chainable<JQuery<HTMLElement>>, text: string): Cypress.Chainable<JQuery<HTMLElement>> {
        return element
            .type(text)
            .then(() => element);
    }
}