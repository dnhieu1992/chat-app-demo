import React from 'react';
import { connect } from 'react-redux';

class UserProfile extends React.Component {
    render() {
        return (
            <div id="profile">
                <div className="wrap">
                    <img id="profile-img" src={this.props.currentUser?.avatar} className="online" alt="" />
                    <p>{this.props.currentUser?.displayName}</p>
                    <i className="fa fa-chevron-down expand-button" aria-hidden="true"></i>
                    <div id="status-options">
                        <ul>
                            <li id="status-online" className="active"><span className="status-circle"></span> <p>Online</p></li>
                            <li id="status-away"><span className="status-circle"></span> <p>Away</p></li>
                            <li id="status-busy"><span className="status-circle"></span> <p>Busy</p></li>
                            <li id="status-offline"><span className="status-circle"></span> <p>Offline</p></li>
                        </ul>
                    </div>
                    <div id="expanded">
                        <label htmlFor="twitter"><i className="fa fa-facebook fa-fw" aria-hidden="true"></i></label>
                        {/* <input name="twitter" type="text" value="mikeross" /> */}
                        <label htmlFor="twitter"><i className="fa fa-twitter fa-fw" aria-hidden="true"></i></label>
                        {/* <input name="twitter" type="text" value="ross81" /> */}
                        <label htmlFor="twitter"><i className="fa fa-instagram fa-fw" aria-hidden="true"></i></label>
                        {/* <input name="twitter" type="text" value="mike.ross" /> */}
                    </div>
                </div>
            </div>
        )
    }
}
const mapStateToProp = state => {
    return {
        currentUser: state.userReducer.currentUser
    }
}
export default connect(mapStateToProp)(UserProfile);