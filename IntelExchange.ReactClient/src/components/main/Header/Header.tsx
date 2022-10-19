import React from 'react';
import { useTranslation } from 'react-i18next';
import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../../../store/ApplicationState';
import { UserState } from '../../../store/UserState';
import * as SidebarStore from '../../../store/SidebarState';
import './Header.scss';


type StateProps = { user: UserState }

type DispatchProps = { showSidebar: typeof SidebarStore.actionCreators.showSidebar }

type HeaderProps = StateProps & DispatchProps & {};

const Header: React.FC<HeaderProps> = ({ user, showSidebar }) => {
    const { t } = useTranslation();
    return (
        <div className="header-component">
            <h2>{t("main.header.title")}</h2>
            {user.login ?
                (<div className="username-placeholder">{user.login}</div>)
                : (<>
                    <div className="header-item"><Link to="/account/login">{t("main.header.log_in")}</Link></div>
                    <div className="header-item"><Link to="/account/signup">{t("main.header.sign_up")}</Link></div>
                </>)}            
            <div className="show-sidebar-icon" onClick={showSidebar}>{"<<"}</div>
        </div>
        );
}

const mapStateToProps = (state: ApplicationState): StateProps => ({
    user: state.user
});

const mapDispatchToProps = (dispatch: Dispatch): DispatchProps => ({
    ...bindActionCreators({
        ...SidebarStore.actionCreators
    }, dispatch),
});

export default connect(mapStateToProps, mapDispatchToProps)(Header);