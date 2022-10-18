import React, { useState, useEffect } from 'react';
import UserService from '../../../services/user-service';
import * as UserStore from '../../../store/UserState';
import { bindActionCreators, Dispatch } from 'redux';
import { connect } from 'react-redux';
import { useTranslation } from 'react-i18next';
import Button from '../../shared/Button/Button';
import { useNavigate } from 'react-router-dom';
import { RoutesEnum } from '../../../data/enums/routes';
import './LoginPage.scss';

type DispatchProps = {
    setUser: typeof UserStore.actionCreators.setUser;
}

type LoginPageProps = DispatchProps & {};

const LoginPage: React.FC<LoginPageProps> = ({ setUser }) => {
    const { t } = useTranslation();
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const userService = new UserService();
    const navigate = useNavigate();

    const handleLogin = () => {
        userService.login({ login, password })
            .then(() => userService.getUserLogin()
            .then(result => { setUser({ id: "", login: result }) })
            .then(() => navigate(RoutesEnum.dashboard)));
    };

    return (
        <div className="loginpage-component">
            <div className="login-form">
                <h2>Please login</h2>
                <div>
                    <label>Login</label>
                    <input type="text" value={login} onChange={(e) => setLogin(e.target.value)} />
                    <label>Password</label>
                    <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
                    <div className="button-container">
                        <Button onClick={handleLogin} title="Log in" type="normal" />       
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