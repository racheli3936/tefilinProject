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
    public class StoreOwnerService:IStoreOwnerService
    {
        private readonly IStoreOwnerRepository _storeOwnerRepository;
        private readonly IMapper _mapper;
        public StoreOwnerService(IStoreOwnerRepository storeOwnerRepository, IMapper mapper)
        {
            _storeOwnerRepository = storeOwnerRepository;
            _mapper = mapper;
        }
        public async Task<List<StoreOwnerDto>> GetStoreOwnersAsync()
        {
           List<StoreOwner> storeOwners=await _storeOwnerRepository.GetStoreOwnersAsync();
            List<StoreOwnerDto> storeOwnersDto = _mapper.Map<List<StoreOwnerDto>>(storeOwners);
            return storeOwnersDto;

        }
        public async Task AddStoreOwnerAsync(StoreOwner storeOwner)
        {
            await _storeOwnerRepository.AddStorOwnerAsync(storeOwner);
        }
    }
}
