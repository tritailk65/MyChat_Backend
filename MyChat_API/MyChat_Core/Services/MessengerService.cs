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
	public class MessengerService : IMessengerService
	{
		private readonly MyChatDbContext _context;
		
		public MessengerService(MyChatDbContext context)
		{
			_context = context;
		}
		public async Task<List<MessengerVm>> GetAllList()
		{
			var query = from c in _context.Messengers
						join ct in _context.Chats on c.ChatId equals ct.Chatid
						select new { c, ct };
			return await query.Select(x => new MessengerVm()
			{
				ChatId=x.c.ChatId,
				Content=x.c.Content,
				Constamps=x.c.Constamps,
				status=x.c.status
			}).ToListAsync();
		}
	}
}
