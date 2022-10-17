import React, { useState, useEffect } from 'react';
import UserService from '../../../services/user-service';
import { User } from '../../../data/user';
import './HomePage.scss';

type HomePageProps = {};

const HomePage: React.FC<HomePageProps> = ({ }) => {
    const [users, setUsers] = useState<User[]>([]);
    const userService = new UserService();
    useEffect(() => {
        userService.getAllUsers()
            .then(result => setUsers(result))
            .catch(err => console.log(`error ${err}`));
    }, []);

    return (
        <div className="homepage-component">
            <h2>Welcome!</h2>
            <div>
                {users.map((user, i) => (
                    <div key={i}>
                        <div>{user.login}</div>
                        <div>{user.type}</div>
                    </div>
                    ))}
            </div>
        </div>
        );
}

export default HomePage;