import React from 'react';
import { connect } from 'react-redux';

class ConversationHeader extends React.Component {
    render() {
        
        return (
            <div className="contact-profile">
                <img src={this.props.conversationSelected?.groupAvatar} alt="" />
                <p>{this.props.conversationSelected?.name}</p>
                <div className="social-media">
                    <i className="fa fa-facebook" aria-hidden="true"></i>
                    <i className="fa fa-twitter" aria-hidden="true"></i>
                    <i className="fa fa-instagram" aria-hidden="true"></i>
                </div>
            </div>
        )
    }
}
const mapStateToProp = state => {
    return {
        conversationSelected: state.conversationReducer.conversationSelected
    }
}
export default connect(mapStateToProp)(ConversationHeader);