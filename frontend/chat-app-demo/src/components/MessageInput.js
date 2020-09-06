import React from 'react';
import * as signalR from '@aspnet/signalr';
import { connect } from 'react-redux';

import { addMessage } from '../actions/messageAction';


class MessageInput extends React.Component {
    constructor() {
        super();
        this.state = {
            searchText: ''
        }
        this.hubConnection = null;
    }
    componentDidMount() {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:44386/chathub", {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets,
                accessTokenFactory: () => {
                    console.log(localStorage.getItem('User'))
                   // return localStorage.getItem('User');
                }
            }).build();

        this.hubConnection.on('sendToAll', (msg) => {
            console.log(msg);
            this.props.dispatch(addMessage({ id: 0, message: msg, type: 'sent' }));
        })
        this.hubConnection.start()
            .then(data => {
                console.log('Hub start');
            }).catch(error => {
            });
    }

    handleOnChange = (event) => {
        this.setState({ searchText: event.target.value });
    }
    sendMessage = (event) => {
        event.preventDefault();
        this.hubConnection
            .invoke('SendMessage', "test", this.state.searchText)
            .catch(err => console.error(err));
        this.setState({ searchText: '' });

    }
    render() {
        return (
            <div className="message-input">
                <div className="wrap">
                    <input type="text" placeholder="Write your message..." value={this.state.searchText} onChange={this.handleOnChange} />
                    <i className="fa fa-paperclip attachment" aria-hidden="true"></i>
                    <button type="button" className="submit" onClick={this.sendMessage}><i className="fa fa-paper-plane" aria-hidden="true"></i></button>
                </div>
            </div>
        )
    }
}

const mapDispactToProps = dispatch => {
    return {
        dispatch
    }
}
export default connect(mapDispactToProps)(MessageInput);