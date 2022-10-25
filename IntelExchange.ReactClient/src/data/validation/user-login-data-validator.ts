import { UserLoginData } from "../user";
import { IValidator } from "./validation";

export default class UserLoginDataValidator implements IValidator<UserLoginData>  {
    validate(model: UserLoginData) {
        const loginError = this.validateLogin(model.login);
        const passwordError = this.validatePassword(model.password);
        const errors: Record<string, string> = {};
        if (loginError) {
            errors.login = loginError;
        }
        if (passwordError) {
            errors.password = passwordError;
        }

        return {
            isValid: Object.keys(errors).length === 0,
            errors
        };
    }

    private validateLogin(login: string): string | undefined {
        if (login === "") {
            return "login cannot be empty";
        }
        return undefined;
    }

    private validatePassword(password: string): string | undefined {
        if (password === "") {
            return "password cannot be empty";
        }
        if (password.length < 8) {
            return "password must be at least 8 characters length";
        }
        if (password.toLowerCase() === password) {
            return "password must contain at least one capital letter";
        }
        return undefined;
    }
}
