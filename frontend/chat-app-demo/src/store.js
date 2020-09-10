import { createStore, combineReducers } from 'redux';
import { userReducer } from './reducers/userReducer';
import messageReducer from './reducers/messageReducer';

const rootReducer = combineReducers({
  userReducer,
  messageReducer
});

const store = createStore(rootReducer);

export default store;