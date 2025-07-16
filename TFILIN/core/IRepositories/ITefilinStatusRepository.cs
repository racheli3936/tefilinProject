using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
    public interface ITefilinStatusRepository
    {
        Task<TefilinStatus> GetByIdAsync(int id);
        //Task<IEnumerable<TefilinStatus>> GetAllAsync();
        //Task AddAsync(TefilinStatus tefilinStatus);
        //Task UpdateAsync(TefilinStatus tefilinStatus);
        //Task DeleteAsync(int id);
    }
}
