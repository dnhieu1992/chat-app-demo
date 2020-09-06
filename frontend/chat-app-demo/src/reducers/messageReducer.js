
const messageState = {
    messages: []
}

const messageReducer = (state = messageState, action) => {
    switch (action.type) {
        case "FETCH_MESSAGE":
            return Object.assign({}, state, {
                messages: action.payload.messages
            });
        case "ADD_MESSAGE":
            return Object.assign({}, state, {
                messages: [
                    ...state.messages,
                    action.payload.messageItem
                ]
            });
        default:
            return state;
    }
}


export default messageReducer;