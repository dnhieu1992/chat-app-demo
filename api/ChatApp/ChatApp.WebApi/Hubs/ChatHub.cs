using ChatApp.WebApi.Services.Conversation;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessageService _messageService;
        public ChatHub(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMessageService messageService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _messageService = messageService;
        }

        //Store message to db
        public async Task SendMessage(Guid conversationId, string message,Guid currentId)
        {
            var result = await _messageService.AddMessageAsync(message, conversationId,currentId);

            await Clients.All.SendAsync("sendToAll", result);
        }
    }
}
