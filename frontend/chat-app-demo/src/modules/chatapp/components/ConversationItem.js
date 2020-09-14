import React from 'react';

class ConversationItem extends React.Component {
    handleOnclickItem=(id)=>{
        this.props.onClick(id);
    }
    render() {
        return (
            <li className="contact" onClick={()=>this.handleOnclickItem(this.props.conversation.id)}>
                <div className="wrap">
                    <span className="contact-status online"></span>
                    <img src={this.props.conversation.groupAvatar} alt="" />

                    <div className="meta">
                        <p className="name" >{this.props.conversation.name}</p>
                        <p className="preview">You just got LITT up, Mike.</p>
                    </div>
                </div>
            </li>
        )
    }
}
export default ConversationItem;