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
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ConversationService(IConversationRepository conversationRepository, IParticipantRepository participantRepository,
            IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _conversationRepository = conversationRepository;
            _participantRepository = participantRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddUserToConversationAsync(ConversationViewModel request)
        {
            foreach (var participantId in request.ParticipantIds)
            {
                var participant = new Participant()
                {
                    Id = Guid.NewGuid(),
                    ConversationId = request.Id,
                    UserId = participantId
                };
                _participantRepository.Add(participant);
            }
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
        public async Task<bool> RemoveUserToConversationAsync(ConversationViewModel request)
        {
            foreach (var participantId in request.ParticipantIds)
            {
                var participant = _participantRepository.FindById(participantId);
                _participantRepository.Delete(participant);
            }
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<ConversationViewModel> CreateConversationAsync(ConversationRequest request)
        {
            var conversation = new Models.Conversation()
            {
                Id = Guid.NewGuid()
            };

            var result = new ConversationViewModel()
            {
                Id = conversation.Id,
            };
            var currentUsername = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _userManager.FindByNameAsync(currentUsername);

            if (!request.IsAutoCreate)
            {
                conversation.Name = request.Name;
                result.Name = request.Name;
            }
            else
            {
                var participant = await _userManager.FindByIdAsync(request.ParticipantIds.FirstOrDefault().ToString());
                result.Name = $"{participant.FirstName} {participant.LastName}";
            }

            _conversationRepository.Add(conversation);
            request.ParticipantIds.Add(currentUser.Id);
            foreach (var participantId in request.ParticipantIds)
            {
                var participant = new Participant()
                {
                    Id = Guid.NewGuid(),
                    ConversationId = conversation.Id,
                    UserId = participantId
                };
                _participantRepository.Add(participant);
            }

            await _unitOfWork.SaveChangeAsync();
            return result;
        }

        public async Task<List<ConversationViewModel>> GetConversationsAsync(Guid currentId)
        {
            var conversations = await _conversationRepository.Query(a => a.Participants.Any(b => b.UserId == currentId)).Select(m => new ConversationViewModel()
            {
                Id = m.Id,
                Name = m.Name != null ? m.Name : $"{m.Participants.FirstOrDefault(x => x.UserId != currentId).User.FirstName} {m.Participants.FirstOrDefault(x => x.UserId != currentId).User.LastName}",
                GroupAvatar = m.Participants.FirstOrDefault(x => x.UserId != currentId).User.AvatarUrl,
                //LastestMessage = m.Messages.OrderByDescending(c => c.Timestamp).Select(a => a.Message).FirstOrDefault()
            }).ToListAsync();

            return conversations;
        }
    }
}
