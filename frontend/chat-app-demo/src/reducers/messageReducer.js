
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
            return state.messages.push(action.payload.messageItem);
        default:
            return state;
    }
}


export default messageReducer;