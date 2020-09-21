import React from 'react';
import './register-style.css';

import { Link } from 'react-router-dom';
import Input from '../../../../helpers/components/Input';


class Register extends React.Component {
    constructor() {
        super();
        this.state = { user: { username: '', email: '', password: '' }, errorMessage: {} }
    }
    onHandleChange(fieldName, e) {
        debugger;
        if (!e.target.value) {
            let errorMessage = this.state.errorMessage;
            errorMessage[fieldName] = "Please fill out this field.";
            this.setState({ errorMessage })
        } else {
            let user = this.state.user;
            user[fieldName] = e.target.value;
            this.setState({ user })
        }
    }

    onHandleSubmit = (e) => {
        e.preventDefault();
        console.log(this.state.user)
        let users = this.state.user;
        let errorMessage = this.state.errorMessage;
        let isValid = true;
        if (!users["username"]) {
            isValid = false;
            errorMessage["username"] = "Please fill out this field.";
        }
        if (!users["email"]) {
            isValid = false;
            errorMessage["email"] = "Please fill out this field.";
        }
        if (!users["password"]) {
            isValid = false;
            errorMessage["password"] = "Please fill out this field.";
        }
        if (!users["repeatPassword"]) {
            isValid = false;
            errorMessage["repeatPassword"] = "Please fill out this field.";
        }
        if (!isValid) {
            this.setState({ errorMessage });
            return;
        }
        
    }
    render() {
        return (
            <div className="card bg-light">
                <article className="card-body mx-auto" style={{ width: '450px' }}>
                    <h4 className="card-title mt-3 text-center">Create Account</h4>
                    <p className="text-center">Get started with your free account</p>
                    <p>
                        <a href="" className="btn btn-block btn-twitter"> <i className="fa fa-twitter"></i>   Login via Twitter</a>
                        <a href="" className="btn btn-block btn-facebook"> <i className="fa fa-facebook-f"></i>   Login via facebook</a>
                    </p>
                    <p className="divider-text">
                        <span className="bg-light">OR</span>
                    </p>
                    <form onSubmit={this.onHandleSubmit} noValidate>
                        <div>
                            <Input name='username' className='form-control' placeholder='Username' type='text'
                                isRequired='true' iconName='fa fa-user'
                                onHandleChange={this.onHandleChange.bind(this, "username")}
                                errorMessage={this.state.errorMessage["username"]} />
                        </div>
                        <div>
                            <Input name='email' className='form-control' placeholder='Email address' type='email'
                                isRequired='true' iconName='fa fa-envelope'
                                onHandleChange={this.onHandleChange.bind(this, "email")}
                                errorMessage={this.state.errorMessage["email"]} />
                        </div>

                        <div>
                            <Input name='password' className='form-control' placeholder='Create password' type='password'
                                isRequired='true' iconName='fa fa-lock'
                                onHandleChange={this.onHandleChange.bind(this, "password")}
                                errorMessage={this.state.errorMessage["password"]} />
                        </div>
                        <div>
                            <Input name='repeatPassword' className='form-control' placeholder='Repeat password' type='password'
                                isRequired='true' iconName='fa fa-lock'
                                onHandleChange={this.onHandleChange.bind(this, "repeatPassword")}
                                errorMessage={this.state.errorMessage["repeatPassword"]} />
                        </div>
                        <div className="form-group">
                            <button type="submit" className="btn btn-primary btn-block"> Create Account  </button>
                        </div>
                        <p className="text-center">Have an account? <Link to="/">Log In</Link> </p>
                    </form>
                </article>
            </div>
        )
    }
}
export default Register;