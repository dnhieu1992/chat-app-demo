import React from 'react';
import { connect } from 'react-redux';
import Api from '../../../apis/baseApi';
import { fetchUser } from '../../auth/containers/userAction';

class UserSearch extends React.Component {
    constructor() {
        super();

        this.state = { txtSearchValue: '' }

        this.onHandlerSearch = this.onHandlerSearch.bind(this);
        this.onChangeValue = this.onChangeValue.bind(this);
    }
    onHandlerSearch(e) {
        e.preventDefault();
        Api.get('/user/getUsers', {
            params: {
                username: this.state.txtSearchValue
            }
        })
            .then(res => {
                if (res.data) {
                    this.props.dispatch(fetchUser(res.data));
                }
            })
            .catch(err => {
                console.log(err);
            })
    }
    onChangeValue(e) {
        this.setState({ txtSearchValue: e.target.value });
    }
    render() {
        return (
            <form onSubmit={this.onHandlerSearch}>
                <div id="search">
                    <label htmlFor=""><i className="fa fa-search" aria-hidden="true"></i></label>
                    <input type="text" value={this.state.txtSearchValue} placeholder="Search contacts..." onChange={this.onChangeValue} />
                </div>
            </form>

        )
    }
}

const mapDispatchToProps = dispatch => {
    return {
        dispatch
    }
}
export default connect(mapDispatchToProps)(UserSearch);