using api.PostModels;
using AutoMapper;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using service;
using System.ComponentModel.DataAnnotations.Schema;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly ICityService _cityService;
        private readonly IRegionService _regionService;


        private readonly IMapper _mapper;

        public StoreController(IStoreService storeService, IMapper mapper, ICityService cityService, IRegionService regionService)
        {
            _storeService = storeService;
            _cityService = cityService;
            _regionService = regionService;
            _mapper = mapper;
        }
        [HttpGet("owner/{ownerId}")]
        public async Task<ActionResult<List<Store>>> GetStoresByOwnerId(int ownerId)
        {
            var stores = await _storeService.GetStoresByOwnerIdAsync(ownerId);

            if (stores == null || stores.Count == 0)
                return NotFound($"לא נמצאו חנויות לבעל מספר מזהה {ownerId}");

            return Ok(stores);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Store>> AddStore([FromBody] StorePostModel newStore)
        {

            string userIdStr = User.FindFirst("UserId")?.Value;
            Console.WriteLine(userIdStr + "_______________________");
            int userId = int.Parse(userIdStr);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            City city = await _cityService.GetCityByIdAsync(newStore.CityId);
            Region region = await _regionService.GetRegionByIdAsync(newStore.RegionId);
            Store store = new Store()
            {
                StoreOwnerId = newStore.StoreOwnerId,
                StoreName = newStore.StoreName,
                Phone = newStore.Phone,
                Address = newStore.Address,
                City = city,
                Region = region,
                Latitude = newStore.Latitude,
                Longitude = newStore.Longitude,
                MoreDetails = newStore.MoreDetails,
                StandPlace = newStore.StandPlace,
                Status = newStore.Status,
                PermitRoles = newStore.PermitRoles,
                StoreStand = new List<StoreStand>(),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = userId,
                UpdatedBy = userId,
            };
            await _storeService.AddStoreAsync(store);
            if (store == null)
                return StatusCode(500, "שגיאה בשמירת החנות");

            return Ok(store);
        }
    }
}
