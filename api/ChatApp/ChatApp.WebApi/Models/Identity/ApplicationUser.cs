using ChatApp.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ChatApp.WepApi.Models.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public virtual ICollection<UserConversation> UserConversations { get; set; }
    }
}
