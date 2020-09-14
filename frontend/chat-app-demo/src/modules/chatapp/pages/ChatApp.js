import React from 'react';

import UserProfile from '../components/UserProfile';
import ConversationList from '../components/ConversationList';
import ConversationHeader from '../components/ConversationHeader';
import Message from '../components/Message';
import MessageInput from '../components/MessageInput';
import UserSearch from '../components/UserSearch';
import './style.css';

const ChatApp = () => {
    return (
        <div id="frame">
            <div id="sidepanel">
                <UserProfile />
                <UserSearch />
                <ConversationList />
                <div id="bottom-bar">
                    <button id="addcontact"><i className="fa fa-user-plus fa-fw" aria-hidden="true"></i> <span>Add contact</span></button>
                    <button id="settings"><i className="fa fa-cog fa-fw" aria-hidden="true"></i> <span>Settings</span></button>
                </div>
            </div>
            <div className="content">
                <ConversationHeader />
                <Message />
                <MessageInput />
            </div>
        </div>
    )
}

export default ChatApp;