using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IStoreService
    {
        Task<Store> AddStoreAsync(Store newStore);
    }
}
