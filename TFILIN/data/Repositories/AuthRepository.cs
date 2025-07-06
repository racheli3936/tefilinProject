using core.IRepositories;
using core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            bool isPasswordValid = false;
            User user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
            }
            if (isPasswordValid)
                return user;
            return null;
        }
        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
           // return user;
        }
        public async Task UpdateUpdated_CreatedBy(int userId)
        {
            User user=await _context.Users.FirstAsync(u=>u.Id==userId);
            if (user != null) 
            { 
                user.CreatedBy= userId;
                user.UpdatedBy= userId;
            }
            await _context.SaveChangesAsync();
        }
    }
}
