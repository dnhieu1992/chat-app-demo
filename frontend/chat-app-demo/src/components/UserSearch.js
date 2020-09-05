import React from 'react';

class UserSearch extends React.Component {
    render() {
        return (
            <div id="search">
                <label htmlFor=""><i className="fa fa-search" aria-hidden="true"></i></label>
                <input type="text" placeholder="Search contacts..." />
            </div>
        )
    }
}
export default UserSearch;