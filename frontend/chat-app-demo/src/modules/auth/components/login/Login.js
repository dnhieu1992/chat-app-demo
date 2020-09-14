import React from 'react';
import './login-style.css';
import authenticationApi from '../../../../apis/auth/loginApi';
import { updateCurrentUser } from '../../containers/userAction';
import Api from '../../../../apis/baseApi';
import {connect} from 'react-redux';


import { Link, Redirect } from 'react-router-dom';

class Login extends React.Component {
    constructor() {
        super();
        this.state = { username: '', password: '', redirect: false }
        this.handleLogin = this.handleLogin.bind(this);
        this.handleUsernameChange = this.handleUsernameChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
    }

    handleLogin(event) {
        event.preventDefault();
        authenticationApi({ username: this.state.username, password: this.state.password }).then(response => {
            console.log(response);
            this.props.dispatch(updateCurrentUser(response));
            updateCurrentUser(response)
            localStorage.setItem('User', JSON.stringify(response));
            Api.interceptors.request.use(function (config) {
                config.headers.Authorization = `Bearer ${response.token}`;
                return config;
            });
            this.setState({ redirect: true });

        })
            .catch(err => console.warn(err));
    }
    handleUsernameChange(event) {
        this.setState({ username: event.target.value });
    }
    handlePasswordChange(event) {
        this.setState({ password: event.target.value });
        console.log(this.state);
    }


    render() {
        if (this.state.redirect) {
            return <Redirect to='/home' />;
        }
        return (
            <div id="logreg-forms">
                <form className="form-signin" onSubmit={this.handleLogin}>
                    <h1 className="h3 mb-3 font-weight-normal" style={{ textAlign: 'center' }}> Sign in</h1>
                    <div className="social-login">
                        <button className="btn facebook-btn social-btn" type="button"><span><i className="fa fa-facebook-f"></i> Sign in with Facebook</span> </button>
                        <button className="btn google-btn social-btn" type="button"><span><i className="fa fa-google-plus"></i> Sign in with Google+</span> </button>
                    </div>
                    <p style={{ textAlign: 'center' }}>OR</p>
                    <input type="text" id="inputEmail" className="form-control" placeholder="Email address" onChange={this.handleUsernameChange} />
                    <input type="password" id="inputPassword" className="form-control" placeholder="Password" onChange={this.handlePasswordChange} />

                    <button className="btn btn-success btn-block" type="submit"><i className="fa fa-sign-in-alt"></i> Sign in</button>
                    <a href="#" id="forgot_pswd">Forgot password?</a>
                    <hr />
                    <Link className="btn btn-primary btn-block" to="/register"><i className="fa fa-user-plus"></i> Sign up New Account</Link>
                </form>

                {/* <form action="/reset/password/" className="form-reset">
                    <input type="email" id="resetEmail" className="form-control" placeholder="Email address" />
                    <button className="btn btn-primary btn-block" type="submit">Reset Password</button>
                    <a href="#" id="cancel_reset"><i className="fa fa-angle-left"></i> Back</a>
                </form> */}


                <br />
            </div>
        );
    }
}
const mapStateToDispatch = dispatch=>{
    return {
        dispatch
    }
}

export default connect(mapStateToDispatch)(Login);