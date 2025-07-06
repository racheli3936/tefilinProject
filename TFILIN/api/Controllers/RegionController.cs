using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Region>>> GetAllRegions()
        {
            var regions = await _regionService.GetAllRegionsAsync();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegionById(int id)
        {
            var region = await _regionService.GetRegionByIdAsync(id);
            if (region == null)
                return NotFound();

            return Ok(region);
        }

        [HttpPost]
        public async Task<ActionResult<Region>> AddNewRegion([FromBody] Region region)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addedRegion = await _regionService.AddRegionAsync(region);
            return CreatedAtAction(nameof(GetRegionById), new { id = addedRegion.Id }, addedRegion);
        }
    }
}
