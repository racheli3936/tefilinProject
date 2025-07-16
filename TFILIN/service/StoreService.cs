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
    public class StoreService:IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
   
        public StoreService(IStoreRepository storeRepository,IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;   
        }
        public async Task<List<StoreDto>> GetStoresByOwnerIdAsync(int ownerId)
        {
            List<Store> stores= await _storeRepository.GetStoresByOwnerIdAsync(ownerId);
            List<StoreDto> storeDtos=_mapper.Map<List<StoreDto>>(stores);
            return storeDtos;
        }

        public async Task<Store> AddStoreAsync(Store newStore)
        {

            return await _storeRepository.AddStoreAsync(newStore);
        }

    }
}
