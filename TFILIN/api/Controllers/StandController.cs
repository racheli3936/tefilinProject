using api.PostModels;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandController : ControllerBase
    {
        private readonly IStandService _standService;
        private readonly ITefilinStatusService _tefilinStatusService;

        public StandController(IStandService standService, ITefilinStatusService tefilinStatusService)
        {
            _standService = standService;
            _tefilinStatusService = tefilinStatusService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Stand>>> GetAllStands()
        //{
        //    var stands = await _standService.GetAllStandsAsync();
        //    return Ok(stands);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Stand>> GetStandById(int id)
        //{
        //    var stand = await _standService.GetStandByIdAsync(id);
        //    if (stand == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(stand);
        //}
        [HttpGet("by-store-owner/{storeOwnerId}")]
        public async Task<ActionResult<List<Stand>>> GetStandsByStoreOwnerId(int storeOwnerId)
        {
            var stands = await _standService.GetStandsByStoreOwnerIdAsync(storeOwnerId);
            if (stands == null || stands.Count == 0)
            {
                return NotFound(); // מחזיר 404 אם לא נמצאו סטנדים
            }
            return Ok(stands); // מחזיר 200 עם התוצאות
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddStand(StandPostModel standPostModel)
        {
            string userIdStr = User.FindFirst("UserId")?.Value;
            int userId = int.Parse(userIdStr);

            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out  userId))
            {
                return BadRequest("User ID is invalid.");
            }
            TefilinStatus status =await _tefilinStatusService.GetByIdAsync(standPostModel.TefilinStatusId);
            var stand = new Stand()
            {
                StandId = standPostModel.StandId,
                Status = standPostModel.Status,
                Notes = standPostModel.Notes,
                CountTefilin = standPostModel.CountTefilin,
                IsThereLeftHanded = standPostModel.IsThereLeftHanded,
                LastCheckDate = standPostModel.LastCheckDate,
                TefilinStatus = status,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = userId,
                UpdatedBy = userId,
                Visits = new List<Visit>(),
                StandItems = new List<StandItem>(),
                Donations = new List<Donation>(),
                StoreStands = new List<StoreStand>()
            };
            await _standService.AddStandAsync(stand);
            return Ok( stand);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateStand(int id, StandPostModel standPostModel)
        //{
        //    await _standService.UpdateStandAsync(id, standPostModel);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteStand(int id)
        //{
        //    await _standService.DeleteStandAsync(id);
        //    return NoContent();
        //}
    }
}
