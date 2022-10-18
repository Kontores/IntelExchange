import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';
import { ApplicationState } from '../../../store/ApplicationState';
import * as SidebarStore from '../../../store/SidebarState';
import SidebarItem from './SidebarItem/SidebarItem';
import { RoutesEnum } from '../../../data/enums/routes';
import './Sidebar.scss';

type StateProps = { isHidden: boolean };

type DispatchProps = { hideSidebar: typeof SidebarStore.actionCreators.hideSidebar }

type SidebarProps = StateProps & DispatchProps & {
    items: { navigateTo: RoutesEnum, title: string }[]
};

const Sidebar: React.FC<SidebarProps> = ({ isHidden, hideSidebar, items }) => {
    const [sidebarClass, setSidebarClass] = useState("sidebar-component");
    const [activeItemIndex, setActiveItemIndex] = useState(0);

    useEffect(() => {
        setSidebarClass(isHidden ? "sidebar-component hidden" : "sidebar-component");
    }, [isHidden]);
  
    return (
        <div className={sidebarClass} >
            <div className="hide-sidebar-button" onClick={hideSidebar}>{">>"}</div>
            {
                items.map((item, i) => (
                    <SidebarItem
                        active={activeItemIndex === i}
                        onClick={() => setActiveItemIndex(i)}
                        key={i}
                        navigateTo={item.navigateTo}
                        title={item.title}
                    />
                ))
            }
        </div>
        );
}

const mapStateToProps = (state: ApplicationState): StateProps => ({
    isHidden: state.sidebar.isHidden
});

const mapDispatchToProps = (dispatch: Dispatch): DispatchProps => ({
    ...bindActionCreators({
        ...SidebarStore.actionCreators
    }, dispatch),
});

export default connect(mapStateToProps, mapDispatchToProps)(Sidebar);