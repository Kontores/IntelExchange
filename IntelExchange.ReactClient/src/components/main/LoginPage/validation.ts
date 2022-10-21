export const loginValidation = (login: string, setValidationMessage: React.Dispatch<React.SetStateAction<string>>) => {
    if (login === "") {
        setValidationMessage("Login cannot be empty");
        return false;
    };

    setValidationMessage("");
    return true;
}

export const passwordValidation = (password: string, setValidationMessage: React.Dispatch<React.SetStateAction<string>>) => {
    if (password === "") {
        setValidationMessage("Password cannot be empty");
        return false;
    }
    if (password.length < 8) {
        setValidationMessage("Password must be at least 8 characters length");
        return false;
    }
    if (password.toLowerCase() === password) {
        setValidationMessage("Password must contain at least one capital letter");
        return false;
    }

    setValidationMessage("");
    return true;
}