using System;

namespace ChatApp.WebApi.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DisplayName { get { return $"{FirstName} {LastName}"; } }
        public string Token { get; set; }
        public string Avatar { get; set; }
    }

    public class UserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
