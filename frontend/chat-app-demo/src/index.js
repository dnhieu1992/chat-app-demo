import React from 'react';
import ReactDom from 'react-dom';
import { BrowserRouter, Switch, Route, Link } from "react-router-dom";

import 'bootstrap/dist/css/bootstrap.min.css';
import $ from 'jquery';
import 'bootstrap/dist/js/bootstrap.bundle';

import ChatApp from './modules/chatapp/pages/ChatApp';

import { Provider } from 'react-redux';
import store from './store';
import Login from './modules/auth/components/login/Login';
import Register from './modules/auth/components/register/Register';
window.store = store;

ReactDom.render(
    <Provider store={store}>
        <BrowserRouter>
            <div>
                <Route exact path="/" component={Login} />
                <Route path="/home" component={ChatApp} />
                <Route path="/register" component={Register} />
            </div>
        </BrowserRouter>
    </Provider >
    ,
    document.getElementById("root")
)