import React from 'react';
import './Button.scss';

type ButtonProps = {
    title: string,
    onClick: React.MouseEventHandler<HTMLButtonElement>,
    type: "normal" | "danger",
};

const Button: React.FC<ButtonProps> = ({title, onClick, type}) => {
    return (<button className={`button-component ${type}`} onClick={onClick}>{title}</button>);
}
export default Button;