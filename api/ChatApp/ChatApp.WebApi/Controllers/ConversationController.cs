using ChatApp.WebApi.Services.Conversation;
using ChatApp.WebApi.ViewModels;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/conversation")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConversationService _conversationService;
        public ConversationController(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager,
            IConversationService conversationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _conversationService = conversationService;
        }
        #region Methods
        [HttpPost("create")]
        public async Task<IActionResult> CreateConversationAsync(ConversationRequest request)
        {
            //var currentUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = await _userManager.FindByNameAsync(currentUser);
            //if (user != null)
            //{
            //    request.ParticipantIds.Add(user.Id);
            //}
            var result = await _conversationService.CreateConversationAsync(request);
            return Ok(result);
        }
        [HttpPut("addUserToConversation")]
        public async Task<IActionResult> AddUserToConversationAsync(ConversationViewModel request)
        {
            var result = await _conversationService.AddUserToConversationAsync(request);
            return Ok(result);
        }
        [HttpDelete("deleteUserToConversation")]
        public async Task<IActionResult> DeleteUserToConversationAsync(ConversationViewModel request)
        {
            var result = await _conversationService.RemoveUserToConversationAsync(request);
            return Ok(result);
        }
        [HttpGet("getConversations")]
        public async Task<IActionResult> GetConversationsAsync()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByNameAsync(username);
            var result = await _conversationService.GetConversationsAsync(user.Id);
            return Ok(result);
        }

        #endregion
    }
}