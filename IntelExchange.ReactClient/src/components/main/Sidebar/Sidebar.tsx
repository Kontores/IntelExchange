import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';
import { ApplicationState } from '../../../store/ApplicationState';
import * as SidebarStore from '../../../store/SidebarState';
import './Sidebar.scss';

type StateProps = { isHidden: boolean };

type DispatchProps = { hideSidebar: typeof SidebarStore.actionCreators.hideSidebar }

type SidebarProps = StateProps & DispatchProps & {};

const Sidebar: React.FC<SidebarProps> = ({ isHidden, hideSidebar}) => {
    const [sidebarClass, setSidebarClass] = useState("sidebar-component");

    useEffect(() => {
        setSidebarClass(isHidden ? "sidebar-component hidden" : "sidebar-component");
    }, [isHidden]);
  
    return (
        <div className={sidebarClass} >
            <div onClick={hideSidebar}>{">>"}</div>
            <p>Sidebar</p>
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