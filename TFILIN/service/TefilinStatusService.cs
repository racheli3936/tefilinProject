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
    public class TefilinStatusService:ITefilinStatusService
    {

        private readonly ITefilinStatusRepository _tefilinStatusRepository;

        public TefilinStatusService(ITefilinStatusRepository tefilinStatusRepository)
        {
            _tefilinStatusRepository = tefilinStatusRepository; 
        }

        public async Task<TefilinStatus> GetByIdAsync(int id)
        {
            return await _tefilinStatusRepository.GetByIdAsync(id);
        }

        //public async Task<IEnumerable<TefilinStatus>> GetAllAsync()
        //{
        //    return await _tefilinStatusRepository.GetAllAsync();
        //}

        //public async Task AddAsync(TefilinStatus model)
        //{
        //    var tefilinStatus = new TefilinStatus { Status = model.Status };
        //    await _tefilinStatusRepository.AddAsync(tefilinStatus);
        //}

        //public async Task UpdateAsync(int id, TefilinStatus model)
        //{
        //    var tefilinStatus = await _repository.GetByIdAsync(id);
        //    if (tefilinStatus != null)
        //    {
        //        tefilinStatus.Status = model.Status;
        //        await _tefilinStatusRepository.UpdateAsync(tefilinStatus);
        //    }
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    await _tefilinStatusRepository.DeleteAsync(id);
        //}
    }
}
