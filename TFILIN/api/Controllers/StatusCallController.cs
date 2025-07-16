using core.DTOs;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusCallController : ControllerBase
    {
        private readonly IStatusCallService _statusCallService;

        public StatusCallController(IStatusCallService statusCallService)
        {
            _statusCallService = statusCallService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusCallDto>>> GetAll()
        {
            var statuses = await _statusCallService.GetAllAsync();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusCall>> GetById(int id)
        {
            var status = await _statusCallService.GetByIdAsync(id);
            if (status == null) return NotFound();
            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] StatusCall status)
        {
            await _statusCallService.AddAsync(status);
            return CreatedAtAction(nameof(GetById), new { id = status.Id }, status);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] StatusCall updated)
        {
            if (id != updated.Id) return BadRequest("Id mismatch");
            await _statusCallService.UpdateAsync(updated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _statusCallService.DeleteAsync(id);
            return NoContent();
        }

    }
}
