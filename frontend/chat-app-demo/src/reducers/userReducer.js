const userState = {
    users: []
}
export const userReducer = (state = userState, action) => {
    if (action.type === 'FETCH_USER') {
        return Object.assign({}, state, {
            users: action.payload.users
        })
    }
    return state
}

// const currentUserReducer = (state = null, action) => {
//     switch (action.type) {
//         case "INIT_USER":
//             return Object.assign({}, state, {
//                 user: action.payload.user
//             })
//         default:
//             return state;
//     }
// }
