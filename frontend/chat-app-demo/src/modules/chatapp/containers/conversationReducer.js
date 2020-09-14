const conversationState = {
    conversations: [],
    conversationSelected: null
}

export const conversationReducer = (state = conversationState, action) => {
    switch (action.type) {
        case 'FETCH_CONVERSATIONS':
            return Object.assign({}, state, {
                conversations: action.payload.conversations
            });
        case 'ADD_CONVERSATION':
            return {
                ...state,
                conversations: [action.payload.conversation, ...state.conversations]
            };
        case 'UPDATE_CONVERSATION_SELECTED':
            debugger;
            return Object.assign({}, state, {
                conversationSelected: action.payload.conversation
            })
        default:
            return state
    }
}