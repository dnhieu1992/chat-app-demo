import React from 'react';

import UserProfile from './UserProfile';
import Contact from './Contact';
import ContactProfile from './ContactProfile';
import Message from './Message';
import MessageInput from './MessageInput';
import UserSearch from './UserSearch';
import '../style.css';

const App = () => {
    return (
        <div id="frame">
            <div id="sidepanel">
                <UserProfile />
                <UserSearch />
                <Contact />
                <div id="bottom-bar">
                    <button id="addcontact"><i className="fa fa-user-plus fa-fw" aria-hidden="true"></i> <span>Add contact</span></button>
                    <button id="settings"><i className="fa fa-cog fa-fw" aria-hidden="true"></i> <span>Settings</span></button>
                </div>
            </div>
            <div className="content">
                <ContactProfile />
                <Message />
                <MessageInput />
            </div>
        </div>
    )
}

export default App;