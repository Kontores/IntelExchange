import React from 'react';
import { Link } from 'react-router-dom';
import { RoutesEnum } from '../../../../data/enums/routes';
import './SidebarItem.scss';

type SidebarItemProps = {
    navigateTo: RoutesEnum,
    title: string
};

const SidebarItem: React.FC<SidebarItemProps> = ({navigateTo, title}) => {

    return (
        <Link className="sidebar-item-component" to={navigateTo}>
            <span className="title">{title}</span>
        </Link>
    );
}
export default SidebarItem;