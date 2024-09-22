import { BasePage } from "./BasePage";

export class LoginPage extends BasePage {
    public static readonly URL = "courses.ultimateqa.com/users/sign_in";

    private readonly EMAIL_INPUT = "input[id='user[email]']";
    private readonly PASSWORD_INPUT = "input[id='user[password]']";
    private readonly SUBMIT_BUTTON = ".form__button-group button[type='submit']";
    private readonly ERROR_SNACKBAR = "div[class*='message-alert'][data-type='alert']";
    private readonly ERROR_MESSAGE = "li[class='form-error__list-item']";

    private errorMessageRegex = /Invalid email or password/i;

    constructor() {
        super();
    }

    public login(username: string, password: string): void {
        this.typeText(this.getElement(this.EMAIL_INPUT), username);
        this.typeText(this.getElement(this.PASSWORD_INPUT), password);
        this.clickElement(this.getElement(this.SUBMIT_BUTTON));
    }

    public assertErrorMessage(): void {
        this.getElement(this.ERROR_SNACKBAR).should('be.visible');
        this.getElement(this.ERROR_MESSAGE).invoke('text').should('to.match', this.errorMessageRegex);
    }
}