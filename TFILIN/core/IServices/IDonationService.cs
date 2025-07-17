using core.DTOs;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IDonationService
    {
        Task<List<DonationDto>> GetActiveDonationsAsync();

        Task<List<DonationDto>> GetDonationsByUserAsync(int userId);
    }
}
