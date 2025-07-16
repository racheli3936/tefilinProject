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
    public class StandRepository:IStandRepository
    {
        private readonly DataContext _context;

        public StandRepository(DataContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Stand>> GetAllStandsAsync()
        //{
        //    return await _context.Stands.ToListAsync();
        //}

        //public async Task<Stand> GetStandByIdAsync(int id)
        //{
        //    return await _context.Stands.FindAsync(id);
        //}
        public async Task<List<Stand>> GetStandsByStoreOwnerIdAsync(int storeOwnerId)
        {
            return await _context.Stands
                .Where(stand => _context.StoreStands
                    .Any(storeStand => storeStand.StandId == stand.Id &&
                                      _context.Stores
                                          .Any(store => store.Id == storeStand.StoreId &&
                                                        store.StoreOwnerId == storeOwnerId)))
                .ToListAsync();
        }
        public async Task AddStandAsync(Stand stand)
        {
            await _context.Stands.AddAsync(stand);
            await _context.SaveChangesAsync();
        }

        //public async Task UpdateStandAsync(Stand stand)
        //{
        //    _context.Stands.Update(stand);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteStandAsync(int id)
        //{
        //    var stand = await GetStandByIdAsync(id);
        //    if (stand != null)
        //    {
        //        _context.Stands.Remove(stand);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
