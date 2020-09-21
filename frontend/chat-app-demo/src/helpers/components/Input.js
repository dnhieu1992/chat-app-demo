import React from 'react';

class Input extends React.Component {

    generateClass = () => {
        if (this.props.errorMessage) {
            return `${this.props.className} is-invalid`;
        }
        return `${this.props.className}`;
    }
    // onHandleChange = (e) => {
    //     let value = e.target.value;
    //     if (!value && this.props.isRequired) {
    //         this.setState({ errorMessage: 'Please fill out this field.' })
    //     } else if (this.props.type == "email" && !this.validateEmail(value)) {
    //         this.setState({ errorMessage: 'This email is invalid.' })
    //     } else {
    //         this.setState({ errorMessage: "" });
    //         this.props.onHandleChange(value);
    //     }
    // }
    validateEmail = (email) => {
        const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    render() {
        console.log(this.props)
        const generateIcon = (this.props.iconName ?
            <div className="input-group-prepend">
                <span className="input-group-text"> <i className={this.props.iconName}></i> </span>
            </div> : "");
        const generateErrorMessage = this.props.errorMessage ? <span className='text-danger order-last'>{this.props.errorMessage}</span> : ""
        const lstClass = this.generateClass();
        return (
            <div style={{ margin: '0', padding: '0' }}>
                <div className="form-group input-group" >
                    {generateIcon}
                    <input name={this.props.name}
                        className={lstClass}
                        placeholder={this.props.placeholder}
                        type={this.props.type}
                        onChange={this.props.onHandleChange}
                        value={this.props.value} />
                </div>
                {generateErrorMessage}
            </div >
        )
    }

}

export default Input;