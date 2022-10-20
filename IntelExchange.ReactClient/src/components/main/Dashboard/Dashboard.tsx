import React, { useEffect } from 'react';
import './Dashboard.scss';
import UserService from '../../../services/user-service';
import LoadingSign from '../../shared/LoadingSign/LoadingSign';

type DashboardProps = {};

const Dashboard: React.FC<DashboardProps> = ({ }) => {
    const userService = new UserService();
    useEffect(() => {
        userService.getUserLogin().then(result => console.log(result)).catch(err => console.log(err));
    }, []);
    return (
        <div className="dashboard-component">
            <h2>Dashboard Page</h2>
            <LoadingSign />
        </div>
        );
}

export default Dashboard;