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
    public class StoreRepository:IStoreRepository
    {
        private readonly DataContext _context;
        public StoreRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Store>> GetStoresByOwnerIdAsync(int ownerId)
        {
            return await _context.Stores.Include(s=>s.StoreStand)
                .Where(s => s.StoreOwnerId == ownerId)
                .ToListAsync();
        }
        public async Task<Store> AddStoreAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return store;
        }

    }
}
