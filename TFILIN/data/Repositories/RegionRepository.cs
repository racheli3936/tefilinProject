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
    public class RegionRepository:IRegionRepository
    {
        private readonly DataContext _context;

        public RegionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionByIdAsync(int id)
        {
            return await _context.Regions.FindAsync(id);
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }
    }
}
