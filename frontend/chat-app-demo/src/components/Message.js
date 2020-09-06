import React from 'react';
import { connect } from 'react-redux';

class Message extends React.Component {

    render() {
        console.log(this.props.messages);
        if (this.props.messages.length > 0) {
            const renderList = this.props.messages.map((messageItem) => {
                if (messageItem.type === 'sent') {
                    return (
                        <li className="sent" key={messageItem.id}>
                            <img src="http://emilcarlsson.se/assets/mikeross.png" alt="" />
                            <p>{messageItem.message}</p>
                        </li>
                    )
                }
                return (
                    <li className="replies" key={messageItem.id}>
                        <img src="http://emilcarlsson.se/assets/harveyspecter.png" alt="" />
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