using core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyDonationController : ControllerBase
    {
        private readonly IMonthlyDonationService _monthlyDonationService;

        public MonthlyDonationController(IMonthlyDonationService service)
        {
            _monthlyDonationService = service;
        }

        [HttpGet("by-donation/{donationId}")]
        public async Task<IActionResult> GetByDonationId(int donationId)
        {
            var result = await _monthlyDonationService.GetMonthlyDonationsByDonationIdAsync(donationId);

            if (result == null || !result.Any())
            {
                return NotFound($"לא נמצאו תרומות חודשיות לתרומה עם מזהה {donationId}");
            }

            return Ok(result);
        }
    }
}
