using ChatApp.WebApi.ViewModels;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        public AuthenticationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserViewModel> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return null;

            var isAuthentication = await _userManager.CheckPasswordAsync(user, password);
            if (isAuthentication)
            {
                return new UserViewModel()
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Avatar = user.AvatarUrl

                };
            }
            return null;
        }

        public async Task<UserViewModel> RegisterAsync(UserRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null)
            {
                throw new Exception("Duplicate user");
            }
            user = new ApplicationUser()
            {
                UserName = request.Username,
                Email = request.Email
            };

            var isResult = await _userManager.CreateAsync(user, request.Password);
            if (isResult.Succeeded)
            {
                return new UserViewModel()
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Id = user.Id
                };
            }
            return null;
        }
    }
}
