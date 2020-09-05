import React from 'react';

class UserItem extends React.Component {
    render() {
        return (
            <li className="contact">
                <div className="wrap">
                    <span className="contact-status online"></span>
                    <img src="http://emilcarlsson.se/assets/louislitt.png" alt="" />

                    <div className="meta">
                        <p className="name" >{this.props.user.name}</p>
                        <p className="preview">You just got LITT up, Mike.</p>
                    </div>
                </div>
            </li>
        )
    }
}
export default UserItem;