
export const addMessage = (msg)=>{
    return {
        type: 'ADD_MESSAGE',
        payload: { messageItem: msg }
    }
}

export const fetchMessage = (messages)=>{
    return {
        type: 'FETCH_MESSAGE',
        payload: { messages: messages }
    }
}
