using ChatApp.WepApi.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.WebApi.Models
{
    public class Participant
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public Guid UserId { get; set; }
        public virtual Conversation Conversation { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
