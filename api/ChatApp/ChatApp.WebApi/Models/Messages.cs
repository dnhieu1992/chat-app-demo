using ChatApp.WepApi.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.WebApi.Models
{
    public class Messages
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }
        public Guid SenderId { get; set; }
        public DateTime Timestamp { get; set; }
        public virtual ApplicationUser Sender { get; set; }
    }
}
