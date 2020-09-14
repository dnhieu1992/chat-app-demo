using System;
using System.Collections.Generic;

namespace ChatApp.WebApi.ViewModels
{
    public class ConversationViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Guid> ParticipantIds { get; set; }
        public string LastestMessage { get; set; }
        public string GroupAvatar { get; set; }
        public string Name { get; set; }
    }
    public class ConversationRequest
    {
        public string Name { get; set; }
        public List<Guid> ParticipantIds { get; set; }
        public bool IsAutoCreate { get; set; }
    }
}
