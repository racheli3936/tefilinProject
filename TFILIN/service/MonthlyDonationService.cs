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
    public class MonthlyDonationService:IMonthlyDonationService
    {
        private readonly IMonthlyDonationRepository _monthlyDonationRepository;
        private readonly IMapper _mapper;

        public MonthlyDonationService(IMonthlyDonationRepository monthlyDonationRepository,IMapper mapper)
        {
            _monthlyDonationRepository = monthlyDonationRepository;
            _mapper = mapper;
        }

        public async Task<List<MonthlyDonationDto>> GetMonthlyDonationsByDonationIdAsync(int donationId)
        {
            List<MonthlyDonation> entities = await _monthlyDonationRepository.GetMonthlyDonationsByDonationIdAsync(donationId);

            List<MonthlyDonationDto> monthlyDonationDto=_mapper.Map<List<MonthlyDonationDto>>(entities);
            return monthlyDonationDto;
        }
    }
}
