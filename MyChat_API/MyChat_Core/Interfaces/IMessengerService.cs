using MyChat_Core.ViewModels;
using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Interfaces
{
    public interface IMessengerService
    {
        Task<List<MessengerVm>> GetAllList();
        Task<int> Create(MessengerRequest request);

    }
}
