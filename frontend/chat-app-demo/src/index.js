import React from 'react';
import ReactDom from 'react-dom';
import { BrowserRouter, Switch, Route, Link, Router } from "react-router-dom";

import 'bootstrap/dist/css/bootstrap.min.css';
import $ from 'jquery';
import 'bootstrap/dist/js/bootstrap.bundle';

import ChatApp from './modules/chatapp/pages/ChatApp';

import { Provider } from 'react-redux';
import store from './store';
import Login from './modules/auth/components/login/Login';
import Register from './modules/auth/components/register/Register';
import UploadImage from './helpers/components/UploadImage';
window.store = store;

ReactDom.render(
    <Provider store={store}>
        <BrowserRouter>
            <div>
                <Route exact path="/" component={Login} />
                <Route path="/home" component={ChatApp} />
                <Route path="/register" component={Register} />
                <Route path="/test" component={UploadImage} />
            </div>
        </BrowserRouter>
    </Provider >
    ,
    document.getElementById("root")
)