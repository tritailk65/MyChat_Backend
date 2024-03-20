using Microsoft.EntityFrameworkCore;
using MyChat_Core.Interfaces;
using MyChat_Core.ViewModels;
using MyChat_Data.EF;
using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Services
{
    public class ContactService : IContactService
    {
        private readonly MyChatDbContext _myChatDbContext;
        public ContactService(MyChatDbContext myChatDbContext)
        {
            _myChatDbContext = myChatDbContext;
        }

		public async Task<int> Create(CreateContactRequest request)
		{
            var contact = new Contact()
            {
                contact_phone = request.contact_phone,
                User = new User()
                {
                    UserId=null
                }
            };
            _myChatDbContext.Contacts.Add(contact);
            await _myChatDbContext.SaveChangesAsync();
            return contact.contact_id;
		}

		public async Task<List<ContactVm>> GetAllList()
        {
            var query = from c in _myChatDbContext.Contacts
                        join ct in _myChatDbContext.Users on c.UserId equals ct.Id
                        select new { c, ct };
            return await query.Select(x => new ContactVm()
            {
                contact_id=x.c.contact_id,
                contact_phone=x.c.contact_phone,
                UserId=x.ct.Id
            }).ToListAsync();
        }
       
    }
}
