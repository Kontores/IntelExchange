import React, { useState, useEffect } from 'react';
import UserService from '../../../services/user-service';
import * as UserStore from '../../../store/UserState';
import { bindActionCreators, Dispatch } from 'redux';
import { connect } from 'react-redux';
import { useTranslation } from 'react-i18next';
import Button from '../../shared/Button/Button';
import Input from '../../shared/Input/Input';
import { useNavigate } from 'react-router-dom';
import { RoutesEnum } from '../../../data/enums/routes';
import { loginValidation, passwordValidation } from './validation';
import './LoginPage.scss';

type DispatchProps = {
    setUser: typeof UserStore.actionCreators.setUser;
}

type LoginPageProps = DispatchProps & {};

const LoginPage: React.FC<LoginPageProps> = ({ setUser }) => {
    const { t } = useTranslation();
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [loginValidationMessage, setLoginValidationMessage] = useState("");
    const [passwordValidationMessage, setPasswordValidationMessage] = useState("");
    const userService = new UserService();
    const navigate = useNavigate();

    const handleLogin = () => {
        const isLoginValid = loginValidation(login, setLoginValidationMessage);
        const isPasswordValid = passwordValidation(password, setPasswordValidationMessage);
        if (isLoginValid && isPasswordValid) {
            userService.login({ login, password })
                .then(() => userService.getLoggedUser())
                .then(result => setUser(result))
               // .then(() => userService.checkAdminPermission())
              //  .then(result => console.log(result))
                .catch(err => console.log(err));
                
                //.then(() => navigate(RoutesEnum.dashboard));
        }
        
    };

    return (
        <div className="loginpage-component">
            <div className="login-form">
                <h2>{t("main.login_page.title")}</h2>
                <div>
                    <Input
                        type="text"
                        value={login}
                        onChange={(e) => setLogin(e.target.value)}
                        label={t("main.login_page.username")}
                        validationMessage={loginValidationMessage}
                    /> 
                    <Input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        label={t("main.login_page.password")}
                        validationMessage={passwordValidationMessage}
                    />                     
                    <div className="button-container">
                        <Button onClick={handleLogin} title={t("main.login_page.log_in")} type="normal" />       
                    </div>                            
                </div>
            </div>           
        </div>
        );
}

const mapDispatchToProps = (dispatch: Dispatch): DispatchProps => ({
    ...bindActionCreators({
        ...UserStore.actionCreators
    }, dispatch),
});

export default connect(null, mapDispatchToProps)(LoginPage);