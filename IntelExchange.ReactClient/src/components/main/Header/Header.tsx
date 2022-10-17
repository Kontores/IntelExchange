import React from 'react';
import './Header.scss';
import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../../../store/ApplicationState';
import { UserState } from '../../../store/UserState';
import * as SidebarStore from '../../../store/SidebarState';

type StateProps = { user: UserState }

type DispatchProps = { showSidebar: typeof SidebarStore.actionCreators.showSidebar }

type HeaderProps = StateProps & DispatchProps & {};

const Header: React.FC<HeaderProps> = ({ user, showSidebar }) => {
    return (
        <div className="header-component">
            <div className="test-class mobile-only">mobile</div>
            <div className="test-class tablet-only">tablet</div>
            <div className="test-class desktop-only">desktop</div>
            <Link to="/dashboard">Dashboard</Link>
            <Link to="/account/login">Login</Link>
            <Link to="/">Home</Link>
            <h2>This is Header</h2>
            <div>welcome {user?.login}</div>
            <div onClick={showSidebar}>Show Sidebar</div>
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