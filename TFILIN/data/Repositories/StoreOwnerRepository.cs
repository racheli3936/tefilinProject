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
    public class StoreOwnerRepository:IStoreOwnerRepository
    {
        private readonly DataContext _context;
        public StoreOwnerRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<List<StoreOwner>> GetStoreOwnersAsync()
        {
            return await _context.StoreOwners.Include(sw=>sw.Stores).ToListAsync();
           
        }
        public async Task AddStorOwnerAsync(StoreOwner storeOwner)
        {
            await _context.StoreOwners.AddAsync(storeOwner);
            await _context.SaveChangesAsync();
        }
    }
}
