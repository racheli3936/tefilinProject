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
    public class StatusCallService : IStatusCallService
    {
        private readonly IStatusCallRepository _statusCallRepository;
        private readonly IMapper _mapper;

        public StatusCallService(IStatusCallRepository statusCallRepository,IMapper mapper)
        {
            _statusCallRepository = statusCallRepository;
            _mapper = mapper;
        }

        public async Task<List<StatusCallDto>> GetAllAsync() {
           List<StatusCall> statuses= await _statusCallRepository.GetAllAsync();
            return _mapper.Map<List<StatusCallDto>>(statuses);

        }

        public async Task<StatusCall> GetByIdAsync(int id)
        { 
        return await _statusCallRepository.GetByIdAsync(id);

        }

        public async Task AddAsync(StatusCall status)
        {
            status.CreatedDate = DateTime.Now;
            status.UpdatedDate = DateTime.Now;
            await _statusCallRepository.AddAsync(status);
        }

        public async Task UpdateAsync(StatusCall status)
        {
            status.UpdatedDate = DateTime.Now;
            await _statusCallRepository.UpdateAsync(status);
        }

        public async Task DeleteAsync(int id) => await _statusCallRepository.DeleteAsync(id);

    }
}
