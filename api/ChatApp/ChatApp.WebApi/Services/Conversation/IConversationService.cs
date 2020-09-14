using ChatApp.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.Conversation
{
    public interface IConversationService
    {
        Task<ConversationViewModel> CreateConversationAsync(ConversationRequest request);
        Task<bool> AddUserToConversationAsync(ConversationViewModel request);
        Task<bool> RemoveUserToConversationAsync(ConversationViewModel request);
        Task<List<ConversationViewModel>> GetConversationsAsync(Guid currentId);
    }
}
