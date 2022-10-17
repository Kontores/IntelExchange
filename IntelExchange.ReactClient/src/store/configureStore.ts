import { combineReducers, createStore, applyMiddleware, compose } from 'redux';
import { ApplicationState, reducers } from './ApplicationState';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { createBrowserHistory, BrowserHistory } from 'history';

const rootReducer = (history: BrowserHistory) => combineReducers({
    ...reducers,
    router: connectRouter(history),
});

export const history = createBrowserHistory();

export const configureStore = (initialState?: ApplicationState) => {
    return createStore(rootReducer(history), initialState, compose(applyMiddleware(routerMiddleware(history))));
};