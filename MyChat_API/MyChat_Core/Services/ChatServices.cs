using Microsoft.EntityFrameworkCore;
using MyChat_Core.Interfaces;
using MyChat_Core.ViewModels;
using MyChat_Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Services
{
	public class ChatServices : IChatService
	{
		private MyChatDbContext _context;
		public ChatServices(MyChatDbContext context)
		{
			_context = context;
		}
		public async Task<List<ChatVm>> GetAllList()
		{
			var query = from c in _context.Chats
			
						select new { c};
			return await query.Select(x => new ChatVm()
			{
				Title=x.c.Title,
				Content=x.c.Content,
				created_at=DateTime.Now,
				Participants=x.c.Participants,
			}).ToListAsync();
		}
	}
}
