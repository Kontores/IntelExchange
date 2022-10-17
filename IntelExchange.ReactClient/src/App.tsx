import React from 'react';
import logo from './logo.svg';
import MainTemplate from './components/main/MainTemplate/MainTemplate';
import './App.scss';
import './Adaptive.scss';

const App: React.FC = () => {
    return (
        <div className="App">
            <MainTemplate />
        </div>
    );
}

export default App;
