using core.IRepositories;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IRegionService
    {
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region> GetRegionByIdAsync(int id);
        Task<Region> AddRegionAsync(Region region);
    }
}
