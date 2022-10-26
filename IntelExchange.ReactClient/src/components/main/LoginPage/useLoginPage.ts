import React, { useState, useEffect } from 'react';
import { isServerSideValidationError, getServerSideValidationErrors, ValidationState } from '../../../data/validation/validation';
import { useNavigate } from 'react-router-dom';
import UserService from '../../../services/user-service';
import UserLoginDataValidator from '../../../data/validation/user-login-data-validator';
import * as UserStore from '../../../store/UserState';

export const useLoginPage = (setUser: typeof UserStore.actionCreators.setUser) => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [validationState, setValidationState] = useState<ValidationState>({ isValid: false, errors: {} });
    const userService = new UserService();
    const navigate = useNavigate();

    const handleLogin = () => {
        const validator = new UserLoginDataValidator();
        const validationResult = validator.validate({ login, password });
        setValidationState(validationResult);
        if (validationResult.isValid) {
            userService.login({ login, password })
                .then(() => userService.getLoggedUser())
                .then(result => setUser(result))
                // .then(() => userService.checkAdminPermission())
                //  .then(result => console.log(result))
                .catch(err => {
                    if (isServerSideValidationError(err)) {
                        const serverValidationErrors = getServerSideValidationErrors(err);
                        setValidationState({ isValid: false, errors: serverValidationErrors });
                        console.log(serverValidationErrors);
                    } else console.log(err);

                    //const data = err.response.data as ValidationErrorResponse;
                    //const keys = Object.keys(data.errors);
                    //keys.forEach(key => console.log(`key: ${key}, value:${data.errors[key]}`));
                    //console.log(Object.keys(data.errors));
                });

            //.then(() => navigate(RoutesEnum.dashboard));
        }

    };

    return { login, setLogin, password, setPassword, validationState, handleLogin}
};