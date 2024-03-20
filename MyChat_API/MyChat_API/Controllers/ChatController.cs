using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyChat_Core.Interfaces;
using MyChat_Core.Services;
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
		public ChatController(MyChatDbContext context, IChatService chatService)
		{
			_chatService = chatService;
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var chatlist = await _chatService.GetAllList();
			return Ok(chatlist);
		}
	}
}
