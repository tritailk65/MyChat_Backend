using MyChat_Core.Common;
using MyChat_Core.ViewModels;
using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUser();
        Task<UserViewModel> Authentication(LoginRequest request);
        Task Register(RegisterRequest user);
        Task<User> GetUserByID(Guid id);
    }
}
