using core.DTOs;
using core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        [HttpGet]
        public async Task<ActionResult<List<DonorDto>>> GetAllDonors()
        {
            var donors = await _donorService.GetAllDonorsAsync();
            return Ok(donors);
        }

    }
}
