using GetWheels.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetWheels.Services.Contracts
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(string email,string userId, User user);
    }
}
