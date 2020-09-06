import React from 'react';
import '../login-style.css';
import Api from '../service/baseApi';

class Login extends React.Component {
    constructor() {
        super();
        this.state = { username: '', password: '' }
        this.handleLogin = this.handleLogin.bind(this);
        this.handleUsernameChange = this.handleUsernameChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
    }

    handleLogin(event) {
        event.preventDefault();
        console.log("button login clicked.")
        Api.post(`/auth/login`, null, {
            params: {
                username: this.state.username,
                password: this.state.password
            }
        })
            .then(response => {
                console.log(response);
                localStorage.setItem('User',JSON.stringify(response.data));
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
                    <button className="btn btn-primary btn-block" type="button" id="btn-signup"><i className="fa fa-user-plus"></i> Sign up New Account</button>
                </form>

                {/* <form action="/reset/password/" className="form-reset">
                    <input type="email" id="resetEmail" className="form-control" placeholder="Email address" />
                    <button className="btn btn-primary btn-block" type="submit">Reset Password</button>
                    <a href="#" id="cancel_reset"><i className="fa fa-angle-left"></i> Back</a>
                </form> */}

                {/* <form action="/signup/" className="form-signup">
                    <div className="social-login">
                        <button className="btn facebook-btn social-btn" type="button"><span><i className="fa fa-facebook-f"></i> Sign up with Facebook</span> </button>
                    </div>
                    <div className="social-login">
                        <button className="btn google-btn social-btn" type="button"><span><i className="fa fa-google-plus"></i> Sign up with Google+</span> </button>
                    </div>

                    <p style={{ textAlign: 'center' }}>OR</p>

                    <input type="text" id="user-name" className="form-control" placeholder="Full name" />
                    <input type="email" id="user-email" className="form-control" placeholder="Email address" />
                    <input type="password" id="user-pass" className="form-control" placeholder="Password" />
                    <input type="password" id="user-repeatpass" className="form-control" placeholder="Repeat Password" />

                    <button className="btn btn-primary btn-block" type="submit"><i className="fas fa-user-plus"></i> Sign Up</button>
                    <a href="#" id="cancel_signup"><i className="fas fa-angle-left"></i> Back</a>
                </form> */}
                <br />
            </div>
        );
    }
}

export default Login;