import React from 'react';
import './LoadingSign.scss';


const LoadingSign: React.FC = () => {
    return (
        <div className="loading-sign-component">
            <div className="container">
                <div className="square"></div>
                <div className="square"></div>
                <div className="square"></div>
            </div>           
        </div>
    );
}
export default LoadingSign;