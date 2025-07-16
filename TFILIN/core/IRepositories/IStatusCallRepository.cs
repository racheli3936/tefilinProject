using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
    public interface IStatusCallRepository
    {
        Task<List<StatusCall>> GetAllAsync();
        Task<StatusCall> GetByIdAsync(int id);
        Task AddAsync(StatusCall status);
        Task UpdateAsync(StatusCall status);
        Task DeleteAsync(int id);
    }
}
