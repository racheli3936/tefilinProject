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
    public class StatusCallRepository:IStatusCallRepository
    {
        private readonly DataContext _context;

        public StatusCallRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<StatusCall>> GetAllAsync()
        {
            return await _context.StatusCalls.ToListAsync();
        }

        public async Task<StatusCall> GetByIdAsync(int id)
        {
            return await _context.StatusCalls.FindAsync(id);
        }

        public async Task AddAsync(StatusCall status)
        {
            await _context.StatusCalls.AddAsync(status);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StatusCall status)
        {
            _context.StatusCalls.Update(status);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var status = await GetByIdAsync(id);
            if (status != null)
            {
                _context.StatusCalls.Remove(status);
                await _context.SaveChangesAsync();
            }
        }
    }
}
