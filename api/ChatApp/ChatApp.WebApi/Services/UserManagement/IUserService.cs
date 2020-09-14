using ChatApp.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.UserManagement
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetUsersAsync(string username, Guid currentUserId); 
    }
}
