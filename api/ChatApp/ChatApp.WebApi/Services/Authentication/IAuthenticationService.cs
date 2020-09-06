using ChatApp.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<UserViewModel> LoginAsync(string username,string password);
    }
}
