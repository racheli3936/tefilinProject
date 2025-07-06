using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetStoresByOwnerIdAsync(int ownerId);
        Task<Store> AddStoreAsync(Store store);
    }
}
