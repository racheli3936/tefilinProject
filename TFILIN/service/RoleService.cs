using core.IRepositories;
using core.IServices;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            try
            {
                return await _roleRepository.GetRoleByNameAsync(roleName);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> CreateRoleAsync(Role newRole)
        {
            
           return await _roleRepository.CreateRoleAsync(newRole);

        }
            
    }
}
