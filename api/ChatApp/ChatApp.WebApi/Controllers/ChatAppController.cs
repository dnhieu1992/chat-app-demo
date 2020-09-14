using ChatApp.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatApp.WebApi.Controllers
{
   // [Authorize]
    [Route("api/chat")]
    [ApiController]
    
    public class ChatAppController : ControllerBase
    {
        private IHttpContextAccessor httpContextAccessor;
        public ChatAppController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            return Ok(InitializeData.GetUsers());
        }

        [HttpGet("user")]
        public IActionResult GetUsers(int id)
        {
            return Ok(InitializeData.GetById(id));
        }
    }
}