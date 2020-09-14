import $ from 'jquery';

const authenticationApi=(user)=>{
    return $.ajax({
        url:'https://localhost:44386/api/auth/login',
        data:JSON.stringify(user),
        method:'post',
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        }
    })
}

export default authenticationApi;
