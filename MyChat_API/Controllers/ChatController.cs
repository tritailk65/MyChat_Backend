using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyChat_API.Hubs;
using MyChat_Core.Interfaces;
using MyChat_Core.ViewModels;
using MyChat_Data.EF;

namespace MyChat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private IChatService _chatService;
        private MyChatDbContext _context;
        private readonly IHubContext<SignalRHub> _chatHubContext;
        public ChatController(MyChatDbContext context, IChatService chatService, IHubContext<SignalRHub> chatHubContext)
        {
            _chatService = chatService;
            _context = context;
            _chatHubContext = chatHubContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chatlist = await _chatService.GetAllList();
            return Ok(chatlist);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateChatRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chatId = await _chatService.Create(request);
            if (chatId == 0)
                return BadRequest();
            return Ok(request);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int chatId)
        {
            var affectedReSult = await _chatService.Delete(chatId);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateChatRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedReSult = await _chatService.Update(request);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPost("send")]
        public IActionResult SendMessage(int senderId, int receiverId, string message)
        {
            _chatHubContext.Clients.All.SendAsync("SendMessage", senderId, receiverId, message);
            return Ok();
        }
    }
}
