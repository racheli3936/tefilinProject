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
    public class StandService:IStandService
    {
        private readonly IStandRepository _standRepository;

        public StandService(IStandRepository standRepository)
        {
            _standRepository = standRepository;
        }

        //public async Task<IEnumerable<Stand>> GetAllStandsAsync()
        //{
        //    return await _standRepository.GetAllStandsAsync();
        //}

        //public async Task<Stand> GetStandByIdAsync(int id)
        //{
        //    return await _standRepository.GetStandByIdAsync(id);
        //}
        public async Task<List<Stand>> GetStandsByStoreOwnerIdAsync(int storeOwnerId)
        {
            return await _standRepository.GetStandsByStoreOwnerIdAsync(storeOwnerId);
        }
        public async Task AddStandAsync(Stand stand)
        {

            await _standRepository.AddStandAsync(stand);
        }

        //public async Task UpdateStandAsync(int id, Stand stand)
        //{
        //    var stand = await GetStandByIdAsync(id);
        //    if (stand != null)
        //    {
        //        stand.StandId = standPostModel.StandId;
        //        stand.Status = standPostModel.Status;
        //        stand.Notes = standPostModel.Notes;
        //        stand.CountTefilin = standPostModel.CountTefilin;
        //        stand.IsThereLeftHanded = standPostModel.IsThereLeftHanded;
        //        stand.LastCheckDate = standPostModel.LastCheckDate;
        //        stand.TefilinStatus = standPostModel.TefilinStatus;
        //        stand.UpdatedDate = DateTime.Now;
        //        // יש לעדכן את UpdatedBy בהתאם לצורך

        //        await _standRepository.UpdateStandAsync(stand);
        //    }
        //}

        //public async Task DeleteStandAsync(int id)
        //{
        //    await _standRepository.DeleteStandAsync(id);
        //}
    }
}
