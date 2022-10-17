import { Action, Reducer } from 'redux';

// state

export type SidebarState = {
    isHidden: boolean
};

// actions

export type HideSidebarAction = {
    type: "HIDE_SIDEBAR";
};

export type ShowSidebarAction = {
    type: "SHOW_SIDEBAR";
};

// action creators - functions exposed to UI components that will trigger a state transition

export const actionCreators = {
    hideSidebar: () => ({
        type: "HIDE_SIDEBAR",
    } as HideSidebarAction),
    showSidebar: () => ({
        type: "SHOW_SIDEBAR",
    } as ShowSidebarAction)
};

// reducer

export const defaultSidebarState: SidebarState = {
    isHidden: false
};

export const reducer: Reducer<SidebarState> = (
    state: SidebarState | undefined = defaultSidebarState,
    incomingAction: Action,
): SidebarState => {
    if (state === undefined) {
        return defaultSidebarState;
    }

    const action = incomingAction as HideSidebarAction | ShowSidebarAction;
    switch (action.type) {
        case "HIDE_SIDEBAR":
            return { isHidden: true};
        case "SHOW_SIDEBAR":
            return defaultSidebarState;
        default:
            return state;
    }
};

