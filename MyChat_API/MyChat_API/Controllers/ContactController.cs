﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyChat_Core.Interfaces;
using MyChat_Core.Services;
using MyChat_Core.ViewModels;
using MyChat_Data.EF;

namespace MyChat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;
        private MyChatDbContext _context;
        public ContactController(MyChatDbContext context, IContactService contactService)
        {
            _contactService = contactService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contactlist = await _contactService.GetAllList();
            return Ok(contactlist);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateContactRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contactId = await _contactService.Create(request);
            if (contactId == 0)
                return BadRequest();
            return Ok(request);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int contactId)
        {
            var affectedReSult = await _contactService.Delete(contactId);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
        
    }
}

