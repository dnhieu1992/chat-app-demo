const fetchUser = (users) => {
    return {
        type: 'FETCH_USER',
        payload: { users: users }
    }
}

const updateCurrentUser = (user) => {
    return {
        type: 'UPDATE_CURRENT_USER',
        payload: { user: user }
    }
}
export {fetchUser, updateCurrentUser}

