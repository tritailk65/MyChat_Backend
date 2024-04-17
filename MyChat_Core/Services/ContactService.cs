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
                
            };
            _myChatDbContext.Contacts.Add(contact);
            await _myChatDbContext.SaveChangesAsync();
            return contact.contact_id;
        }

        public async Task<int> Delete(int id)
        {
            var contact = await _myChatDbContext.Contacts.FindAsync(id);
            if (contact == null)
                return 0;
            _myChatDbContext.Remove(contact);
            return await _myChatDbContext.SaveChangesAsync();
        }

        public async Task<List<ContactVm>> GetAllList()
        {
            var query = from c in _myChatDbContext.Contacts
                        join ct in _myChatDbContext.Messengers on c.MessengerId equals ct.MessengerId
                        select new { c, ct };
            return await query.Select(x => new ContactVm()
            {
                contact_id=x.c.contact_id,
                contact_phone=x.c.contact_phone,
                MessengerId=x.ct.MessengerId
            }).ToListAsync();
        }

        public async Task<ContactVm> GetbyId(int id)
        {
            var query = from c in _myChatDbContext.Contacts
                        join ct in _myChatDbContext.Messengers on c.MessengerId equals ct.MessengerId
                        where c.MessengerId == id
                        select new { c, ct };
            return await query.Select(x => new ContactVm()
            {
               contact_id=x.c.contact_id,
               contact_phone=x.c.contact_phone,
               MessengerId=x.ct.MessengerId

            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(UpdateContactRequest request)
        {
            var contact = await _myChatDbContext.Contacts.FindAsync(request.Id);

            if (contact == null)
                throw new Exception($"Can't find Contacts with id:{request.Id}");
            contact.contact_phone = request.contact_phone;
           
            return await _myChatDbContext.SaveChangesAsync();
        }

    }
}
