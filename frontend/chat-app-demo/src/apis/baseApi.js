import axios from 'axios';

const getToken = () => {
  debugger;
  let user = JSON.parse(localStorage.getItem('User'));
  if (user) {
    return user.token;
  }
  return '';
}
export default axios.create({

  baseURL: `https://localhost:44386/api`,
  headers: {
    'Authorization': `Bearer ${getToken()}`
  }
  // params: {
  //   part: 'snippet',
  //   maxResults: 5,
  //   type: 'video',
  //   //key: 'AIzaSyDneWz7GOAVHYeY--Mo_IYbihGCfT63_LU',
  //   key: 'AIzaSyCR4W_FKQiikQJxO1RGiPxRv2o-ouMWk5A'
  // }
});