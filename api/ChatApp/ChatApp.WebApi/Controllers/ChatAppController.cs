using ChatApp.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.WebApi.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatAppController : ControllerBase
    {
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(InitializeData.GetUsers());
        }

        [HttpGet("user")]
        public IActionResult GetUsers(int id)
        {
            return Ok(InitializeData.GetById(id));
        }
    }
}