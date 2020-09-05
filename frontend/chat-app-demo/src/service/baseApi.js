import axios from 'axios'; 

export default axios.create({
  baseURL: `https://localhost:44386/api`,
//   params:{
//         part: 'snippet',
//         maxResults: 5,
//         type: 'video',
//         //key: 'AIzaSyDneWz7GOAVHYeY--Mo_IYbihGCfT63_LU',
//         key:'AIzaSyCR4W_FKQiikQJxO1RGiPxRv2o-ouMWk5A'
//   }
});