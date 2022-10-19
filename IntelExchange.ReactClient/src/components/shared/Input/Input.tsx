import React from 'react';
import './Input.scss';

type InputProps = {
    value: any,
    onChange: React.ChangeEventHandler<HTMLInputElement>,
    label?: string,
    type: "text" | "password",
    validationMessage?: string,
};

const Input: React.FC<InputProps> = ({value, onChange, label, type, validationMessage}) => {
    return (
        <div className="input-component">
            {label && <div className="input-label">{label}</div>}
            <input className="input-element" type={type} value={value} onChange={onChange} />
            <span className="validation-message">{validationMessage}</span>
        </div>
    );
}
export default Input;