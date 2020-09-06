using ChatApp.WebApi.Models.Entities.Common;
using System.Collections.Generic;

namespace ChatApp.WebApi.Models
{
    public class Conversation : BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<UserConversation> UserConversations { get; set; }
    }
}
