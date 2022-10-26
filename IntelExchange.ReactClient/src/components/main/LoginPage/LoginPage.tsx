import React, { useState, useEffect } from 'react';
import * as UserStore from '../../../store/UserState';
import { bindActionCreators, Dispatch } from 'redux';
import { connect } from 'react-redux';
import { useTranslation } from 'react-i18next';
import Button from '../../shared/Button/Button';
import Input from '../../shared/Input/Input';
import { RoutesEnum } from '../../../data/enums/routes';
import './LoginPage.scss';
import { useLoginPage } from './useLoginPage';

type DispatchProps = {
    setUser: typeof UserStore.actionCreators.setUser;
}

type LoginPageProps = DispatchProps & {};

const LoginPage: React.FC<LoginPageProps> = ({ setUser }) => {
    const { t } = useTranslation();
    const { login, setLogin, password, setPassword, handleLogin, validationState } = useLoginPage(setUser);

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
                        validationMessage={validationState.errors.login}
                    /> 
                    <Input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        label={t("main.login_page.password")}
                        validationMessage={validationState.errors.password}
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