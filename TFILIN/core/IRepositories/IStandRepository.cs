using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
    public interface IStandRepository
    {
        //Task<IEnumerable<Stand>> GetAllStandsAsync();
        //Task<Stand> GetStandByIdAsync(int id);
        Task<List<Stand>> GetStandsByStoreOwnerIdAsync(int storeOwnerId);
        Task AddStandAsync(Stand stand);
        //Task UpdateStandAsync(Stand stand);
        //Task DeleteStandAsync(int id);
    }
}
