using ChatApp.WebApi.ViewModels;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.UserManagement
{
    public class UserService : IUserService
    {
        #region Propeties
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion
        #region Constructors
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        #endregion
        public async Task<List<UserViewModel>> GetUsersAsync(string username, Guid currentUserId)
        {
            var users = await _userManager.Users.Where(a => a.UserName.Contains(username) && a.Id != currentUserId).Select(b => new UserViewModel()
            {
                Id = b.Id,
                Username = b.UserName,
                Email = b.Email,
                FirstName = b.FirstName,
                LastName = b.LastName,
                Avatar=b.AvatarUrl
            }).ToListAsync();

            return users;
        }
    }
}
