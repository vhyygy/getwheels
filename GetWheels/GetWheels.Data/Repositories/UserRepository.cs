using GetWheels.Data.Contracts;
using GetWheels.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetWheels.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly GWContextDb _db;

        public UserRepository(GWContextDb db)
        {
            _db = db;
        }

        public async Task<User> CreateUser(User user)
        {
            _db.Users.Add(user);
            try
            {
                await _db.SaveChangesAsync();

            }catch(DbUpdateException)
            {
                throw new Exception("Unexpected error!");
            }
            return await GetUserByIdAsync(user.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            User user = await _db.Users.FindAsync(id);
            if(user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _db.Users
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _db.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new Exception("User not found!");
            }
            return await GetUserByIdAsync(user.Id);
        }
    }
}
