import React, { useState, useEffect, useMemo } from 'react';
import './Select.scss';

type SelectProps = {
    defaultValue?: any;
    onChange: (value: any) => void;
    placeholder?: string;
    items: SelectItem[];
    multiselect: boolean
};

export type SelectItem = {
    label: string;
    value: any;
};

const Select: React.FC<SelectProps> = ({ defaultValue, onChange, placeholder, items, multiselect  }) => {

    const [isOpen, setIsOpen] = useState(false);
    const [selectedValues, setSelectedValues] = useState<any[]>([]);

    useEffect(() => {
        const selectedItem = defaultValue ? items.find(item => item.value === defaultValue) : undefined;
        if (selectedItem) {
            setSelectedValues([selectedItem.value]);
        }
    }, []);

    const title = useMemo(() => {
        return selectedValues.length > 0 ? items.find(item => item.value === selectedValues[0])?.label : placeholder ? placeholder : "";
    }, [selectedValues, placeholder]);

    const handleSelect = (value: any) => {
        onChange(value);
        if (multiselect) {
            const newValues = selectedValues.includes(value) ? selectedValues.filter(v => v !== value) : [...selectedValues, value];
            setSelectedValues(newValues);
        } else {
            setSelectedValues([value]);
        }
    };

    return (
        <div className="select-component">
            <div className="selector" onClick={() => setIsOpen(!isOpen)}>{title}</div>
            <div className="dropdown">
                {
                    items.map((item, i) => (
                        <div
                            key={i}
                            className="select-item"
                            onClick={(e) => handleSelect(item.value)}
                        >
                            {items[i].label}
                        </div>
                    ))}
            </div>
        </div>
    );
}
export default Select;