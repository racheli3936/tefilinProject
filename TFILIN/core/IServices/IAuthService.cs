using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IAuthService
    {
        Task<(string token, User user)> LoginAsync(string email, string password);
        Task<string> RegisterUserAsync(User user);
    }
}
