using ChatApp.WebApi.Infrastructure.Repositories;
using ChatApp.WebApi.Infrastructure.UnitOfWork;
using ChatApp.WebApi.Models;
using ChatApp.WebApi.ViewModels;
using System;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.Conversation
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ConversationService(IConversationRepository conversationRepository, IParticipantRepository participantRepository, IUnitOfWork unitOfWork)
        {
            _conversationRepository = conversationRepository;
            _participantRepository = participantRepository;
            _unitOfWork = unitOfWork;
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

        public async Task<bool> CreateConversationAsync(ConversationViewModel request)
        {
            var conversation = new Models.Conversation()
            {
                Id = Guid.NewGuid(),
                Title = request.Title
            };
            _conversationRepository.Add(conversation);
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
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
