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
    public class MonthlyDonationRepository:IMonthlyDonationRepository
    {
        private readonly DataContext _context;

        public MonthlyDonationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MonthlyDonation>> GetMonthlyDonationsByDonationIdAsync(int donationId)
        {
            return await _context.MonthlyDonations
                .Where(md => md.DonationId == donationId)
                .ToListAsync();
        }
    }
}
