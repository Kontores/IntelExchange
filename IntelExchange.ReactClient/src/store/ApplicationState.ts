import * as UserStore from './UserState';

export type ApplicationState = {
    user: UserStore.UserState;
};

export const reducers = {
    user: UserStore.reducer,
};

