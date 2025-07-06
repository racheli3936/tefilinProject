using AutoMapper;
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
   
        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task<Store> AddStoreAsync(Store newStore)
        {

            return await _storeRepository.AddStoreAsync(newStore);
        }

    }
}
