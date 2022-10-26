import React, { useState, useEffect } from 'react';
import * as UserStore from '../../../store/UserState';
import { bindActionCreators, Dispatch } from 'redux';
import { connect } from 'react-redux';
import { useTranslation } from 'react-i18next';
import Button from '../../shared/Button/Button';
import Input from '../../shared/Input/Input';
import { RoutesEnum } from '../../../data/enums/routes';
import './Signup.scss';
import { useSignup } from './useSignup';
import { UserType } from '../../../data/enums/user-type';

type DispatchProps = {
    setUser: typeof UserStore.actionCreators.setUser;
}

type SignupProps = DispatchProps & {};

const Signup: React.FC<SignupProps> = ({ setUser }) => {
    const { t } = useTranslation();
   // const { login, setLogin, password, setPassword, handleLogin, validationState } = useSignup(setUser);
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [passwordRepeat, setPasswordRepeat] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [userType, setUserType] = useState<UserType>(UserType.individual);
    const [address, setAddress] = useState("");
    const [ITIN, setITIN] = useState("");

    return (
        <div className="signup-component">
            <div className="signup-form">
                <h2>{t("main.signup.title")}</h2>
                <div>
                    <Input
                        type="text"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        label={t("main.signup.choose_username")}
                       // validationMessage={validationState.errors.login}
                    /> 
                    <Input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        label={t("main.signup.choose_password")}
                      //  validationMessage={validationState.errors.password}
                    />   
                    <Input
                        type="password"
                        value={passwordRepeat}
                        onChange={(e) => setPasswordRepeat(e.target.value)}
                        label={t("main.signup.repeat_password")}
                    //  validationMessage={validationState.errors.password}
                    />  
                    <div className="button-container">
                        <Button onClick={() => { } } title={t("main.signup.sign_up")} type="normal" />       
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

export default connect(null, mapDispatchToProps)(Signup);