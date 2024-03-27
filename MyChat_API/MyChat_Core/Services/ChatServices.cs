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
                Participants = x.c.Participants,
            }).ToListAsync();
        }
        public async Task<int> Create(CreateChatRequest request)
        {
            var chatdata = new Chat()
            {
                Content = request.Content,
                Title = request.Title,
                Participants = request.Participants,
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
            chat.Participants = request.Participants;
            chat.created_at = request.created_at;
            return await _context.SaveChangesAsync();
        }
    }
}
