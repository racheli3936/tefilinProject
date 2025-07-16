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
    public class ToDoVisitService : IToDoVisitService
    {
        private readonly IToDoVisitRepository _repository;

        public ToDoVisitService(IToDoVisitRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ToDoVisit>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        public async Task<ToDoVisit> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ToDoVisit visit)
        {
            visit.CreatedDate = DateTime.Now;
            visit.UpdatedDate = DateTime.Now;
            await _repository.AddAsync(visit);
        }

        public async Task UpdateAsync(ToDoVisit visit)
        {
            visit.UpdatedDate = DateTime.Now;
            await _repository.UpdateAsync(visit);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
