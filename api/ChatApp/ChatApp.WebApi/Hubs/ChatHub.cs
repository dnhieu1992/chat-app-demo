using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Hubs
{
    public class ChatHub:Hub
    {
        
        //Store message to db
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("sendToAll", message);
        }
    }
}
