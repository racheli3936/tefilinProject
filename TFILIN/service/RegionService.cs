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
    public class RegionService:IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await _regionRepository.GetAllRegionsAsync();
        }

        public async Task<Region> GetRegionByIdAsync(int id)
        {
            return await _regionRepository.GetRegionByIdAsync(id);
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            return await _regionRepository.AddRegionAsync(region);
        }
    }
}
