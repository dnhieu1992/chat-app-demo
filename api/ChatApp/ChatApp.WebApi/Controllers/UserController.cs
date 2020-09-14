using ChatApp.WebApi.Services.UserManagement;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Controllers
{
    //[Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Properties
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructors
        public UserController(IUserService userService, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region Methods
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsersAsync(string username)
        {
            var currentUsername = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByNameAsync(currentUsername);
            var result = await _userService.GetUsersAsync(username, user.Id);
            return Ok(result);
        }
        #endregion

    }
}