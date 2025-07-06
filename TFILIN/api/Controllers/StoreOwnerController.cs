using api.PostModels;
using core.DTOs;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreOwnerController : ControllerBase
    {
        private readonly IStoreOwnerService _storeOwnerService;
        public StoreOwnerController(IStoreOwnerService storeOwnerService)
        {
            _storeOwnerService = storeOwnerService;
        }
        [HttpGet]
        public async Task<ActionResult<List<StoreOwnerDto>>> GetAllStoreOwners()
        {
            List<StoreOwnerDto> storeOwners = await _storeOwnerService.GetStoreOwnersAsync();
            return Ok(storeOwners);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddStoreOwner(StoreOwnerModel newStoreOwner)
        {
            Console.WriteLine("before add storeOwner");
            string userIdStr = User.FindFirst("UserId")?.Value;
            Console.WriteLine(userIdStr + "_______________________");
            int userId = int.Parse(userIdStr);

            StoreOwner storeOwner = new StoreOwner()
            {
                Name = newStoreOwner.Name,
                Address = newStoreOwner.Address,
                Phone = newStoreOwner.Phone,
                Email= newStoreOwner.Email,
                Stores=new List<Store>(),
                CreatedBy=userId,
                UpdatedBy=userId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            try
            {
                await _storeOwnerService.AddStoreOwnerAsync(storeOwner);
                return Ok(storeOwner);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
