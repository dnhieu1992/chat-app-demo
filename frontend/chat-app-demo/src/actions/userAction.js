import React from 'react';


const fetchUser = (users) => {
    return {
        type: 'FETCH_USER',
        payload: { users: users }
    }
}

const initUser = (user) => {
    return {
        type: 'INIT_USER',
        payload: { user: user }
    }
}
export {fetchUser, initUser}

