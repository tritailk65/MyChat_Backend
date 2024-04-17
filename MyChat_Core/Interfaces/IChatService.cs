using MyChat_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatVm>> GetAllList();
        Task<int> Create(CreateChatRequest request);
        Task<int> Delete(int chatid);
        Task<int> Update(UpdateChatRequest request);
        Task<ChatVm> GetById(int chatId);
        Task<ChatVm> GetUserId(Guid userchatId);
    }
}
