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
    public class DonorRepository:IDonorRepository
    {
        private readonly DataContext _context;
        public DonorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Donor>> GetAllDonorsAsync()
        {
            return await _context.Donors.Include(d=>d.City).Include(d=>d.Region).ToListAsync();
        }
    }
}
