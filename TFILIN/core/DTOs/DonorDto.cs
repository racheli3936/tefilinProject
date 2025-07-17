using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTOs
{
    public class DonorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public CityDto City { get; set; }
        public RegionDto Region { get; set; }
        public string Email { get; set; }
        public List<DonationDto> Donations { get; set; } = new List<DonationDto>();
    }
}
