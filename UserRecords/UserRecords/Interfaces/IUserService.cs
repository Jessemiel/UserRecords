using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserRecords.Models;

namespace UserRecords.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers();
    }
}
