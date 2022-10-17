import React from 'react';
import './Header.scss';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../../../store/ApplicationState';
import { UserState } from '../../../store/UserState';

type StateProps = { user: UserState }

type HeaderProps = StateProps & {};

const Header: React.FC<HeaderProps> = ({ user }) => {
    console.log("header rendered");
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
        </div>
        );
}

const mapStateToProps = (state: ApplicationState): StateProps => ({
    user: state.user
});

export default connect(mapStateToProps)(Header);