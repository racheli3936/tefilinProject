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
    public class DonationRepository:IDonationRepository
    {

        private readonly DataContext _context;

        public DonationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Donation>> GetActiveDonationsAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return await _context.Donations
                .Where(d => d.EndDonation > today)
                .ToListAsync();
        }
    }
}
