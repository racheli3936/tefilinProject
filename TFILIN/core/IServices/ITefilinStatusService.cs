using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface ITefilinStatusService
    {
        Task<TefilinStatus> GetByIdAsync(int id);
        //Task<IEnumerable<TefilinStatus>> GetAllAsync();
        //Task AddAsync(TefilinStatus model);
        //Task UpdateAsync(int id, TefilinStatus model);
        //Task DeleteAsync(int id);
    }
}
