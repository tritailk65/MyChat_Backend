using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyChat_Core.Interfaces;
using MyChat_Data.EF;

namespace MyChat_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class MessengerController : ControllerBase
	{

		private IMessengerService _messengerService;
		private MyChatDbContext _context;
		public MessengerController(MyChatDbContext context, IMessengerService messengerService)
		{
			_messengerService = messengerService;
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var mess = await _messengerService.GetAllList();
			return Ok(mess);
		}
	}
}
