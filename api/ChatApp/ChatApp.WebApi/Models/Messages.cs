using ChatApp.WebApi.Models.Entities.Common;
using System;

namespace ChatApp.WebApi.Models
{
    public class Messages : BaseEntity
    {
        public string Message { get; set; }
        public Guid ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}
