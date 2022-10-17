import React from 'react';
import './Footer.scss';

type FooterProps = {};

const Footer: React.FC<FooterProps> = ({ }) => {
    return (
        <div className="footer-component">
            <p>Intel Exchange. Copyright, 2022, Kirill Kontorez</p>
        </div>
        );
}

export default Footer;