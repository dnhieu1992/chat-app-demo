using System;

namespace ChatApp.WebApi.ViewModels
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid SenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get { return $"{FirstName} {LastName}"; } }
        public string Avatar { get; set; }
        public string Type { get; set; }
    }
}
