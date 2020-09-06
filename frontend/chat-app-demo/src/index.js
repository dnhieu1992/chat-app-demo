import React from 'react';
import ReactDom from 'react-dom';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

import 'bootstrap/dist/css/bootstrap.min.css';
import $ from 'jquery';
import 'bootstrap/dist/js/bootstrap.bundle';

import App from './components/App';

import { Provider } from 'react-redux';
import store from './store';
import Login from './components/Login';
window.store = store;

ReactDom.render(
    <Provider store={store}>
        <Router>
            <div>
                <Route exact path="/" component={Login} />
                <Route path="/home" component={App} />
            </div>
        </Router>
    </Provider >
    ,
    document.getElementById("root")
)