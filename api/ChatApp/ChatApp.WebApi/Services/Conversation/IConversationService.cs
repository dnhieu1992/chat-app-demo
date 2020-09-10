using ChatApp.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.Conversation
{
    public interface IConversationService
    {
        Task<bool> CreateConversationAsync(ConversationViewModel request);
        Task<bool> AddUserToConversationAsync(ConversationViewModel request);
        Task<bool> RemoveUserToConversationAsync(ConversationViewModel request);
    }
}
