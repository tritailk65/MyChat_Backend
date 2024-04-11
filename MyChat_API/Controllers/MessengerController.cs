using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyChat_Core.Interfaces;
using MyChat_Core.Services;
using MyChat_Core.ViewModels;
using MyChat_Data.EF;
using MyChat_Data.Entities;

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
        [HttpPost]
        public async Task<IActionResult> Create(MessengerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chatId = await _messengerService.Create(request);
            if (chatId == 0)
                return BadRequest();
            return Ok(request);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedReSult = await _messengerService.Delete(Id);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult>Update([FromForm]UpdateMessengerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedReSult = await _messengerService.Update(request);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
