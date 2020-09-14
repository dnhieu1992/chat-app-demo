import React from 'react';
import Api from '../../../apis/baseApi';
import { connect } from 'react-redux';
import { addConversation } from '../containers/conversationAction';

class UserItem extends React.Component {
    constructor() {
        super();
        this.createConversation = this.createConversation.bind(this);
    }

    createConversation(event) {
        event.preventDefault();
        let participantIds = [this.props.user.id]
        Api.post('/conversation/create', { isAutoCreate: true, participantIds: participantIds }).then(res => {
            debugger;
            this.props.dispatch(addConversation(res.data))
        }).catch(err => {
            console.log(err);
        })
    }
    render() {
        return (
            <li className="contact">
                <div className="wrap">
                    <span className="contact-status online"></span>
                    <img src={this.props.user.avatar} alt="" />

                    <div className="meta">
                        <p className="name" >{this.props.user.displayName}</p>
                    </div>
                    <button className='btn btn-default btn-info' onClick={this.createConversation}>
                        <i className='fa fa-user-plus'></i>
                    </button>
                </div>
            </li>
        )
    }
}
const mapStateToDispatch = dispatch => {
    return { dispatch }
}
export default connect(mapStateToDispatch)(UserItem);