import React from 'react';
import { connect } from 'react-redux';
import Api from '../service/baseApi';
import { fetchUser } from '../actions/userAction';

import UserItem from './UserItem';

class Contact extends React.Component {
    
    componentDidMount() {
        console.log("token is",JSON.parse(localStorage.getItem('User')).token);
        Api.get('/chat/users')
            .then(res => {
                if (res.data.length > 0) {
                    this.props.dispatch(fetchUser(res.data));
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
    return { users: state.userReducer.users }
}

export default connect(mapStateToProps, mapDispatchToProps)(Contact);