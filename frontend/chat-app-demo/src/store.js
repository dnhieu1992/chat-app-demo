import { createStore, combineReducers } from 'redux';
import { userReducer } from './modules/auth/containers/userReducer';
import { messageReducer } from './modules/chatapp/containers/messageReducer';
import { conversationReducer } from './modules/chatapp/containers/conversationReducer';

const rootReducer = combineReducers({
  userReducer,
  messageReducer,
  conversationReducer
});

const store = createStore(rootReducer);

export default store;