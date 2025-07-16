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
    public class TefilinStatusRepository:ITefilinStatusRepository
    {
        private readonly DataContext _context;

        public TefilinStatusRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TefilinStatus> GetByIdAsync(int id)
        {
            return await _context.TefilinStatuses.FindAsync(id);
        }

        //public async Task<IEnumerable<TefilinStatus>> GetAllAsync()
        //{
        //    return await _context.TefilinStatuses.ToListAsync();
        //}

        //public async Task AddAsync(TefilinStatus tefilinStatus)
        //{
        //    await _context.TefilinStatuses.AddAsync(tefilinStatus);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(TefilinStatus tefilinStatus)
        //{
        //    _context.TefilinStatuses.Update(tefilinStatus);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var tefilinStatus = await GetByIdAsync(id);
        //    if (tefilinStatus != null)
        //    {
        //        _context.TefilinStatuses.Remove(tefilinStatus);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
