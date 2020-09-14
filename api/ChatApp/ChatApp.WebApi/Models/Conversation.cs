using ChatApp.WebApi.Models.Entities.Common;
using System.Collections.Generic;

namespace ChatApp.WebApi.Models
{
    public class Conversation : BaseEntity
    {
        public string Name { get; set; }
        public string GroupAvatar { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
