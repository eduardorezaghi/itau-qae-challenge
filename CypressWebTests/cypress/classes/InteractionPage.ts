import { BasePage } from "./BasePage";

export class InteractionPage extends BasePage {
    public static readonly URL = "/simple-html-elements-for-automation";

    private readonly GENERIC_RADIO_LOCATOR = "input[type='radio'][name='gender']";
    private readonly GENERIC_CHECKBOX_LOCATOR = "input[type='checkbox'][name='vehicle']";
    private readonly DROPDOWN_LOCATOR = "div[class='et_pb_blurb_description'] > select";

    constructor() {
        super();
    }

    public checkRadioButton(radioValue: string): Cypress.Chainable<JQuery<HTMLElement>> {
        return this.getElement(this.GENERIC_RADIO_LOCATOR + `[value='${radioValue}']`)
            .check();
    }

    public toggleCheckbox(checkboxValue: string): Cypress.Chainable<JQuery<HTMLElement>> {
        return this.getElement(this.GENERIC_CHECKBOX_LOCATOR + `[value='${checkboxValue}']`)
            .check();
    }

    public selectDropdownOption(option: string): Cypress.Chainable<JQuery<HTMLElement>> {
        return this.getElement(this.DROPDOWN_LOCATOR)
            .select(option);
    }

    public assertRadioButtonIsChecked(radio: JQuery<HTMLElement>) {
        return cy.wrap(radio).should('be.checked');
    }

    public assertCheckboxIsChecked(checkbox: JQuery<HTMLElement>): void {
        cy.wrap(checkbox).should('be.checked');
    }

    public assertDropdownOptionIsSelected(dropdown: JQuery<HTMLElement>, option: string): void {
        cy.wrap(dropdown).should('have.value', option);
    }
}