import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
/*import { ConnectedRouter as Router  } from 'connected-react-router';*/
/*import { history } from '../../../store/configureStore';*/
import Header from '../Header/Header';
import Sidebar from '../Sidebar/Sidebar';
import Footer from '../Footer/Footer';
import HomePage from '../HomePage/HomePage';
import LoginPage from '../LoginPage/LoginPage';
import Dashboard from '../Dashboard/Dashboard';
import './MainTemplate.scss';

type MainTemplateProps = {};

const MainTemplate: React.FC<MainTemplateProps> = ({ }) => {
    return (
        <div className="main-template-component">
            <div className="top-part">
                <Router>
                    <Header />
                    <Routes>
                        <Route path="/"  element={<HomePage />} />
                        <Route path="/dashboard" element={<Dashboard />} />
                        <Route path="/account/login" element={<LoginPage />} />
                    </Routes>
                </Router>
            </div>
            <Sidebar />
            <Footer />
        </div>
        );
}

export default MainTemplate;