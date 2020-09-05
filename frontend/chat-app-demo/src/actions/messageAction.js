
export const addMessage = (message)=>{
    return {
        type: 'ADD_MESSAGE',
        payload: { message: message }
    }
}

export const fetchMessage = (messages)=>{
    return {
        type: 'FETCH_MESSAGE',
        payload: { messages: messages }
    }
}
