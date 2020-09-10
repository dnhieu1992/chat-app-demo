import React from 'react';
import ReactDom from 'react-dom';
import { BrowserRouter, Switch, Route, Link } from "react-router-dom";

import 'bootstrap/dist/css/bootstrap.min.css';
import $ from 'jquery';
import 'bootstrap/dist/js/bootstrap.bundle';

import App from './components/App';

import { Provider } from 'react-redux';
import store from './store';
import Login from './components/Login';
import Register from './components/Register';
window.store = store;

ReactDom.render(
    <Provider store={store}>
        <BrowserRouter>
            <div>
                <Route exact path="/" component={Login} />
                <Route path="/home" component={App} />
                <Route path="/register" component={Register} />
            </div>
        </BrowserRouter>
    </Provider >
    ,
    document.getElementById("root")
)