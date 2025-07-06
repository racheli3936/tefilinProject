using core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface IDonorService
    {
        Task<List<DonorDto>> GetAllDonorsAsync();
    }
}
