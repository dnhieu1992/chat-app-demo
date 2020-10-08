import React from 'react';
import '../../assets/css/uploadImage.scss';

class UploadImage extends React.Component {
    onImageChange = (event)=>{
        console.log(URL.createObjectURL(event.target.files[0]))
       
    }
    render() {
        return (
            <div className="avatar-wrapper">
                <img className="profile-pic" src="" />
                <div className="upload-button">
                    <i className="fa fa-arrow-circle-up" aria-hidden="true"></i>
                </div>
                <input className="file-upload" type="file" accept="image/*" onChange={this.onImageChange} />
            </div>
        )
    }
}
export default UploadImage;
