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
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;
        public DonorService(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<List<DonorDto>> GetAllDonorsAsync()
        {
            List<Donor> donors = await _donorRepository.GetAllDonorsAsync();
            List<DonorDto> donorDto = _mapper.Map<List<DonorDto>>(donors);
            return donorDto;
        }
    }
}
