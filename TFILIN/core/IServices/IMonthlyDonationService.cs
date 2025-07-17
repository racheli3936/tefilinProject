using core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IMonthlyDonationService
    {
        Task<List<MonthlyDonationDto>> GetMonthlyDonationsByDonationIdAsync(int donationId);
    }
}
