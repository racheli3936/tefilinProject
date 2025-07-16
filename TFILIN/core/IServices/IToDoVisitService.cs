using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IToDoVisitService
    {
        Task<List<ToDoVisit>> GetAllAsync();
        Task<ToDoVisit> GetByIdAsync(int id);
        Task AddAsync(ToDoVisit visit);
        Task UpdateAsync(ToDoVisit visit);
        Task DeleteAsync(int id);
    }
}
