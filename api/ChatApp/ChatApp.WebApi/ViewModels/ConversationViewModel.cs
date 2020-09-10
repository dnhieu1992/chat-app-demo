using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.WebApi.ViewModels
{
    public class ConversationViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Guid> ParticipantIds { get; set; }
    }
}
