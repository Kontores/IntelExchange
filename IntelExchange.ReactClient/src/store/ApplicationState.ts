import * as UserStore from './UserState';
import * as SidebarStore from './SidebarState';

export type ApplicationState = {
    user: UserStore.UserState;
    sidebar: SidebarStore.SidebarState;
};

export const reducers = {
    user: UserStore.reducer,
    sidebar: SidebarStore.reducer,
};

