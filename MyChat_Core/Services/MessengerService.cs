﻿using Microsoft.EntityFrameworkCore;
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
    public class MessengerService:IMessengerService
    {
        private readonly MyChatDbContext _myChatDbContext;
        public MessengerService(MyChatDbContext myChatDbContext)
        {
            _myChatDbContext = myChatDbContext;
        }

        public MessengerService()
        {

        }
        public async Task<List<MessengerVm>> GetAllList()
        {
            var query = from c in _myChatDbContext.Messengers
                        join ct in _myChatDbContext.Chats on c.ChatId equals ct.Chatid
                        select new { c, ct };
            return await query.Select(x => new MessengerVm()
            {
               Content=x.c.Content,
               Constamps=x.c.Constamps,
               status=x.c.status,
               ChatId=x.ct.Chatid
            }).ToListAsync();
        }

        public async Task<int> Create(MessengerRequest request)
        {
            var mess = new Messenger()
            {
               Content=request.Content,
               Constamps=request.Constamps,
               status=request.status,
               Chat=new Chat()
               {
                   Title=request.Title,
                   Participants=request.Participants,
                   
               }
            };
            _myChatDbContext.Messengers.Add(mess);
            await _myChatDbContext.SaveChangesAsync();
            return mess.ChatId;
        }

       
    }
}