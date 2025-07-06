using core.DTOs;
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
    public class RoleRepository: IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<Role>GetRoleByNameAsync(string roleName)
        {
           return  await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
             
        }
        public async Task<bool> CreateRoleAsync(Role role)
        {
            try
            {
                _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            { 
                return false;
            }
           
        }
    }
}
