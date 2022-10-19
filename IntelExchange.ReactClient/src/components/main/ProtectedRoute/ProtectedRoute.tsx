import React from 'react';
import { Route, Navigate } from 'react-router-dom';
import { RoutesEnum } from '../../../data/enums/routes';
import { UserRole } from '../../../data/enums/user-role';
import { ApplicationState } from '../../../store/ApplicationState';
import { UserState } from '../../../store/UserState';
import { connect } from 'react-redux';

type StateProps = {
    user: UserState;
}

type ProtectedRouteProps = StateProps & {
    path: RoutesEnum;
    roles: UserRole[];
    element: JSX.Element;
};

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ path, roles, user, element }) => {
    const isUserAuthorized = (userRoles: UserRole[], requiredRoles: UserRole[]) => (
        requiredRoles.reduce((res: boolean, role: UserRole) => userRoles.includes(role), false));

    if (!user) {
        return (<Navigate to={RoutesEnum.login} />)
    } else {
        return (isUserAuthorized(user.roles, roles))
            ? (<Route path={path} element={element} />) : (<Navigate to={RoutesEnum.home} />);
    }
    
}

const mapStateToProps = (state: ApplicationState): StateProps => ({
    user: state.user
});

export default connect(mapStateToProps)(ProtectedRoute);