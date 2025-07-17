using AutoMapper;
using core.DTOs;
using core.IRepositories;
using core.IServices;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class DonationService:IDonationService
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IMapper _mapper;

        public DonationService(IDonationRepository donationRepository,IMapper mapper)
        {
            _donationRepository = donationRepository;
            _mapper = mapper;
        }

        public async Task<List<DonationDto>> GetActiveDonationsAsync()
        {
            List<Donation> donations= await _donationRepository.GetActiveDonationsAsync();
            List<DonationDto> donationDtos = _mapper.Map<List<DonationDto>>(donations);
            return donationDtos;
        }
    }
}
