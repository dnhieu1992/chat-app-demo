import {HubConnectionBuilder, Loglevel} from '@microsoft/signalr';


class ChatService1{
    constructor(props){
        this.rConnection = new HubConnectionBuilder().withUrl("https://localhost:44386/chathub")
        .configureLogging(Loglevel.Information).build();

        this.rConnection.start().catch(err=>{
            console.log("errorr.");
        });



    }

    registerReceiveMessage = (callback)=>{
        this.rConnection.on("ReceiveMessage",function(message){
            console.log(message);
            callback(message);
        })
    }
    sendMessage(message){
      return   this.rConnection.invoke("SendMessge",message)
            .catch((data)=>{
                console.log("failed");
            })
    }
}

const ChatService1 = new ChatService1();
export default ChatService1;