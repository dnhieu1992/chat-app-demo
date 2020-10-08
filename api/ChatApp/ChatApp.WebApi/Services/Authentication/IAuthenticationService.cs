using ChatApp.WebApi.ViewModels;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<UserViewModel> LoginAsync(string username, string password);
        Task<UserViewModel> RegisterAsync(UserRequest request);
    }
}
