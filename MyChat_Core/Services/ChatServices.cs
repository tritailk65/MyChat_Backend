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
      public class Chatservices:IChatService
    {
        private MyChatDbContext _context;

        public Chatservices(MyChatDbContext context)
        {
            _context = context;
        }
        public async Task<List<ChatVm>> GetAllList()
        {
            var query = from c in _context.Chats

                        select new { c };
            return await query.Select(x => new ChatVm()
            {
                Title = x.c.Title,
                Content = x.c.Content,
                created_at = DateTime.Now,
                UserId=x.c.UserId
            }).ToListAsync();
        }
        public async Task<int> Create(CreateChatRequest request)
        {
            var chatdata = new Chat()
            {
                Content = request.Content,
                Title = request.Title,
                User = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Birthday = request.Birthday,
                    UserName = request.Username_Display,
                    last_seen = request.last_seen,
                    Status = request.Status
                },
                created_at = request.created_at
            };
            _context.Chats.Add(chatdata);
            await _context.SaveChangesAsync();
            return chatdata.Chatid;
        }
        public async Task<int> Delete(int chatId)
        {
            var contact = await _context.Contacts.FindAsync(chatId);
            if (contact == null)
                return 0;
            _context.Remove(contact);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(UpdateChatRequest request)
        {
            var chat = await _context.Chats.FindAsync(request.Id);

            if (chat == null)
                throw new Exception($"Can't find Chat with id:{request.Id}");
            chat.Content = request.Content;
            chat.Title = request.Title;
            chat.User.UserName = request.Username_Display;
            chat.created_at = request.created_at;
            return await _context.SaveChangesAsync();
        }

        public async Task<ChatVm> GetById(Guid id)
        {
            var query = from c in _context.Chats

                        where c.UserId== id
                        select new { c };
            return await query.Select(x => new ChatVm()
            {
                Title=x.c.Title,
                Content=x.c.Content,
                UserId =x.c.UserId,
                created_at=x.c.created_at,
                Messengers=x.c.Messengers

            }).FirstOrDefaultAsync();
        }

        
    }
}
