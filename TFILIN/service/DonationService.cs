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

        public async Task<List<DonationDto>> GetDonationsByUserAsync(int userId)
        {
            var donation= await _donationRepository.GetDonationsByDonorIdAsync(userId);
            var donationDto=_mapper.Map<List<DonationDto>>(donation);
            return donationDto;
        }
    }
}
