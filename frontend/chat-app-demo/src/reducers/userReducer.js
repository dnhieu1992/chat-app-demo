const userState = {
    users: []
}
const userReducer = (state = userState, action) => {
    if (action.type === 'FETCH_USER') {
        return Object.assign({}, state, {
            users: action.payload.users
        })
    }
    return userState
}

export default userReducer;