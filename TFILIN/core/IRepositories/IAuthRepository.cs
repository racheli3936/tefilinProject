using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
   public interface IAuthRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        Task CreateUserAsync(User user);
        Task UpdateUpdated_CreatedBy(int userId);
    }
}
