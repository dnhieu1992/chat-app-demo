using ChatApp.WebApi.Services.Conversation;
using ChatApp.WebApi.ViewModels;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Controllers
{
    [Route("api/conversation")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConversationService _conversationService;
        public ConversationController(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IConversationService conversationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _conversationService = conversationService;
        }
        #region Methods
        [HttpPost("create")]
        public async Task<IActionResult> CreateConversation(ConversationViewModel request)
        {
            var currentUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByNameAsync(currentUser);
            if (user != null)
            {
                request.ParticipantIds.Add(user.Id);
            }
            var result = await _conversationService.CreateConversationAsync(request);
            return Ok(result);
        }
        [HttpPut("addUserToConversation")]
        public async Task<IActionResult> AddUserToConversation(ConversationViewModel request)
        {
            var result = await _conversationService.AddUserToConversationAsync(request);
            return Ok(result);
        }
        [HttpDelete("deleteUserToConversation")]
        public async Task<IActionResult> DeleteUserToConversation(ConversationViewModel request)
        {
            var result = await _conversationService.RemoveUserToConversationAsync(request);
            return Ok(result);
        }
        #endregion
    }
}