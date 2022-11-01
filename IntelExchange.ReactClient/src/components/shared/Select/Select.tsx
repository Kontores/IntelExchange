import React, { useState, useEffect, useRef } from 'react';
import { useOnClickOutside } from '../../../helpers/outside-click-helper';
import './Select.scss';

type SelectProps = {
    defaultValue?: any;
    onChange: (value: any) => void;
    placeholder?: string;
    items: SelectItem[];
    multiselect?: boolean;
};

export type SelectItem = {
    label: string;
    value: any;
};

const Select: React.FC<SelectProps> = ({ defaultValue, onChange, placeholder, items, multiselect = false  }) => {

    const [isOpen, setIsOpen] = useState(false);
    const [selectedValues, setSelectedValues] = useState<any[]>([]);
    const ref = useRef(null);

    useEffect(() => {
        const selectedItem = defaultValue ? items.find(item => item.value === defaultValue) : undefined;
        if (selectedItem) {
            setSelectedValues([selectedItem.value]);
        }
    }, []);

    const title = selectedValues.length > 0 ? items.find(item => item.value === selectedValues[0])?.label : placeholder ? placeholder : "";

    const titleClassName = selectedValues.length > 0 ? "title" : "placeholder";

    const handleSelect = (value: any) => {
        onChange(value);
        if (multiselect) {
            const newValues = selectedValues.includes(value) ? selectedValues.filter(v => v !== value) : [...selectedValues, value];
            setSelectedValues(newValues);
        } else {
            setSelectedValues([value]);
        }
        setIsOpen(false);
    };

    useOnClickOutside(ref, () => setIsOpen(false));

    return (
        <div className="select-component" ref={ref}>
            <div className="selector" onClick={() => setIsOpen(!isOpen)}>
                <span className={titleClassName}>{title}</span>
            </div>
            <div className={isOpen ? "select-items" : "select-items hidden"}>
                {
                    items.map((item, i) => (
                        <div key={i} className="select-item" onClick={() => handleSelect(item.value)}>
                            <span className="item-label">{item.label}</span>
                        </div>
                    ))}
            </div>        
        </div>
    );
}
export default Select;