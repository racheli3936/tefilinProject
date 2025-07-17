using core.DTOs;
using core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationService _donationService;
        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveDonations()
        {
            List<DonationDto> activeDonations = await _donationService.GetActiveDonationsAsync();
            return Ok(activeDonations);
        }
    }
}
