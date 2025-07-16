using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IStandService
    {
        //Task<IEnumerable<Stand>> GetAllStandsAsync();
        //Task<Stand> GetStandByIdAsync(int id);
        Task<List<Stand>> GetStandsByStoreOwnerIdAsync(int storeOwnerId);
        Task AddStandAsync(Stand stand);
        //Task UpdateStandAsync(int id, Stand stand);
        //Task DeleteStandAsync(int id);
    }
}
