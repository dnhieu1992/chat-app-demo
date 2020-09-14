import React from 'react';
import { connect } from 'react-redux';
import Api from '../../../apis/baseApi';
import { fetchConversation, updateConversationSelected } from '../containers/conversationAction';
import { fetchMessage } from '../containers/messageAction';

import UserItem from './UserItem';
import ConversationItem from './ConversationItem';

class Contact extends React.Component {
    componentDidMount() {
        console.log(this.props.conversations);
        Api.get('/conversation/getConversations')
            .then(res => {
                if (res.data.length > 0) {
                    this.props.dispatch(fetchConversation(res.data));
                }
            })
            .catch(err => {
                console.log(err);
            })
    }
    handleSelectedGroup = (id) => {
        console.log(id);
        Api.get('/message/getMessages', {
            params: {
                conversationId: id
            }
        })
            .then(res => {
                if (res.data) {
                    this.props.dispatch(fetchMessage(res.data));
                    this.props.dispatch(updateConversationSelected(this.props.conversations.find((conversation) => {
                        return conversation.id == id
                    })))
                }
            })
            .catch(err => {
                console.log(err);
            })
    }
    render() {
        if (this.props.users.length > 0) {
            const renderedList = this.props.users.map((user) => {
                return <UserItem key={user.id} user={user} />
            });
            return (
                <div id="contacts">
                    <ul>
                        {renderedList}
                    </ul>
                </div>
            )
        } else if (this.props.conversations.length > 0) {
            const renderedListConversation = this.props.conversations.map((conversation) => {
                return <ConversationItem key={conversation.id} conversation={conversation}
                    onClick={this.handleSelectedGroup} />
            });
            return <div id="contacts">
                <ul>
                    {renderedListConversation}
                </ul>
            </div>
        }

        return (
            <div>Not found</div>
        )
    }
}
const mapDispatchToProps = dispatch => {
    return {
        dispatch
    }
}
const mapStateToProps = state => {
    return {
        users: state.userReducer.users,
        conversations: state.conversationReducer.conversations
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Contact);