import React from 'react';
import './Input.scss';

type InputProps = {
    value: any,
    onChange: React.ChangeEventHandler<HTMLInputElement>,
    label?: string,
    type: "text" | "password"
};

const Input: React.FC<InputProps> = ({value, onChange, label, type}) => {
    return (
        <div className="input-component">
            {label && <div className="input-label">{label}</div>}
            <input className="input-element" type={type} value={value} onChange={onChange} />
        </div>
    );
}
export default Input;