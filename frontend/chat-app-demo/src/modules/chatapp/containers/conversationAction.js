
const fetchConversation = (conversations) => {
    return {
        type: 'FETCH_CONVERSATIONS',
        payload: { conversations: conversations }
    }
}

const addConversation = (conversation) => {
    return {
        type: 'ADD_CONVERSATION',
        payload: { conversation: conversation }
    }
}

const updateConversationSelected = (conversation) => {
    return {
        type: 'UPDATE_CONVERSATION_SELECTED',
        payload: { conversation: conversation }
    }
}
export { fetchConversation, addConversation, updateConversationSelected }