using MyChat_Core.Interfaces;
using MyChat_Data.EF;
using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Services
{
    public class UserService : IUserService
    {
        private readonly MyChatDbContext _db;

        public UserService(MyChatDbContext db)
        {
            _db = db;
        }

        public List<User> GetAllUser()
        {
            return _db.Users.ToList();
        }
    }
}
