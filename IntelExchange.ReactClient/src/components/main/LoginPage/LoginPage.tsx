import React, { useState, useEffect } from 'react';
import UserService from '../../../services/user-service';
import * as UserStore from '../../../store/UserState';
import { bindActionCreators, Dispatch } from 'redux';
import { connect } from 'react-redux';
import './LoginPage.scss';

type DispatchProps = {
    setUser: typeof UserStore.actionCreators.setUser;
}

type LoginPageProps = DispatchProps & {};

const LoginPage: React.FC<LoginPageProps> = ({ setUser }) => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const userService = new UserService();

    const handleLogin = () => {
        userService.login({ login, password })
            .then(() => userService.getUserLogin()
            .then(result => { setUser({ id: "", login: result }) }))
    };

    return (
        <div className="loginpage-component">
            <h2>Please login</h2>
            <div>
                <p>Login</p>
                <input type="text" value={login} onChange={(e) => setLogin(e.target.value)} />
                <p>Password</p>
                <input type="text" value={password} onChange={(e) => setPassword(e.target.value)} />
                <button onClick={handleLogin}>Log In</button>
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