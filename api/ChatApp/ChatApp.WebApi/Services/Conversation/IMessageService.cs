using ChatApp.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.Conversation
{
    public interface IMessageService
    {
        Task<List<MessageViewModel>> GetMessageByConversationIdAsync(Guid conversationId);
        Task<MessageViewModel> AddMessageAsync(string message, Guid conversationId,Guid currentUserId);
    }
}
