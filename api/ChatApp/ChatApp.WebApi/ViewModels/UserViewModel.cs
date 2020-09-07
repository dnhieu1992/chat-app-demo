namespace ChatApp.WebApi.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
