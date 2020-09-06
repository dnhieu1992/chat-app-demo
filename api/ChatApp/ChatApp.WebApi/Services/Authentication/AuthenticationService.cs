﻿using ChatApp.WebApi.ViewModels;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Identity;
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
                    Email = user.Email
                };
            }
            return null;
        }
    }
}