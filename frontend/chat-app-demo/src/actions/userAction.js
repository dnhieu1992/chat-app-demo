import React from 'react';


export const fetchUser = (users)=>{
    return {
        type: 'FETCH_USER',
        payload: { users: users }
    }
}

