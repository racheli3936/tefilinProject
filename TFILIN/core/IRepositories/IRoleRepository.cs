using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<bool> CreateRoleAsync(Role role);
    }
}
