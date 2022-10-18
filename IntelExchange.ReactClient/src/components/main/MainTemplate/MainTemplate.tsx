import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
/*import { ConnectedRouter as Router  } from 'connected-react-router';*/
/*import { history } from '../../../store/configureStore';*/
import { RoutesEnum } from '../../../data/enums/routes';
import Header from '../Header/Header';
import Sidebar from '../Sidebar/Sidebar';
import Footer from '../Footer/Footer';
import HomePage from '../HomePage/HomePage';
import LoginPage from '../LoginPage/LoginPage';
import Dashboard from '../Dashboard/Dashboard';
import './MainTemplate.scss';

type MainTemplateProps = {};

const MainTemplate: React.FC<MainTemplateProps> = ({ }) => {

    // todo: define items in separate helper.ts class based on user permissions; create protected route component 
    const sidebarItems = [{ title: "Home", navigateTo: RoutesEnum.home }, { title: "Dashboard", navigateTo: RoutesEnum.dashboard }];

    return (
        <div className="main-template-component">
            <div className="top-part">
                <Router>
                    <Header />
                    <Sidebar items={sidebarItems} />
                    <Routes>
                        <Route path={RoutesEnum.home}  element={<HomePage />} />
                        <Route path={RoutesEnum.dashboard} element={<Dashboard />} />
                        <Route path={RoutesEnum.login} element={<LoginPage />} />
                    </Routes>
                </Router>
            </div>
            <Footer />
        </div>
        );
}

export default MainTemplate;