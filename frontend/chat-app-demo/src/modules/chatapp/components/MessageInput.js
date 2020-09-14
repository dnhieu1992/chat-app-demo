import React from 'react';
import * as signalR from '@aspnet/signalr';
import { connect } from 'react-redux';

import { addMessage } from '../containers/messageAction';


class MessageInput extends React.Component {
    constructor() {
        super();
        this.state = {
            inputText: ''
        }
        this.hubConnection = null;
    }
    componentDidMount() {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:44386/chathub", {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets,
                accessTokenFactory: () => {
                    // console.log("token is",JSON.parse(localStorage.getItem('User')).token);
                    // return JSON.parse(localStorage.getItem('User')).token;
                }
            }).build();

        this.hubConnection.on('sendToAll', (msg) => {
            this.props.dispatch(addMessage(msg));
        })
        this.hubConnection.start()
            .then(data => {
                console.log('Hub start');
            }).catch(error => {
            });
    }

    handleOnChange = (event) => {
        this.setState({ inputText: event.target.value });
    }
    sendMessage = (event) => {
        event.preventDefault();
        this.hubConnection
            .invoke('SendMessage', this.props.conversationSelected?.id, this.state.inputText, JSON.parse(localStorage.getItem('User'))?.id)
            .catch(err => console.error(err));
        this.setState({ inputText: '' });

    }
    render() {
        return (
            <form onSubmit={this.sendMessage}>
                <div className="message-input">
                    <div className="wrap">
                        <input type="text" placeholder="Write your message..." value={this.state.inputText} onChange={this.handleOnChange} />
                        <i className="fa fa-paperclip attachment" aria-hidden="true"></i>
                        <button type="submit" className="submit"><i className="fa fa-paper-plane" aria-hidden="true"></i></button>
                    </div>
                </div>
            </form>
        )
    }
}

const mapDispactToProps = dispatch => {
    return {
        dispatch
    }
}
const mapStateToProps = state => {
    return {
        conversationSelected: state.conversationReducer.conversationSelected
    }
}
export default connect(mapStateToProps, mapDispactToProps)(MessageInput);