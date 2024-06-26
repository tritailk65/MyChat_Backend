﻿using MyChat_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Core.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactVm>> GetAllList();
        Task<int> Create(CreateContactRequest request);
        Task<int> Delete(int id);
        Task<int> Update(UpdateContactRequest request);
        Task<ContactVm> GetbyId(Guid id);
    }
}
