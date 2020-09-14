using ChatApp.WebApi.Infrastructure.Repositories;
using ChatApp.WebApi.Infrastructure.UnitOfWork;
using ChatApp.WebApi.Models;
using ChatApp.WebApi.ViewModels;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.Conversation
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        public MessageService(IMessageRepository messageRepository, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageViewModel> AddMessageAsync(string message, Guid conversationId,Guid currentUserId)
        {
            var user = await _userManager.FindByIdAsync(currentUserId.ToString());
            var messageItem = new Messages()
            {
                Id = Guid.NewGuid(),
                ConversationId = conversationId,
                SenderId = user.Id,
                Timestamp = DateTime.UtcNow,
                Message = message
            };
            _messageRepository.Add(messageItem);
            await _unitOfWork.SaveChangeAsync();

            return new MessageViewModel()
            {
                Id = messageItem.Id,
                Message = messageItem.Message,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Avatar = user.AvatarUrl,
                SenderId = user.Id,
                Type = "sent"
            };

        }

        public async Task<List<MessageViewModel>> GetMessageByConversationIdAsync(Guid conversationId)
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByNameAsync(username);

            var messages = await _messageRepository.Query(a => a.ConversationId == conversationId).OrderBy(c => c.Timestamp).Select(b => new MessageViewModel()
            {
                Id = b.Id,
                Message = b.Message,
                FirstName = b.Sender.FirstName,
                LastName = b.Sender.LastName,
                Avatar = b.Sender.AvatarUrl,
                Type = b.Sender.Id == user.Id ? "sent" : "received",
                SenderId=b.SenderId

            }).ToListAsync();

            return messages;
        }
    }
}
