import React from 'react';
import ReactDom from 'react-dom';



import 'bootstrap/dist/css/bootstrap.min.css';
import $ from 'jquery';
import 'bootstrap/dist/js/bootstrap.bundle';

import App from './components/App';

import { Provider } from 'react-redux';
import store from './store';
window.store = store;

ReactDom.render(
    <Provider store={store}>
        <App />
    </Provider>
    ,
    document.getElementById("root")
)