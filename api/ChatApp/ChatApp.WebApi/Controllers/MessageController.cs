using ChatApp.WebApi.Services.Conversation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet("getMessages")]
        public async Task<IActionResult> GetMessagesAsync(Guid conversationId)
        {
            var result = await _messageService.GetMessageByConversationIdAsync(conversationId);
            return Ok(result);
        }
    }
}