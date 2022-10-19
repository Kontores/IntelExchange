import { Action, Reducer } from 'redux';
import { UserRole } from '../data/enums/user-role';

// state

export type UserState = {
    id?: string,
    login?: string,
    roles?: UserRole[],
};

// actions

export type SetUserAction = {
    type: "SET_USER";
    user: UserState;
};

export type UnsetUserAction = {
    type: "UNSET_USER"
};

// action creators - functions exposed to UI components that will trigger a state transition

export const actionCreators = {
    setUser: (user: UserState) => ({
        type: "SET_USER",
        user,
    } as SetUserAction),
    unsetUser: () => ({
        type: "UNSET_USER",
    } as UnsetUserAction)
};

// reducer

export const defaultState: UserState = {};

export const reducer: Reducer<UserState> = (
    state: UserState | undefined = defaultState,
    incomingAction: Action,
): UserState => {
    if (state === undefined) {
        return defaultState;
    }

    const action = incomingAction as SetUserAction | UnsetUserAction;
    switch (action.type) {
        case "SET_USER":
            return { ...action.user };
        case "UNSET_USER":
            return defaultState;
        default:
            return state;
    }
};

