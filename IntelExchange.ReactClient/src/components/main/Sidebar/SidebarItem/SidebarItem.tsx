import React from 'react';
import { Link } from 'react-router-dom';
import { RoutesEnum } from '../../../../data/enums/routes';
import './SidebarItem.scss';

type SidebarItemProps = {
    active: boolean,
    navigateTo: RoutesEnum,
    title: string,
    onClick?: () => void,
};

const SidebarItem: React.FC<SidebarItemProps> = ({navigateTo, title, active, onClick}) => {

    return (
        <Link onClick={onClick} className={`sidebar-item-component ${active ? "active" : ""}`} to={navigateTo}>
            <span className="title">{title}</span>
        </Link>
    );
}
export default SidebarItem;