using core.IRepositories;
using core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public class ToDoVisitRepository:IToDoVisitRepository
    {
        private readonly DataContext _context;

        public ToDoVisitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoVisit>> GetAllAsync()
        {
            return await _context.ToDoStand.ToListAsync();
        }

        public async Task<ToDoVisit> GetByIdAsync(int id)
        {
            return await _context.ToDoStand.FindAsync(id);
        }

        public async Task AddAsync(ToDoVisit visit)
        {
            await _context.ToDoStand.AddAsync(visit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoVisit visit)
        {
            _context.ToDoStand.Update(visit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var visit = await GetByIdAsync(id);
            if (visit != null)
            {
                _context.ToDoStand.Remove(visit);
                await _context.SaveChangesAsync();
            }
        }

    }
}
