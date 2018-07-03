using GetWheels.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetWheels.Data.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(Guid id);

        Task<User> UpdateAsync(User user);

        Task DeleteAsync(Guid id);

        Task<User> CreateUser(User user);
    }
}
