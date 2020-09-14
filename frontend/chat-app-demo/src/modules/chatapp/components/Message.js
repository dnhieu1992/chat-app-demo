import React from 'react';
import { connect } from 'react-redux';

class Message extends React.Component {
    componentDidMount() {
    }

    render() {
        let userid = JSON.parse(localStorage.getItem('User')).id
        if (this.props.messages.length > 0) {
            const renderList = this.props.messages.map((messageItem) => {
                if (messageItem.senderId != userid) {
                    return (
                        <li className="sent" key={messageItem.id}>
                            <img src={messageItem.avatar} alt="" />
                            <p>{messageItem.message}</p>
                        </li>
                    )
                }
                return (
                    <li className="replies" key={messageItem.id}>
                        <img src={messageItem.avatar} alt="" />
                        <p>{messageItem.message}</p>
                    </li>
                )
            });
            return (
                <div className="messages clear-fix">
                    <ul>
                        {renderList}
                    </ul>
                </div>
            )
        }
        return (
            <div></div>
        )
    }
}
const mapStateToProps = state => {
    console.log(state.messageReducer.messages);
    return { messages: state.messageReducer.messages }
}

export default connect(mapStateToProps)(Message);