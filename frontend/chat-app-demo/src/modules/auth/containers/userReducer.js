const currentUser=JSON.parse(localStorage.getItem('User'));
const userState = {
    users: [],
    currentUser: currentUser
}
export const userReducer = (state = userState, action) => {
    if (action.type === 'FETCH_USER') {

    }
    switch (action.type) {
        case "FETCH_USER":
            return Object.assign({}, state, {
                users: action.payload.users
            });
        case "UPDATE_CURRENT_USER":
            return Object.assign({}, state, {
                currentUser: action.payload.user
            });
        default:
            return state;
    }
    return state
}
